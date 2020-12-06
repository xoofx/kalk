using System;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public sealed partial class VectorModule : KalkModuleWithFunctions
    {
        public const string CategoryMathVectorMatrixFunctions = "Math Vector/Matrix Functions";
        private static readonly KalkColorRgbConstructor RgbConstructor = new KalkColorRgbConstructor();
        private static readonly KalkColorRgbaConstructor RgbaConstructor = new KalkColorRgbaConstructor();
        private MathModule _mathModule;

        public VectorModule() : base("Vectors")
        {
            IsBuiltin = true;
            RegisterFunctionsAuto();
        }

        protected override void Initialize()
        {
            _mathModule = Engine.GetOrCreateModule<MathModule>();
            //Engine.LoadSystemFile(Path.Combine("Modules", "Vectors", "colorspaces.kalk"));
        }

        /// <summary>
        /// Returns the length of the specified floating-point vector.
        /// </summary>
        /// <param name="x">The specified floating-point vector.</param>
        /// <returns>A floating-point scalar that represents the length of the x parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> length float2(1, 2)
        /// # length(float2(1, 2))
        /// out = 2.23606797749979
        /// >>> length(-5)
        /// # length(-5)
        /// out = 5
        /// ```
        /// </example>
        [KalkExport("length", CategoryMathVectorMatrixFunctions)]
        public object Length(object x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (_mathModule == null) throw new InvalidOperationException($"The module {Name} is not initialized.");
            if (x is KalkVector v)
            {
                return _mathModule.Sqrt(new KalkDoubleValue(KalkVector.Dot(v, v)));
            }
            return _mathModule.Abs(new KalkCompositeValue(x));
        }

        /// <summary>
        /// Normalizes the specified floating-point vector according to x / length(x).
        /// </summary>
        /// <param name="x">he specified floating-point vector.</param>
        /// <returns>The normalized x parameter. If the length of the x parameter is 0, the result is indefinite.</returns>
        /// <example>
        /// ```kalk
        /// >>> normalize float2(1,2)
        /// # normalize(float2(1, 2))
        /// out = float2(0.4472136, 0.8944272)
        /// ```
        /// </example>
        [KalkExport("normalize", CategoryMathVectorMatrixFunctions)]
        public object Normalize(object x)
        {
            return ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.Divide, x, Length(x));
        }

        /// <summary>
        /// Returns the dot product of two vectors.
        /// </summary>
        /// <param name="x">The first vector.</param>
        /// <param name="y">The second vector.</param>
        /// <returns>The dot product of the x parameter and the y parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> dot(float3(1,2,3), float3(4,5,6))
        /// # dot(float3(1, 2, 3), float3(4, 5, 6))
        /// out = 32
        /// >>> dot(float3(1,2,3), 4)
        /// # dot(float3(1, 2, 3), 4)
        /// out = 24
        /// >>> dot(4, float3(1,2,3))
        /// # dot(4, float3(1, 2, 3))
        /// out = 24
        /// >>> dot(5,6)
        /// # dot(5, 6)
        /// out = 30
        /// ```
        /// </example>
        [KalkExport("dot", CategoryMathVectorMatrixFunctions)]
        public object Dot(object x, object y)
        {
            if (x is KalkVector vx)
            {
                if (y is KalkVector vy)
                {
                    return KalkVector.Dot(vx, vy);
                }
                return KalkVector.Dot(vx, vx.FromValue(Engine.ToObject(1, y, vx.ElementType)));
            }
            else if (y is KalkVector vy)
            {
                return KalkVector.Dot(vy.FromValue(Engine.ToObject(1, x, vy.ElementType)), vy);
            }

            return ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.Multiply, x, y);
        }

        /// <summary>
        /// Returns the cross product of two floating-point, 3D vectors.
        /// </summary>
        /// <param name="x">The first floating-point, 3D vector.</param>
        /// <param name="y">The second floating-point, 3D vector.</param>
        /// <returns>The cross product of the x parameter and the y parameter.</returns>
        /// <example>
        /// ```kalk
        /// >>> cross(float3(1,2,3), float3(4,5,6))
        /// # cross(float3(1, 2, 3), float3(4, 5, 6))
        /// out = float3(-3, 6, -3)
        /// >>> cross(float3(1,0,0), float3(0,1,0))
        /// # cross(float3(1, 0, 0), float3(0, 1, 0))
        /// out = float3(0, 0, 1)
        /// >>> cross(float3(0,0,1), float3(0,1,0))
        /// # cross(float3(0, 0, 1), float3(0, 1, 0))
        /// out = float3(-1, 0, 0)
        /// ```
        /// </example>
        [KalkExport("cross", CategoryMathVectorMatrixFunctions)]
        public object Cross(KalkVector x, KalkVector y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            if (x.Length != 3 || (x.ElementType != typeof(float) && x.ElementType != typeof(double))) throw new ArgumentOutOfRangeException(nameof(x), "Expecting a float3 or double3 vector.");
            if (y.Length != 3 || (y.ElementType != typeof(float) && y.ElementType != typeof(double))) throw new ArgumentOutOfRangeException(nameof(y), "Expecting a float3 or double3 vector.");
            return KalkVector.Cross(x, y);
        }
    }
}