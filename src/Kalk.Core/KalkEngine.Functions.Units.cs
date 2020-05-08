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
        private const string CategoryUnits = "Unit Functions";

        private void RegisterUnitFunctions()
        {
            RegisterFunction("units", new Func<ScriptObject>(GetUnits), CategoryUnits);
            RegisterFunction("unit", new Func<ScriptVariable, string, ScriptVariable, KalkUnit, ScriptVariable, KalkUnit>(DefineUserUnit), CategoryUnits);
        }

        [KalkDoc("units")]
        public ScriptObject GetUnits()
        {
            var units = new ScriptObject();
            foreach (var unitPair in Units)
            {
                units.Add(unitPair.Key, unitPair.Value);
            }

            return units;
        }

        [KalkDoc("unit")]
        public KalkUnit DefineUserUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkUnit value = null, ScriptVariable prefix = null)
        {
            return RegisterUnit(name, description, symbol, value, prefix, true);
        }

        public KalkUnit RegisterUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkUnit value = null, ScriptVariable prefix = null, bool isUser = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var nameStr = name.Name;

            if (Units.ContainsKey(nameStr))
            {
                throw new ArgumentException($"The name {nameStr} is already used by another unit.", nameof(name));
            }
            if (Builtins.ContainsKey(nameStr))
            {
                throw new ArgumentException($"The name {nameStr} is already used a builtin variable or function.", nameof(name));
            }

            var unit = new KalkDefinitionUnit(name.Name)
            {
                Description = description,
                Symbol = symbol?.Name ?? nameStr,
                Value = value,
                IsUser =  isUser,
                Prefix = prefix?.Name,
            };


            if (unit.Symbol != unit.Name)
            {
                if (Units.TryGetValue(unit.Symbol, out var existingUnit))
                {
                    throw new ArgumentException($"The unit symbol {unit.Symbol} is already used another unit ({existingUnit}).", nameof(symbol));
                }

                if (!Builtins.ContainsKey(unit.Symbol))
                {
                    Units.Add(unit.Symbol, unit);
                }
            }

            Units.Add(nameStr, unit);

            return unit;
        }
    }
}