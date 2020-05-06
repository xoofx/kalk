using System;
using Scriban;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkUnit : IScriptCustomType
    {
        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            return false;
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            result = null;
            return false;
        }

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            value = null;
            return false;
        }
    }

    // s	second	time
    // m	metre	length
    // kg	kilogram	mass
    // A	ampere	electric current
    // K	kelvin	thermodynamic temperature
    // mol	mole	amount of substance
    // cd	candela	luminous intensity


    public class KalkComplexUnit : KalkUnit
    {
        public ScriptExpression Expression { get; set; }

        public override string ToString()
        {
            return Expression?.ToString();
        }
    }

    public class KalkSimpleUnit : KalkUnit
    {
        public KalkSimpleUnit(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }

        public ScriptExpression Expression { get; set; }

        public override string ToString()
        {
            if (Symbol != null)
            {
                if (Expression != null) return $"{Name},{Symbol}: {Expression}";
                return $"{Name},{Symbol}";
            }
            return Name;
        }
    }
}