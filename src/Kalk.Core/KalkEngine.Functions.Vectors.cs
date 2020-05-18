using System;
using System.Collections.Generic;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public const string CategoryTypeConstructors = "Type Constructors";
        public const string CategoryVectorTypeConstructors = "Type Vector Constructors";
        public const string CategoryMathVectorMatrixFunctions = "Math Vector/Matrix Functions";
        private static readonly KalkVectorConstructor<int> Int2Constructor = new KalkVectorConstructor<int>(2);
        private static readonly KalkVectorConstructor<int> Int3Constructor = new KalkVectorConstructor<int>(3);
        private static readonly KalkVectorConstructor<int> Int4Constructor = new KalkVectorConstructor<int>(4);
        private static readonly KalkVectorConstructor<int> Int8Constructor = new KalkVectorConstructor<int>(8);
        private static readonly KalkVectorConstructor<int> Int16Constructor = new KalkVectorConstructor<int>(16);
        private static readonly KalkVectorConstructor<bool> Bool2Constructor = new KalkVectorConstructor<bool>(2);
        private static readonly KalkVectorConstructor<bool> Bool3Constructor = new KalkVectorConstructor<bool>(3);
        private static readonly KalkVectorConstructor<bool> Bool4Constructor = new KalkVectorConstructor<bool>(4);
        private static readonly KalkVectorConstructor<bool> Bool8Constructor = new KalkVectorConstructor<bool>(8);
        private static readonly KalkVectorConstructor<bool> Bool16Constructor = new KalkVectorConstructor<bool>(16);
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

        private void RegisterVectors()
        {
            RegisterFunction("int", CreateInt, CategoryTypeConstructors);
            RegisterFunction("int2", CreateInt2, CategoryVectorTypeConstructors);
            RegisterFunction("int3", CreateInt3, CategoryVectorTypeConstructors);
            RegisterFunction("int4", CreateInt4, CategoryVectorTypeConstructors);
            RegisterFunction("int8", CreateInt8, CategoryVectorTypeConstructors);
            RegisterFunction("int16", CreateInt16, CategoryVectorTypeConstructors);

            RegisterFunction("bool",   CreateBool, CategoryTypeConstructors);
            RegisterFunction("bool2",  CreateBool2, CategoryVectorTypeConstructors);
            RegisterFunction("bool3",  CreateBool3, CategoryVectorTypeConstructors);
            RegisterFunction("bool4",  CreateBool4, CategoryVectorTypeConstructors);
            RegisterFunction("bool8",  CreateBool8, CategoryVectorTypeConstructors);
            RegisterFunction("bool16", CreateBool16, CategoryVectorTypeConstructors);

            RegisterFunction("float",   CreateFloat, CategoryTypeConstructors);
            RegisterFunction("float2",  CreateFloat2, CategoryVectorTypeConstructors);
            RegisterFunction("float3",  CreateFloat3, CategoryVectorTypeConstructors);
            RegisterFunction("float4",  CreateFloat4, CategoryVectorTypeConstructors);
            RegisterFunction("float8",  CreateFloat8, CategoryVectorTypeConstructors);
            RegisterFunction("float16", CreateFloat16, CategoryVectorTypeConstructors);

            RegisterFunction("double",  (Func<object, double>)CreateDouble, CategoryTypeConstructors);
            RegisterFunction("double2", CreateDouble2, CategoryVectorTypeConstructors);
            RegisterFunction("double3", CreateDouble3, CategoryVectorTypeConstructors);
            RegisterFunction("double4", CreateDouble4, CategoryVectorTypeConstructors);
            RegisterFunction("double8", CreateDouble8, CategoryVectorTypeConstructors);

            RegisterFunction("rgb", CreateRgb, CategoryVectorTypeConstructors);
            RegisterFunction("rgba", CreateRgba, CategoryVectorTypeConstructors);

            RegisterFunction("vector", CreateVector, CategoryVectorTypeConstructors);

            RegisterFunction("dot", KalkVector.Dot, CategoryMathVectorMatrixFunctions);
            RegisterFunction("cross", KalkVector.Cross, CategoryMathVectorMatrixFunctions);
            RegisterFunction("length", Length, CategoryMathVectorMatrixFunctions);
        }

        [KalkDoc("length")]
        public object Length(object x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (x is KalkVector v)
            {
                return Sqrt(new KalkDoubleValue(KalkVector.Dot(v, v)));
            }
            return Abs(new KalkCompositeValue(x));
        }

        [KalkDoc("int")]
        public int CreateInt(object value = null) => value == null ? 0 : ToObject<int>(0, value);

        [KalkDoc("bool")]
        public bool CreateBool(object value = null) => value != null && ToObject<bool>(0, value);

        [KalkDoc("float")]
        public float CreateFloat(object value = null) => value == null ? 0.0f : ToObject<float>(0, value);

        [KalkDoc("double")]
        public double CreateDouble(object value = null) => value == null ? 0.0 : ToObject<double>(0, value);

        [KalkDoc("int2")]
        public KalkVector<int> CreateInt2(params object[] arguments) => Int2Constructor.Invoke(this, arguments);

        [KalkDoc("int3")]
        public KalkVector<int> CreateInt3(params object[] arguments) => Int3Constructor.Invoke(this, arguments);

        [KalkDoc("int4")]
        public KalkVector<int> CreateInt4(params object[] arguments) => Int4Constructor.Invoke(this, arguments);

        [KalkDoc("int8")]
        public KalkVector<int> CreateInt8(params object[] arguments) => Int8Constructor.Invoke(this, arguments);
        
        [KalkDoc("int16")]
        public KalkVector<int> CreateInt16(params object[] arguments) => Int16Constructor.Invoke(this, arguments);

        [KalkDoc("bool2")]
        public KalkVector<bool> CreateBool2(params object[] arguments) => Bool2Constructor.Invoke(this, arguments);

        [KalkDoc("bool3")]
        public KalkVector<bool> CreateBool3(params object[] arguments) => Bool3Constructor.Invoke(this, arguments);

        [KalkDoc("bool4")]
        public KalkVector<bool> CreateBool4(params object[] arguments) => Bool4Constructor.Invoke(this, arguments);

        [KalkDoc("bool8")]
        public KalkVector<bool> CreateBool8(params object[] arguments) => Bool8Constructor.Invoke(this, arguments);

        [KalkDoc("bool16")]
        public KalkVector<bool> CreateBool16(params object[] arguments) => Bool16Constructor.Invoke(this, arguments);

        [KalkDoc("float2")]
        public KalkVector<float> CreateFloat2(params object[] arguments) => Float2Constructor.Invoke(this, arguments);

        [KalkDoc("float3")]
        public KalkVector<float> CreateFloat3(params object[] arguments) => Float3Constructor.Invoke(this, arguments);

        [KalkDoc("float4")]
        public KalkVector<float> CreateFloat4(params object[] arguments) => Float4Constructor.Invoke(this, arguments);

        [KalkDoc("float8")]
        public KalkVector<float> CreateFloat8(params object[] arguments) => Float8Constructor.Invoke(this, arguments);

        [KalkDoc("float16")]
        public KalkVector<float> CreateFloat16(params object[] arguments) => Float16Constructor.Invoke(this, arguments);

        [KalkDoc("double2")]
        public KalkVector<double> CreateDouble2(params object[] arguments) => Double2Constructor.Invoke(this, arguments);
        
        [KalkDoc("double3")]
        public KalkVector<double> CreateDouble3(params object[] arguments) => Double3Constructor.Invoke(this, arguments);

        [KalkDoc("double4")]
        public KalkVector<double> CreateDouble4(params object[] arguments) => Double4Constructor.Invoke(this, arguments);

        [KalkDoc("double8")]
        public KalkVector<double> CreateDouble8(params object[] arguments) => Double8Constructor.Invoke(this, arguments);

        [KalkDoc("vector")]
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
                    return new KalkVectorConstructor<int>(dimension).Invoke(this, arguments);
                case "bool":
                    switch (dimension)
                    {
                        case 2: return CreateBool2(arguments);
                        case 3: return CreateBool3(arguments);
                        case 4: return CreateBool4(arguments);
                        case 8: return CreateBool8(arguments);
                        case 16: return CreateBool16(arguments);
                    }
                    return new KalkVectorConstructor<bool>(dimension).Invoke(this, arguments);

                case "float":
                    switch (dimension)
                    {
                        case 2: return CreateFloat2(arguments);
                        case 3: return CreateFloat3(arguments);
                        case 4: return CreateFloat4(arguments);
                        case 8: return CreateFloat8(arguments);
                        case 16: return CreateFloat16(arguments);
                    }
                    return new KalkVectorConstructor<float>(dimension).Invoke(this, arguments);

                case "double":
                    switch (dimension)
                    {
                        case 2: return CreateDouble2(arguments);
                        case 3: return CreateDouble3(arguments);
                        case 4: return CreateDouble4(arguments);
                        case 8: return CreateDouble8(arguments);
                    }
                    return new KalkVectorConstructor<double>(dimension).Invoke(this, arguments);
            }

            throw new ArgumentException($"Unsupported vector type {name.Name}. Only bool, int, float and double are supported", nameof(name));
        }


        [KalkDoc("rgb")]
        public KalkColorRgb CreateRgb(params object[] arguments) => (KalkColorRgb)RgbConstructor.Invoke(this, arguments);

        [KalkDoc("rgba")]
        public KalkColorRgba CreateRgba(params object[] arguments) => (KalkColorRgba)RgbaConstructor.Invoke(this, arguments);
    }
}