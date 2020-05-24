using System;
using System.IO;
using System.Text;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class VectorModule : KalkModuleWithFunctions
    {
        public const string CategoryTypeConstructors = "Type Constructors";
        public const string CategoryVectorTypeConstructors = "Type Vector Constructors";
        public const string CategoryMathVectorMatrixFunctions = "Math Vector/Matrix Functions";
        
        private static readonly KalkVectorConstructor<byte> Byte16Constructor = new KalkVectorConstructor<byte>(16);
        private static readonly KalkVectorConstructor<byte> Byte32Constructor = new KalkVectorConstructor<byte>(32);
        private static readonly KalkVectorConstructor<byte> Byte64Constructor = new KalkVectorConstructor<byte>(64);

        private static readonly KalkVectorConstructor<sbyte> SByte16Constructor = new KalkVectorConstructor<sbyte>(16);
        private static readonly KalkVectorConstructor<sbyte> SByte32Constructor = new KalkVectorConstructor<sbyte>(32);
        private static readonly KalkVectorConstructor<sbyte> SByte64Constructor = new KalkVectorConstructor<sbyte>(64);

        private static readonly KalkVectorConstructor<short> Short8Constructor = new KalkVectorConstructor<short>(8);
        private static readonly KalkVectorConstructor<short> Short16Constructor = new KalkVectorConstructor<short>(16);
        private static readonly KalkVectorConstructor<short> Short32Constructor = new KalkVectorConstructor<short>(32);
        
        private static readonly KalkVectorConstructor<ushort> UShort8Constructor = new KalkVectorConstructor<ushort>(8);
        private static readonly KalkVectorConstructor<ushort> UShort16Constructor = new KalkVectorConstructor<ushort>(16);
        private static readonly KalkVectorConstructor<ushort> UShort32Constructor = new KalkVectorConstructor<ushort>(32);
        
        private static readonly KalkVectorConstructor<int> Int2Constructor = new KalkVectorConstructor<int>(2);
        private static readonly KalkVectorConstructor<int> Int3Constructor = new KalkVectorConstructor<int>(3);
        private static readonly KalkVectorConstructor<int> Int4Constructor = new KalkVectorConstructor<int>(4);
        private static readonly KalkVectorConstructor<int> Int8Constructor = new KalkVectorConstructor<int>(8);
        private static readonly KalkVectorConstructor<int> Int16Constructor = new KalkVectorConstructor<int>(16);

        private static readonly KalkVectorConstructor<uint> UInt2Constructor = new KalkVectorConstructor<uint>(2);
        private static readonly KalkVectorConstructor<uint> UInt3Constructor = new KalkVectorConstructor<uint>(3);
        private static readonly KalkVectorConstructor<uint> UInt4Constructor = new KalkVectorConstructor<uint>(4);
        private static readonly KalkVectorConstructor<uint> UInt8Constructor = new KalkVectorConstructor<uint>(8);
        private static readonly KalkVectorConstructor<uint> UInt16Constructor = new KalkVectorConstructor<uint>(16);
        
        private static readonly KalkVectorConstructor<long> Long2Constructor = new KalkVectorConstructor<long>(2);
        private static readonly KalkVectorConstructor<long> Long3Constructor = new KalkVectorConstructor<long>(3);
        private static readonly KalkVectorConstructor<long> Long4Constructor = new KalkVectorConstructor<long>(4);
        private static readonly KalkVectorConstructor<long> Long8Constructor = new KalkVectorConstructor<long>(8);
                
        private static readonly KalkVectorConstructor<ulong> ULong2Constructor = new KalkVectorConstructor<ulong>(2);
        private static readonly KalkVectorConstructor<ulong> ULong3Constructor = new KalkVectorConstructor<ulong>(3);
        private static readonly KalkVectorConstructor<ulong> ULong4Constructor = new KalkVectorConstructor<ulong>(4);
        private static readonly KalkVectorConstructor<ulong> ULong8Constructor = new KalkVectorConstructor<ulong>(8);
        
        private static readonly KalkVectorConstructor<bool> Bool2Constructor = new KalkVectorConstructor<bool>(2);
        private static readonly KalkVectorConstructor<bool> Bool3Constructor = new KalkVectorConstructor<bool>(3);
        private static readonly KalkVectorConstructor<bool> Bool4Constructor = new KalkVectorConstructor<bool>(4);
        private static readonly KalkVectorConstructor<bool> Bool8Constructor = new KalkVectorConstructor<bool>(8);
        private static readonly KalkVectorConstructor<bool> Bool16Constructor = new KalkVectorConstructor<bool>(16);
        private static readonly KalkVectorConstructor<bool> Bool32Constructor = new KalkVectorConstructor<bool>(32);
        private static readonly KalkVectorConstructor<bool> Bool64Constructor = new KalkVectorConstructor<bool>(64);
        
        private static readonly KalkVectorConstructor<float> Float2Constructor = new KalkVectorConstructor<float>(2);
        private static readonly KalkVectorConstructor<float> Float3Constructor = new KalkVectorConstructor<float>(3);
        private static readonly KalkVectorConstructor<float> Float4Constructor = new KalkVectorConstructor<float>(4);
        private static readonly KalkVectorConstructor<float> Float8Constructor = new KalkVectorConstructor<float>(8);
        private static readonly KalkVectorConstructor<float> Float16Constructor = new KalkVectorConstructor<float>(16);
        
        private static readonly KalkVectorConstructor<double> Double2Constructor = new KalkVectorConstructor<double>(2);
        private static readonly KalkVectorConstructor<double> Double3Constructor = new KalkVectorConstructor<double>(3);
        private static readonly KalkVectorConstructor<double> Double4Constructor = new KalkVectorConstructor<double>(4);
        private static readonly KalkVectorConstructor<double> Double8Constructor = new KalkVectorConstructor<double>(8);
        
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
            Engine.LoadSystemFile(Path.Combine("Modules", "Vectors", "colorspaces.kalk"));
        }
        
        [KalkDoc("length", CategoryTypeConstructors)]
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

        [KalkDoc("dot", CategoryTypeConstructors)]
        public static object Dot(KalkVector x, KalkVector y) => KalkVector.Dot(x, y);

        [KalkDoc("cross", CategoryTypeConstructors)]
        public static object Cross(KalkVector x, KalkVector y) => KalkVector.Cross(x, y);

        [KalkDoc("byte", CategoryTypeConstructors)]
        public byte CreateByte(object value = null) => value == null ? (byte)0 : Engine.ToObject<byte>(0, value);
        [KalkDoc("sbyte", CategoryTypeConstructors)]
        public sbyte CreateSByte(object value = null) => value == null ? (sbyte)0 : Engine.ToObject<sbyte>(0, value);

        [KalkDoc("short", CategoryTypeConstructors)]
        public short CreateShort(object value = null) => value == null ? (short)0 : Engine.ToObject<short>(0, value);
        [KalkDoc("ushort", CategoryTypeConstructors)]
        public ushort CreateUShort(object value = null) => value == null ? (ushort)0 : Engine.ToObject<ushort>(0, value);
        
        [KalkDoc("uint", CategoryTypeConstructors)]
        public uint CreateUInt(object value = null) => value == null ? (uint)0 : Engine.ToObject<uint>(0, value);
        
        [KalkDoc("int", CategoryTypeConstructors)]
        public int CreateInt(object value = null) => value == null ? 0 : Engine.ToObject<int>(0, value);
        
        [KalkDoc("ulong", CategoryTypeConstructors)]
        public ulong CreateULong(object value = null) => value == null ? (ulong)0 : Engine.ToObject<ulong>(0, value);
        
        [KalkDoc("long", CategoryTypeConstructors)]
        public long CreateLong(object value = null) => value == null ? (long)0 : Engine.ToObject<long>(0, value);

        [KalkDoc("bool", CategoryTypeConstructors)]
        public bool CreateBool(object value = null) => value != null && Engine.ToObject<bool>(0, value);

        [KalkDoc("float", CategoryTypeConstructors)]
        public float CreateFloat(object value = null) => value == null ? 0.0f : Engine.ToObject<float>(0, value);

        [KalkDoc("double", CategoryTypeConstructors)]
        public double CreateDouble(object value = null) => value == null ? 0.0 : Engine.ToObject<double>(0, value);

        [KalkDoc("byte16", CategoryTypeConstructors)]
        public KalkVector<byte> CreateByte16(params object[] arguments) => Byte16Constructor.Invoke(Engine, arguments);
        [KalkDoc("byte32", CategoryTypeConstructors)]
        public KalkVector<byte> CreateByte32(params object[] arguments) => Byte32Constructor.Invoke(Engine, arguments);
        [KalkDoc("byte64", CategoryTypeConstructors)]
        public KalkVector<byte> CreateByte64(params object[] arguments) => Byte64Constructor.Invoke(Engine, arguments);

        [KalkDoc("sbyte16", CategoryTypeConstructors)]
        public KalkVector<sbyte> CreateSByte16(params object[] arguments) => SByte16Constructor.Invoke(Engine, arguments);
        [KalkDoc("sbyte32", CategoryTypeConstructors)]
        public KalkVector<sbyte> CreateSByte32(params object[] arguments) => SByte32Constructor.Invoke(Engine, arguments);
        [KalkDoc("sbyte64", CategoryTypeConstructors)]
        public KalkVector<sbyte> CreateSByte64(params object[] arguments) => SByte64Constructor.Invoke(Engine, arguments);

        [KalkDoc("short8", CategoryTypeConstructors)]
        public KalkVector<short> CreateShort8(params object[] arguments) => Short8Constructor.Invoke(Engine, arguments);

        [KalkDoc("short16", CategoryTypeConstructors)]
        public KalkVector<short> CreateShort16(params object[] arguments) => Short16Constructor.Invoke(Engine, arguments);

        [KalkDoc("short32", CategoryTypeConstructors)]
        public KalkVector<short> CreateShort32(params object[] arguments) => Short32Constructor.Invoke(Engine, arguments);

        [KalkDoc("ushort8", CategoryTypeConstructors)]
        public KalkVector<ushort> CreateUShort8(params object[] arguments) => UShort8Constructor.Invoke(Engine, arguments);

        [KalkDoc("ushort16", CategoryTypeConstructors)]
        public KalkVector<ushort> CreateUShort16(params object[] arguments) => UShort16Constructor.Invoke(Engine, arguments);

        [KalkDoc("ushort32", CategoryTypeConstructors)]
        public KalkVector<ushort> CreateUShort32(params object[] arguments) => UShort32Constructor.Invoke(Engine, arguments);
        
        [KalkDoc("int2", CategoryTypeConstructors)]
        public KalkVector<int> CreateInt2(params object[] arguments) => Int2Constructor.Invoke(Engine, arguments);

        [KalkDoc("int3", CategoryTypeConstructors)]
        public KalkVector<int> CreateInt3(params object[] arguments) => Int3Constructor.Invoke(Engine, arguments);

        [KalkDoc("int4", CategoryTypeConstructors)]
        public KalkVector<int> CreateInt4(params object[] arguments) => Int4Constructor.Invoke(Engine, arguments);

        [KalkDoc("int8", CategoryTypeConstructors)]
        public KalkVector<int> CreateInt8(params object[] arguments) => Int8Constructor.Invoke(Engine, arguments);

        [KalkDoc("int16", CategoryTypeConstructors)]
        public KalkVector<int> CreateInt16(params object[] arguments) => Int16Constructor.Invoke(Engine, arguments);

        
        [KalkDoc("uint2", CategoryTypeConstructors)]
        public KalkVector<uint> CreateUInt2(params object[] arguments) => UInt2Constructor.Invoke(Engine, arguments);

        [KalkDoc("uint3", CategoryTypeConstructors)]
        public KalkVector<uint> CreateUInt3(params object[] arguments) => UInt3Constructor.Invoke(Engine, arguments);

        [KalkDoc("uint4", CategoryTypeConstructors)]
        public KalkVector<uint> CreateUInt4(params object[] arguments) => UInt4Constructor.Invoke(Engine, arguments);

        [KalkDoc("uint8", CategoryTypeConstructors)]
        public KalkVector<uint> CreateUInt8(params object[] arguments) => UInt8Constructor.Invoke(Engine, arguments);

        [KalkDoc("uint16", CategoryTypeConstructors)]
        public KalkVector<uint> CreateUInt16(params object[] arguments) => UInt16Constructor.Invoke(Engine, arguments);
        
        [KalkDoc("long2", CategoryTypeConstructors)]
        public KalkVector<long> CreateLong2(params object[] arguments) => Long2Constructor.Invoke(Engine, arguments);

        [KalkDoc("long3", CategoryTypeConstructors)]
        public KalkVector<long> CreateLong3(params object[] arguments) => Long3Constructor.Invoke(Engine, arguments);

        [KalkDoc("long4", CategoryTypeConstructors)]
        public KalkVector<long> CreateLong4(params object[] arguments) => Long4Constructor.Invoke(Engine, arguments);

        [KalkDoc("long8", CategoryTypeConstructors)]
        public KalkVector<long> CreateLong8(params object[] arguments) => Long8Constructor.Invoke(Engine, arguments);        
        
        [KalkDoc("ulong2", CategoryTypeConstructors)]
        public KalkVector<ulong> CreateULong2(params object[] arguments) => ULong2Constructor.Invoke(Engine, arguments);

        [KalkDoc("ulong3", CategoryTypeConstructors)]
        public KalkVector<ulong> CreateULong3(params object[] arguments) => ULong3Constructor.Invoke(Engine, arguments);

        [KalkDoc("ulong4", CategoryTypeConstructors)]
        public KalkVector<ulong> CreateULong4(params object[] arguments) => ULong4Constructor.Invoke(Engine, arguments);

        [KalkDoc("ulong8", CategoryTypeConstructors)]
        public KalkVector<ulong> CreateULong8(params object[] arguments) => ULong8Constructor.Invoke(Engine, arguments);        
        
        [KalkDoc("bool2", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool2(params object[] arguments) => Bool2Constructor.Invoke(Engine, arguments);

        [KalkDoc("bool3", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool3(params object[] arguments) => Bool3Constructor.Invoke(Engine, arguments);

        [KalkDoc("bool4", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool4(params object[] arguments) => Bool4Constructor.Invoke(Engine, arguments);

        [KalkDoc("bool8", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool8(params object[] arguments) => Bool8Constructor.Invoke(Engine, arguments);

        [KalkDoc("bool16", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool16(params object[] arguments) => Bool16Constructor.Invoke(Engine, arguments);

        [KalkDoc("bool32", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool32(params object[] arguments) => Bool32Constructor.Invoke(Engine, arguments);

        [KalkDoc("bool64", CategoryTypeConstructors)]
        public KalkVector<bool> CreateBool64(params object[] arguments) => Bool64Constructor.Invoke(Engine, arguments);

        [KalkDoc("float2", CategoryTypeConstructors)]
        public KalkVector<float> CreateFloat2(params object[] arguments) => Float2Constructor.Invoke(Engine, arguments);

        [KalkDoc("float3", CategoryTypeConstructors)]
        public KalkVector<float> CreateFloat3(params object[] arguments) => Float3Constructor.Invoke(Engine, arguments);

        [KalkDoc("float4", CategoryTypeConstructors)]
        public KalkVector<float> CreateFloat4(params object[] arguments) => Float4Constructor.Invoke(Engine, arguments);

        [KalkDoc("float8", CategoryTypeConstructors)]
        public KalkVector<float> CreateFloat8(params object[] arguments) => Float8Constructor.Invoke(Engine, arguments);

        [KalkDoc("float16", CategoryTypeConstructors)]
        public KalkVector<float> CreateFloat16(params object[] arguments) => Float16Constructor.Invoke(Engine, arguments);

        [KalkDoc("double2", CategoryTypeConstructors)]
        public KalkVector<double> CreateDouble2(params object[] arguments) => Double2Constructor.Invoke(Engine, arguments);

        [KalkDoc("double3", CategoryTypeConstructors)]
        public KalkVector<double> CreateDouble3(params object[] arguments) => Double3Constructor.Invoke(Engine, arguments);

        [KalkDoc("double4", CategoryTypeConstructors)]
        public KalkVector<double> CreateDouble4(params object[] arguments) => Double4Constructor.Invoke(Engine, arguments);

        [KalkDoc("double8", CategoryTypeConstructors)]
        public KalkVector<double> CreateDouble8(params object[] arguments) => Double8Constructor.Invoke(Engine, arguments);

        [KalkDoc("vector", CategoryTypeConstructors)]
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
                    return new KalkVectorConstructor<bool>(dimension).Invoke(Engine, arguments);

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


        [KalkDoc("rgb", CategoryTypeConstructors)]
        public KalkColorRgb CreateRgb(params object[] arguments) => (KalkColorRgb)RgbConstructor.Invoke(Engine, arguments);

        [KalkDoc("rgba", CategoryTypeConstructors)]
        public KalkColorRgba CreateRgba(params object[] arguments) => (KalkColorRgba)RgbaConstructor.Invoke(Engine, arguments);
        
        [KalkDoc("colors", KalkEngine.CategoryMisc)]
        public object Colors()
        {
            var colors = KalkColorRgb.GetKnownColors();
            if (Engine.CurrentNode?.Parent?.GetType() != typeof(ScriptExpressionStatement))
            {
                return new ScriptArray(colors);
            }

            var builder = new StringBuilder();
            int count = 0;
            const int PerColumn = 2;
            foreach (var knownColor in colors)
            {
                var colorName = knownColor.ToString("aligned", Engine);
                builder.Append(colorName);
                count++;

                if (count == PerColumn)
                {
                    Engine.WriteHighlightLine(builder.ToString());
                    builder.Clear();
                    count = 0;
                }
                else
                {
                    builder.Append(" ");
                }
            }

            if (builder.Length > 0)
            {
                Engine.WriteHighlightLine(builder.ToString());
                builder.Clear();
            }

            return null;
        }
    }
}