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

    public interface IKalkMatrixObject
    {
        int RowLength { get; }

        int ColumnLength { get; }

        Type ElementType { get; }
    }

    public interface IKalkMatrixObject<T> : IKalkMatrixObject
    {
        object Transform(Func<T, T> apply);
    }

}