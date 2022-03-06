using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Scriban;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Kalk.Core
{
    public struct KalkComplex : IScriptCustomType, IKalkSpannable
    {
        private Complex _value;
        private const double MaxRoundToZero = 1e-14;

        public KalkComplex(double real, double im)
        {
            _value = new Complex(real, im);
        }

        public KalkComplex(Complex value)
        {
            _value = value;
        }

        public string TypeName => "complex";

        public double Re => _value.Real;
        
        public double Im => _value.Imaginary;

        public double Phase => _value.Phase;

        public double Magnitude => _value.Magnitude;
        
        public bool HasIm => _value.Imaginary > MaxRoundToZero;
        
        internal Complex Value => _value;

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            if (leftValue is KalkComplex leftComplex && rightValue is KalkComplex rightComplex)
            {
                switch (op)
                {
                    case ScriptBinaryOperator.Add:
                        result = (KalkComplex) (leftComplex._value + rightComplex._value);
                        return true;
                    case ScriptBinaryOperator.Subtract:
                        result = (KalkComplex)(leftComplex._value - rightComplex._value);
                        return true;
                    case ScriptBinaryOperator.Divide:
                        result = (KalkComplex)(leftComplex._value / rightComplex._value);
                        return true;
                    case ScriptBinaryOperator.DivideRound:
                        result = (KalkComplex)(leftComplex._value / rightComplex._value);
                        return true;
                    case ScriptBinaryOperator.Multiply:
                        result = (KalkComplex)(leftComplex._value * rightComplex._value);
                        return true;
                    case ScriptBinaryOperator.Power:
                        result = (KalkComplex)(Complex.Pow(leftComplex._value, rightComplex._value));
                        return true;
                }
            }
            else if (rightValue is KalkComplex rightComplex2)
            {
                var leftAsDouble = (double)context.ToObject(span, leftValue, typeof(double));
                switch (op)
                {
                    case ScriptBinaryOperator.Add:
                        result = (KalkComplex)(leftAsDouble + rightComplex2._value);
                        return true;
                    case ScriptBinaryOperator.Subtract:
                        result = (KalkComplex)(leftAsDouble - rightComplex2._value);
                        return true;
                    case ScriptBinaryOperator.Divide:
                        result = (KalkComplex)(leftAsDouble / rightComplex2._value);
                        return true;
                    case ScriptBinaryOperator.DivideRound:
                        result = (KalkComplex)(leftAsDouble / rightComplex2._value);
                        return true;
                    case ScriptBinaryOperator.Multiply:
                        result = (KalkComplex)(leftAsDouble * rightComplex2._value);
                        return true;
                }
            }
            else if (leftValue is KalkComplex leftComplex2)
            {
                var rightAsDouble = (double)context.ToObject(span, rightValue, typeof(double));
                switch (op)
                {
                    case ScriptBinaryOperator.Add:
                        result = (KalkComplex)(leftComplex2._value + rightAsDouble);
                        return true;
                    case ScriptBinaryOperator.Subtract:
                        result = (KalkComplex)(leftComplex2._value - rightAsDouble);
                        return true;
                    case ScriptBinaryOperator.Divide:
                        result = (KalkComplex)(leftComplex2._value / rightAsDouble);
                        return true;
                    case ScriptBinaryOperator.DivideRound:
                        result = (KalkComplex)(leftComplex2._value / rightAsDouble);
                        return true;
                    case ScriptBinaryOperator.Multiply:
                        result = (KalkComplex)(leftComplex2._value * rightAsDouble);
                        return true;
                    case ScriptBinaryOperator.Power:
                        result = (KalkComplex)(Complex.Pow(leftComplex2._value, rightAsDouble));
                        return true;
                }
            }
            return false;
        }


        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            result = null;
            switch (op)
            {
                case ScriptUnaryOperator.Negate:
                    result = (KalkComplex) (-((KalkComplex) rightValue)._value);
                    return true;
                case ScriptUnaryOperator.Plus:
                    result = rightValue;
                    return true;
            }
            return false;
        }

        public static implicit operator KalkComplex(Complex complex)
        {
            return new KalkComplex(complex);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            // We round the number to make the display nicer
            var re = Math.Round(Re, 10, MidpointRounding.AwayFromZero);
            var im = Math.Round(Im, 10, MidpointRounding.AwayFromZero);

            if (Math.Abs(re) > 1e-14) builder.AppendFormat(CultureInfo.CurrentCulture, "{0}", re);

            if (HasIm)
            {
                if (builder.Length > 0) builder.Append(" + ");

                if (Math.Abs(Math.Abs(im) - 1.0) < MaxRoundToZero)
                {
                    builder.Append("i");
                }
                else
                {
                    builder.AppendFormat(CultureInfo.CurrentCulture, "{0}i", im);
                }
            }

            if (builder.Length == 0) builder.Append("0");
            return builder.ToString();
        }

        public Span<byte> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Unsafe.As<KalkComplex, byte>(ref Unsafe.AsRef(this)), Unsafe.SizeOf<KalkComplex>());
        }

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            if (type == typeof(object))
            {
                value = this;
                return true;
            }
            if (type == typeof(int))
            {
                if (HasIm) throw new ScriptRuntimeException(span, $"Cannot convert {this} to an integer as it has an imaginary part.");
                value = (int) Re;
                return true;
            }
            if (type == typeof(float))
            {
                if (HasIm) throw new ScriptRuntimeException(span, $"Cannot convert {this} to a float as it has an imaginary part.");
                value = (float)Re;
                return true;
            }
            if (type == typeof(double))
            {
                if (HasIm) throw new ScriptRuntimeException(span, $"Cannot convert {this} to a double as it has an imaginary part.");
                value = (double)Re;
                return true;
            }
            if (type == typeof(decimal))
            {
                if (HasIm) throw new ScriptRuntimeException(span, $"Cannot convert {this} to a decimal as it has an imaginary part.");
                value = (decimal)Re;
                return true;
            }
            if (type == typeof(BigInteger))
            {
                if (HasIm) throw new ScriptRuntimeException(span, $"Cannot convert {this} to a big integer as it has an imaginary part.");
                value = (BigInteger)Re;
                return true;
            }

            throw new ScriptRuntimeException(span, $"Cannot convert {this} to an {type} as it has an imaginary part.");
        }
    }
}