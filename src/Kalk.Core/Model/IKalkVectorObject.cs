using System;

namespace Kalk.Core
{
    public interface IKalkVectorObject
    {
        int Length { get; }

        Type ElementType { get; }
    }

    public interface IKalkVectorObject<T> : IKalkVectorObject
    {
        object Transform(Func<T, T> apply);
    }
}