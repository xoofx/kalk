using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using MathNet.Numerics;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Kalk.Core
{
    public interface IKalkSpannable
    {
        Span<byte> AsSpan();
    }
    
    
    public abstract class KalkValue : KalkObject, IScriptTransformable, IKalkSpannable
    {
        public abstract Type ElementType { get; }
        
        public abstract bool CanTransform(Type transformType);

        public abstract Span<byte> AsSpan();

        public void BitCastFrom(Span<byte> bytes)
        {
            var destByte = AsSpan();
            var minLength = Math.Min(destByte.Length, bytes.Length);
            Unsafe.CopyBlockUnaligned(ref destByte[0], ref bytes[0], (uint)minLength);
        }

        public abstract bool Visit(TemplateContext context, SourceSpan span, Func<object, bool> visit);

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