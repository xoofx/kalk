using System;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class VectorModule
    {
        [KalkExport("transpose", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Transpose(KalkMatrix m) => KalkMatrix.Transpose(m);

        [KalkExport("identity", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Identity(KalkMatrix m) => KalkMatrix.Identity(m);
        
        [KalkExport("determinant", CategoryMathVectorMatrixFunctions)]
        public static object Determinant(KalkMatrix m) => KalkMatrix.Determinant(m);

        [KalkExport("inverse", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Inverse(KalkMatrix m) => KalkMatrix.Inverse(m);
        
        [KalkExport("diag", CategoryMathVectorMatrixFunctions)]
        public object Diagonal(object x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));

            if (x is KalkMatrix m)
            {
                return KalkMatrix.Diagonal(m);
            }

            if (x is KalkVector v)
            {
                return KalkVector.Diagonal(v);
            }

            throw new ArgumentException($"Invalid argument type {Engine.GetTypeName(x)}. Expecting a matrix or a vector type.", nameof(x));
        }
        
        [KalkExport("matrix", CategoryMatrixConstructors)]
        public object CreateMatrix(ScriptVariable name, int row, int column, params object[] arguments)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (row <= 1) throw new ArgumentOutOfRangeException(nameof(row), $"Invalid row count {row}. Expecting a value > 1.");
            if (column <= 1) throw new ArgumentOutOfRangeException(nameof(column), $"Invalid column count {column}. Expecting a value > 1.");
            switch (name.Name)
            {
                case "int":
                    return new KalkMatrixConstructor<int>(row, column).Invoke(Engine, arguments);
                case "bool":
                    return new KalkMatrixConstructor<KalkBool>(row, column).Invoke(Engine, arguments);
                case "float":
                    return new KalkMatrixConstructor<float>(row, column).Invoke(Engine, arguments);
                case "double":
                    return new KalkMatrixConstructor<double>(row, column).Invoke(Engine, arguments);
            }

            throw new ArgumentException($"Unsupported matrix type {name.Name}. Only bool, int, float and double are supported", nameof(name));
        }

        [KalkExport("row", CategoryMathVectorMatrixFunctions)]
        public KalkVector GetRow(KalkMatrix x, int index)
        {
            return x.GetRow(index);
        }
        
        [KalkExport("col", CategoryMathVectorMatrixFunctions)]
        public KalkVector GetColumn(KalkMatrix x, int index)
        {
            return x.GetColumn(index);
        }
        

        [KalkExport("mul", CategoryMathVectorMatrixFunctions)]
        public object Multiply(object x, object y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));

            if (x is KalkVector vx && y is KalkVector vy)
            {
                return KalkVector.Dot(vx, vy);
            }

            if (x is KalkVector vx1 && y is KalkMatrix my)
            {
                return KalkMatrix.Multiply(vx1, my);
            }
            if (x is KalkMatrix mx && y is KalkVector vy1)
            {
                return KalkMatrix.Multiply(mx, vy1);
            }

            if (x is KalkMatrix mx1 && y is KalkMatrix my2)
            {
                return KalkMatrix.Multiply(mx1, my2);
            }

            throw new ArgumentException($"Unsupported type for matrix multiplication. The combination of {Engine.GetTypeName(x)} * {Engine.GetTypeName(y)} is not supported.", nameof(x));
        }

    }
}