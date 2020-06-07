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

        /// <summary>
        /// Calculates the fibonacci number for the specified input.
        /// </summary>
        /// <param name="x">The input number.</param>
        /// <returns>The fibonacci number.</returns>
        /// <example>
        /// ```kalk
        /// >>> fib 50
        /// # fib(50)
        /// out = 12586269025
        /// ```
        /// </example>
        [KalkDoc("fib", CategoryMathFunctions, Functor = true)]
        public object Fib(KalkIntValue x) => x.TransformArg(Engine, FibFunc);

        /// <summary>
        /// Defines the imaginary part of a complex number.
        /// </summary>
        /// <returns>A complex number.</returns>
        /// <example>
        /// ```kalk
        /// >>> 1 + 2i
        /// # 1 + 2 * i
        /// out = 1 + 2i
        /// ```
        /// </example>
        [KalkDoc("i", CategoryMathFunctions)]
        public static object ComplexNumber()
        {
            return new KalkComplex(0, 1);
        }

        /// <summary>
        /// Determines if all components of the specified value are non-zero.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>true if all components of the x parameter are non-zero; otherwise, false.</returns>
        /// <remarks>This function is similar to the `any` function.
        /// The `any` function determines if any components of the specified value are non-zero, while the `all` function determines if all components of the specified value are non-zero.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> all(bool4(true, false, true, false))
        /// # all(bool4(true, false, true, false))
        /// out = false
        /// >>> all(bool4(true, true, true, true))
        /// # all(bool4(true, true, true, true))
        /// out = true
        /// >>> all([0,1,0,2])
        /// # all([0,1,0,2])
        /// out = false
        /// >>> all([1,1,1,1])
        /// # all([1,1,1,1])
        /// out = true
        /// ```
        /// </example>
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

        /// <summary>
        /// Determines if any components of the specified value are non-zero.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>true if any components of the x parameter are non-zero; otherwise, false.</returns>
        /// <remarks>This function is similar to the `all` intrinsic function.
        /// The `any` function determines if any components of the specified value are non-zero,
        /// while the `all` function determines if all components of the specified value are non-zero.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> any(bool4(true, false, true, false))
        /// # any(bool4(true, false, true, false))
        /// out = true
        /// >>> any(bool4(false, false, false, false))
        /// # any(bool4(false, false, false, false))
        /// out = false
        /// >>> any([0,1,0,2])
        /// # any([0,1,0,2])
        /// out = true
        /// >>> any([0,0,0,0])
        /// # any([0,0,0,0])
        /// out = false
        /// ```
        /// </example>
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
        /// <remarks>The x is not specified, it will generate a random seed automatically.</remarks>
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
        public void Seed(int? x = null)
        {
            _random = x.HasValue ? new Random(x.Value) : new Random();
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
        /// Converts the specified value from degrees to radians.
        /// </summary>
        /// <param name="x">The specified value in degrees.</param>
        /// <returns>The x parameter converted from degrees to radians.</returns>
        /// <example>
        /// ```kalk
        /// >>> radians(90)
        /// # radians(90)
        /// out = 1.5707963267948966
        /// >>> radians(180)
        /// # radians(180)
        /// out = 3.141592653589793
        /// ```
        /// </example>
        [KalkDoc("radians", CategoryMathFunctions, Functor = true)]
        public object Radians(KalkCompositeValue x) => x.TransformArg(Engine, RadiansFunc);

        /// <summary>
        /// Converts the specified value from radians to degrees.
        /// </summary>
        /// <returns>The x parameter converted from radians to degrees.</returns>
        /// <example>
        /// ```kalk
        /// >>> degrees(pi/2)
        /// # degrees(pi / 2)
        /// out = 90
        /// >>> degrees(pi)
        /// # degrees(pi)
        /// out = 180
        /// ```
        /// </example>
        [KalkDoc("degrees", CategoryMathFunctions, Functor = true)]
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
        /// <example>
        /// ```kalk
        /// >>> sign(-5); sign(0); sign(2.3)
        /// # sign(-5); sign(0); sign(2.3)
        /// out = -1
        /// out = 0
        /// out = 1
        /// >>> sign float4(-1, 2, 0, 1.5)
        /// # sign(float4(-1, 2, 0, 1.5))
        /// out = float4(-1, 1, 0, 1)
        /// ```
        /// </example>
        [KalkDoc("sign", CategoryMathFunctions, Functor = true)]
        public object Sign(KalkCompositeValue x) => x.TransformArg(Engine, SignFunc);

        /// <summary>
        /// Returns the cosine of the specified value.
        /// </summary>
        /// <param name="x">The specified value, in radians.</param>
        /// <returns>The cosine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> cos 0.5
        /// # cos(0.5)
        /// out = 0.8775825618903728
        /// >>> cos float4(pi, pi/2, 0, 0.5)
        /// # cos(float4(pi, pi / 2, 0, 0.5))
        /// out = float4(-1, -4.371139E-08, 1, 0.87758255)
        /// ```
        /// </example>
        [KalkDoc("cos", CategoryMathFunctions, Functor = true)]
        public object Cos(KalkDoubleValue x) => x.TransformArg(Engine, CosFunc);

        /// <summary>
        /// Returns the arccosine of the specified value.
        /// </summary>
        /// <param name="x">The specified value. Each component should be a floating-point value within the range of -1 to 1.</param>
        /// <returns>The arccosine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> acos(-1)
        /// # acos(-1)
        /// out = 3.141592653589793
        /// >>> acos(0)
        /// # acos(0)
        /// out = 1.5707963267948966
        /// >>> acos(1)
        /// # acos(1)
        /// out = 0
        /// >>> acos(float4(-1,0,1,0.5))
        /// # acos(float4(-1, 0, 1, 0.5))
        /// out = float4(3.1415927, 1.5707964, 0, 1.0471976)
        /// ```
        /// </example>
        [KalkDoc("acos", CategoryMathFunctions, Functor = true)]
        public object Acos(KalkDoubleValue x) => x.TransformArg(Engine, AcosFunc);

        /// <summary>
        /// Returns the hyperbolic cosine of the specified value.
        /// </summary>
        /// <param name="x">The specified value, in radians.</param>
        /// <returns>The hyperbolic cosine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> cosh(-1)
        /// # cosh(-1)
        /// out = 1.5430806348152437
        /// >>> cosh(1)
        /// # cosh(1)
        /// out = 1.5430806348152437
        /// >>> cosh(0)
        /// # cosh(0)
        /// out = 1
        /// >>> cosh(float4(-1, 1, 0, 2))
        /// # cosh(float4(-1, 1, 0, 2))
        /// out = float4(1.5430807, 1.5430807, 1, 3.7621956)
        /// ```
        /// </example>
        [KalkDoc("cosh", CategoryMathFunctions, Functor = true)]
        public object Cosh(KalkDoubleValue x) => x.TransformArg(Engine, CoshFunc);

        /// <summary>
        /// Returns the inverse hyperbolic cosine of a number. The number must be greater than or equal to 1.
        /// </summary>
        /// <param name="x">Any real number equal to or greater than 1.</param>
        /// <returns>The inverse hyperbolic cosine of the x parameter</returns>
        /// <example>
        /// ```kalk
        /// >>> acosh(1)
        /// # acosh(1)
        /// out = 0
        /// >>> acosh(10)
        /// # acosh(10)
        /// out = 2.993222846126381
        /// >>> acosh(float4(1,2,4,10))
        /// # acosh(float4(1, 2, 4, 10))
        /// out = float4(0, 1.316958, 2.063437, 2.993223)
        /// ```
        /// </example>
        [KalkDoc("acosh", CategoryMathFunctions, Functor = true)]
        public object Acosh(KalkDoubleValue x) => x.TransformArg(Engine, AcoshFunc);

        /// <summary>
        /// Returns the sine of the specified value.
        /// </summary>
        /// <param name="x">The specified value, in radians.</param>
        /// <returns>The sine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> sin 0.5
        /// # sin(0.5)
        /// out = 0.479425538604203
        /// >>> sin float4(pi, pi/2, 0, 0.5)
        /// # sin(float4(pi, pi / 2, 0, 0.5))
        /// out = float4(-8.742278E-08, 1, 0, 0.47942555)
        /// ```
        /// </example>
        [KalkDoc("sin", CategoryMathFunctions, Functor = true)]
        public object Sin(KalkDoubleValue x) => x.TransformArg(Engine, SinFunc);

        /// <summary>
        /// Returns the arcsine of the specified value.
        /// </summary>
        /// <param name="x">The specified value. Each component of the x parameter should be within the range of -π/2 to π/2.</param>
        /// <returns>The arcsine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> asin 0.5
        /// # asin(0.5)
        /// out = 0.5235987755982989
        /// >>> asin float4(-1, 0, 1, 0.5)
        /// # asin(float4(-1, 0, 1, 0.5))
        /// out = float4(-1.5707964, 0, 1.5707964, 0.5235988)
        /// ```
        /// </example>
        [KalkDoc("asin", CategoryMathFunctions, Functor = true)]
        public object Asin(KalkDoubleValue x) => x.TransformArg(Engine, AsinFunc);

        /// <summary>
        /// Returns the hyperbolic sine of the specified value.
        /// </summary>
        /// <param name="x">The specified value, in radians.</param>
        /// <returns>The hyperbolic sine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> sinh(-1)
        /// # sinh(-1)
        /// out = -1.1752011936438014
        /// >>> sinh(0)
        /// # sinh(0)
        /// out = 0
        /// >>> sinh(1)
        /// # sinh(1)
        /// out = 1.1752011936438014
        /// >>> sinh(float4(-1, 1, 0, 2))
        /// # sinh(float4(-1, 1, 0, 2))
        /// out = float4(-1.1752012, 1.1752012, 0, 3.6268604)
        /// ```
        /// </example>
        [KalkDoc("sinh", CategoryMathFunctions, Functor = true)]
        public object Sinh(KalkDoubleValue x) => x.TransformArg(Engine, SinhFunc);

        /// <summary>
        /// Returns the inverse hyperbolic sine of a number.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The inverse hyperbolic sine of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> asinh(-1.1752011936438014)
        /// # asinh(-1.1752011936438014)
        /// out = -1
        /// >>> asinh(0)
        /// # asinh(0)
        /// out = 0
        /// >>> asinh(1.1752011936438014)
        /// # asinh(1.1752011936438014)
        /// out = 1
        /// >>> asinh(float4(-1.1752011936438014, 0, 1.1752011936438014, 2))
        /// # asinh(float4(-1.1752011936438014, 0, 1.1752011936438014, 2))
        /// out = float4(-1, 0, 1, 1.4436355)
        /// ```
        /// </example>
        [KalkDoc("asinh", CategoryMathFunctions, Functor = true)]
        public object Asinh(KalkDoubleValue x) => x.TransformArg(Engine, AsinhFunc);

        /// <summary>
        /// Returns the tangent of the specified value.
        /// </summary>
        /// <param name="x">The specified value, in radians.</param>
        /// <returns>The tangent of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> tan(0.5)
        /// # tan(0.5)
        /// out = 0.5463024898437905
        /// >>> tan(1)
        /// # tan(1)
        /// out = 1.5574077246549023
        /// >>> tan float4(1, 2, 3, 4)
        /// # tan(float4(1, 2, 3, 4))
        /// out = float4(1.5574077, -2.1850398, -0.14254655, 1.1578213)
        /// ```
        /// </example>
        [KalkDoc("tan", CategoryMathFunctions, Functor = true)]
        public object Tan(KalkDoubleValue x) => x.TransformArg(Engine, TanFunc);

        /// <summary>
        /// Returns the arctangent of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The arctangent of the x parameter. This value is within the range of -π/2 to π/2.</returns>
        /// <example>
        /// ```kalk
        /// >>> atan(0.5)
        /// # atan(0.5)
        /// out = 0.4636476090008061
        /// >>> atan(1)
        /// # atan(1)
        /// out = 0.7853981633974483
        /// >>> atan(0)
        /// # atan(0)
        /// out = 0
        /// >>> atan(float4(0,1,2,3))
        /// # atan(float4(0, 1, 2, 3))
        /// out = float4(0, 0.7853982, 1.1071488, 1.2490457)
        /// ```
        /// </example>
        [KalkDoc("atan", CategoryMathFunctions, Functor = true)]
        public object Atan(KalkDoubleValue x) => x.TransformArg(Engine, AtanFunc);

        /// <summary>
        /// Returns the hyperbolic tangent of the specified value.
        /// </summary>
        /// <param name="x">The specified value, in radians.</param>
        /// <returns>The hyperbolic tangent of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> tanh(0)
        /// # tanh(0)
        /// out = 0
        /// >>> tanh(1)
        /// # tanh(1)
        /// out = 0.7615941559557649
        /// >>> tanh(2)
        /// # tanh(2)
        /// out = 0.9640275800758169
        /// >>> tanh(float4(0, 1, 2, 3))
        /// # tanh(float4(0, 1, 2, 3))
        /// out = float4(0, 0.7615942, 0.9640276, 0.9950548)
        /// ```
        /// </example>
        [KalkDoc("tanh", CategoryMathFunctions, Functor = true)]
        public object Tanh(KalkDoubleValue x) => x.TransformArg(Engine, TanhFunc);

        /// <summary>
        /// Returns the inverse hyperbolic tangent of a number.
        /// </summary>
        /// <param name="x">The specified value. Number must be between -1 and 1 (excluding -1 and 1).</param>
        /// <returns>The inverse hyperbolic tangent of the x parameter</returns>
        /// <example>
        /// ```kalk
        /// >>> atanh(0)
        /// # atanh(0)
        /// out = 0
        /// >>> atanh(0.5)
        /// # atanh(0.5)
        /// out = 0.5493061443340549
        /// >>> atanh(float4(-0.5, 0, 0.5, 0.8))
        /// # atanh(float4(-0.5, 0, 0.5, 0.8))
        /// out = float4(-0.54930615, 0, 0.54930615, 1.0986123)
        /// ```
        /// </example>
        [KalkDoc("atanh", CategoryMathFunctions, Functor = true)]
        public object Atanh(KalkDoubleValue x) => x.TransformArg(Engine, AtanhFunc);

        /// <summary>
        /// Returns the arctangent of two values (x,y).
        /// </summary>
        /// <param name="y">The y value.</param>
        /// <param name="x">The x value.</param>
        /// <returns>The arctangent of (y,x).</returns>
        /// <remarks>The signs of the x and y parameters are used to determine the quadrant of the return values within the range of -π to π. The `atan2` function is well-defined for every point other than the origin, even if y equals 0 and x does not equal 0.</remarks>
        /// <example>
        /// ```kalk
        /// >>> atan2(1,1)
        /// # atan2(1, 1)
        /// out = 0.7853981633974483
        /// >>> atan2(1,0)
        /// # atan2(1, 0)
        /// out = 1.5707963267948966
        /// >>> atan2(0,1)
        /// # atan2(0, 1)
        /// out = 0
        /// >>> atan2(float4(1), float4(0,1,-1,2))
        /// # atan2(float4(1), float4(0, 1, -1, 2))
        /// out = float4(1.5707964, 0.7853982, 2.3561945, 0.4636476)
        /// ```
        /// </example>
        [KalkDoc("atan2", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Returns the floating-point remainder of x/y.
        /// </summary>
        /// <param name="x">The floating-point dividend.</param>
        /// <param name="y">The floating-point divisor.</param>
        /// <returns>The floating-point remainder of the x parameter divided by the y parameter.</returns>
        /// <remarks>The floating-point remainder is calculated such that x = i * y + f, where i is an integer, f has the same sign as x, and the absolute value of f is less than the absolute value of y.</remarks>
        /// <example>
        /// ```kalk
        /// >>> fmod(2.5, 2)
        /// # fmod(2.5, 2)
        /// out = 0.5
        /// >>> fmod(2.5, 3)
        /// # fmod(2.5, 3)
        /// out = 2.5
        /// >>> fmod(-1.5, 1)
        /// # fmod(-1.5, 1)
        /// out = -0.5
        /// >>> fmod(float4(1.5, 1.2, -2.3, -4.6), 0.2)
        /// # fmod(float4(1.5, 1.2, -2.3, -4.6), 0.2)
        /// out = float4(0.09999998, 2.9802322E-08, -0.09999992, -0.19999984)
        /// ```
        /// </example>
        [KalkDoc("fmod", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Returns the fractional (or decimal) part of x; which is greater than or equal to 0 and less than 1.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The fractional part of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> frac(1.25)
        /// # frac(1.25)
        /// out = 0.25
        /// >>> frac(10.5)
        /// # frac(10.5)
        /// out = 0.5
        /// >>> frac(-1.75)
        /// # frac(-1.75)
        /// out = 0.25
        /// >>> frac(-10.25)
        /// # frac(-10.25)
        /// out = 0.75
        /// >>> frac(float4(1.25, 10.5, -1.75, -10.25))
        /// # frac(float4(1.25, 10.5, -1.75, -10.25))
        /// out = float4(0.25, 0.5, 0.25, 0.75)
        /// ```
        /// </example>
        [KalkDoc("frac", CategoryMathFunctions, Functor = true)]
        public object Frac(KalkDoubleValue x) => x.TransformArg(Engine, FracFunc);

        /// <summary>
        /// Returns the reciprocal of the square root of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The reciprocal of the square root of the x parameter.</returns>
        /// <remarks>This function uses the following formula: 1 / sqrt(x).</remarks>
        /// <example>
        /// ```kalk
        /// >>> rsqrt(1)
        /// # rsqrt(1)
        /// out = 1
        /// >>> rsqrt(2)
        /// # rsqrt(2)
        /// out = 0.7071067811865475
        /// >>> rsqrt(float4(1,2,3,4))
        /// # rsqrt(float4(1, 2, 3, 4))
        /// out = float4(1, 0.70710677, 0.57735026, 0.5)
        /// ```
        /// </example>
        [KalkDoc("rsqrt", CategoryMathFunctions, Functor = true)]
        public object Rsqrt(KalkDoubleValue x) => x.TransformArg(Engine, RsqrtFunc);

        /// <summary>
        /// Returns the square root of the specified floating-point value, per component.
        /// </summary>
        /// <param name="x">The specified floating-point value.</param>
        /// <returns>The square root of the x parameter, per component.</returns>
        /// <example>
        /// ```kalk
        /// >>> sqrt(1)
        /// # sqrt(1)
        /// out = 1
        /// >>> sqrt(2)
        /// # sqrt(2)
        /// out = 1.4142135623730951
        /// >>> sqrt(float4(1,2,3,4))
        /// # sqrt(float4(1, 2, 3, 4))
        /// out = float4(1, 1.4142135, 1.7320508, 2)
        /// ```
        /// </example>
        [KalkDoc("sqrt", CategoryMathFunctions, Functor = true)]
        public object Sqrt(KalkDoubleValue x) => x.TransformArg(Engine, SqrtFunc);

        /// <summary>
        /// Returns the base-e logarithm of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The base-e logarithm of the x parameter. If the x parameter is negative, this function returns indefinite. If the x parameter is 0, this function returns `-inf`.</returns>
        /// <example>
        /// ```kalk
        /// >>> log 1
        /// # log(1)
        /// out = 0
        /// >>> log 2
        /// # log(2)
        /// out = 0.6931471805599453
        /// >>> log 0
        /// # log(0)
        /// out = -inf
        /// >>> log float4(0,1,2,3)
        /// # log(float4(0, 1, 2, 3))
        /// out = float4(-inf, 0, 0.6931472, 1.0986123)
        /// ```
        /// </example>
        [KalkDoc("log", CategoryMathFunctions, Functor = true)]
        public object Log(KalkDoubleValue x) => x.TransformArg(Engine, LogFunc);

        /// <summary>
        /// Returns the base-2 logarithm of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The base-2 logarithm of the x parameter. If the x parameter is negative, this function returns indefinite. If the x parameter is 0, this function returns -inf.</returns>
        /// <example>
        /// ```kalk
        /// >>> log2 0
        /// # log2(0)
        /// out = -inf
        /// >>> log2 8
        /// # log2(8)
        /// out = 3
        /// >>> log2 129
        /// # log2(129)
        /// out = 7.011227255423254
        /// >>> log2 float4(0, 2, 16, 257)
        /// # log2(float4(0, 2, 16, 257))
        /// out = float4(-inf, 1, 4, 8.005625)
        /// ```
        /// </example>
        [KalkDoc("log2", CategoryMathFunctions, Functor = true)]
        public object Log2(KalkDoubleValue x) => x.TransformArg(Engine, Log2Func);

        /// <summary>
        /// Returns the base-10 logarithm of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The base-10 logarithm of the x parameter. If the x parameter is negative, this function returns indefinite. If the x is 0, this function returns -inf.</returns>
        /// <example>
        /// ```kalk
        /// >>> log10 0
        /// # log10(0)
        /// out = -inf
        /// >>> log10 10
        /// # log10(10)
        /// out = 1
        /// >>> log10 100
        /// # log10(100)
        /// out = 2
        /// >>> log10 1001
        /// # log10(1001)
        /// out = 3.000434077479319
        /// >>> log10(float4(0,10,100,1001))
        /// # log10(float4(0, 10, 100, 1001))
        /// out = float4(-inf, 1, 2, 3.0004342)
        /// ```
        /// </example>
        [KalkDoc("log10", CategoryMathFunctions, Functor = true)]
        public object Log10(KalkDoubleValue x) => x.TransformArg(Engine, Log10Func);

        /// <summary>
        /// Returns the base-e exponential, or e^x, of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The base-e exponential of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> exp(0)
        /// # exp(0)
        /// out = 1
        /// >>> exp(1)
        /// # exp(1)
        /// out = 2.718281828459045
        /// >>> exp(float4(0,1,2,3))
        /// # exp(float4(0, 1, 2, 3))
        /// out = float4(1, 2.7182817, 7.389056, 20.085537)
        /// ```
        /// </example>
        [KalkDoc("exp", CategoryMathFunctions, Functor = true)]
        public object Exp(KalkDoubleValue x) => x.TransformArg(Engine, ExpFunc);

        /// <summary>
        /// Returns the base 2 exponential, or 2^x, of the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The base-2 exponential of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> exp2(0)
        /// # exp2(0)
        /// out = 1
        /// >>> exp2(1)
        /// # exp2(1)
        /// out = 2
        /// >>> exp2(4)
        /// # exp2(4)
        /// out = 16
        /// >>> exp2(float4(0,1,2,3))
        /// # exp2(float4(0, 1, 2, 3))
        /// out = float4(1, 2, 4, 8)
        /// ```
        /// </example>
        [KalkDoc("exp2", CategoryMathFunctions, Functor = true)]
        public object Exp2(KalkDoubleValue x) => x.TransformArg(Engine, Exp2Func);

        /// <summary>
        /// Returns the specified value raised to the specified power.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <param name="y">The specified power.</param>
        /// <returns>The x parameter raised to the power of the y parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> pow(1.5, 3.5)
        /// # pow(1.5, 3.5)
        /// out = 4.133513940946613
        /// >>> pow(2, 4)
        /// # pow(2, 4)
        /// out = 16
        /// >>> pow(float4(1,2,3,4), 4)
        /// # pow(float4(1, 2, 3, 4), 4)
        /// out = float4(1, 16, 81, 256)
        /// >>> pow(float4(1..4), float4(5..8))
        /// # pow(float4(1..4), float4(5..8))
        /// out = float4(1, 64, 2187, 65536)
        /// ```
        /// </example>
        [KalkDoc("pow", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Rounds the specified value to the nearest integer.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The x parameter, rounded to the nearest integer within a floating-point type.</returns>
        /// <example>
        /// ```kalk
        /// >>> round(0.2); round(1.5); round(10.7)
        /// # round(0.2); round(1.5); round(10.7)
        /// out = 0
        /// out = 2
        /// out = 11
        /// >>> round(-0.2); round(-1.5); round(-10.7)
        /// # round(-0.2); round(-1.5); round(-10.7)
        /// out = -0
        /// out = -2
        /// out = -11
        /// ```
        /// </example>
        [KalkDoc("round", CategoryMathFunctions, Functor = true)]
        public object Round(KalkDoubleValue x) => x.TransformArg(Engine, RoundFunc);

        /// <summary>
        /// Returns the largest integer that is less than or equal to the specified value.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The largest integer value (returned as a floating-point type) that is less than or equal to the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> floor(0.2); floor(1.5); floor(10.7)
        /// # floor(0.2); floor(1.5); floor(10.7)
        /// out = 0
        /// out = 1
        /// out = 10
        /// >>> floor(-0.2); floor(-1.5); floor(-10.7)
        /// # floor(-0.2); floor(-1.5); floor(-10.7)
        /// out = -1
        /// out = -2
        /// out = -11
        /// ```
        /// </example>
        [KalkDoc("floor", CategoryMathFunctions, Functor = true)]
        public object Floor(KalkDoubleValue x) => x.TransformArg(Engine, FloorFunc);

        /// <summary>
        /// Returns the smallest integer value that is greater than or equal to the specified value.
        /// </summary>
        /// <param name="x">The specified input.</param>
        /// <returns>The smallest integer value (returned as a floating-point type) that is greater than or equal to the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> ceil(0.2); ceil(1.5); ceil(10.7)
        /// # ceil(0.2); ceil(1.5); ceil(10.7)
        /// out = 1
        /// out = 2
        /// out = 11
        /// >>> ceil(-0.2); ceil(-1.5); ceil(-10.7)
        /// # ceil(-0.2); ceil(-1.5); ceil(-10.7)
        /// out = -0
        /// out = -1
        /// out = -10
        /// ```
        /// </example>
        [KalkDoc("ceil", CategoryMathFunctions, Functor = true)]
        public object Ceiling(KalkDoubleValue x) => x.TransformArg(Engine, CeilFunc);

        /// <summary>
        /// Truncates a floating-point value to the integer component.
        /// </summary>
        /// <param name="x">The specified input.</param>
        /// <returns>The input value truncated to an integer component.</returns>
        /// <remarks>This function truncates a floating-point value to the integer component. Given a floating-point value of 1.6, the trunc function would return 1.0, where as the round function would return 2.0.</remarks>
        /// <example>
        /// ```kalk
        /// >>> trunc(0.2); trunc(1.5); trunc(10.7)
        /// # trunc(0.2); trunc(1.5); trunc(10.7)
        /// out = 0
        /// out = 1
        /// out = 10
        /// >>> trunc(-0.2); trunc(-1.5); trunc(-10.7)
        /// # trunc(-0.2); trunc(-1.5); trunc(-10.7)
        /// out = -0
        /// out = -1
        /// out = -10
        /// ```
        /// </example>
        [KalkDoc("trunc", CategoryMathFunctions, Functor = true)]
        public object Trunc(KalkDoubleValue x) => x.TransformArg(Engine, TruncFunc);

        /// <summary>
        /// Clamps the specified value within the range of 0 to 1.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>The x parameter, clamped within the range of 0 to 1.</returns>
        /// <example>
        /// ```kalk
        /// >>> saturate(10)
        /// # saturate(10)
        /// out = 1
        /// >>> saturate(-10)
        /// # saturate(-10)
        /// out = 0
        /// >>> saturate(float4(-1, 0.5, 1, 2))
        /// # saturate(float4(-1, 0.5, 1, 2))
        /// out = float4(0, 0.5, 1, 1)
        /// ```
        /// </example>
        [KalkDoc("saturate", CategoryMathFunctions, Functor = true)]
        public object Saturate(KalkDoubleValue x) => x.TransformArg(Engine, SaturateFunc);

        /// <summary>
        /// Selects the lesser of x and y.
        /// </summary>
        /// <param name="x">The x input value.</param>
        /// <param name="y">The y input value.</param>
        /// <returns>The x or y parameter, whichever is the smallest value.</returns>
        /// <example>
        /// ```kalk
        /// >>> min(-5, 6)
        /// # min(-5, 6)
        /// out = -5
        /// >>> min(1, 0)
        /// # min(1, 0)
        /// out = 0
        /// >>> min(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
        /// # min(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
        /// out = float4(0, 0, 2, 2)
        /// ```
        /// </example>
        [KalkDoc("min", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Selects the greater of x and y.
        /// </summary>
        /// <param name="x">The x input value.</param>
        /// <param name="y">The y input value.</param>
        /// <returns>The x or y parameter, whichever is the largest value.</returns>
        /// <example>
        /// ```kalk
        /// >>> max(-5, 6)
        /// # max(-5, 6)
        /// out = 6
        /// >>> max(1, 0)
        /// # max(1, 0)
        /// out = 1
        /// >>> max(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
        /// # max(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
        /// out = float4(1, 1, 3, 3)
        /// ```
        /// </example>
        [KalkDoc("max", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Compares two values, returning 0 or 1 based on which value is greater.
        /// </summary>
        /// <param name="y">The first floating-point value to compare.</param>
        /// <param name="x">The second floating-point value to compare.</param>
        /// <returns>1 if the x parameter is greater than or equal to the y parameter; otherwise, 0.</returns>
        /// <remarks>This function uses the following formula: (x >= y) ? 1 : 0. The function returns either 0 or 1 depending on whether the x parameter is greater than the y parameter. To compute a smooth interpolation between 0 and 1, use the `smoothstep` function.</remarks>
        /// <example>
        /// ```kalk
        /// >>> step(1, 5)
        /// # step(1, 5)
        /// out = 1
        /// >>> step(5, 1)
        /// # step(5, 1)
        /// out = 0
        /// >>> step(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
        /// # step(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
        /// out = float4(1, 0, 1, 0)
        /// >>> step(-10, 5)
        /// # step(-10, 5)
        /// out = 1
        /// >>> step(5.5, -10.5)
        /// # step(5.5, -10.5)
        /// out = 0
        /// ```
        /// </example>
        [KalkDoc("step", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Returns a smooth Hermite interpolation between 0 and 1, if x is in the range [min, max].
        /// </summary>
        /// <param name="min">The minimum range of the x parameter.</param>
        /// <param name="max">The maximum range of the x parameter.</param>
        /// <param name="x">The specified value to be interpolated.</param>
        /// <returns>Returns 0 if x is less than min; 1 if x is greater than max; otherwise, a value between 0 and 1 if x is in the range [min, max].</returns>
        /// <remarks>Use the smoothstep function to create a smooth transition between two values. For example, you can use this function to blend two colors smoothly.</remarks>
        /// <example>
        /// ```kalk
        /// >>> smoothstep(float4(0), float4(1), float4(-0.5))
        /// # smoothstep(float4(0), float4(1), float4(-0.5))
        /// out = float4(0, 0, 0, 0)
        /// >>> smoothstep(float4(0), float4(1), float4(1.5))
        /// # smoothstep(float4(0), float4(1), float4(1.5))
        /// out = float4(1, 1, 1, 1)
        /// >>> smoothstep(float4(0), float4(1), float4(0.5))
        /// # smoothstep(float4(0), float4(1), float4(0.5))
        /// out = float4(0.5, 0.5, 0.5, 0.5)
        /// >>> smoothstep(float4(0), float4(1), float4(0.9))
        /// # smoothstep(float4(0), float4(1), float4(0.9))
        /// out = float4(0.972, 0.972, 0.972, 0.972)
        /// ```
        /// </example>
        [KalkDoc("smoothstep", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="x">The first-floating point value.</param>
        /// <param name="y">The second-floating point value.</param>
        /// <param name="s">A value that linearly interpolates between the x parameter and the y parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        /// <example>
        /// ```kalk
        /// >>> lerp(0, 10, 0.5)
        /// # lerp(0, 10, 0.5)
        /// out = 5
        /// >>> lerp(rgb("AliceBlue").xyz, rgb("Green").xyz, 0.5)
        /// # lerp(rgb("AliceBlue").xyz, rgb("Green").xyz, 0.5)
        /// out = float3(0.47058824, 0.7372549, 0.5)
        /// ```
        /// </example>
        [KalkDoc("lerp", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Clamps the specified value to the specified minimum and maximum range.
        /// </summary>
        /// <param name="x">A value to clamp.</param>
        /// <param name="min">The specified minimum range.</param>
        /// <param name="max">The specified maximum range.</param>
        /// <returns>The clamped value for the x parameter.</returns>
        /// <remarks>For values of -inf or inf, clamp will behave as expected. However for values of `nan`, the results are undefined.</remarks>
        /// <example>
        /// ```kalk
        /// >>> clamp(-1, 0, 1)
        /// # clamp(-1, 0, 1)
        /// out = 0
        /// >>> clamp(2, 0, 1)
        /// # clamp(2, 0, 1)
        /// out = 1
        /// >>> clamp(0.5, 0, 1)
        /// # clamp(0.5, 0, 1)
        /// out = 0.5
        /// >>> clamp(float4(0, 1, -2, 3), float4(0, -1, 3, 4), float4(1, 2, 5, 6))
        /// # clamp(float4(0, 1, -2, 3), float4(0, -1, 3, 4), float4(1, 2, 5, 6))
        /// out = float4(0, 1, 3, 4)
        /// ```
        /// </example>
        [KalkDoc("clamp", CategoryMathFunctions, Functor = true)]
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

        /// <summary>
        /// Returns the real part of the complex number.
        /// </summary>
        /// <param name="x">A complex number.</param>
        /// <returns>The real part of the parameter x complex number.</returns>
        /// <example>
        /// ```kalk
        /// >>> real(1.5 + 2.5i)
        /// # real(1.5 + 2.5 * i)
        /// out = 1.5
        /// ```
        /// </example>
        [KalkDoc("real", CategoryMathFunctions)]
        public double Real(KalkComplex x) => x.Re;

        /// <summary>
        /// Returns the imaginary part of the complex number.
        /// </summary>
        /// <param name="x">A complex number.</param>
        /// <returns>The imaginary part of the parameter x complex number.</returns>
        /// <example>
        /// ```kalk
        /// >>> imag(1.5 + 2.5i)
        /// # imag(1.5 + 2.5 * i)
        /// out = 2.5
        /// ```
        /// </example>
        [KalkDoc("imag", CategoryMathFunctions)]
        public double Imag(KalkComplex x) => x.Im;

        /// <summary>
        /// Returns the phase of the complex number.
        /// </summary>
        /// <param name="x">A complex number.</param>
        /// <returns>The phase of the parameter x complex number.</returns>
        /// <example>
        /// ```kalk
        /// >>> phase(1.5 + 2.5i)
        /// # phase(1.5 + 2.5 * i)
        /// out = 1.0303768265243125
        /// ```
        /// </example>
        [KalkDoc("phase", CategoryMathFunctions)]
        public double Phase(KalkComplex x) => x.Phase;

        /// <summary>
        /// Determines if the specified floating-point value is finite.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>Returns a value of the same size as the input, with a value set to `true` if the x parameter is finite; otherwise `false`.</returns>
        /// <example>
        /// ```kalk
        /// >>> isfinite(1)
        /// # isfinite(1)
        /// out = true
        /// >>> isfinite(nan)
        /// # isfinite(nan)
        /// out = false
        /// >>> isfinite(inf)
        /// # isfinite(inf)
        /// out = false
        /// >>> isfinite(float4(1, -10.5, inf, nan))
        /// # isfinite(float4(1, -10.5, inf, nan))
        /// out = bool4(true, true, false, false)
        /// ```
        /// </example>
        [KalkDoc("isfinite", CategoryMathFunctions, Functor = true)]
        public object IsFinite(KalkCompositeValue x) => x.TransformArg(Engine, IsFiniteFunc);

        /// <summary>
        /// Determines if the specified value is infinite.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>Returns a value of the same size as the input, with a value set to `true` if the x parameter is +inf or -inf. Otherwise, `false`.</returns>
        /// <example>
        /// ```kalk
        /// >>> isinf(1)
        /// # isinf(1)
        /// out = false
        /// >>> isinf(inf)
        /// # isinf(inf)
        /// out = true
        /// >>> isinf(float4(1, -10.5, inf, nan))
        /// # isinf(float4(1, -10.5, inf, nan))
        /// out = bool4(false, false, true, false)
        /// ```
        /// </example>
        [KalkDoc("isinf", CategoryMathFunctions, Functor = true)]
        public object IsInf(KalkCompositeValue x) => x.TransformArg(Engine, IsInfFunc);

        /// <summary>
        /// Determines if the specified value is `nan`.
        /// </summary>
        /// <param name="x">The specified value.</param>
        /// <returns>Returns a value of the same size as the input, with a value set to `true` if the x parameter is `nan`. Otherwise, `false`.</returns>
        /// <example>
        /// ```kalk
        /// >>> isnan(1)
        /// # isnan(1)
        /// out = false
        /// >>> isnan(inf)
        /// # isnan(inf)
        /// out = false
        /// >>> isnan(nan)
        /// # isnan(nan)
        /// out = true
        /// >>> isnan(float4(1, -10.5, inf, nan))
        /// # isnan(float4(1, -10.5, inf, nan))
        /// out = bool4(false, false, false, true)
        /// ```
        /// </example>
        [KalkDoc("isnan", CategoryMathFunctions, Functor = true)]
        public object IsNan(KalkCompositeValue x) => x.TransformArg(Engine, IsNanFunc);

        /// <summary>
        /// Performs the summation of the specified value.
        /// </summary>
        /// <param name="value">The specified value.</param>
        /// <param name="values">Additional values.</param>
        /// <returns>The summation of the values.</returns>
        /// <example>
        /// ```kalk
        /// >>> sum(1,2,3,4)
        /// # sum(1, 2, 3, 4)
        /// out = 10
        /// >>> sum(float4(1..4))
        /// # sum(float4(1..4))
        /// out = 10
        /// >>> sum(float4(1..4), float4(5..8))
        /// # sum(float4(1..4), float4(5..8))
        /// out = float4(15, 16, 17, 18)
        /// >>> sum("a", "b", "c")
        /// # sum("a", "b", "c")
        /// out = "abc"
        /// >>> sum(["a", "b", "c"])
        /// # sum(["a", "b", "c"])
        /// out = "abc"
        /// ```
        /// </example>
        [KalkDoc("sum", CategoryMathFunctions)]
        public object Sum(object value, params object[] values)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            object result = value;
            if (value is IEnumerable it)
            {
                bool resetFirst = true;
                foreach (var nextValue in it)
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