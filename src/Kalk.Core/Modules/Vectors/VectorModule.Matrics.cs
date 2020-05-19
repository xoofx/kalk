using System;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class VectorModule : KalkModule
    {
        private void RegisterMatrices()
        {
            RegisterMatrixTypes();

            RegisterFunction("determinant", (Func<KalkMatrix, object>) KalkMatrix.Determinant, CategoryMathVectorMatrixFunctions);
            RegisterFunction("inverse", (Func<KalkMatrix, KalkMatrix>)KalkMatrix.Inverse, CategoryMathVectorMatrixFunctions);
            RegisterFunction("transpose", (Func<KalkMatrix, KalkMatrix>)KalkMatrix.Transpose, CategoryMathVectorMatrixFunctions);
            RegisterFunction("mul", (Func<object, object, object>)Multiply, CategoryMathVectorMatrixFunctions);
            RegisterFunction("identity", (Func<KalkMatrix, KalkMatrix>)KalkMatrix.Identity, CategoryMathVectorMatrixFunctions);
            RegisterFunction("diag", (Func<object, object>)Diagonal, CategoryMathVectorMatrixFunctions);
        }

        [KalkDoc("diag")]
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

        [KalkDoc("mul")]
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