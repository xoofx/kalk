using System;

namespace Kalk.Core
{
    public interface IKalkVectorObject
    {
        int Length { get; }

        Type ElementType { get; }

        object GetElement(int index);

        void SetElement(int index, object value);
    }

    public interface IKalkVectorObject<T> : IKalkVectorObject where T : struct, IEquatable<T>, IFormattable
    {
        object Transform(Func<T, T> apply);
    }
}