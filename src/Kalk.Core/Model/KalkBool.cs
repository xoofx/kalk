using System;
using Scriban;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Kalk.Core
{
    public struct KalkBool : IEquatable<KalkBool>, IFormattable, IScriptCustomType, IScriptConvertibleFrom
    {
        private bool _value;

        public KalkBool(bool value)
        {
            _value = value;
        }
        
        public bool Equals(KalkBool other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            return obj is KalkBool other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(KalkBool left, KalkBool right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(KalkBool left, KalkBool right)
        {
            return !left.Equals(right);
        }
        
        public string ToString(string? format, IFormatProvider formatProvider)
        {
            return ToString();
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            var leftBool = leftValue is KalkBool lb ? lb : new KalkBool(context.ToBool(leftSpan, leftValue));
            var rightBool = rightValue is KalkBool rb ? rb : new KalkBool(context.ToBool(rightSpan, rightValue));

            switch (op)
            {
                case ScriptBinaryOperator.CompareEqual:
                    result = leftBool._value == rightBool._value;
                    return true;
                case ScriptBinaryOperator.CompareNotEqual:
                    result = leftBool._value != rightBool._value;
                    return true;
            }

            return false;
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            result = null;
            switch (op)
            {
                case ScriptUnaryOperator.Not:
                    result = new KalkBool(!((KalkBool)rightValue)._value);
                    return true;
            }
            return false;
        }

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            value = null;
            if (type == typeof(bool))
            {
                value = _value;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return _value ? "true" : "false";
        }

        public bool TryConvertFrom(TemplateContext context, SourceSpan span, object value)
        {
            _value = context.ToBool(span, value);
            return true;
        }

        public static implicit operator bool(KalkBool kbool) => kbool._value;

        public static implicit operator KalkBool(bool value) => new KalkBool(value);
    }
}