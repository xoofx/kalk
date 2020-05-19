using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Consolus;
using Kalk.Core.Helpers;
using Scriban;
using Scriban.Functions;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private const string CategoryMisc = "Misc Functions";

        private void RegisterMiscFunctions()
        {
            RegisterVariable("ascii", AsciiTable, CategoryMisc);
            RegisterFunction("keys", DelegateCustomFunction.CreateFunc<object, IEnumerable>(Keys), CategoryMisc);
            RegisterFunction("values", DelegateCustomFunction.CreateFunc<object, IEnumerable>(Values), CategoryMisc);
            RegisterFunction("guid", DelegateCustomFunction.CreateFunc(Guid), CategoryMisc);
            RegisterFunction("size", DelegateCustomFunction.CreateFunc<object, int>(Size), CategoryMisc);
            RegisterFunction("hex", DelegateCustomFunction.CreateFunc<object, string, bool, object>(Hexadecimal), CategoryMisc);
            RegisterFunction("asbytes", DelegateCustomFunction.CreateFunc<object, object>(AsBytes), CategoryMisc);
            RegisterFunction("utf8", DelegateCustomFunction.CreateFunc<object, object>(GetUtf8), CategoryMisc);
            RegisterFunction("utf16", DelegateCustomFunction.CreateFunc<object, object>(GetUtf16), CategoryMisc);
            RegisterFunction("utf32", DelegateCustomFunction.CreateFunc<object, object>(GetUtf32), CategoryMisc);
            RegisterFunction("bitcast", DelegateCustomFunction.CreateFunc<object , object, object>(Bitcast), CategoryMisc);
            RegisterFunction("replace", DelegateCustomFunction.CreateFunc<object, object, object, object>(Replace), CategoryMisc);
            RegisterFunction("contains", DelegateCustomFunction.CreateFunc<object, object, bool>(Contains), CategoryMisc);
            RegisterFunction("insert_at", DelegateCustomFunction.CreateFunc<object, int, object, object>(InsertAt), CategoryMisc);
            RegisterFunction("remove_at", DelegateCustomFunction.CreateFunc<object, int, object>(RemoveAt), CategoryMisc);
        }

        /// <summary>
        /// Returns the ascii table or print
        /// </summary>
        [KalkDoc("ascii")]
        public KalkAsciiTable AsciiTable { get; }
        
        [KalkDoc("keys")]
        public IEnumerable Keys(object obj)
        {
            return ObjectFunctions.Keys(this, obj);
        }

        [KalkDoc("guid")]
        public string Guid()
        {
            return System.Guid.NewGuid().ToString();
        }

        [KalkDoc("size")]
        public int Size(object value)
        {
            return ObjectFunctions.Size(value);
        }

        [KalkDoc("values")]
        public IEnumerable Values(object obj)
        {
            switch (obj)
            {
                case IDictionary<string, object> dict:
                    return ObjectFunctions.Values(dict);
                case IEnumerable list:
                    return new ScriptArray(list);
                default:
                    return new ScriptArray() {obj};
            }
        }
        
        [KalkDoc("hex")]
        public object Hexadecimal(object value, string separator = " ", bool prefix = false)
        {
            return Hexadecimal(value, separator, prefix, false);
        }

        [KalkDoc("utf8")]
        public object GetUtf8(object value)
        {
            switch (value)
            {
                case string str:
                {
                    var buffer = Encoding.UTF8.GetBytes(str);
                    return AsBytes(buffer.Length, in buffer[0]);
                }
                case IEnumerable it:
                {
                    var bytes = new MemoryStream();
                    foreach (var b in it)
                    {
                        bytes.WriteByte(ToObject<byte>(0, b));
                    }
                    return Encoding.UTF8.GetString(bytes.GetBuffer(), 0, (int) bytes.Length);
                }
                default:
                    throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }


        [KalkDoc("utf16")]
        public object GetUtf16(object value)
        {
            switch (value)
            {
                case string str:
                {
                    unsafe
                    {
                        fixed (void* pBuffer = str)
                        {
                            return AsBytes(str.Length * 2, in *(byte*)pBuffer);
                        }
                    }
                }
                case IEnumerable it:
                {
                    var bytes = new MemoryStream();
                    foreach (var b in it)
                    {

                        bytes.WriteByte(ToObject<byte>(0, b));
                    }
                    unsafe
                    {
                        fixed (void* pBuffer = bytes.GetBuffer())
                            return new string((char*) pBuffer, 0, (int) bytes.Length / 2);
                    }
                }
                default:
                    throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        [KalkDoc("utf32")]
        public object GetUtf32(object value)
        {
            switch (value)
            {
                case string str:
                {
                    var buffer = Encoding.UTF32.GetBytes(str);
                    return AsBytes(buffer.Length, in buffer[0]);
                }
                case IEnumerable it:
                {
                    var bytes = new MemoryStream();
                    foreach (var b in it)
                    {
                        bytes.WriteByte(ToObject<byte>(0, b));
                    }
                    return Encoding.UTF32.GetString(bytes.GetBuffer(), 0, (int)bytes.Length);
                }
                default:
                    throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        [KalkDoc("bitcast")]
        public object Bitcast(object type, object value)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            var bytes = (byte[])((ScriptRange)AsBytes(value))?.Values;
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
                    dest.BitCastFrom(bytes);
                    return dest;

                default:
                    throw new ArgumentException($"The destination type `{GetTypeName(type)}` is not supported.", nameof(value));
            }
        }

        [KalkDoc("asbytes")]
        public object AsBytes(object value)
        {
            if (value == null) return null;

            switch (value)
            {
                case string str:
                {
                    var buffer = Encoding.UTF8.GetBytes(str);
                    return AsBytes(buffer.Length, in buffer[0]);
                }
                case byte vbyte:
                    return AsBytes(1, vbyte);
                case sbyte vsbyte:
                    return AsBytes(1, vsbyte);
                case short vshort:
                    return AsBytes(2, vshort);
                case ushort vushort:
                    return AsBytes(2, vushort);
                case int vint:
                    return AsBytes(4, vint);
                case uint vuint:
                    return AsBytes(4, vuint);
                case long vlong:
                    return AsBytes(8, vlong);
                case ulong vulong:
                    return AsBytes(8, vulong);
                case float vfloat:
                {
                    var floatAsInt = BitConverter.SingleToInt32Bits(vfloat);
                    return AsBytes(4, floatAsInt);
                }
                case double vdouble:
                {
                    var doubleAsLong = BitConverter.DoubleToInt64Bits(vdouble);
                    return AsBytes(8, doubleAsLong);
                }
                case BigInteger bigInt:
                {
                    var array = bigInt.ToByteArray();
                    return AsBytes(array.Length, in array[0]);
                }
                case KalkValue kalkValue:
                {
                    var span = kalkValue.AsSpan();
                    return AsBytes(span.Length, in span[0]);
                }
                default:
                    throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }
        
        [KalkDoc("insert_at")]
        public object InsertAt(object value, int index, object item)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (value is string valueStr)
            {
                var itemStr = ObjectToString(item);

                index = index % valueStr.Length;
                index = index < 0 ? valueStr.Length + 1 + index : index;

                var builder = new StringBuilder(valueStr.Substring(0, index));
                builder.Append(itemStr);
                if (index < valueStr.Length)
                {
                    builder.Append(valueStr.Substring(index));
                }
                return builder.ToString();
            }
            else if (value is IList list)
            {
                index = index % list.Count;
                index = index < 0 ? list.Count + 1 + index : index;

                list.Insert(index, item);
                return list;
            }
            else
            {
                throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        [KalkDoc("remove_at")]
        public object RemoveAt(object value, int index)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value is string valueStr)
            {
                index = index % valueStr.Length;
                index = index < 0 ? valueStr.Length + index : index;

                var builder = new StringBuilder(valueStr.Substring(0, index));
                if (index < valueStr.Length)
                {
                    builder.Append(valueStr.Substring(index + 1));
                }
                return builder.ToString();
            }
            else if (value is IList list)
            {
                index = index % list.Count;
                index = index < 0 ? list.Count + index : index;

                list.RemoveAt(index);
                return list;
            }
            else
            {
                throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }
        
        [KalkDoc("contains")]
        public bool Contains(object value, object match)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (value is string valueStr)
            {
                var matchStr = ObjectToString(match);
                return valueStr.Contains(matchStr, StringComparison.Ordinal);
            }

            var composite = new KalkCompositeValue(value);
            bool contains = false;

            // Force the evaluation of the object
            composite.Visit(this, CurrentSpan, input =>
            {
                var result = (bool) ScriptBinaryExpression.Evaluate(this, CurrentSpan, ScriptBinaryOperator.CompareEqual, input, match);
                if (result)
                {
                    contains = true;
                    return false;
                }

                return true;
            });

            return contains;
        }

        [KalkDoc("replace")]
        public object Replace(object value, object match, object by)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (@by == null) throw new ArgumentNullException(nameof(@by));
            if (value is string valueStr)
            {
                var matchStr = ObjectToString(match);
                var byStr = ObjectToString(by);
                return valueStr.Replace(matchStr, byStr);
            }

            var composite = new KalkCompositeValue(value);
            return composite.Transform(this, CurrentSpan, input => ReplaceImpl(input, match, @by));
        }

        private object ReplaceImpl(object value, object match, object by)
        {
            var result = (bool) ScriptBinaryExpression.Evaluate(this, CurrentSpan, ScriptBinaryOperator.CompareEqual, value, match);
            return result ? @by : value;
        }

        private object Hexadecimal(object value, string separator, bool prefix, bool returnString)
        {
            CheckAbort();
            switch (value)
            {
                case string str when returnString:
                    throw new ArgumentException($"Cannot convert a string to hexadecimal inside a list", nameof(value));
                case string str:
                {
                    var array = new ScriptArray<byte>();
                    int count = 0;
                    int hexa = 0;
                    for (int i = 0; i < str.Length; i++)
                    {
                        var c = str[i];
                        if (char.IsWhiteSpace(c) || c == ',' || c == ':' || c == ';' || c == '_' || c == '-') continue;
                        //if (c >= '0' && c <= '9' || c >= 'A' && c <= 'F' || c )
                        if (CharHelper.TryHexaToInt(c, out var n))
                        {
                            // TODO: Add parsing for 0x00
                            hexa = (hexa << 4) | n;
                            if (count == 1)
                            {
                                array.Add((byte)hexa);
                                hexa = 0;
                                count = 0;
                            }
                            else
                            {
                                count++;
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid character found `{StringEscape(c.ToString())}`. Expecting only hexadecimal.", nameof(value));
                        }
                    }

                    if (count > 0)
                    {
                        throw new ArgumentException($"Invalid odd number of hexadecimal character found. Expecting an hexadecimal character.", nameof(value));
                    }

                    return array;
                }
                case byte vbyte:
                    return HexaFromBytes(1, vbyte, prefix, separator);
                case sbyte vsbyte:
                    return HexaFromBytes(1, vsbyte, prefix, separator);
                case short vshort:
                    return HexaFromBytes(2, vshort, prefix, separator);
                case ushort vushort:
                    return HexaFromBytes(2, vushort, prefix, separator);
                case int vint:
                    return HexaFromBytes(4, vint, prefix, separator);
                case uint vuint:
                    return HexaFromBytes(4, vuint, prefix, separator);
                case long vlong:
                    return HexaFromBytes(8, vlong, prefix, separator);
                case ulong vulong:
                    return HexaFromBytes(8, vulong, prefix, separator);
                case float vfloat:
                {
                    var floatAsInt = BitConverter.SingleToInt32Bits(vfloat);
                    return HexaFromBytes(4, floatAsInt, prefix, separator);
                }
                case double vdouble:
                {
                    var doubleAsLong = BitConverter.DoubleToInt64Bits(vdouble);
                    return HexaFromBytes(8, doubleAsLong, prefix, separator);
                }
                case BigInteger bigInt:
                {
                    var array = bigInt.ToByteArray();
                    return HexaFromBytes(array.Length, array[0], prefix, separator);
                }
                case KalkValue kalkValue:
                {
                    var span = kalkValue.AsSpan();
                    return HexaFromBytes(span.Length, span[0], prefix, separator);
                }
                case IEnumerable list:
                {
                    var builder = new StringBuilder();
                    bool isFirst = true;
                    foreach (var item in list)
                    {
                        if (!isFirst)
                        {
                            builder.Append(separator);
                        }
                        isFirst = false;
                        byte byteItem = ToObject<byte>(0, item);
                        if (prefix) builder.Append("0x");
                        builder.Append(byteItem.ToString("X2"));
                    }
                    return builder.ToString();
                }
                default:
                    throw new ArgumentException($"The type {GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        private static string HexaFromBytes<T>(int byteCount, in T element, bool prefix, string separator)
        {
            var builder = new StringBuilder(byteCount * 2);
            for (int i = 0; i < byteCount; i++)
            {
                if (i > 0) builder.Append(separator);
                var b = Unsafe.As<T, byte>(ref Unsafe.AddByteOffset(ref Unsafe.AsRef(element), new IntPtr(i)));
                if (prefix) builder.Append("0x");
                builder.Append(b.ToString("X2"));
            }
            return builder.ToString();
        }

        private static ScriptRange AsBytes<T>(int byteCount, in T element)
        {
            var bytes = new byte[byteCount];
            Unsafe.CopyBlockUnaligned(ref bytes[0], ref Unsafe.As<T, byte>(ref Unsafe.AsRef(element)), (uint)byteCount);
            return new ScriptRange(bytes);
        }
    }
}