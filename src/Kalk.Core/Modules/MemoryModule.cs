using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Kalk.Core.Helpers;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Memory functions.
    /// </summary>
    public sealed partial class MemoryModule : KalkModuleWithFunctions
    {
        public const string CategoryMiscMemory = "Misc Memory Functions";

        public MemoryModule()
        {
            IsBuiltin = true;
            RegisterFunctionsAuto();
        }

        /// <summary>
        /// Allocates a `bytebuffer` of the specified size.
        /// </summary>
        /// <param name="size">Size of the bytebuffer.</param>
        /// <returns>A bytebuffer of the specified size.</returns>
        /// <example>
        /// ```kalk
        /// >>> buffer = malloc(16)
        /// # buffer = malloc(16)
        /// buffer = bytebuffer([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0])
        /// >>> buffer[0] = 5
        /// >>> buffer
        /// # buffer
        /// out = bytebuffer([5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0])
        /// ```
        /// </example>
        [KalkExport("malloc", CategoryMiscMemory)]
        public KalkNativeBuffer Malloc(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size), "Size must be >= 0");
            return new KalkNativeBuffer(size);
        }

        /// <summary>
        /// Binary cast of a value to a target type.
        /// </summary>
        /// <param name="type">The type to cast to.</param>
        /// <param name="value">The value to cast.</param>
        /// <returns>The binary cast of the input value.</returns>
        /// <remarks>The supported types are `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `rgb`, `rgba` and all vector and matrix types.</remarks>
        /// <example>
        /// ```kalk
        /// >>> bitcast(int, 1.5f)
        /// # bitcast(int, 1.5f)
        /// out = 1069547520
        /// >>> bitcast(float, out)
        /// # bitcast(float, out)
        /// out = 1.5
        /// >>> bitcast(long, 2.5)
        /// # bitcast(long, 2.5)
        /// out = 4612811918334230528
        /// >>> bitcast(double, out)
        /// # bitcast(double, out)
        /// out = 2.5
        /// >>> asbytes(float4(1..4))
        /// # asbytes(float4(1..4))
        /// out = bytebuffer([0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64])
        /// >>> bitcast(float4, out)
        /// # bitcast(float4, out)
        /// out = float4(1, 2, 3, 4)
        /// ```
        /// </example>
        [KalkExport("bitcast", CategoryMiscMemory)]
        public object Bitcast(object type, object value)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            var bytes = AsBytes(value);
            if (bytes == null) return null;

            switch (type)
            {
                case byte vbyte:
                    UnsafeHelpers.BitCast(ref vbyte, 1, bytes);
                    return vbyte;
                case sbyte vsbyte:
                    UnsafeHelpers.BitCast(ref vsbyte, 1, bytes);
                    return vsbyte;
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
                case ulong vulong:
                    UnsafeHelpers.BitCast(ref vulong, 8, bytes);
                    return vulong;
                case long vlong:
                    UnsafeHelpers.BitCast(ref vlong, 8, bytes);
                    return vlong;
                case float _:
                    int vfloat = 0;
                    UnsafeHelpers.BitCast(ref vfloat, 4, bytes);
                    return BitConverter.Int32BitsToSingle(vfloat);
                case double _:
                    long vdouble = 0;
                    UnsafeHelpers.BitCast(ref vdouble, 8, bytes);
                    return BitConverter.Int64BitsToDouble(vdouble);
                case KalkValue kalkValue:
                    var dest = (KalkValue)kalkValue.Clone(true);
                    dest.BitCastFrom(bytes.AsSpan());
                    return dest;

                default:
                    throw new ArgumentException($"The destination type `{Engine.GetTypeName(type)}` is not supported.", nameof(value));
            }
        }

        /// <summary>
        /// Binary cast the specified value to a bytebuffer.
        /// </summary>
        /// <param name="value">An input value.</param>
        /// <returns>A binary bytebuffer representing the value in binary form. The size of the buffer equals the binary size in memory of the input value.</returns>
        /// <example>
        /// ```kalk
        /// >>> asbytes(float4(1..4))
        /// # asbytes(float4(1..4))
        /// out = bytebuffer([0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64])
        /// >>> asbytes(int(0x01020304))
        /// # asbytes(int(16909060))
        /// out = bytebuffer([4, 3, 2, 1])
        /// >>> asbytes(1.5)
        /// # asbytes(1.5)
        /// out = bytebuffer([0, 0, 0, 0, 0, 0, 248, 63])
        /// >>> asbytes(2.5f)
        /// # asbytes(2.5f)
        /// out = bytebuffer([0, 0, 32, 64])
        /// ```
        /// </example>
        [KalkExport("asbytes", CategoryMiscMemory)]
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

        /// <summary>
        /// Counts the number of bits (per component) of the input value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The number of bits (per component if the input is an int vector).</returns>
        /// <example>
        /// ```kalk
        /// >>> for val in 0..7; countbits(val); end;
        /// # for val in 0..7; countbits(val); end;
        /// out = 0
        /// out = 1
        /// out = 1
        /// out = 2
        /// out = 1
        /// out = 2
        /// out = 2
        /// out = 3
        /// >>> countbits(int4(1,2,3,4))
        /// # countbits(int4(1, 2, 3, 4))
        /// out = int4(1, 1, 2, 1)
        /// >>> countbits(bytebuffer(1..16))
        /// # countbits(bytebuffer(1..16))
        /// out = 33
        /// ```
        /// </example>
        [KalkExport("countbits", CategoryMiscMemory)]
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

        /// <summary>
        /// Gets the location of the first set bit starting from the highest order bit and working downward, per component.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The location of the first set bit.</returns>
        /// <remarks>If no bits are sets, this function will return -1.</remarks>
        /// <example>
        /// ```kalk
        /// >>> firstbithigh 128
        /// # firstbithigh(128)
        /// out = 24
        /// >>> firstbithigh byte(128)
        /// # firstbithigh(byte(128))
        /// out = 0
        /// >>> firstbithigh 0
        /// # firstbithigh(0)
        /// out = -1
        /// >>> firstbithigh(int4(1, -1, 65536, 1 &lt;&lt; 20))
        /// # firstbithigh(int4(1, -1, 65536, 1 &lt;&lt; 20))
        /// out = int4(31, 0, 15, 11)
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> firstbithigh ulong(1 &lt;&lt; 63)
        /// # firstbithigh(ulong(1 &lt;&lt; 63))
        /// out = 0
        /// >>> firstbithigh long(1)
        /// # firstbithigh(long(1))
        /// out = 63
        /// >>> firstbithigh long(0)
        /// # firstbithigh(long(0))
        /// out = -1
        /// ```
        /// </test>
        [KalkExport("firstbithigh", CategoryMiscMemory)]
        public object FirstBitHigh(object value)
        {
            if (value == null) return 0;

            switch (value)
            {
                case sbyte vsbyte:
                {
                    var result = BitOperations.LeadingZeroCount((byte)(uint)vsbyte);
                    if (result >= 32) return -1;
                    return result - 24;
                }
                case byte vbyte:
                {
                    var result = BitOperations.LeadingZeroCount(vbyte);
                    if (result >= 32) return -1;
                    return result - 24;
                }
                case short vshort:
                {
                    var result = BitOperations.LeadingZeroCount((ushort)(uint)vshort);
                    if (result >= 32) return -1;
                    return result - 16;
                }
                case ushort vushort:
                {
                    var result = BitOperations.LeadingZeroCount((uint)vushort);
                    if (result >= 32) return -1;
                    return result - 16;
                }
                case int vint:
                {
                    var result = BitOperations.LeadingZeroCount((uint)vint);
                    if (result >= 32) return -1;
                    return result;
                }
                case uint vuint:
                {
                    var result = BitOperations.LeadingZeroCount((uint)vuint);
                    if (result >= 32) return -1;
                    return result;
                }
                case long vlong:
                {
                    var result = BitOperations.LeadingZeroCount((ulong)vlong);
                    if (result >= 64) return -1;
                    return result;
                }
                case ulong vulong:
                {
                    var result = BitOperations.LeadingZeroCount((ulong)vulong);
                    if (result >= 64) return -1;
                    return result;
                }
                case KalkVector vector:
                    var uintVector = new KalkVector<int>(vector.Length);
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var result = FirstBitHigh(vector.GetComponent(i));
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
                        uintMatrix.SetRow(y, (KalkVector<int>)FirstBitHigh(matrix.GetRow(y)));
                    }
                    return uintMatrix;

                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported.", nameof(value));
            }
        }

        /// <summary>
        /// Returns the location of the first set bit starting from the lowest order bit and working upward, per component.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The location of the first set bit.</returns>
        /// <remarks>If no bits are sets, this function will return -1.</remarks>
        /// <example>
        /// ```kalk
        /// >>> firstbitlow 128
        /// # firstbitlow(128)
        /// out = 7
        /// >>> firstbitlow byte(128)
        /// # firstbitlow(byte(128))
        /// out = 7
        /// >>> firstbitlow 0
        /// # firstbitlow(0)
        /// out = -1
        /// >>> firstbitlow(int4(1, -1, 65536, 1 &lt;&lt; 20))
        /// # firstbitlow(int4(1, -1, 65536, 1 &lt;&lt; 20))
        /// out = int4(0, 0, 16, 20)
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> firstbitlow ulong(1 &lt;&lt; 63)
        /// # firstbitlow(ulong(1 &lt;&lt; 63))
        /// out = 63
        /// >>> firstbitlow long(1)
        /// # firstbitlow(long(1))
        /// out = 0
        /// >>> firstbitlow long(0)
        /// # firstbitlow(long(0))
        /// out = -1
        /// ```
        /// </test>
        [KalkExport("firstbitlow", CategoryMiscMemory)]
        public object FirstBitLow(object value)
        {
            if (value == null) return 0;

            switch (value)
            {
                case sbyte vsbyte:
                {
                    var result = BitOperations.TrailingZeroCount(vsbyte);
                    if (result >= 32) return -1;
                    return result;
                }
                case byte vbyte:
                {
                    var result = BitOperations.TrailingZeroCount(vbyte);
                    if (result >= 32) return -1;
                    return result;
                }
                case short vshort:
                {
                    var result = BitOperations.TrailingZeroCount(vshort);
                    if (result >= 32) return -1;
                    return result;
                }
                case ushort vushort:
                {
                    var result = BitOperations.TrailingZeroCount(vushort);
                    if (result >= 32) return -1;
                    return result;
                }
                case int vint:
                {
                    var result = BitOperations.TrailingZeroCount(vint);
                    if (result >= 32) return -1;
                    return result;
                }
                case uint vuint:
                {
                    var result = BitOperations.TrailingZeroCount(vuint);
                    if (result >= 32) return -1;
                    return result;
                }
                case long vlong:
                {
                    var result = BitOperations.TrailingZeroCount(vlong);
                    if (result >= 64) return -1;
                    return result;
                }
                case ulong vulong:
                {
                    var result = BitOperations.TrailingZeroCount(vulong);
                    if (result >= 64) return -1;
                    return result;
                }
                case BigInteger bigint:
                    if (bigint >= 0 && bigint <= ulong.MaxValue)
                    {
                        var result = BitOperations.TrailingZeroCount((ulong)bigint);
                        if (result >= 64) return -1;
                        return result;
                    }
                    else if (bigint < 0 && bigint >= long.MinValue)
                    {
                        var result = BitOperations.TrailingZeroCount((long)bigint);
                        if (result >= 64) return -1;
                        return result;
                    }
                    // TODO: implement this case for bigint
                    goto default;
                    
                case KalkVector vector:
                    var uintVector = new KalkVector<int>(vector.Length);
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var result = FirstBitLow(vector.GetComponent(i));
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
                        uintMatrix.SetRow(y, (KalkVector<int>)FirstBitLow(matrix.GetRow(y)));
                    }
                    return uintMatrix;

                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported.", nameof(value));
            }
        }

        /// <summary>
        /// Reverses the order of the bits, per component
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The input value, with the bit order reversed</returns>
        /// <example>
        /// ```kalk
        /// >>> reversebits 128
        /// # reversebits(128)
        /// out = 16777216
        /// >>> reversebits out
        /// # reversebits(out)
        /// out = 128
        /// >>> reversebits byte(128)
        /// # reversebits(byte(128))
        /// out = 1
        /// >>> reversebits(out)
        /// # reversebits(out)
        /// out = 128
        /// >>> reversebits(int4(1,2,3,4))
        /// # reversebits(int4(1, 2, 3, 4))
        /// out = int4(-2147483648, 1073741824, -1073741824, 536870912)
        /// >>> reversebits out
        /// # reversebits(out)
        /// out = int4(1, 2, 3, 4)
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> reversebits long(1)
        /// # reversebits(long(1))
        /// out = -9223372036854775808
        /// >>> reversebits out
        /// # reversebits(out)
        /// out = 1
        /// >>> reversebits(bytebuffer([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]))
        /// # reversebits(bytebuffer([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]))
        /// out = bytebuffer([240, 112, 176, 48, 208, 80, 144, 16, 224, 96, 160, 32, 192, 64, 128])
        /// >>> reversebits out
        /// # reversebits(out)
        /// out = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])
        /// ```
        /// </test>
        [KalkExport("reversebits", CategoryMiscMemory)]
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

        /// <summary>
        /// Reinterprets a 64-bit value into a double.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input recast as a double.</returns>
        /// <example>
        /// ```kalk
        /// >>> asdouble(1.5)
        /// # asdouble(1.5)
        /// out = 1.5
        /// >>> aslong(1.5)
        /// # aslong(1.5)
        /// out = 4609434218613702656
        /// >>> asdouble(out)
        /// # asdouble(out)
        /// out = 1.5
        /// ```
        /// </example>
        [KalkExport("asdouble", CategoryMiscMemory)]
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
                case KalkNativeBuffer buffer:
                    return BitCastTo<double>(buffer);
            }

            var bigInteger = Engine.ToObject<BigInteger>(0, x);
            var value = (long) bigInteger;
            return BitConverter.Int64BitsToDouble(value);
        }

        /// <summary>
        /// Reinterprets a 32-bit value into a float.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input recast as a float.</returns>
        /// <example>
        /// ```kalk
        /// >>> asfloat(1.5f)
        /// # asfloat(1.5f)
        /// out = 1.5
        /// >>> asint(1.5f)
        /// # asint(1.5f)
        /// out = 1069547520
        /// >>> asfloat(out)
        /// # asfloat(out)
        /// out = 1.5
        /// ```
        /// </example>
        [KalkExport("asfloat", CategoryMiscMemory)]
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
                case KalkNativeBuffer buffer:
                    return BitCastTo<float>(buffer);
            }

            var bigInteger = Engine.ToObject<BigInteger>(0, x);
            var value = (long)bigInteger;
            return (float)BitConverter.Int64BitsToDouble(value);
        }

        /// <summary>
        /// Reinterprets an input value to a 64-bit long.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input recast as a 64-bit long.</returns>
        /// <example>
        /// ```kalk
        /// >>> aslong(1.5)
        /// # aslong(1.5)
        /// out = 4609434218613702656
        /// >>> asdouble(out)
        /// # asdouble(out)
        /// out = 1.5
        /// ```
        /// </example>
        [KalkExport("aslong", CategoryMiscMemory)]
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
                case KalkNativeBuffer buffer:
                    return BitCastTo<long>(buffer);
                default:
                    return (long)Engine.ToObject<BigInteger>(0, x);
            }
        }

        /// <summary>
        /// Reinterprets an input value to a 64-bit ulong.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input recast as a 64-bit ulong.</returns>
        /// <example>
        /// ```kalk
        /// >>> asulong(-1.5)
        /// # asulong(-1.5)
        /// out = 13832806255468478464
        /// >>> asdouble(out)
        /// # asdouble(out)
        /// out = -1.5
        /// ```
        /// </example>
        [KalkExport("asulong", CategoryMiscMemory)]
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
                case KalkNativeBuffer buffer:
                    return BitCastTo<ulong>(buffer);
                default:
                    return (ulong)(long)Engine.ToObject<BigInteger>(0, x);
            }
        }

        /// <summary>
        /// Reinterprets an input value into a 32-bit int.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input recast as a 32-bit int.</returns>
        /// <example>
        /// ```kalk
        /// >>> asint(1.5f)
        /// # asint(1.5f)
        /// out = 1069547520
        /// >>> asfloat(out)
        /// # asfloat(out)
        /// out = 1.5
        /// ```
        /// </example>
        [KalkExport("asint", CategoryMiscMemory)]
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
                case KalkNativeBuffer buffer:
                    return BitCastTo<int>(buffer);
                default:
                    return (int)Engine.ToObject<BigInteger>(0, x);
            }
        }

        /// <summary>
        /// Reinterprets an input value into a 32-bit uint.
        /// </summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input recast as a 32-bit uint.</returns>
        /// <example>
        /// ```kalk
        /// >>> asuint(-1.5f)
        /// # asuint(-1.5f)
        /// out = 3217031168
        /// >>> asfloat(out)
        /// # asfloat(out)
        /// out = -1.5
        /// ```
        /// </example>
        [KalkExport("asuint", CategoryMiscMemory)]
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
                case KalkNativeBuffer buffer:
                    return BitCastTo<uint>(buffer);
                default:
                    return (uint)(int)Engine.ToObject<BigInteger>(0, x);
            }
        }

        /// <summary>
        /// Creates a bytebuffer from the specified input.
        /// </summary>
        /// <param name="values">The input values.</param>
        /// <returns>A bytebuffer from the specified input.</returns>
        /// <example>
        /// ```kalk
        /// >>> bytebuffer
        /// # bytebuffer
        /// out = bytebuffer([])
        /// >>> bytebuffer(0,1,2,3,4)
        /// # bytebuffer(0, 1, 2, 3, 4)
        /// out = bytebuffer([0, 1, 2, 3, 4])
        /// >>> bytebuffer(float4(1))
        /// # bytebuffer(float4(1))
        /// out = bytebuffer([0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63])
        /// >>> bytebuffer([1,2,3,4])
        /// # bytebuffer([1,2,3,4])
        /// out = bytebuffer([1, 2, 3, 4])
        /// ```
        /// </example>
        [KalkExport("bytebuffer", CategoryMiscMemory)]
        public KalkNativeBuffer ByteBuffer(params object[] values)
        {
            if (values == null || values.Length == 0) return new KalkNativeBuffer(0);

            // If we have a single value, try to extract a buffer from it.
            if (values.Length == 1)
            {
                var element = values[0];
                if (element is KalkNativeBuffer nativeBuffer)
                {
                    return nativeBuffer;
                }

                if (element is string || element is IKalkSpannable)
                {
                    return AsBytes(element);
                }

                if (element is IEnumerable it)
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
            }

            var byteBuffer = new KalkNativeBuffer(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                byteBuffer[i] = (byte) Engine.ToObject<long>(i, values[i]);
            }

            return byteBuffer;
        }

        private static unsafe T BitCastTo<T>(KalkNativeBuffer buffer) where T : unmanaged
        {
            var sizeOfT = Unsafe.SizeOf<T>();
            T value = default;
            var maxLength = Math.Min(buffer.Count, sizeOfT);
            for (int i = 0; i < maxLength; i++)
            {
                ((byte*)(&value))[i] = buffer[i];
            }
            return value;
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