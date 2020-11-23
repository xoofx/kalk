using System;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public sealed partial class VectorModule : KalkModuleWithFunctions
    {
        public const string CategoryTypeConstructors = "Type Constructors";
        public const string CategoryVectorTypeConstructors = "Type Vector Constructors";
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
        /// >>> length -5
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

        /// <summary>
        /// Creates an unsigned byte value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An unsigned byte value</returns>
        /// <example>
        /// ```kalk
        /// >>> byte
        /// # byte
        /// out = 0
        /// >>> byte 0
        /// # byte(0)
        /// out = 0
        /// >>> byte 255
        /// # byte(255)
        /// out = 255
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> byte 256
        /// Unable to convert type `int` to `byte`
        /// ```
        /// </test>
        [KalkExport("byte", CategoryTypeConstructors)]
        public byte CreateByte(object value = null) => value == null ? (byte)0 : Engine.ToObject<byte>(0, value);

        /// <summary>
        /// Creates a signed-byte value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A signed-byte value</returns>
        /// <example>
        /// ```kalk
        /// >>> sbyte
        /// # sbyte
        /// out = 0
        /// >>> sbyte 0
        /// # sbyte(0)
        /// out = 0
        /// >>> sbyte 127
        /// # sbyte(127)
        /// out = 127
        /// >>> sbyte -128
        /// # sbyte(-128)
        /// out = -128
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> sbyte 128
        /// Unable to convert type `int` to `sbyte`
        /// ```
        /// </test>
        [KalkExport("sbyte", CategoryTypeConstructors)]
        public sbyte CreateSByte(object value = null) => value == null ? (sbyte)0 : Engine.ToObject<sbyte>(0, value);

        /// <summary>
        /// Creates a signed-short (16-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A signed-short (16-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> short
        /// # short
        /// out = 0
        /// >>> short 0
        /// # short(0)
        /// out = 0
        /// >>> short 32767
        /// # short(32767)
        /// out = 32767
        /// >>> short -32768
        /// # short(-32768)
        /// out = -32768
        /// >>> short 32768
        /// Unable to convert type `int` to `short`
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> short 32768
        /// Unable to convert type `int` to `short`
        /// ```
        /// </test>
        [KalkExport("short", CategoryTypeConstructors)]
        public short CreateShort(object value = null) => value == null ? (short)0 : Engine.ToObject<short>(0, value);

        /// <summary>
        /// Creates an unsigned short (16-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An unsigned short (16-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> ushort
        /// # ushort
        /// out = 0
        /// >>> ushort 0
        /// # ushort(0)
        /// out = 0
        /// >>> ushort 65535
        /// # ushort(65535)
        /// out = 65535
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> ushort 65536
        /// Unable to convert type `int` to `ushort`
        /// ```
        /// </test>
        [KalkExport("ushort", CategoryTypeConstructors)]
        public ushort CreateUShort(object value = null) => value == null ? (ushort)0 : Engine.ToObject<ushort>(0, value);

        /// <summary>
        /// Creates an unsigned int (32-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An unsigned int (32-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> uint
        /// # uint
        /// out = 0
        /// >>> uint 0
        /// # uint(0)
        /// out = 0
        /// >>> uint(1&lt;&lt;32 - 1)
        /// # uint(1 &lt;&lt; 32 - 1)
        /// out = 4294967295
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> uint 1 &lt;&lt; 32
        /// Unable to convert type `long` to `uint`
        /// ```
        /// </test>
        [KalkExport("uint", CategoryTypeConstructors)]
        public uint CreateUInt(object value = null) => value == null ? 0U : Engine.ToObject<uint>(0, value);

        /// <summary>
        /// Creates a signed-int (32-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A signed-int (32-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> int
        /// # int
        /// out = 0
        /// >>> int 0
        /// # int(0)
        /// out = 0
        /// >>> int(1 &lt;&lt; 31 - 1)
        /// # int(1 &lt;&lt; 31 - 1)
        /// out = 2147483647
        /// >>> int(-(1&lt;&lt;31))
        /// # int(-(1 &lt;&lt; 31))
        /// out = -2147483648
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> int 1 &lt;&lt; 31
        /// Unable to convert type `long` to int
        /// ```
        /// </test>
        [KalkExport("int", CategoryTypeConstructors)]
        public int CreateInt(object value = null) => value == null ? 0 : Engine.ToObject<int>(0, value);

        /// <summary>
        /// Creates an unsigned long (64-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An unsigned long (64-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> ulong
        /// # ulong
        /// out = 0
        /// >>> ulong 0
        /// # ulong(0)
        /// out = 0
        /// >>> ulong(1 &lt;&lt; 64 - 1)
        /// # ulong(1 &lt;&lt; 64 - 1)
        /// out = 18446744073709551615
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> ulong 1 &lt;&lt; 64
        /// Unable to convert type `bigint` to `ulong`
        /// ```
        /// </test>
        [KalkExport("ulong", CategoryTypeConstructors)]
        public ulong CreateULong(object value = null) => value == null ? 0UL : Engine.ToObject<ulong>(0, value);

        /// <summary>
        /// Creates a signed-long (64-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A signed-long (64-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> long
        /// # long
        /// out = 0
        /// >>> long 0
        /// # long(0)
        /// out = 0
        /// >>> long(1 &lt;&lt; 63 - 1)
        /// # long(1 &lt;&lt; 63 - 1)
        /// out = 9223372036854775807
        /// >>> long(-(1&lt;&lt;63))
        /// # long(-(1 &lt;&lt; 63))
        /// out = -9223372036854775808
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> long 1 &lt;&lt; 63
        /// Unable to convert type `bigint` to `long`
        /// ```
        /// </test>
        [KalkExport("long", CategoryTypeConstructors)]
        public long CreateLong(object value = null) => value == null ? 0L : Engine.ToObject<long>(0, value);

        /// <summary>
        /// Creates a boolean value (32-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A boolean (32-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> bool 1
        /// # bool(1)
        /// out = true
        /// >>> bool 0
        /// # bool(0)
        /// out = false
        /// >>> bool true
        /// # bool(true)
        /// out = true
        /// >>> bool false
        /// # bool(false)
        /// out = false
        /// ```
        /// </example>
        [KalkExport("bool", CategoryTypeConstructors)]
        public KalkBool CreateBool(object value = null) => value != null && Engine.ToObject<KalkBool>(0, value);

        /// <summary>
        /// Creates a float value (32-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A float (32-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> float(1)
        /// # float(1)
        /// out = 1
        /// >>> float(-1)
        /// # float(-1)
        /// out = -1
        /// >>> float(100000000000)
        /// # float(100000000000)
        /// out = 1E+11
        /// ```
        /// </example>
        [KalkExport("float", CategoryTypeConstructors)]
        public float CreateFloat(object value = null) => value == null ? 0.0f : Engine.ToObject<float>(0, value);

        /// <summary>
        /// Creates a double value (64-bit) value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A double (64-bit) value</returns>
        /// <example>
        /// ```kalk
        /// >>> double(1)
        /// # double(1)
        /// out = 1
        /// >>> double(-1)
        /// # double(-1)
        /// out = -1
        /// >>> double(100000000000)
        /// # double(100000000000)
        /// out = 100000000000
        /// >>> double(1&lt;&lt;200)
        /// # double(1 &lt;&lt; 200)
        /// out = 1.6069380442589903E+60
        /// ```
        /// </example>
        [KalkExport("double", CategoryTypeConstructors)]
        public double CreateDouble(object value = null) => value == null ? 0.0 : Engine.ToObject<double>(0, value);

        [KalkExport("vector", CategoryVectorTypeConstructors)]
        public object CreateVector(ScriptVariable name, int dimension, params object[] arguments)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (dimension <= 1) throw new ArgumentOutOfRangeException(nameof(dimension), "Invalid dimension. Expecting a value > 1.");
            switch (name.Name)
            {
                case "int":
                    switch (dimension)
                    {
                        case 2: return CreateInt2(arguments);
                        case 3: return CreateInt3(arguments);
                        case 4: return CreateInt4(arguments);
                        case 8: return CreateInt8(arguments);
                        case 16: return CreateInt16(arguments);
                    }
                    return new KalkVectorConstructor<int>(dimension).Invoke(Engine, arguments);
                case "bool":
                    switch (dimension)
                    {
                        case 2: return CreateBool2(arguments);
                        case 3: return CreateBool3(arguments);
                        case 4: return CreateBool4(arguments);
                        case 8: return CreateBool8(arguments);
                        case 16: return CreateBool16(arguments);
                    }
                    return new KalkVectorConstructor<KalkBool>(dimension).Invoke(Engine, arguments);

                case "float":
                    switch (dimension)
                    {
                        case 2: return CreateFloat2(arguments);
                        case 3: return CreateFloat3(arguments);
                        case 4: return CreateFloat4(arguments);
                        case 8: return CreateFloat8(arguments);
                        case 16: return CreateFloat16(arguments);
                    }
                    return new KalkVectorConstructor<float>(dimension).Invoke(Engine, arguments);

                case "double":
                    switch (dimension)
                    {
                        case 2: return CreateDouble2(arguments);
                        case 3: return CreateDouble3(arguments);
                        case 4: return CreateDouble4(arguments);
                        case 8: return CreateDouble8(arguments);
                    }
                    return new KalkVectorConstructor<double>(dimension).Invoke(Engine, arguments);
            }

            throw new ArgumentException($"Unsupported vector type {name.Name}. Only bool, int, float and double are supported", nameof(name));
        }


        [KalkExport("rgb", CategoryVectorTypeConstructors)]
        public KalkColorRgb CreateRgb(params object[] arguments) => (KalkColorRgb)RgbConstructor.Invoke(Engine, arguments);

        [KalkExport("rgba", CategoryVectorTypeConstructors)]
        public KalkColorRgba CreateRgba(params object[] arguments) => (KalkColorRgba)RgbaConstructor.Invoke(Engine, arguments);
    }
}