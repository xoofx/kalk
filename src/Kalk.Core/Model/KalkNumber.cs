using System;
using MathNet.Numerics;
using Scriban.Helpers;

namespace Kalk.Core
{
    public abstract class KalkNumber : KalkObject
    {
        public static bool IsNumber(object value)
        {
            return value is KalkNumber || (value != null && value.GetType().IsNumber());
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