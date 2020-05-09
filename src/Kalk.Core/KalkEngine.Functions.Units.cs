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
            RegisterVariable("units", Units, CategoryUnits);
            RegisterFunction("unit", new Func<ScriptVariable, string, ScriptVariable, KalkExpression, ScriptVariable, KalkExpression>(DefineUserUnit), CategoryUnits);

            RegisterFunction("to", new Func<KalkExpression, KalkExpression, KalkExpression>(ConvertTo), CategoryUnits);

            // Register SI units
            RegisterUnit("second", "SI time in second", "s");
            RegisterUnit("meter", "SI length in meter", "m");
            RegisterUnit("gram", "SI mass in g", "g");
            RegisterUnit("ampere", "SI electric current in A", "A");
            RegisterUnit("kelvin", "SI thermodynamic temperature", "K");
            RegisterUnit("mole", "SI amount of substance", "mol");
            RegisterUnit("candela", "SI luminous intensity", "cd");

            // Developers units
            RegisterUnit("byte", "Byte octets", "b");
            RegisterUnit("kilobyte", "kilo byte octets", "kb", new KalkBinaryExpression(1024, ScriptBinaryOperator.Multiply, Units["b"]));
            RegisterUnit("megabyte", "kilo byte octets", "Mb", new KalkBinaryExpression(1024, ScriptBinaryOperator.Multiply, Units["kb"]), symbolHasNoCase: true);

            RegisterUnit("kilometer", "kilo * SI length in meter", "km", new KalkBinaryExpression(1000, ScriptBinaryOperator.Multiply, Units["m"]));
            
            RegisterUnit("minute", "time in minutes", "min", new KalkBinaryExpression(60, ScriptBinaryOperator.Multiply, Units["s"]));
            RegisterUnit("hour", "time in hours", "h", new KalkBinaryExpression(60, ScriptBinaryOperator.Multiply, Units["min"]));
            RegisterUnit("day", "time in days", "day", new KalkBinaryExpression(24, ScriptBinaryOperator.Multiply, Units["h"]));
        }

        [KalkDoc("to")]
        public KalkExpression ConvertTo(KalkExpression src, KalkExpression dst)
        {
            return src.ConvertTo(this, dst);
        }
        
        [KalkDoc("unit")]
        public KalkExpression DefineUserUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkExpression value = null, ScriptVariable prefix = null)
        {
            return RegisterUnit(name?.Name, description, symbol?.Name, value, prefix?.Name, true);
        }

        public KalkExpression RegisterUnit(string name, string description = null, string symbol = null, KalkExpression value = null, string prefix = null, bool isUser = false, bool symbolHasNoCase = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            if (Units.ContainsKey(name))
            {
                throw new ArgumentException($"The name {name} is already used by another unit.", nameof(name));
            }
            if (Builtins.ContainsKey(name))
            {
                throw new ArgumentException($"The name {name} is already used a builtin variable or function.", nameof(name));
            }

            var unit = new KalkSymbol(name)
            {
                Description = description,
                Symbol = symbol ?? name,
                Value = value,
                IsUser =  isUser,
                Prefix = prefix,
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
                    if (symbolHasNoCase)
                    {
                        Units.Add(unit.Symbol.ToLowerInvariant(), unit);
                    }
                }
            }

            Units.Add(name, unit);

            return unit;
        }
    }
}