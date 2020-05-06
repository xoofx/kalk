using System;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public const string MathCategory = "Math Functions";

        private static readonly Func<double, double> LogFunc = Math.Log;
        private static readonly Func<double, double> CosFunc = Math.Cos;
        private static readonly Func<double, double> AcosFunc = Math.Acos;
        private static readonly Func<double, double> CoshFunc = Math.Cosh;
        //private static readonly Func<double, double> AcoshFunc = Math.Acosh;
        private static readonly Func<double, double> SinFunc = Math.Sin;
        private static readonly Func<double, double> AsinFunc = Math.Asin;
        private static readonly Func<double, double> SinhFunc = Math.Sinh;
        //private static readonly Func<double, double> AsinhFunc = Math.Asinh;
        private static readonly Func<double, double> SqrtFunc = Math.Sqrt;
        private static readonly Func<double, double> TanFunc = Math.Tan;
        private static readonly Func<double, double> ExpFunc = Math.Exp;
        private static readonly Func<double, double> SignFunc = SignFuncImpl;


        private void RegisterMathFunctions()
        {
            Builtins.SetValue("nan", double.NaN, true);
            Builtins.SetValue("inf", double.PositiveInfinity, true);

            Builtins.SetValue("log", DelegateCustomFunction.CreateFunc<KalkValue, object>(Log), true);
            Builtins.SetValue("cos", DelegateCustomFunction.CreateFunc<KalkValue, object>(Cos), true);
            Builtins.SetValue("sin", DelegateCustomFunction.CreateFunc<KalkValue, object>(Sin), true);

            Builtins.SetValue("int2", new KalkVectorConstructor<int>(2), true);

            Builtins.SetValue("float2", new KalkVectorConstructor<float>(2), true);
            Builtins.SetValue("float3", new KalkVectorConstructor<float>(3), true);
            Builtins.SetValue("float4", new KalkVectorConstructor<float>(4), true);
            Builtins.SetValue("float8", new KalkVectorConstructor<float>(8), true);

            Builtins.SetValue("double2", new KalkVectorConstructor<double>(2), true);
            Builtins.SetValue("double3", new KalkVectorConstructor<double>(3), true);
            Builtins.SetValue("double4", new KalkVectorConstructor<double>(4), true);
            Builtins.SetValue("double8", new KalkVectorConstructor<double>(8), true);

            Builtins.Import("fib", new Func<int, long>(Fibonacci));

            Builtins.SetValue("pi", Math.PI, true);
            Builtins.SetValue("e", Math.E, true);
        }



        [KalkFunction("fib", Category = MathCategory)]
        public long Fibonacci(int value)
        {

            Context.CheckAbort();
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "The value must be > 0");
            if (value == 0) return 0;
            if (value == 1) return 1;
            return Fibonacci(value - 1) + Fibonacci(value - 2);
        }

       
        [KalkFunction("log", Category = MathCategory)]
        public object Log(KalkValue value) => value.Transform(_context, _context.CurrentSpan, LogFunc);

        [KalkFunction("cos", Category = MathCategory)]
        public object Cos(KalkValue value) => value.Transform(_context, _context.CurrentSpan, CosFunc);

        [KalkFunction("acos", Category = MathCategory)]
        public object Acos(KalkValue value) => value.Transform(_context, _context.CurrentSpan, AcosFunc);

        [KalkFunction("cosh", Category = MathCategory)]
        public object Cosh(KalkValue value) => value.Transform(_context, _context.CurrentSpan, CoshFunc);

        //[KalkFunction("acosh", Category = MathCategory)]
        //public static object Acosh(KalkValue value) => value.Transform(AcoshFunc);

        [KalkFunction("sin", Category = MathCategory)]
        public object Sin(KalkValue value) => value.Transform(_context, _context.CurrentSpan, SinFunc);

        [KalkFunction("asin", Category = MathCategory)]
        public object Asin(KalkValue value) => value.Transform(_context, _context.CurrentSpan, AsinFunc);

        [KalkFunction("sinh", Category = MathCategory)]
        public object Sinh(KalkValue value) => value.Transform(_context, _context.CurrentSpan, SinhFunc);

        //[KalkFunction("asinh", Category = MathCategory)]
        //public static object Asinh(KalkValue value) => value.Transform(AsinhFunc);

        [KalkFunction("sqrt", Category = MathCategory)]
        public object Sqrt(KalkValue value) => value.Transform(_context, _context.CurrentSpan, SqrtFunc);

        [KalkFunction("tan", Category = MathCategory)]
        public object Tan(KalkValue value) => value.Transform(_context, _context.CurrentSpan, TanFunc);

        [KalkFunction("exp", Category = MathCategory)]
        public object Exp(KalkValue value) => value.Transform(_context, _context.CurrentSpan, ExpFunc);

        private static double SignFuncImpl(double value)
        {
            return Math.Sign(value);
        }
    }


    public struct KalkValue : IScriptConvertibleFrom, IKalkTransformable
    {
        public IKalkTransformable Transformable;

        public double Value;

        public object Transform(TemplateContext context, SourceSpan span, Func<double, double> apply)
        {
            if (Transformable != null) return Transformable.Transform(context, span, apply);
            return apply(Value);
        }
        
        public bool TryConvertFrom(TemplateContext context, SourceSpan span, object value)
        {
            if (value is IKalkTransformable valuable) Transformable = valuable;
            else Value = context.ToObject<double>(span, value);
            return true;
        }
    }

    public interface IKalkTransformable
    {
        object Transform(TemplateContext context, SourceSpan span, Func<double, double> apply);
    }
}