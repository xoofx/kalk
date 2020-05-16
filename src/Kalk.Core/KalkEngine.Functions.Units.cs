using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Consolus;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private const string CategoryUnitsAndCurrencies = "Symbol, Unit & Currency Functions";

        private void RegisterUnitFunctions()
        {
            RegisterVariable("units", Units, CategoryUnitsAndCurrencies);
            RegisterFunction("unit", new Func<ScriptVariable, string, ScriptVariable, KalkExpression, string, string, KalkExpression>(DefineUserUnit), CategoryUnitsAndCurrencies);
            
            RegisterVariable("currencies", Currencies, CategoryUnitsAndCurrencies);
            RegisterFunction("currency", new Func<ScriptVariable, decimal?, KalkCurrency>(Currency), CategoryUnitsAndCurrencies);

            RegisterFunction("to", new Func<KalkExpression, KalkExpression, KalkExpression>(ConvertTo), CategoryUnitsAndCurrencies);
        }
        
        [KalkDoc("to")]
        public KalkExpression ConvertTo(KalkExpression src, KalkExpression dst)
        {
            return src.ConvertTo(this, dst);
        }

        [KalkDoc("currency")]
        public KalkCurrency Currency(ScriptVariable name = null, decimal? value = null)
        {
            return GetOrSetCurrency(name?.Name, value);
        }

        public KalkCurrency GetSafeBaseCurrencyFromConfig()
        {
            if (Units.TryGetValue(Config.BaseCurrency, out var symbol))
            {
                if (symbol is KalkCurrency currency) return currency;
                throw new ScriptRuntimeException(CurrentSpan, $"Invalid base currency defined. The symbol `{Config.BaseCurrency}` defined from `config.{KalkConfig.BaseCurrencyProp}` is already attached to a different unit: {symbol}.");
            }
            throw new ScriptRuntimeException(CurrentSpan, $"Unable to find base currency `{Config.BaseCurrency}` defined from `config.{KalkConfig.BaseCurrencyProp}`");
        }

        public KalkCurrency GetOrSetCurrency(string name = null, decimal? value = null)
        {
            if (name == null)
            {
                return GetSafeBaseCurrencyFromConfig();
            }

            if (value == null)
            {
                return RegisterBaseCurrency(name);
            }

            // Verify that the currency name is valid
            KalkCurrency.CheckValid(CurrentSpan, name);

            if (Units.TryGetValue(name, out var symbol))
            {
                if (symbol is KalkCurrency currency)
                {
                    currency.Value = new KalkBinaryExpression(1.0m / value, ScriptBinaryOperator.Multiply, GetSafeBaseCurrencyFromConfig());
                    return currency;
                }
                throw new ScriptRuntimeException(CurrentSpan, $"Unable to define currency `{name}` as it is already attached to a different unit: {symbol}.");
            }

            // New currency
            return RegisterCurrency(name, value.Value, true);
        }

        public KalkCurrency RegisterBaseCurrency(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            KalkCurrency.CheckValid(CurrentSpan, name);

            KalkCurrency baseCurrency;
            if (Units.TryGetValue(name, out var unit))
            {
                baseCurrency = unit as KalkCurrency;
                if (baseCurrency != null)
                {
                    // It is already the default unit
                    if (unit.Value == null) return baseCurrency;

                    var existingBase = GetSafeBaseCurrencyFromConfig();
                    var existingConvert = (KalkBinaryExpression) unit.Value;
                    unit.Value = null;

                    // ratio USD = 1.1 EUR
                    var ratio = ToObject<decimal>(CurrentSpan, existingConvert.Value);

                    existingBase.Value = new KalkBinaryExpression(1.0m, ScriptBinaryOperator.Multiply, baseCurrency);

                    foreach (var currency in Units.Values.OfType<KalkCurrency>())
                    {
                        if (currency == baseCurrency) continue;

                        var existingRatio = ToObject<decimal>(CurrentSpan, ((KalkBinaryExpression) currency.Value).Value);
                        currency.Value = new KalkBinaryExpression(existingRatio / ratio, ScriptBinaryOperator.Multiply, baseCurrency);
                    }
                }
                else
                {
                    throw new ArgumentException($"Cannot create a new base currency for the existing unity `{unit}`.", nameof(name));
                }
            }
            else
            {
                if (Currencies.Count > 0)
                {
                    throw new ArgumentException($"Cannot create a new base currency when there are already currencies. You need to first create this currency relative to the existing base `{GetSafeBaseCurrencyFromConfig().Name}` currency", nameof(name));
                }

                baseCurrency = new KalkCurrency(name)
                {
                    Description = "Default Currency"
                };
                Units.Add(name, baseCurrency);
            }

            Config.RegisteringBaseCurrency = true;
            try
            {
                Config.BaseCurrency = name;
            } finally
            {
                Config.RegisteringBaseCurrency = false;
            }

            return baseCurrency;
        }


        public KalkCurrency RegisterCurrency(string name, decimal value, bool isUser = false)
        {
            if (value <= 0 || KalkValue.AlmostEqual(value, 0.0f)) throw new ArgumentOutOfRangeException(nameof(value), "The currency value must be > 0");
            return (KalkCurrency)RegisterUnit(name, $"Currency {name}", null, new KalkBinaryExpression(1.0m/value, ScriptBinaryOperator.Multiply, GetSafeBaseCurrencyFromConfig()), isUser: isUser, isCurrency:true);
        }

        [KalkDoc("unit")]
        public KalkExpression DefineUserUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkExpression value = null, string plural = null, string prefix = null)
        {
            return RegisterUnit(name?.Name, description, symbol?.Name, value, plural, prefix, isUser: true);
        }

        public KalkExpression RegisterUnit(string name, string description = null, string symbol = null, KalkExpression value = null, string plural = null, string prefix = null, bool isUser = false, bool isCurrency = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            // Override isUser
            if (_registerAsSystem) isUser = false;

            CheckVariableAvailable(name, nameof(name), false);

            var prefixList = new List<KalkUnitPrefix>();
            if (prefix != null)
            {
                var prefixes = prefix.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach(var prefixItem in prefixes)
                {
                    if (prefixItem == "decimal")
                    {
                        prefixList.AddRange(KalkUnitPrefix.GetDecimals());
                    }
                    else if (prefixItem == "binary")
                    {
                        prefixList.AddRange(KalkUnitPrefix.GetBinaries());
                    }
                    else if (KalkUnitPrefix.TryGet(prefixItem, out var descriptor))
                    {
                        prefixList.Add(descriptor);
                    }
                    else
                    {
                        throw new ArgumentException($"The prefix `{prefixItem}` does not exist.", nameof(prefix));
                    }
                }
                prefixList = prefixList.Distinct().ToList();
            }

            // Pre-check all prefix with name/symbol
            foreach (var prefixDesc in prefixList)
            {
                var prefixWithName = $"{prefixDesc.Name}{name}";
                CheckVariableAvailable(prefixWithName, nameof(name), false);

                var prefixWithSymbol = $"{prefixDesc.Prefix}{symbol}";
                CheckVariableAvailable(prefixWithSymbol, nameof(name), false);
            }

            var unit = isCurrency ? new KalkCurrency(name) : new KalkUnit(name);
            unit.Description = description;
            unit.Symbol = symbol ?? name;
            unit.Value = value;
            unit.IsUser = isUser;
            unit.Prefix = prefix;
            if (plural != null)
            {
                unit.Plural = plural;
            }

            if (unit.Symbol != unit.Name)
            {
                CheckVariableAvailable(unit.Symbol, nameof(symbol), false);
            }

            if (unit.Plural != unit.Name)
            {
                CheckVariableAvailable(unit.Plural, nameof(plural), false);
            }

            // Here we are all done after checking everything

            Units.Add(name, unit);


            if (unit.Symbol != unit.Name)
            {
                Units.Add(unit.Symbol, unit);
            }

            if (unit.Plural != unit.Name)
            {
                Units.Add(unit.Plural, unit);
            }
            
            // Register prefixes
            foreach (var prefixDesc in prefixList)
            {
                var prefixWithName = $"{prefixDesc.Name}{name}";
                var prefixWithSymbol = $"{prefixDesc.Prefix}{symbol}";

                var unitPrefix = new KalkUnit(prefixWithName)
                {
                    Description = description,
                    Symbol = prefixWithSymbol,
                    Value = new KalkBinaryExpression(Math.Pow(prefixDesc.Base, prefixDesc.Exponent), ScriptBinaryOperator.Multiply, unit),
                    IsUser = isUser,
                    Parent = unit,
                };
                unit.Derived.Add(unitPrefix);

                Units.Add(prefixWithName, unitPrefix);
                Units.Add(prefixWithSymbol, unitPrefix);
            }

            return unit;
        }

        private void CheckVariableAvailable(string name, string nameOf, bool prefix)
        {
            if (Units.ContainsKey(name))
            {
                throw new ArgumentException(prefix ? $"The name with prefix `{name}` is already used by another unit." : $"The name `{name}` is already used by another unit.", nameOf);
            }

            if (Builtins.ContainsKey(name))
            {
                throw new ArgumentException(prefix ? $"The name with prefix `{name}` is already used a builtin variable or function." : $"The name `{name}` is already used a builtin variable or function.", nameOf);
            }
        }
    }
}