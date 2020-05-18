using System;
using MathNet.Numerics;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Kalk.Core
{
    public abstract class KalkValue : KalkObject, IScriptTransformable
    {
        public abstract Type ElementType { get; }
        
        public abstract bool CanTransform(Type transformType);

        public abstract object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply);

        public static bool IsNumber(object value)
        {
            return value is KalkValue || (value != null && value.GetType().IsNumber());
        }

        public static bool AlmostEqual(object left, object right)
        {
            if (!IsNumber(left)) throw new ArgumentOutOfRangeException(nameof(left), $"The value `{left}` is not a number");
            if (!IsNumber(right)) throw new ArgumentOutOfRangeException(nameof(left), $"The value `{right}` is not a number");

            var leftDouble = Convert.ToDouble(left);
            var rightDouble = Convert.ToDouble(right);
            return leftDouble.AlmostEqual(rightDouble);
        }

        public static bool AlmostEqual(double left, double right)
        {
            return left.AlmostEqual(right);
        }
    }
}