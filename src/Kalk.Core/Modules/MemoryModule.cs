using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CsvHelper.Configuration;
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

        [KalkDoc("countbits", CategoryMiscMemory)]
        public object CountBits(object value)
        {
            if (value == null) return 0;

            switch (value)
            {
                case byte vbyte:
                    return BitOperations.PopCount(vbyte);
                case sbyte vsbyte:
                    return BitOperations.PopCount((uint)vsbyte);
                case short vshort:
                    return BitOperations.PopCount((uint)vshort);
                case ushort vushort:
                    return BitOperations.PopCount((uint)vushort);
                case int vint:
                    return BitOperations.PopCount((uint)vint);
                case uint vuint:
                    return BitOperations.PopCount((uint)vuint);
                case long vlong:
                    return BitOperations.PopCount((ulong)vlong);
                case ulong vulong:
                    return BitOperations.PopCount((ulong)vulong);
                case BigInteger bigInt:
                {
                    // TODO: not optimized, should use 64 bits
                    var array = bigInt.ToByteArray();
                    int count = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        count += BitOperations.PopCount(array[i]);
                    }
                    return count;
                }
                case KalkVector vector:
                    var uintVector = new KalkVector<int>(vector.Length);
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var result = CountBits(vector.GetComponent(i));
                        if (result is int intv)
                        {
                            uintVector[i] = (int)intv;
                        }
                        else 
                        {
                            uintVector[i] = (int)(long)result;
                        }
                    }
                    return uintVector;

                case KalkNativeBuffer nativeBuffer:
                {
                    var span = nativeBuffer.AsSpan();
                    int count = 0;
                    for (int i = 0; i < span.Length; i++)
                    {
                        count += BitOperations.PopCount(span[i]);
                    }
                    return count;
                }

                case KalkMatrix matrix:
                    var uintMatrix = new KalkMatrix<int>(matrix.RowCount, matrix.ColumnCount);
                    for (int y = 0; y < matrix.RowCount; y++)
                    {
                        uintMatrix.SetRow(y, (KalkVector<int>)CountBits(matrix.GetRow(y)));
                    }
                    return uintMatrix;

                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported.", nameof(value));
            }
        }

        [KalkDoc("firstbithigh", CategoryMiscMemory)]
        public object LeadingZeroCount(object value)
        {
            if (value == null) return 0;

            switch (value)
            {
                case byte vbyte:
                    return BitOperations.LeadingZeroCount(vbyte);
                case sbyte vsbyte:
                    return BitOperations.LeadingZeroCount((uint)vsbyte);
                case short vshort:
                    return BitOperations.LeadingZeroCount((uint)vshort);
                case ushort vushort:
                    return BitOperations.LeadingZeroCount((uint)vushort);
                case int vint:
                    return BitOperations.LeadingZeroCount((uint)vint);
                case uint vuint:
                    return BitOperations.LeadingZeroCount((uint)vuint);
                case long vlong:
                    return BitOperations.LeadingZeroCount((ulong)vlong);
                case ulong vulong:
                    return BitOperations.LeadingZeroCount((ulong)vulong);

                case KalkVector vector:
                    var uintVector = new KalkVector<int>(vector.Length);
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var result = LeadingZeroCount(vector.GetComponent(i));
                        if (result is int intv)
                        {
                            uintVector[i] = (int)intv;
                        }
                        else
                        {
                            uintVector[i] = (int)(long)result;
                        }
                    }
                    return uintVector;

                case KalkMatrix matrix:
                    var uintMatrix = new KalkMatrix<int>(matrix.RowCount, matrix.ColumnCount);
                    for (int y = 0; y < matrix.RowCount; y++)
                    {
                        uintMatrix.SetRow(y, (KalkVector<int>)LeadingZeroCount(matrix.GetRow(y)));
                    }
                    return uintMatrix;

                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported.", nameof(value));
            }
        }

        [KalkDoc("firstbitlow", CategoryMiscMemory)]
        public object TrailingZeroCount(object value)
        {
            if (value == null) return 0;

            switch (value)
            {
                case byte vbyte:
                    return BitOperations.TrailingZeroCount(vbyte);
                case sbyte vsbyte:
                    return BitOperations.TrailingZeroCount((uint)vsbyte);
                case short vshort:
                    return BitOperations.TrailingZeroCount((uint)vshort);
                case ushort vushort:
                    return BitOperations.TrailingZeroCount((uint)vushort);
                case int vint:
                    return BitOperations.TrailingZeroCount((uint)vint);
                case uint vuint:
                    return BitOperations.TrailingZeroCount((uint)vuint);
                case long vlong:
                    return BitOperations.TrailingZeroCount((ulong)vlong);
                case ulong vulong:
                    return BitOperations.TrailingZeroCount((ulong)vulong);

                case BigInteger bigint:
                    if (bigint >= 0 && bigint <= ulong.MaxValue)
                    {
                        
                        return BitOperations.TrailingZeroCount((ulong)bigint);
                    }
                    goto default;
                    
                case KalkVector vector:
                    var uintVector = new KalkVector<int>(vector.Length);
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var result = TrailingZeroCount(vector.GetComponent(i));
                        if (result is int intv)
                        {
                            uintVector[i] = (int)intv;
                        }
                        else
                        {
                            uintVector[i] = (int)(long)result;
                        }
                    }
                    return uintVector;

                case KalkMatrix matrix:
                    var uintMatrix = new KalkMatrix<int>(matrix.RowCount, matrix.ColumnCount);
                    for (int y = 0; y < matrix.RowCount; y++)
                    {
                        uintMatrix.SetRow(y, (KalkVector<int>)TrailingZeroCount(matrix.GetRow(y)));
                    }
                    return uintMatrix;

                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported.", nameof(value));
            }
        }

        [KalkDoc("reversebits", CategoryMiscMemory)]
        public object ReverseBits(object value)
        {
            if (value == null) return 0;

            switch (value)
            {
                case byte vbyte:
                    return ReverseBytes[vbyte];
                case sbyte vsbyte:
                    return ReverseBytes[(byte)vsbyte];
                case short vshort:
                    return (short) ((ReverseBytes[(byte) vshort] << 8) | ReverseBytes[(byte) (vshort >> 8)]);
                case ushort vushort:
                    return (short) ((ReverseBytes[(byte) vushort] << 8) | ReverseBytes[(byte) (vushort >> 8)]);
                case int vint:
                    return (ReverseBytes[(byte) vint] << 24) |
                           (ReverseBytes[(byte) (vint >> 8)] << 16) |
                           (ReverseBytes[(byte) (vint >> 16)] << 8) |
                           ReverseBytes[(byte) (vint >> 24)];
                case uint vuint:
                    return (ReverseBytes[(byte)vuint] << 24) |
                           (ReverseBytes[(byte)(vuint >> 8)] << 16) |
                           (ReverseBytes[(byte)(vuint >> 16)] << 8) |
                           ReverseBytes[(byte)(vuint >> 24)];
                case long vlong:
                    return ((long) ReverseBytes[(byte) vlong] << 56) |
                           ((long) ReverseBytes[(byte) (vlong >> 8)] << 48) |
                           ((long) ReverseBytes[(byte) (vlong >> 16)] << 40) |
                           ((long) ReverseBytes[(byte) (vlong >> 24)] << 32) |
                           ((long) ReverseBytes[(byte) (vlong >> 32)] << 24) |
                           ((long) ReverseBytes[(byte) (vlong >> 40)] << 16) |
                           ((long) ReverseBytes[(byte) (vlong >> 48)] << 8) |
                           (long) ReverseBytes[(byte) (vlong >> 56)];
                case ulong vulong:
                    return ((ulong)ReverseBytes[(byte)vulong] << 56) |
                           ((ulong)ReverseBytes[(byte)(vulong >> 8)] << 48) |
                           ((ulong)ReverseBytes[(byte)(vulong >> 16)] << 40) |
                           ((ulong)ReverseBytes[(byte)(vulong >> 24)] << 32) |
                           ((ulong)ReverseBytes[(byte)(vulong >> 32)] << 24) |
                           ((ulong)ReverseBytes[(byte)(vulong >> 40)] << 16) |
                           ((ulong)ReverseBytes[(byte)(vulong >> 48)] << 8) |
                           (ulong)ReverseBytes[(byte)(vulong >> 56)];
                case BigInteger bigInt:
                {
                    var array = bigInt.ToByteArray();
                    int mid = array.Length / 2;
                    for (int i = 0; i < mid; i++)
                    {
                        var highIndex = array.Length - i - 1;
                        var high = ReverseBytes[array[highIndex]];
                        var low = ReverseBytes[array[i]];
                        array[i] = high;
                        array[highIndex] = low;
                    }

                    if ((array.Length & 1) != 0)
                    {
                        array[mid] = ReverseBytes[array[mid]];
                    }
                    return new BigInteger(array);
                }
                case KalkVector vector:
                    var outVector = vector.Clone();
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var result = ReverseBits(vector.GetComponent(i));
                        outVector.SetComponent(i, result);
                    }
                    return outVector;

                case KalkNativeBuffer nativeBuffer:
                {
                    var buffer = new KalkNativeBuffer(nativeBuffer.Count);
                    int mid = nativeBuffer.Count / 2;
                    for (int i = 0; i < mid; i++)
                    {
                        var highIndex = nativeBuffer.Count - i - 1;
                        var high = ReverseBytes[nativeBuffer[highIndex]];
                        var low = ReverseBytes[nativeBuffer[i]];
                        buffer[i] = high;
                        buffer[highIndex] = low;
                    }

                    if ((buffer.Count & 1) != 0)
                    {
                        buffer[mid] = ReverseBytes[nativeBuffer[mid]];
                    }

                    return buffer;
                }

                case KalkMatrix matrix:
                    var uintMatrix = new KalkMatrix<int>(matrix.RowCount, matrix.ColumnCount);
                    for (int y = 0; y < matrix.RowCount; y++)
                    {
                        uintMatrix.SetRow(y, (KalkVector<int>)ReverseBits(matrix.GetRow(y)));
                    }
                    return uintMatrix;

                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported.", nameof(value));
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

        private static readonly byte[] ReverseBytes = new byte[256]
        {
            0x00, 0x80, 0x40, 0xC0, 0x20, 0xA0, 0x60, 0xE0, 0x10, 0x90, 0x50, 0xD0, 0x30, 0xB0, 0x70, 0xF0,
            0x08, 0x88, 0x48, 0xC8, 0x28, 0xA8, 0x68, 0xE8, 0x18, 0x98, 0x58, 0xD8, 0x38, 0xB8, 0x78, 0xF8,
            0x04, 0x84, 0x44, 0xC4, 0x24, 0xA4, 0x64, 0xE4, 0x14, 0x94, 0x54, 0xD4, 0x34, 0xB4, 0x74, 0xF4,
            0x0C, 0x8C, 0x4C, 0xCC, 0x2C, 0xAC, 0x6C, 0xEC, 0x1C, 0x9C, 0x5C, 0xDC, 0x3C, 0xBC, 0x7C, 0xFC,
            0x02, 0x82, 0x42, 0xC2, 0x22, 0xA2, 0x62, 0xE2, 0x12, 0x92, 0x52, 0xD2, 0x32, 0xB2, 0x72, 0xF2,
            0x0A, 0x8A, 0x4A, 0xCA, 0x2A, 0xAA, 0x6A, 0xEA, 0x1A, 0x9A, 0x5A, 0xDA, 0x3A, 0xBA, 0x7A, 0xFA,
            0x06, 0x86, 0x46, 0xC6, 0x26, 0xA6, 0x66, 0xE6, 0x16, 0x96, 0x56, 0xD6, 0x36, 0xB6, 0x76, 0xF6,
            0x0E, 0x8E, 0x4E, 0xCE, 0x2E, 0xAE, 0x6E, 0xEE, 0x1E, 0x9E, 0x5E, 0xDE, 0x3E, 0xBE, 0x7E, 0xFE,
            0x01, 0x81, 0x41, 0xC1, 0x21, 0xA1, 0x61, 0xE1, 0x11, 0x91, 0x51, 0xD1, 0x31, 0xB1, 0x71, 0xF1,
            0x09, 0x89, 0x49, 0xC9, 0x29, 0xA9, 0x69, 0xE9, 0x19, 0x99, 0x59, 0xD9, 0x39, 0xB9, 0x79, 0xF9,
            0x05, 0x85, 0x45, 0xC5, 0x25, 0xA5, 0x65, 0xE5, 0x15, 0x95, 0x55, 0xD5, 0x35, 0xB5, 0x75, 0xF5,
            0x0D, 0x8D, 0x4D, 0xCD, 0x2D, 0xAD, 0x6D, 0xED, 0x1D, 0x9D, 0x5D, 0xDD, 0x3D, 0xBD, 0x7D, 0xFD,
            0x03, 0x83, 0x43, 0xC3, 0x23, 0xA3, 0x63, 0xE3, 0x13, 0x93, 0x53, 0xD3, 0x33, 0xB3, 0x73, 0xF3,
            0x0B, 0x8B, 0x4B, 0xCB, 0x2B, 0xAB, 0x6B, 0xEB, 0x1B, 0x9B, 0x5B, 0xDB, 0x3B, 0xBB, 0x7B, 0xFB,
            0x07, 0x87, 0x47, 0xC7, 0x27, 0xA7, 0x67, 0xE7, 0x17, 0x97, 0x57, 0xD7, 0x37, 0xB7, 0x77, 0xF7,
            0x0F, 0x8F, 0x4F, 0xCF, 0x2F, 0xAF, 0x6F, 0xEF, 0x1F, 0x9F, 0x5F, 0xDF, 0x3F, 0xBF, 0x7F, 0xFF
        };
    }
}