using System;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class VectorModule
    {
        /// <summary>
        /// Transposes the specified matrix.
        /// </summary>
        /// <param name="m">The matrix to transpose.</param>
        /// <returns>The transposed matrix.</returns>
        /// <example>
        /// ```kalk
        /// >>> transpose float3x4(1..12)
        /// # transpose(float3x4(1..12))
        /// out = float4x3(1, 5, 9, 2, 6, 10, 3, 7, 11, 4, 8, 12)
        ///       # col  0           1           2           / row
        ///       float3(1         , 5         , 9         ) # 0
        ///       float3(2         , 6         , 10        ) # 1
        ///       float3(3         , 7         , 11        ) # 2
        ///       float3(4         , 8         , 12        ) # 3
        /// >>> transpose(out)
        /// # transpose(out)
        /// out = float3x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)
        ///       # col  0           1           2           3           / row
        ///       float4(1         , 2         , 3         , 4         ) # 0
        ///       float4(5         , 6         , 7         , 8         ) # 1
        ///       float4(9         , 10        , 11        , 12        ) # 2
        /// ```
        /// </example>
        [KalkExport("transpose", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Transpose(KalkMatrix m) => KalkMatrix.Transpose(m);

        /// <summary>
        /// Creates an identity of a squared matrix.
        /// </summary>
        /// <param name="m">The type of the squared matrix.</param>
        /// <returns>The identity matrix of the squared matrix type.</returns>
        /// <example>
        /// ```kalk
        /// >>> identity(float4x4)
        /// # identity(float4x4)
        /// out = float4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)
        ///       # col  0           1           2           3           / row
        ///       float4(1         , 0         , 0         , 0         ) # 0
        ///       float4(0         , 1         , 0         , 0         ) # 1
        ///       float4(0         , 0         , 1         , 0         ) # 2
        ///       float4(0         , 0         , 0         , 1         ) # 3
        /// ```
        /// </example>
        [KalkExport("identity", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Identity(KalkMatrix m) => KalkMatrix.Identity(m);

        /// <summary>
        /// Calculates the determinant of the specified matrix.
        /// </summary>
        /// <param name="m">The matrix to calculate the determinant for.</param>
        /// <returns>A scalar representing the determinant of the matrix.</returns>
        /// <example>
        /// ```kalk
        /// >>> float4x4(4,3,2,2,0,1,-3,3,0,-1,3,3,0,3,1,1)
        /// # float4x4(4, 3, 2, 2, 0, 1, -3, 3, 0, -1, 3, 3, 0, 3, 1, 1)
        /// out = float4x4(4, 3, 2, 2, 0, 1, -3, 3, 0, -1, 3, 3, 0, 3, 1, 1)
        ///       # col  0            1           2          3           / row
        ///       float4(4         ,  3        ,  2        , 2         ) # 0
        ///       float4(0         ,  1        , -3        , 3         ) # 1
        ///       float4(0         , -1        ,  3        , 3         ) # 2
        ///       float4(0         ,  3        ,  1        , 1         ) # 3
        /// >>> determinant out
        /// # determinant(out)
        /// out = -240
        /// ```
        /// </example>
        [KalkExport("determinant", CategoryMathVectorMatrixFunctions)]
        public static object Determinant(KalkMatrix m) => KalkMatrix.Determinant(m);

        /// <summary>
        /// Calculates the inverse of the specified matrix.
        /// </summary>
        /// <param name="m">The matrix to calculate the inverse for.</param>
        /// <returns>The inverse matrix of the specified matrix.</returns>
        /// <example>
        /// ```kalk
        /// >>> inverse(float3x3(10,20,10,4,5,6,2,3,5))
        /// # inverse(float3x3(10, 20, 10, 4, 5, 6, 2, 3, 5))
        /// out = float3x3(-0.1, 1, -1, 0.11428571, -0.42857143, 0.28571427, -0.028571427, -0.14285715, 0.42857143)
        ///       # col   0             1            2           / row
        ///       float3(-0.1        ,  1         , -1         ) # 0
        ///       float3( 0.11428571 , -0.42857143,  0.28571427) # 1
        ///       float3(-0.028571427, -0.14285715,  0.42857143) # 2
        /// ```
        /// </example>
        [KalkExport("inverse", CategoryMathVectorMatrixFunctions)]
        public static KalkMatrix Inverse(KalkMatrix m) => KalkMatrix.Inverse(m);
        
        /// <summary>
        /// Returns the diagonal vector of a squared matrix or a diagonal matrix from the specified vector.
        /// </summary>
        /// <param name="x">A vector or matrix to return the associated diagonal for.</param>
        /// <returns>A diagonal vector of a matrix or a diagonal matrix of a vector.</returns>
        /// <example>
        /// ```kalk
        /// >>> diag(float4x4(1..16))
        /// # diag(float4x4(1..16))
        /// out = float4(1, 6, 11, 16)
        /// >>> diag(float4(1,2,3,4))
        /// # diag(float4(1, 2, 3, 4))
        /// out = float4x4(1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 4)
        ///       # col  0           1           2           3           / row
        ///       float4(1         , 0         , 0         , 0         ) # 0
        ///       float4(0         , 2         , 0         , 0         ) # 1
        ///       float4(0         , 0         , 3         , 0         ) # 2
        ///       float4(0         , 0         , 0         , 4         ) # 3
        ///
        /// ```
        /// </example>
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
        
        /// <summary>
        /// Creates a matrix of the specified element type, number of rows and columns and optional values.
        /// </summary>
        /// <param name="name">The element type of the matrix (e.g float).</param>
        /// <param name="row">The number of rows.</param>
        /// <param name="column">The number of columns.</param>
        /// <param name="arguments">The optional values (must have 1 or row x column elements).</param>
        /// <returns>A matrix of the specified row x column.</returns>
        /// <example>
        /// ```kalk
        /// >>> matrix(float,4,3,1..12)
        /// # matrix(float, 4, 3, 1..12)
        /// out = float4x3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)
        ///       # col  0           1           2           / row
        ///       float3(1         , 2         , 3         ) # 0
        ///       float3(4         , 5         , 6         ) # 1
        ///       float3(7         , 8         , 9         ) # 2
        ///       float3(10        , 11        , 12        ) # 3
        /// ```
        /// </example>
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

        /// <summary>
        /// Extract a row from the specified matrix.
        /// </summary>
        /// <param name="x">The matrix to extract a row from.</param>
        /// <param name="index">The index of the row (zero based).</param>
        /// <returns>A vector extracted from the matrix.</returns>
        /// <example>
        /// ```kalk
        /// >>> row(float4x4(1..16), 2)
        /// # row(float4x4(1..16), 2)
        /// out = float4(9, 10, 11, 12)
        /// ```
        /// </example>
        [KalkExport("row", CategoryMathVectorMatrixFunctions)]
        public KalkVector GetRow(KalkMatrix x, int index)
        {
            return x.GetRow(index);
        }

        /// <summary>
        /// Extract a column from the specified matrix.
        /// </summary>
        /// <param name="x">The matrix to extract a column from.</param>
        /// <param name="index">The index of the column (zero based).</param>
        /// <returns>A vector extracted from the matrix.</returns>
        /// <example>
        /// ```kalk
        /// >>> col(float4x4(1..16), 2)
        /// # col(float4x4(1..16), 2)
        /// out = float4(3, 7, 11, 15)
        /// ```
        /// </example>
        [KalkExport("col", CategoryMathVectorMatrixFunctions)]
        public KalkVector GetColumn(KalkMatrix x, int index)
        {
            return x.GetColumn(index);
        }
        
        /// <summary>
        /// Multiplies a vector x vector (dot product), or a vector x matrix, or a matrix x vector or a matrix x matrix.
        /// </summary>
        /// <param name="x">A left vector or a matrix.</param>
        /// <param name="y">A right vector or matrix.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <example>
        /// ```kalk
        /// >>> mul(float4(1,2,3,4), float4(5,6,7,8))
        /// # mul(float4(1, 2, 3, 4), float4(5, 6, 7, 8))
        /// out = 70
        /// >>> mul(float3(3,7,5), float3x3(2,3,-4,11,8,7,2,5,3))
        /// # mul(float3(3, 7, 5), float3x3(2, 3, -4, 11, 8, 7, 2, 5, 3))
        /// out = float3(7, 124, 56)
        /// >>> mul(float3x3(2,3,-4,11,8,7,2,5,3), float3(3,7,5))
        /// # mul(float3x3(2, 3, -4, 11, 8, 7, 2, 5, 3), float3(3, 7, 5))
        /// out = float3(93, 90, 52)
        /// >>> mul(float3x3(2,7,4,3,2,1,9,-1,2), float3x3(1,4,6,-1,-2,5,8,7,6))
        /// # mul(float3x3(2, 7, 4, 3, 2, 1, 9, -1, 2), float3x3(1, 4, 6, -1, -2, 5, 8, 7, 6))
        /// out = float3x3(68, 9, 20, 37, -16, 4, 91, 64, 51)
        ///       # col  0            1          2           / row
        ///       float3(68        ,  9        , 20        ) # 0
        ///       float3(37        , -16       , 4         ) # 1
        ///       float3(91        ,  64       , 51        ) # 2
        /// ```
        /// </example>
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