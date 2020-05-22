using System;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class VectorModule
    {
        [KalkDoc("transpose", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Transpose(KalkMatrix m) => KalkMatrix.Transpose(m);

        [KalkDoc("identity", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Identity(KalkMatrix m) => KalkMatrix.Identity(m);
        
        [KalkDoc("determinant", CategoryMathVectorMatrixFunctions)]
        public static object Determinant(KalkMatrix m) => KalkMatrix.Determinant(m);

        [KalkDoc("inverse", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Inverse(KalkMatrix m) => KalkMatrix.Inverse(m);
        
        [KalkDoc("diag", CategoryMathVectorMatrixFunctions)]
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

        [KalkDoc("mul", CategoryMathVectorMatrixFunctions)]
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