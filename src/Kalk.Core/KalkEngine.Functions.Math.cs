using System;
using System.ComponentModel;
using System.Numerics;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public const string CategoryMathConstants = "Math Constants";
        public const string CategoryMathFunctions = "Math Functions";
        public const string CategoryVectorConstructors = "Vector Constructors";

        private Func<int, BigInteger> FibFunc;
        private Func<object, object> AbsFunc;
        private static readonly Func<double, double> CosFunc = Math.Cos;
        private static readonly Func<double, double> AcosFunc = Math.Acos;
        private static readonly Func<double, double> CoshFunc = Math.Cosh;
        private static readonly Func<double, double> CotFunc = MathNet.Numerics.Trig.Cot;
        private static readonly Func<double, double> AcoshFunc = MathNet.Numerics.Trig.Acosh;
        private static readonly Func<double, double> SinFunc = Math.Sin;
        private static readonly Func<double, double> AsinFunc = Math.Asin;
        private static readonly Func<double, double> SinhFunc = Math.Sinh;
        private static readonly Func<double, double> AsinhFunc = MathNet.Numerics.Trig.Asinh;

        private static readonly Func<double, double> TanFunc = Math.Tan;
        private static readonly Func<double, double> TanhFunc = Math.Tanh;
        private static readonly Func<double, double> AtanFunc = Math.Atan;
        private static readonly Func<double, double> AtanhFunc = MathNet.Numerics.Trig.Atanh;

        private static readonly Func<double, double> RsqrtFunc = x => 1.0 / Math.Sqrt(x);
        private static readonly Func<double, double> SqrtFunc = Math.Sqrt;
        private static readonly Func<double, double> LogFunc = Math.Log;
        private static readonly Func<double, double> Log10Func = Math.Log10;
        private static readonly Func<double, double> Log2Func = Math.Log2;
        private static readonly Func<double, double> ExpFunc = Math.Exp;
        private static readonly Func<double, double> Exp2Func = x => Math.Pow(2, x);

        private static readonly Func<double, double> FracFunc = FracImpl;

        private static readonly Func<double, double> RoundFunc = Math.Round;
        private static readonly Func<double, double> FloorFunc= Math.Floor;
        private static readonly Func<double, double> CeilFunc = Math.Ceiling;
        private static readonly Func<double, double> TruncFunc= Math.Truncate;
        private Func<object, object> SignFunc;

        /// <summary>
        /// Defines the "Not a Number" constant for a double.
        /// </summary>
        [KalkDoc("nan")] public const double Nan = double.NaN;

        /// <summary>
        /// Defines the infinity constant for a double.
        /// </summary>
        [KalkDoc("inf")] public const double Inf = double.PositiveInfinity;

        /// <summary>
        /// Defines the PI constant. pi = 3.14159265358979
        /// </summary>
        [KalkDoc("pi")] public const double Pi = Math.PI;

        /// <summary>
        /// Defines the natural logarithmic base. e = 2.71828182845905
        /// </summary>
        [KalkDoc("e")] public const double E = Math.E;

        private void RegisterMathFunctions()
        {
            FibFunc = Fibonacci;
            AbsFunc = AbsImpl;
            SignFunc = SignFuncImpl;

            Builtins.Import("i", new Func<object, object>(ComplexNumber));

            RegisterConstant("nan", Nan, CategoryMathConstants);
            RegisterConstant("inf", double.PositiveInfinity, CategoryMathConstants);
            RegisterConstant("pi", Math.PI, CategoryMathConstants);
            RegisterConstant("e", Math.E, CategoryMathConstants);

            RegisterFunction("abs", Abs, CategoryMathFunctions);
            RegisterFunction("sign",Sign, CategoryMathFunctions);
            RegisterFunction("fib", Fib, CategoryMathFunctions);

            RegisterFunction("cos", Cos, CategoryMathFunctions);
            RegisterFunction("acos", Acos, CategoryMathFunctions);
            RegisterFunction("cosh", Cosh, CategoryMathFunctions);
            RegisterFunction("acosh", Acosh, CategoryMathFunctions);
            
            RegisterFunction("sin", Sin, CategoryMathFunctions);
            RegisterFunction("asin", Asin, CategoryMathFunctions);
            RegisterFunction("sinh", Sinh, CategoryMathFunctions);
            RegisterFunction("asinh", Asinh, CategoryMathFunctions);

            RegisterFunction("tan", Tan, CategoryMathFunctions);
            RegisterFunction("atan", Atan, CategoryMathFunctions);
            RegisterFunction("tanh", Tanh, CategoryMathFunctions);
            RegisterFunction("atanh", Atanh, CategoryMathFunctions);

            RegisterFunction("atan2", Atan2, CategoryMathFunctions);

            RegisterFunction("rsqrt", Rsqrt, CategoryMathFunctions);
            RegisterFunction("sqrt", Sqrt, CategoryMathFunctions);
            RegisterFunction("log", Log, CategoryMathFunctions);
            RegisterFunction("log2", Log2, CategoryMathFunctions);
            RegisterFunction("log10", Log10, CategoryMathFunctions);
            RegisterFunction("exp", Exp, CategoryMathFunctions);
            RegisterFunction("exp2", Exp2, CategoryMathFunctions);
            RegisterFunction("pow", Pow, CategoryMathFunctions);

            RegisterFunction("fmod", Fmod, CategoryMathFunctions);
            RegisterFunction("frac", Frac, CategoryMathFunctions);
            RegisterFunction("round", Round, CategoryMathFunctions);
            RegisterFunction("floor", Floor, CategoryMathFunctions);
            RegisterFunction("ceil", Ceiling, CategoryMathFunctions);
            RegisterFunction("trunc", Trunc, CategoryMathFunctions);

            RegisterFunction("asdouble", (Func<object, double>)AsDouble, CategoryMathFunctions);
            RegisterFunction("aslong", (Func<object, long>)AsLong, CategoryMathFunctions);

            RegisterFunction("int", new KalkVectorConstructor<int>(1), CategoryVectorConstructors);
            RegisterFunction("int2", new KalkVectorConstructor<int>(2), CategoryVectorConstructors);
            RegisterFunction("int3", new KalkVectorConstructor<int>(3), CategoryVectorConstructors);
            RegisterFunction("int4", new KalkVectorConstructor<int>(4), CategoryVectorConstructors);
            RegisterFunction("int8", new KalkVectorConstructor<int>(8), CategoryVectorConstructors);

            RegisterFunction("float", new KalkVectorConstructor<float>(1), CategoryVectorConstructors);
            RegisterFunction("float2", new KalkVectorConstructor<float>(2), CategoryVectorConstructors);
            RegisterFunction("float3", new KalkVectorConstructor<float>(3), CategoryVectorConstructors);
            RegisterFunction("float4", new KalkVectorConstructor<float>(4), CategoryVectorConstructors);
            RegisterFunction("float8", new KalkVectorConstructor<float>(8), CategoryVectorConstructors);

            RegisterFunction("double", new KalkVectorConstructor<double>(1), CategoryVectorConstructors);
            RegisterFunction("double2", new KalkVectorConstructor<double>(2), CategoryVectorConstructors);
            RegisterFunction("double3", new KalkVectorConstructor<double>(3), CategoryVectorConstructors);
            RegisterFunction("double4", new KalkVectorConstructor<double>(4), CategoryVectorConstructors);
            RegisterFunction("double8", new KalkVectorConstructor<double>(8), CategoryVectorConstructors);

            RegisterFunction("rgb", new RgbDelegate(Rgb), CategoryVectorConstructors);
            RegisterFunction("rgba", new RgbaDelegate(Rgba), CategoryVectorConstructors);

            RegisterFunction("float4x4", new KalkMatrixConstructor<float>(4, 4), CategoryVectorConstructors);
        }


        [KalkDoc("fib")]
        public object Fib(KalkIntValue x) => x.Transform(this, CurrentSpan, FibFunc);

        protected delegate KalkColorRgb RgbDelegate(object rgb, params int[] others);
        protected delegate KalkColorRgba RgbaDelegate(int rgb, params int[] others);


        [KalkDoc("i")]
        public static object ComplexNumber(object value = null)
        {
            if (value == null) return new KalkComplex(0, 1);

            if (value is BigInteger bigInt) return new KalkComplex(0, (double)bigInt);
            if (value is double vFloat64) return new KalkComplex(0, vFloat64);
            if (value is float vFloat32) return new KalkComplex(0, vFloat32);
            if (value is long vInt64) return new KalkComplex(0, vInt64);
            if (value is int vInt32) return new KalkComplex(0, vInt32);

            throw new ArgumentOutOfRangeException(nameof(value));
        }
        
        [KalkDoc("rgb")]
        public KalkColorRgb Rgb(object rgb, params int[] others)
        {
            if (others.Length == 0)
            {
                if (rgb is string rgbStr)
                {
                    try
                    {
                        return new KalkColorRgb(int.Parse(rgbStr.TrimStart('#'), System.Globalization.NumberStyles.HexNumber));
                    }
                    catch
                    {
                        throw new ArgumentOutOfRangeException($"Expecting an hexadecimal rgb string (e.g #FF80C2) instead of {rgbStr}");
                    }
                }

                return new KalkColorRgb(ToObject<int>(CurrentSpan, rgb));
            }

            if (others.Length == 2)
            {
                return new KalkColorRgb(ToObject<int>(CurrentSpan, rgb), others[0], others[1]);
            }

            throw new ArgumentException("Invalid number of arguments. Expecting 3 arguments for `rgb(r,g,b)` or one argument `rgb(0xRRGGBB)`.");
        }

        [KalkDoc("rgba")]
        public KalkColorRgba Rgba(int rgba, params int[] others)
        {
            if (others.Length == 0)
            {
                return new KalkColorRgba(rgba);
            }

            if (others.Length == 3)
            {
                return new KalkColorRgba(rgba, others[0], others[1], others[2]);
            }

            throw new ArgumentException("Invalid number of arguments. Expecting 4 arguments for `rgba(r,g,b, a)` or one argument `rgb(0xRRGGBBAA)`.");
        }

        /// <summary>
        /// Returns the absolute value of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The absolute value of the <paramref name="x"/> parameter.</returns>
        [KalkDoc("abs")]
        public object Abs(KalkValue x) => x.Transform(this, CurrentSpan, AbsFunc);

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
        [KalkDoc("sign")]
        public object Sign(KalkValue x) => x.Transform(this, CurrentSpan, SignFunc);

        [KalkDoc("cos")]
        public object Cos(KalkDoubleValue x) => x.Transform(this, CurrentSpan, CosFunc);

        [KalkDoc("acos")]
        public object Acos(KalkDoubleValue x) => x.Transform(this, CurrentSpan, AcosFunc);

        [KalkDoc("cosh")]
        public object Cosh(KalkDoubleValue x) => x.Transform(this, CurrentSpan, CoshFunc);

        [KalkDoc("acosh")]
        public object Acosh(KalkDoubleValue x) => x.Transform(this, CurrentSpan, AcoshFunc);

        [KalkDoc("sin")]
        public object Sin(KalkDoubleValue x) => x.Transform(this, CurrentSpan, SinFunc);

        [KalkDoc("asin")]
        public object Asin(KalkDoubleValue x) => x.Transform(this, CurrentSpan, AsinFunc);

        [KalkDoc("sinh")]
        public object Sinh(KalkDoubleValue x) => x.Transform(this, CurrentSpan, SinhFunc);

        [KalkDoc("asinh")]
        public object Asinh(KalkDoubleValue x) => x.Transform(this, CurrentSpan, AsinhFunc);

        [KalkDoc("fmod")]
        public double Fmod(double x, double y) => x % y;

        [KalkDoc("frac")]
        public object Frac(KalkDoubleValue x) => x.Transform(this, CurrentSpan, FracFunc);

        [KalkDoc("tan")]
        public object Tan(KalkDoubleValue x) => x.Transform(this, CurrentSpan, TanFunc);
        [KalkDoc("atan")]
        public object Atan(KalkDoubleValue x) => x.Transform(this, CurrentSpan, AtanFunc);
        [KalkDoc("tanh")]
        public object Tanh(KalkDoubleValue x) => x.Transform(this, CurrentSpan, TanhFunc);
        [KalkDoc("atanh")]
        public object Atanh(KalkDoubleValue x) => x.Transform(this, CurrentSpan, AtanhFunc);
        
        [KalkDoc("atan2")]
        public double Atan2(double y, double x) => Math.Atan2(y, x);

        [KalkDoc("rsqrt")]
        public object Rsqrt(KalkDoubleValue x) => x.Transform(this, CurrentSpan, RsqrtFunc);
        [KalkDoc("sqrt")]
        public object Sqrt(KalkDoubleValue x) => x.Transform(this, CurrentSpan, SqrtFunc);
        [KalkDoc("log")]
        public object Log(KalkDoubleValue x) => x.Transform(this, CurrentSpan, LogFunc);
        [KalkDoc("log2")]
        public object Log2(KalkDoubleValue x) => x.Transform(this, CurrentSpan, Log2Func);
        [KalkDoc("log10")]
        public object Log10(KalkDoubleValue x) => x.Transform(this, CurrentSpan, Log10Func);
        [KalkDoc("exp")]
        public object Exp(KalkDoubleValue x) => x.Transform(this, CurrentSpan, ExpFunc);
        [KalkDoc("exp2")]
        public object Exp2(KalkDoubleValue x) => x.Transform(this, CurrentSpan, Exp2Func);

        [KalkDoc("pow")]
        public double Pow(double x, double y) => Math.Pow(x, y);


        [KalkDoc("round")]
        public object Round(KalkDoubleValue x) => x.Transform(this, CurrentSpan, RoundFunc);
        [KalkDoc("floor")]
        public object Floor(KalkDoubleValue x) => x.Transform(this, CurrentSpan, FloorFunc);
        [KalkDoc("ceil")]
        public object Ceiling(KalkDoubleValue x) => x.Transform(this, CurrentSpan, CeilFunc);
        [KalkDoc("trunc")]
        public object Trunc(KalkDoubleValue x) => x.Transform(this, CurrentSpan, TruncFunc);
        
        [KalkDoc("asdouble")]
        public double AsDouble(object x)
        {
            if (x is double d) return d;
            if (x is float f) return f;
            if (x is int intValue)
            {
                unsafe
                {
                    var uVal = (ulong) ((long) intValue);
                    return *(double*) &uVal;
                }
            }

            if (x is long longValue)
            {
                unsafe
                {
                    var uVal = (ulong)longValue;
                    return *(double*)&uVal;
                }
            }

            var bigInteger = ToObject<BigInteger>(CurrentSpan, x);
            unsafe
            {
                var value = (ulong) bigInteger;
                return *(double*) &value;
            }
        }

        [KalkDoc("aslong")]
        public long AsLong(object x)
        {
            if (x is long longValue) return longValue;
            if (x is int intValue) return intValue;
            if (x is double f64)
            {
                unsafe
                {
                    return *(long*)&f64;
                }
            }
            if (x is float f32)
            {
                unsafe
                {
                    double v = f32;
                    return *(long*)&v;
                }
            }

            return (long)ToObject<BigInteger>(CurrentSpan, x);
        }


        private static double FracImpl(double x)
        {
            if (x < 0)
            {
                return 1.0 + x + Math.Truncate(-x);
            }
            return x - Math.Truncate(x);
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

            return Math.Sign(ToObject<double>(CurrentSpan, value));
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

            return Math.Abs(ToObject<double>(CurrentSpan, value));
        }
    }
}