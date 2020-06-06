using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.Random;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class MathModule : KalkModuleWithFunctions
    {
        public const string CategoryMathConstants = "Math Constants";
        public const string CategoryMathFunctions = "Math Functions";

        private readonly Func<int, BigInteger> FibFunc;
        private readonly Func<object, object> AbsFunc;
        private readonly Func<object, object> RndFunc;
        private static readonly Func<double, double> CosFunc = Math.Cos;
        private static readonly Func<double, double> AcosFunc = Math.Acos;
        private static readonly Func<double, double> CoshFunc = Math.Cosh;
        private static readonly Func<double, double> AcoshFunc = Math.Acosh;
        private static readonly Func<double, double> SinFunc = Math.Sin;
        private static readonly Func<double, double> AsinFunc = Math.Asin;
        private static readonly Func<double, double> SinhFunc = Math.Sinh;
        private static readonly Func<double, double> AsinhFunc = Math.Asinh;

        private static readonly Func<double, double> TanFunc = Math.Tan;
        private static readonly Func<double, double> TanhFunc = Math.Tanh;
        private static readonly Func<double, double> AtanFunc = Math.Atan;
        private static readonly Func<double, double> AtanhFunc = Math.Atanh;

        private static readonly Func<double, double> RsqrtFunc = x => 1.0 / Math.Sqrt(x);
        private static readonly Func<double, double> SqrtFunc = Math.Sqrt;
        private static readonly Func<double, double> LogFunc = Math.Log;
        private static readonly Func<double, double> Log10Func = Math.Log10;
        private static readonly Func<double, double> Log2Func = Math.Log2;
        private static readonly Func<double, double> ExpFunc = Math.Exp;
        private static readonly Func<double, double> Exp2Func = x => Math.Pow(2, x);

        private static readonly Func<double, double> FracFunc = FracImpl;
        private static readonly Func<double, double> FracSignedFunc = FracSignedImpl;

        private static readonly Func<double, double> RoundFunc = Math.Round;
        private static readonly Func<double, double> FloorFunc= Math.Floor;
        private static readonly Func<double, double> CeilFunc = Math.Ceiling;
        private static readonly Func<double, double> TruncFunc= Math.Truncate;
        private readonly Func<object, object> SignFunc;

        private static readonly Func<double, double> RadiansFunc = x => x * Math.PI / 180.0;
        private static readonly Func<double, double> DegreesFunc = x => x * 180.0 / Math.PI;

        private static readonly Func<object, KalkBool> IsFiniteFunc = IsFiniteFuncImpl;
        private static readonly Func<object, KalkBool> IsInfFunc = IsInfFuncImpl;
        private static readonly Func<object, KalkBool> IsNanFunc = IsNanFuncImpl;

        private static readonly Func<double, double> SaturateFunc = SaturateImpl;
        private Random _random;

        public MathModule()
        {
            IsBuiltin = true;

            FibFunc = Fibonacci;
            AbsFunc = AbsImpl;
            SignFunc = SignFuncImpl;
            _random = new Random();
            RndFunc = RndImpl;

            RegisterFunctionsAuto();
        }
        
        /// <summary>
        /// Defines the "Not a Number" constant for a double.
        /// </summary>
        [KalkDoc("nan", CategoryMathFunctions)] public const double Nan = double.NaN;

        /// <summary>
        /// Defines the infinity constant for a double.
        /// </summary>
        [KalkDoc("inf", CategoryMathFunctions)] public const double Inf = double.PositiveInfinity;

        /// <summary>
        /// Defines the PI constant. pi = 3.14159265358979
        /// </summary>
        [KalkDoc("pi", CategoryMathFunctions)] public const double Pi = Math.PI;

        /// <summary>
        /// Defines the natural logarithmic base. e = 2.71828182845905
        /// </summary>
        [KalkDoc("e", CategoryMathFunctions)] public const double E = Math.E;

        [KalkDoc("fib", CategoryMathFunctions)]
        public object Fib(KalkIntValue x) => x.TransformArg(Engine, FibFunc);

        [KalkDoc("i", CategoryMathFunctions)]
        public static object ComplexNumber()
        {
            return new KalkComplex(0, 1);
        }
        
        [KalkDoc("all", CategoryMathFunctions)]
        public KalkBool All(object x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (x is IEnumerable it)
            {
                foreach(var item in it)
                {
                    if (!Engine.ToBool(Engine.CurrentSpan, item))
                    {
                        return false;
                    }
                }
                return true;
            }
            return Engine.ToBool(Engine.CurrentSpan, x);
        }

        [KalkDoc("any", CategoryMathFunctions)]
        public KalkBool Any(object x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (x is IEnumerable it)
            {
                foreach (var item in it)
                {
                    if (Engine.ToBool(Engine.CurrentSpan, item))
                    {
                        return true;
                    }
                }
                return false;
            }
            return Engine.ToBool(Engine.CurrentSpan, x);
        }

        /// <summary>
        /// Returns the absolute value of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The absolute value of the <paramref name="x"/> parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> abs(-1)
        /// # abs(-1)
        /// out = 1
        /// >>> abs(float4(-1, 1, -2, -3))
        /// # abs(float4(-1, 1, -2, -3))
        /// out = float4(1, 1, 2, 3)
        /// ```
        /// </example>
        [KalkDoc("abs", CategoryMathFunctions, Functor = true)]
        public object Abs(KalkCompositeValue x) => x.TransformArg(Engine, AbsFunc);

        /// <summary>
        /// Returns a random value.
        /// </summary>
        /// <param name="x">A value to create random values for.</param>
        /// <returns>A random value or a random value of the <paramref name="x"/> parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> seed(0); rnd
        /// # seed(0); rnd
        /// out = 0.7262432699679598
        /// >>> rnd
        /// # rnd
        /// out = 0.8173253595909687
        /// >>> rnd(float4)
        /// # rnd(float4)
        /// out = float4(0.7680227, 0.5581612, 0.20603316, 0.5588848)
        /// ```
        /// </example>
        [KalkDoc("rnd", CategoryMathFunctions, Functor = true)]
        public object Rnd(KalkCompositeValue x = null)
        {
            if (x != null)
            {
                return x.TransformArg(Engine, RndFunc);
            }
            else
            {
                return RndFunc(null);
            }
        }

        /// <summary>
        /// Setup the seed function for rnd. The default seed is random.
        /// </summary>
        /// <param name="x">An original seed value for the `rnd` function.</param>
        /// <example>
        /// ```kalk
        /// >>> seed(0); rnd
        /// # seed(0); rnd
        /// out = 0.7262432699679598
        /// >>> seed(1); rnd
        /// # seed(1); rnd
        /// out = 0.24866858415709278
        /// ```
        /// </example>
        [KalkDoc("seed", CategoryMathFunctions)]
        public void Seed(int x)
        {
            _random = new Random(x);
        }

        /// <summary>
        /// Splits the value x into fractional and integer parts, each of which has the same sign as x.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The signed-fractional portion of x.</returns>
        /// <example>
        /// ```kalk
        /// >>> modf(1.5)
        /// # modf(1.5)
        /// out = [1, 0.5]
        /// >>> modf(float2(-1.2, 3.4))
        /// # modf(float2(-1.2, 3.4))
        /// out = [float2(-1, 3), float2(-0.20000005, 0.4000001)]
        /// ```
        /// </example>
        [KalkDoc("modf", CategoryMathFunctions, Functor = true)]
        public ScriptArray Modf(KalkCompositeValue x)
        {
            return new ScriptArray(2)
            {
                x.TransformArg(Engine, TruncFunc),
                x.TransformArg(Engine, FracSignedFunc)
            };
        }

        /// <summary>
        /// Converts x from degrees to radians.
        /// </summary>
        [KalkDoc("radians", CategoryMathFunctions)]
        public object Radians(KalkCompositeValue x) => x.TransformArg(Engine, RadiansFunc);

        /// <summary>
        /// Converts x from radians to degrees.
        /// </summary>
        [KalkDoc("degrees", CategoryMathFunctions)]
        public object Degrees(KalkCompositeValue x) => x.TransformArg(Engine, DegreesFunc);
        
        /// <summary>
        /// Returns an integer that indicates the sign of a number.
        /// </summary>
        /// <param name="x">A signed number.</param>
        /// <returns>
        /// A number that indicates the sign of x:
        ///  - -1 if x is less than zero
        ///  - 0 if x is equal to zero
        ///  - 1 if x is greater than zero.
        /// </returns>
        [KalkDoc("sign", CategoryMathFunctions)]
        public object Sign(KalkCompositeValue x) => x.TransformArg(Engine, SignFunc);

        [KalkDoc("cos", CategoryMathFunctions)]
        public object Cos(KalkDoubleValue x) => x.TransformArg(Engine, CosFunc);

        [KalkDoc("acos", CategoryMathFunctions)]
        public object Acos(KalkDoubleValue x) => x.TransformArg(Engine, AcosFunc);

        [KalkDoc("cosh", CategoryMathFunctions)]
        public object Cosh(KalkDoubleValue x) => x.TransformArg(Engine, CoshFunc);

        [KalkDoc("acosh", CategoryMathFunctions)]
        public object Acosh(KalkDoubleValue x) => x.TransformArg(Engine, AcoshFunc);

        [KalkDoc("sin", CategoryMathFunctions)]
        public object Sin(KalkDoubleValue x) => x.TransformArg(Engine, SinFunc);

        [KalkDoc("asin", CategoryMathFunctions)]
        public object Asin(KalkDoubleValue x) => x.TransformArg(Engine, AsinFunc);

        [KalkDoc("sinh", CategoryMathFunctions)]
        public object Sinh(KalkDoubleValue x) => x.TransformArg(Engine, SinhFunc);

        [KalkDoc("asinh", CategoryMathFunctions)]
        public object Asinh(KalkDoubleValue x) => x.TransformArg(Engine, AsinhFunc);

        [KalkDoc("fmod", CategoryMathFunctions)]
        public object Fmod(KalkDoubleValue x, KalkDoubleValue y)
        {
            var (xValues, yValues) = GetPairValues(x, y);
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var result = xValues[index] % yValues[index];
                index++;
                return result;
            });
        }

        [KalkDoc("frac", CategoryMathFunctions)]
        public object Frac(KalkDoubleValue x) => x.TransformArg(Engine, FracFunc);

        [KalkDoc("tan", CategoryMathFunctions)]
        public object Tan(KalkDoubleValue x) => x.TransformArg(Engine, TanFunc);
        [KalkDoc("atan", CategoryMathFunctions)]
        public object Atan(KalkDoubleValue x) => x.TransformArg(Engine, AtanFunc);
        [KalkDoc("tanh", CategoryMathFunctions)]
        public object Tanh(KalkDoubleValue x) => x.TransformArg(Engine, TanhFunc);
        [KalkDoc("atanh", CategoryMathFunctions)]
        public object Atanh(KalkDoubleValue x) => x.TransformArg(Engine, AtanhFunc);

        [KalkDoc("atan2", CategoryMathFunctions)]
        public object Atan2(KalkDoubleValue y, KalkDoubleValue x)
        {
            var (xValues, yValues) = GetPairValues(x, y);
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var result = Math.Atan2(yValues[index], xValues[index]);
                index++;
                return result;
            });
        }

        [KalkDoc("rsqrt", CategoryMathFunctions)]
        public object Rsqrt(KalkDoubleValue x) => x.TransformArg(Engine, RsqrtFunc);
        [KalkDoc("sqrt", CategoryMathFunctions)]
        public object Sqrt(KalkDoubleValue x) => x.TransformArg(Engine, SqrtFunc);
        [KalkDoc("log", CategoryMathFunctions)]
        public object Log(KalkDoubleValue x) => x.TransformArg(Engine, LogFunc);
        [KalkDoc("log2", CategoryMathFunctions)]
        public object Log2(KalkDoubleValue x) => x.TransformArg(Engine, Log2Func);
        [KalkDoc("log10", CategoryMathFunctions)]
        public object Log10(KalkDoubleValue x) => x.TransformArg(Engine, Log10Func);
        [KalkDoc("exp", CategoryMathFunctions)]
        public object Exp(KalkDoubleValue x) => x.TransformArg(Engine, ExpFunc);
        [KalkDoc("exp2", CategoryMathFunctions)]
        public object Exp2(KalkDoubleValue x) => x.TransformArg(Engine, Exp2Func);

        [KalkDoc("pow", CategoryMathFunctions)]
        public object Pow(KalkDoubleValue x, KalkDoubleValue y)
        {
            var (xValues, yValues) = GetPairValues(x, y);
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var result = Math.Pow(xValues[index], yValues[index]);
                index++;
                return result;
            });
        } 
        
        [KalkDoc("round", CategoryMathFunctions)]
        public object Round(KalkDoubleValue x) => x.TransformArg(Engine, RoundFunc);
        [KalkDoc("floor", CategoryMathFunctions)]
        public object Floor(KalkDoubleValue x) => x.TransformArg(Engine, FloorFunc);
        [KalkDoc("ceil", CategoryMathFunctions)]
        public object Ceiling(KalkDoubleValue x) => x.TransformArg(Engine, CeilFunc);
        [KalkDoc("trunc", CategoryMathFunctions)]
        public object Trunc(KalkDoubleValue x) => x.TransformArg(Engine, TruncFunc);
        
        [KalkDoc("saturate", CategoryMathFunctions)]
        public object Saturate(KalkDoubleValue x) => x.TransformArg(Engine, SaturateFunc);

        [KalkDoc("min", CategoryMathFunctions)]
        public object Min(KalkDoubleValue x, KalkDoubleValue y)
        {
            var (xValues,yValues) = GetPairValues(x,y);
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var result = Math.Min(xValues[index], yValues[index]);
                index++;
                return result;
            });
        }

        [KalkDoc("max", CategoryMathFunctions)]
        public object Max(KalkDoubleValue x, KalkDoubleValue y)
        {
            var (xValues, yValues) = GetPairValues(x, y);
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var result = Math.Max(xValues[index], yValues[index]);
                index++;
                return result;
            });
        }

        [KalkDoc("step", CategoryMathFunctions)]
        public object Step(KalkDoubleValue y, KalkDoubleValue x)
        {
            var (xValues, yValues) = GetPairValues(x, y, nameof(x), nameof(y));
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var yv = yValues[index];
                var xv = xValues[index];
                index++;
                return xv >= yv ? 1.0 : 0.0;
            });
        }

        [KalkDoc("smoothstep", CategoryMathFunctions)]
        public object Smoothstep(KalkDoubleValue min, KalkDoubleValue max, KalkDoubleValue x)
        {
            var (xValues, minValues, maxValues) = GetTripleValues(x, min, max, nameof(x), nameof(min), nameof(max));
            int index = 0;
            return x.TransformArg(Engine, (double v) =>
            {
                var minValue = minValues[index];
                var maxValue = maxValues[index];
                index++;
                if (v < minValue) v = 0.0;
                if (v > maxValue) v = 1.0;
                return v * v * (3.0f - (2.0f * v));
            });
        }
        
        [KalkDoc("lerp", CategoryMathFunctions)]
        public object Lerp(KalkDoubleValue x, KalkDoubleValue y, KalkDoubleValue s)
        {
            var (xValues, yValues, sValues) = GetTripleValues(x, y, s, nameof(x), nameof(y), nameof(s));
            int index = 0;
            return x.TransformArg(Engine, (double xv) =>
            {
                var yv = yValues[index];
                var sv = sValues[index];
                index++;
                return xv * (1 - sv) + yv * sv;
            });
        }

        [KalkDoc("clamp", CategoryMathFunctions)]
        public object Clamp(KalkDoubleValue x, KalkDoubleValue min, KalkDoubleValue max)
        {
            var (xValues, minValues, maxValues) = GetTripleValues(x, min, max, nameof(x), nameof(min), nameof(max));
            int index = 0;
            return x.TransformArg(Engine, (double xv) =>
            {
                var minv = minValues[index];
                var maxv = maxValues[index];
                index++;
                return ClampImpl(xv, minv, maxv);
            });
        }

        [KalkDoc("real", CategoryMathFunctions)]
        public double Real(KalkComplex x) => x.Re;

        [KalkDoc("imag", CategoryMathFunctions)]
        public double Imag(KalkComplex x) => x.Im;

        [KalkDoc("phase", CategoryMathFunctions)]
        public double Phase(KalkComplex x) => x.Phase;
        
        private (List<double>, List<double>) GetPairValues(KalkDoubleValue x, KalkDoubleValue y, string nameofx = "x", string nameofy = "y")
        {
            var xValues = new List<double>();
            var yValues = new List<double>();
            x.TransformArg(Engine, (double v) =>
            {
                xValues.Add(v);
                return v;
            });

            y = Cast(x, y, nameofy);
            y.TransformArg(Engine, (double v) =>
            {
                yValues.Add(v);
                return v;
            });
            if (xValues.Count != yValues.Count)
            {
                throw new ArgumentException($"Invalid length between {nameofx} with {xValues.Count} elements and {nameofy} with {yValues.Count} elements.", nameofx);
            }

            return (xValues, yValues);
        }

        /// <summary>
        /// Cast y to x type.
        /// </summary>
        private KalkDoubleValue Cast(KalkDoubleValue x, KalkDoubleValue y, string nameofy = "y")
        {
            if (x.Transformable != null && y.Transformable == null)
            {
                try
                {
                    var ty = Engine.ToObject<double>(1, y.Value);
                    return new KalkDoubleValue((IScriptTransformable) x.TransformArg(Engine, (double v) => ty));
                }
                catch
                {
                    throw new ArgumentException($"Error converting {nameofy} to {Engine.GetTypeName(x)}.", nameofy);
                }
            }

            return y;
        }
        
        private (List<double>, List<double>, List<double>) GetTripleValues(KalkDoubleValue x, KalkDoubleValue y, KalkDoubleValue z, string nameofx = "x", string nameofy = "y", string nameofz = "z")
        {
            var xValues = new List<double>();
            var yValues = new List<double>();
            var zValues = new List<double>();
            x.TransformArg(Engine, (double v) =>
            {
                xValues.Add(v);
                return v;
            });

            y = Cast(x, y, nameofy);
            y.TransformArg(Engine, (double v) =>
            {
                yValues.Add(v);
                return v;
            });

            z = Cast(x, z, nameofz);
            z.TransformArg(Engine, (double v) =>
            {
                zValues.Add(v);
                return v;
            });

            if (xValues.Count != yValues.Count || xValues.Count != zValues.Count)
            {
                throw new ArgumentException($"Invalid length between {nameofx} with {xValues.Count} elements, {nameofy} with {yValues.Count} elements and {nameofz} with {zValues.Count} elements.", nameofx);
            }

            return (xValues, yValues, zValues);
        }

        [KalkDoc("isfinite", CategoryMathFunctions)]
        public object IsFinite(KalkCompositeValue x) => x.TransformArg(Engine, IsFiniteFunc);
        [KalkDoc("isinf", CategoryMathFunctions)]
        public object IsInf(KalkCompositeValue x) => x.TransformArg(Engine, IsInfFunc);
        [KalkDoc("isnan", CategoryMathFunctions)]
        public object IsNan(KalkCompositeValue x) => x.TransformArg(Engine, IsNanFunc);
        
        private delegate object SumDelegate(object value, params object[] values);

        [KalkDoc("sum", CategoryMathFunctions)]
        public object Sum(object value, params object[] values)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            object result = value;
            if (value is IEnumerable it)
            {
                bool resetFirst = true;
                foreach(var nextValue in it)
                {
                    if (resetFirst)
                    {
                        result = nextValue;
                        resetFirst = false;
                    }
                    else
                    {
                        result = ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.Add, result, nextValue);
                    }
                }
            }

            foreach (var nextValue in values)
            {
                result = ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.Add, result, nextValue);
            }
            
            return result;
        }

        private static double FracImpl(double x)
        {
            if (x < 0)
            {
                return 1.0 + x + Math.Truncate(-x);
            }
            return x - Math.Truncate(x);
        }

        private static double FracSignedImpl(double x)
        {
            return x - Math.Truncate(x);
        }

        private static KalkBool IsFiniteFuncImpl(object arg)
        {
            if (arg is float f32) return float.IsFinite(f32);
            if (arg is double f64) return double.IsFinite(f64);
            return true;
        }

        private static KalkBool IsInfFuncImpl(object arg)
        {
            if (arg is float f32) return float.IsInfinity(f32);
            if (arg is double f64) return double.IsInfinity(f64);
            return false;
        }

        private static KalkBool IsNanFuncImpl(object arg)
        {
            if (arg is float f32) return float.IsNaN(f32);
            if (arg is double f64) return double.IsNaN(f64);
            return false;
        }

        private object SignFuncImpl(object value)
        {
            if (value == null) return null;

            var type = value.GetType();
            if (type == typeof(int))
            {
                return Math.Sign((int)value);
            }
            if (type == typeof(float))
            {
                return Math.Sign((float)value);
            }
            if (type == typeof(double))
            {
                return Math.Sign((double)value);
            }
            if (type == typeof(long))
            {
                return Math.Sign((long)value);
            }
            if (type == typeof(decimal))
            {
                return Math.Sign((decimal)value);
            }
            if (type == typeof(BigInteger))
            {
                return ((BigInteger)value).Sign;
            }

            return Math.Sign(Engine.ToObject<double>(0, value));
        }

        private BigInteger Fibonacci(int value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "The value must be > 0");
            if (value == 0) return BigInteger.Zero;
            if (value == 1) return BigInteger.One;

            var fn = BigInteger.Zero;
            var fn1 = BigInteger.One;
            var n = (uint) value;
            
            for (uint bit = (0x80000000 >> BitOperations.LeadingZeroCount(n)); bit != 0; bit >>= 1)
            {
                // F(2n) = F(n) * (2*F(n+1) - F(n))
                // F(2n+1) = F(n+1)^2 + F(n)^2
                var f2n = fn * ((fn1 << 1) - fn);
                var f2n1 = fn1 * fn1 + fn * fn;
                fn = f2n;
                fn1 = f2n1;

                if ((n & bit) != 0)
                {
                    var nfn1 = fn + fn1;
                    fn = fn1;
                    fn1 = nfn1;
                }
            }
            return fn;
        }

        private object RndImpl(object value = null)
        {
            if (value == null) return _random.NextDouble();

            var type = value.GetType();
            if (type == typeof(int))
            {
                return _random.NextFullRangeInt32();
            }
            if (type == typeof(float))
            {
                return (float)_random.NextDouble();
            }
            if (type == typeof(double))
            {
                return _random.NextDouble();
            }
            if (type == typeof(long))
            {
                return _random.NextFullRangeInt64();
            }
            if (type == typeof(decimal))
            {
                return _random.NextDecimal();
            }
            if (type == typeof(BigInteger))
            {
                return (BigInteger)_random.NextFullRangeInt64();
            }

            return _random.NextDouble();
        }

        private object AbsImpl(object value)
        {
            if (value == null) return null;

            var type = value.GetType();
            if (type == typeof(int))
            {
                return Math.Abs((int) value);
            }
            if (type == typeof(float))
            {
                return Math.Abs((float)value);
            }
            if (type == typeof(double))
            {
                return Math.Abs((double)value);
            }
            if (type == typeof(long))
            {
                return Math.Abs((long)value);
            }
            if (type == typeof(decimal))
            {
                return Math.Abs((decimal)value);
            }
            if (type == typeof(BigInteger))
            {
                return BigInteger.Abs((BigInteger)value);
            }

            return Math.Abs(Engine.ToObject<double>(0, value));
        }

        public static double SaturateImpl(double x) => x < 0.0 ? 0.0 : x > 1.0 ? 1.0 : x;

        public static double ClampImpl(double x, double min, double max) => Math.Min(Math.Max(x, min), max);
    }
}