using System;
using System.Collections.Generic;
using System.Linq;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public const string CategoryUnits = "Unit Functions";

        [KalkExport("to", CategoryUnits)]
        public KalkExpression ConvertTo(KalkExpression src, KalkExpression dst)
        {
            return src.ConvertTo(this, dst);
        }

        [KalkExport("unit", CategoryUnits)]
        public KalkExpression DefineUserUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkExpression value = null, string plural = null, string prefix = null)
        {
            if (name == null || string.IsNullOrEmpty(name.Name)) throw new ArgumentNullException(nameof(name));
            return RegisterUnit(new KalkUnit(name.Name), description, symbol?.Name, value, plural, prefix, isUser: true);
        }

        public KalkExpression RegisterUnit(KalkUnit unit, string description = null, string symbol = null, KalkExpression value = null, string plural = null, string prefix = null, bool isUser = false)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            var name = unit.Name;

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