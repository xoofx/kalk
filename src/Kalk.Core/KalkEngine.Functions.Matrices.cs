using System;
using System.Collections.Generic;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private void RegisterMatrices()
        {
            RegisterMatrixTypes();

            RegisterFunction("determinant", KalkMatrix.Determinant, CategoryMathVectorMatrixFunctions);
            RegisterFunction("inverse", KalkMatrix.Inverse, CategoryMathVectorMatrixFunctions);
            RegisterFunction("transpose", KalkMatrix.Transpose, CategoryMathVectorMatrixFunctions);
            RegisterFunction("mul", Multiply, CategoryMathVectorMatrixFunctions);
            RegisterFunction("identity", KalkMatrix.Identity, CategoryMathVectorMatrixFunctions);
            RegisterFunction("diag", Diagonal, CategoryMathVectorMatrixFunctions);
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

            throw new ArgumentException($"Invalid argument type {x.GetType().ScriptPrettyName()}. Expecting a matrix or a vector type.", nameof(x));
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

            throw new ArgumentException($"Unsupported type for matrix multiplication. The combination of {x.GetType().ScriptPrettyName()} * {y.GetType().ScriptPrettyName()} is not supported.", nameof(x));
        }
    }
}