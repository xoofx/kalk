using System;

namespace Kalk.Core
{
    public interface IKalkVectorObject
    {
        int Length { get; }

        Type ElementType { get; }
    }

    public interface IKalkVectorObject<T> : IKalkVectorObject where T : struct, IEquatable<T>, IFormattable
    {
        object Transform(Func<T, T> apply);
    }


    public interface IKalkMatrixObject
    {
        int RowLength { get; }

        int ColumnLength { get; }

        Type ElementType { get; }
    }

    public interface IKalkMatrixObject<T> : IKalkMatrixObject where T : struct, IEquatable<T>, IFormattable
    {
        object Transform(Func<T, T> apply);
    }

}