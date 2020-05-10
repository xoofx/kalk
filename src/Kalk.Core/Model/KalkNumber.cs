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

        public static bool AlmostEqual(double left, double right)
        {
            return left.AlmostEqual(right);
        }
    }
}