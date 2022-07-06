using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    /// <summary>
    /// Represents a IEE-754 half-float 16-bit
    /// </summary>
    public readonly struct KalkHalf : IScriptCustomType, IKalkSpannable, IFormattable, IScriptTransformable, IKalkDisplayable
    {
        private readonly Half _value;

        public KalkHalf(float value)
        {
            _value = (Half) value;
        }

        public KalkHalf(Half value)
        {
            _value = value;
        }

        public string TypeName => "half";
        
        internal Half Value => _value;


        public static float[] ToFloatValues(KalkHalf[] values)
        {
            if (values == null) return null;
            var floatValues = new float[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                floatValues[i] = (float)values[i];
            }
            return floatValues;
        }

        public static KalkHalf[] ToHalfValues(float[] values)
        {
            if (values == null) return null;
            var halfValues = new KalkHalf[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                halfValues[i] = (KalkHalf)values[i];
            }
            return halfValues;
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            if (leftValue is KalkHalf leftHalf && rightValue is KalkHalf rightHalf)
            {
                result = (KalkHalf)(float)ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, (float) leftHalf, rightSpan, (float)rightHalf);
                return true;
            }

            if (leftValue is KalkHalf leftHalf1)
            {
                result = (KalkHalf)(float)ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, (float)leftHalf1, rightSpan, rightValue);
                return true;
            }

            if (rightValue is KalkHalf rightHalf1)
            {
                result = (KalkHalf)(float)ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, leftValue, rightSpan, rightHalf1);
                return true;
            }

            return false;
        }


        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            result = ScriptUnaryExpression.Evaluate(context, span, op, (float)(KalkHalf)rightValue);
            return true;
        }

        public static implicit operator KalkHalf(Half half)
        {
            return new KalkHalf(half);
        }

        public static explicit operator KalkHalf(float value)
        {
            return new KalkHalf(value);
        }


        public static explicit operator float(KalkHalf half)
        {
            return (float)half._value;
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture);
        }

        public void Display(KalkEngine engine, KalkDisplayMode mode)
        {
            switch (mode)
            {
                case KalkDisplayMode.Raw:
                case KalkDisplayMode.Standard:
                    break;
                case KalkDisplayMode.Developer:
                    DisplayDetailed(engine);
                    break;
            }
        }

        private void DisplayDetailed(KalkEngine engine)
        {
            var u16 = Unsafe.As<Half, ushort>(ref Unsafe.AsRef(_value));
            engine.WriteHighlightLine($"    # IEEE 754 - half float - 16-bit");
            engine.WriteHighlightLine($"    #");
            engine.WriteInt16(u16, true);

            // Prints the 16 bits indices
            engine.WriteHighlightLine($"    #   15       8         0");

            engine.WriteHighlightLine($"    #");
            engine.WriteHighlightLine($"    #  sign     exponent    |-- fraction -|");
            //                                 #   1 * 2 ^ (15 - 15) * 0b1.1000000000

            var sign = (u16 >> 15);
            var exponent = (u16 >> 10) & 0b11111;
            var fraction = u16 & 0b1111111111;

            var builder = new StringBuilder();
            builder.Append(sign != 0 ? " -1" : "  1");
            builder.Append(" * 2 ^ (");
            builder.Append($"{(exponent == 0 ? 1 : exponent),2} - 15) * 0b{(exponent == 0 ? '0' : '1')}.");
            for (int i = 9; i >= 0; i--)
            {
                builder.Append(((fraction >> i) & 1) == 0 ? '0' : '1');
            }
            engine.WriteHighlightLine($"    = {builder}f");
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return _value.ToString(format, formatProvider);
        }

        public Span<byte> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Unsafe.As<KalkHalf, byte>(ref Unsafe.AsRef(this)), Unsafe.SizeOf<KalkHalf>());
        }

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            if (type == typeof(KalkDoubleValue))
            {
                value = new KalkDoubleValue(this);
                return true;
            }

            if (type == typeof(KalkTrigDoubleValue))
            {
                value = new KalkTrigDoubleValue(this);
                return true;
            }

            if (type == typeof(object))
            {
                value = this;
                return true;
            }
            if (type == typeof(int))
            {
                value = (int)(float)_value;
                return true;
            }
            if (type == typeof(float))
            {
                value = (float)_value;
                return true;
            }
            if (type == typeof(long))
            {
                value = (long)(float)_value;
                return true;
            }
            if (type == typeof(double))
            {
                value = (double)(float)_value;
                return true;
            }
            if (type == typeof(decimal))
            {
                value = (decimal) (float) _value;
                return true;
            }

            throw new ScriptRuntimeException(span, $"Cannot convert {this} to an {type} as it has an imaginary part.");
        }

        public bool CanTransform(Type transformType)
        {
            return transformType == typeof(float) || transformType == typeof(double) || transformType == typeof(int);
        }

        public bool Visit(TemplateContext context, SourceSpan span, Func<object, bool> visit)
        {
            return false;
        }

        public object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply, Type destType)
        {
            if (destType == typeof(KalkHalf))
            {
                return new KalkHalf((float) apply((float) _value));
            }
            else if (destType == typeof(float))
            {
                return (KalkHalf)(float) apply((float) _value);
            }
            else if (destType == typeof(double))
            {
                return (KalkHalf)(double)apply((float)_value);
            }
            else if (destType == typeof(int))
            {
                return (KalkHalf)(int)apply((float)_value);
            }

            return null;
        }

        public static KalkHalf FromObject(KalkEngine engine, SourceSpan span, object value)
        {
            if (value == null) return new KalkHalf();

            if (value is KalkHalf half) return half;

            if (value is IConvertible convertible)
            {
                return (KalkHalf) convertible.ToSingle(engine);
            }

            throw new ScriptRuntimeException(span, $"The type {engine.GetTypeName(value)} is not convertible to half");
        }

        public Type ElementType => typeof(float);
    }
}