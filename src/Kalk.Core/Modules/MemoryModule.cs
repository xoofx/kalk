using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Kalk.Core.Helpers;

namespace Kalk.Core.Modules
{
    public partial class MemoryModule : KalkModuleWithFunctions
    {
        public const string CategoryMiscMemory = "Misc Memory Functions";

        public MemoryModule()
        {
            IsBuiltin = true;
            RegisterFunctionsAuto();
        }

        [KalkDoc("malloc", CategoryMiscMemory)]
        public KalkNativeBuffer Malloc(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size), "Size must be >= 0");
            return new KalkNativeBuffer(size);
        }

        [KalkDoc("bitcast", CategoryMiscMemory)]
        public object Bitcast(object type, object value)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            var bytes = AsBytes(value);
            if (bytes == null) return null;

            switch (type)
            {
                case short vshort:
                    UnsafeHelpers.BitCast(ref vshort, 2, bytes);
                    return vshort;
                case ushort vushort:
                    UnsafeHelpers.BitCast(ref vushort, 2, bytes);
                    return vushort;
                case int vint:
                    UnsafeHelpers.BitCast(ref vint, 4, bytes);
                    return vint;
                case uint vuint:
                    UnsafeHelpers.BitCast(ref vuint, 4, bytes);
                    return (long) vuint;
                case float _:
                    int vfloat = 0;
                    UnsafeHelpers.BitCast(ref vfloat, 4, bytes);
                    return BitConverter.Int32BitsToSingle(vfloat);
                case double _:
                    long vdouble = 0;
                    UnsafeHelpers.BitCast(ref vdouble, 4, bytes);
                    return BitConverter.Int64BitsToDouble(vdouble);
                case long vlong:
                    UnsafeHelpers.BitCast(ref vlong, 4, bytes);
                    return vlong;

                case KalkValue kalkValue:
                    var dest = (KalkValue)kalkValue.Clone(true);
                    dest.BitCastFrom(bytes.AsSpan());
                    return dest;

                default:
                    throw new ArgumentException($"The destination type `{Engine.GetTypeName(type)}` is not supported.", nameof(value));
            }
        }

        [KalkDoc("asbytes", CategoryMiscMemory)]
        public KalkNativeBuffer AsBytes(object value)
        {
            if (value == null) return null;

            switch (value)
            {
                case string str:
                {
                    var buffer = Encoding.UTF8.GetBytes(str);
                    return KalkNativeBuffer.AsBytes(buffer.Length, in buffer[0]);
                }
                case byte vbyte:
                    return KalkNativeBuffer.AsBytes(1, vbyte);
                case sbyte vsbyte:
                    return KalkNativeBuffer.AsBytes(1, vsbyte);
                case short vshort:
                    return KalkNativeBuffer.AsBytes(2, vshort);
                case ushort vushort:
                    return KalkNativeBuffer.AsBytes(2, vushort);
                case int vint:
                    return KalkNativeBuffer.AsBytes(4, vint);
                case uint vuint:
                    return KalkNativeBuffer.AsBytes(4, vuint);
                case long vlong:
                    return KalkNativeBuffer.AsBytes(8, vlong);
                case ulong vulong:
                    return KalkNativeBuffer.AsBytes(8, vulong);
                case float vfloat:
                {
                    var floatAsInt = BitConverter.SingleToInt32Bits(vfloat);
                    return KalkNativeBuffer.AsBytes(4, floatAsInt);
                }
                case double vdouble:
                {
                    var doubleAsLong = BitConverter.DoubleToInt64Bits(vdouble);
                    return KalkNativeBuffer.AsBytes(8, doubleAsLong);
                }
                case BigInteger bigInt:
                {
                    var array = bigInt.ToByteArray();
                    return KalkNativeBuffer.AsBytes(array.Length, in array[0]);
                }
                case IKalkSpannable spannable:
                {
                    var span = spannable.AsSpan();
                    return KalkNativeBuffer.AsBytes(span.Length, in span[0]);
                }
                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }
        
        [KalkDoc("asdouble", CategoryMiscMemory)]
        public double AsDouble(object x)
        {
            switch (x)
            {
                case long longValue:
                    return BitConverter.Int64BitsToDouble(longValue);
                case ulong ulongValue:
                    return BitConverter.Int64BitsToDouble((long)ulongValue);
                case int intValue:
                    return BitConverter.Int32BitsToSingle(intValue);
                case uint uintValue:
                    return BitConverter.Int32BitsToSingle((int)uintValue);
                case double d:
                    return d;
                case float f:
                    return f;
            }

            var bigInteger = Engine.ToObject<BigInteger>(0, x);
            var value = (long) bigInteger;
            return BitConverter.Int64BitsToDouble(value);
        }

        [KalkDoc("asfloat", CategoryMiscMemory)]
        public float AsFloat(object x)
        {
            switch (x)
            {
                case long longValue:
                    return (float)BitConverter.Int64BitsToDouble(longValue);
                case ulong ulongValue:
                    return (float)BitConverter.Int64BitsToDouble((long)ulongValue);
                case int intValue:
                    return BitConverter.Int32BitsToSingle(intValue);
                case uint uintValue:
                    return BitConverter.Int32BitsToSingle((int)uintValue);
                case double d:
                    return (float)d;
                case float f:
                    return f;
            }

            var bigInteger = Engine.ToObject<BigInteger>(0, x);
            var value = (long)bigInteger;
            return (float)BitConverter.Int64BitsToDouble(value);
        }

        [KalkDoc("aslong", CategoryMiscMemory)]
        public long AsLong(object x)
        {
            switch (x)
            {
                case long longValue:
                    return longValue;
                case ulong ulongValue:
                    return (long)ulongValue;
                case int intValue:
                    return intValue;
                case uint uintValue:
                    return uintValue;
                case double f64:
                    return BitConverter.DoubleToInt64Bits(f64);
                case float f32:
                    return BitConverter.SingleToInt32Bits(f32);
                default:
                    return (long)Engine.ToObject<BigInteger>(0, x);
            }
        }
        
        [KalkDoc("asulong", CategoryMiscMemory)]
        public ulong AsULong(object x)
        {
            switch (x)
            {
                case long longValue:
                    return (ulong)longValue;
                case ulong ulongValue:
                    return ulongValue;
                case int intValue:
                    return (ulong)intValue;
                case uint uintValue:
                    return uintValue;
                case double f64:
                    return (ulong)BitConverter.DoubleToInt64Bits(f64);
                case float f32:
                    return (ulong)BitConverter.SingleToInt32Bits(f32);
                default:
                    return (ulong)(long)Engine.ToObject<BigInteger>(0, x);
            }
        }

        [KalkDoc("asint", CategoryMiscMemory)]
        public int AsInt(object x)
        {
            switch (x)
            {
                case long longValue:
                    return (int)longValue;
                case ulong ulongValue:
                    return (int)ulongValue;
                case int intValue:
                    return intValue;
                case uint uintValue:
                    return (int)uintValue;
                case double f64:
                    return BitConverter.SingleToInt32Bits((float)f64);
                case float f32:
                    return BitConverter.SingleToInt32Bits(f32);
                default:
                    return (int)Engine.ToObject<BigInteger>(0, x);
            }
        }

        [KalkDoc("asuint", CategoryMiscMemory)]
        public uint AsUInt(object x)
        {
            switch (x)
            {
                case long longValue:
                    return (uint)longValue;
                case ulong ulongValue:
                    return (uint)ulongValue;
                case int intValue:
                    return (uint)intValue;
                case uint uintValue:
                    return uintValue;
                case double f64:
                    return (uint)BitConverter.SingleToInt32Bits((float)f64);
                case float f32:
                    return (uint)BitConverter.SingleToInt32Bits(f32);
                default:
                    return (uint)(int)Engine.ToObject<BigInteger>(0, x);
            }
        }        

        [KalkDoc("bytebuffer", CategoryMiscMemory)]
        public KalkNativeBuffer ByteBuffer(object array)
        {
            if (array == null) new KalkNativeBuffer(0);

            if (array is KalkNativeBuffer nativeBuffer)
            {
                return nativeBuffer;
            }
            
            if (array is IEnumerable it)
            {
                var buffer = new List<byte>();
                foreach (var item in it)
                {
                    var b = Engine.ToObject<byte>(0, item);
                    buffer.Add(b);
                }
                var result = new KalkNativeBuffer(buffer.Count);
                var span = result.AsSpan();
                for (int i = 0; i < buffer.Count; i++)
                {
                    span[i] = buffer[i];
                }

                return result;
            }
            
            throw new ArgumentException($"Invalid argument type {Engine.GetTypeName(array)}. Must be an array of byte or an existing bytebuffer.", nameof(array));
        }
    }
}