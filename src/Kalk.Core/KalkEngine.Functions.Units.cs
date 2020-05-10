using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private const string CategoryUnitsAndCurrencies = "Unit & Currency Functions";

        private void RegisterUnitFunctions()
        {
            RegisterVariable("units", Units, CategoryUnitsAndCurrencies);
            RegisterFunction("unit", new Func<ScriptVariable, string, ScriptVariable, KalkExpression, string, KalkExpression>(DefineUserUnit), CategoryUnitsAndCurrencies);
            
            RegisterVariable("currencies", Currencies, CategoryUnitsAndCurrencies);
            RegisterFunction("currency", new Func<ScriptVariable, double?, KalkCurrency>(Currency), CategoryUnitsAndCurrencies);

            RegisterFunction("to", new Func<KalkExpression, KalkExpression, KalkExpression>(ConvertTo), CategoryUnitsAndCurrencies);

            // Register SI units
            RegisterUnit("second", "SI Time", "s", prefix: "m,µ,n,p,f,a,z,y");
            RegisterUnit("meter", "SI Length", "m", prefix: "decimal");
            RegisterUnit("gram", "SI Mass", "g", prefix: "decimal");
            RegisterUnit("ampere", "SI Electric current", "A", prefix: "decimal");
            RegisterUnit("kelvin", "SI Thermodynamic temperature", "K", prefix: "decimal");
            RegisterUnit("mole", "SI Amount of substance", "mol", prefix: "decimal");
            RegisterUnit("candela", "SI Luminous intensity", "cd", prefix: "decimal");

            // Binary units
            RegisterUnit("bit", "A digital information, data size", "b", prefix: "Y,Z,E,P,T,G,M,k,binary");
            RegisterUnit("byte", "An octet, composed of 8 bits", "B", new KalkBinaryExpression(8, ScriptBinaryOperator.Multiply, Units["b"]), prefix: "Y,Z,E,P,T,G,M,k,binary");

            // Time units
            RegisterUnit("minute", "time in minutes", "min", new KalkBinaryExpression(60, ScriptBinaryOperator.Multiply, Units["s"]));
            RegisterUnit("hour", "time in hours", "h", new KalkBinaryExpression(60, ScriptBinaryOperator.Multiply, Units["min"]));
            RegisterUnit("day", "time in days", "day", new KalkBinaryExpression(24, ScriptBinaryOperator.Multiply, Units["h"]));
        }

        [KalkDoc("to")]
        public KalkExpression ConvertTo(KalkExpression src, KalkExpression dst)
        {
            return src.ConvertTo(this, dst);
        }

        [KalkDoc("currency")]
        public KalkCurrency Currency(ScriptVariable name = null, double? value = null)
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

        public KalkCurrency GetOrSetCurrency(string name = null, double? value = null)
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
                    currency.Value = new KalkBinaryExpression(1.0 / value, ScriptBinaryOperator.Multiply, GetSafeBaseCurrencyFromConfig());
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
                    var ratio = ToObject<double>(CurrentSpan, existingConvert.Left);

                    existingBase.Value = new KalkBinaryExpression(1.0, ScriptBinaryOperator.Multiply, baseCurrency);

                    foreach (var currency in Units.Values.OfType<KalkCurrency>())
                    {
                        if (currency == baseCurrency) continue;

                        var existingRatio = ToObject<double>(CurrentSpan, ((KalkBinaryExpression) currency.Value).Left);
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

            Config.BaseCurrency = name;

            return baseCurrency;
        }


        public KalkCurrency RegisterCurrency(string name, double value, bool isUser = false)
        {
            if (value <= 0 || KalkNumber.AlmostEqual(value, 0.0f)) throw new ArgumentOutOfRangeException(nameof(value), "The currency value must be > 0");

            return (KalkCurrency)RegisterUnit(name, $"Currency {name}", null, new KalkBinaryExpression(1.0/value, ScriptBinaryOperator.Multiply, GetSafeBaseCurrencyFromConfig()), null, isUser, true);
        }

        [KalkDoc("unit")]
        public KalkExpression DefineUserUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkExpression value = null, string prefix = null)
        {
            return RegisterUnit(name?.Name, description, symbol?.Name, value, prefix, true);
        }

        public KalkExpression RegisterUnit(string name, string description = null, string symbol = null, KalkExpression value = null, string prefix = null, bool isUser = false, bool isCurrency = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

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

            var unit = isCurrency ? new KalkCurrency(name) : new KalkSymbol(name);
            unit.Description = description;
            unit.Symbol = symbol ?? name;
            unit.Value = value;
            unit.IsUser = isUser;
            unit.Prefix = prefix;

            if (unit.Symbol != unit.Name)
            {
                CheckVariableAvailable(unit.Symbol, nameof(symbol), false);
                Units.Add(unit.Symbol, unit);
            }

            Units.Add(name, unit);

            // Register prefixes
            foreach (var prefixDesc in prefixList)
            {
                var prefixWithName = $"{prefixDesc.Name}{name}";
                var prefixWithSymbol = $"{prefixDesc.Prefix}{symbol}";

                var unitPrefix = new KalkSymbol(prefixWithName)
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