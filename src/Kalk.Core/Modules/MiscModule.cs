using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Kalk.Core.Helpers;
using Scriban.Functions;
using Scriban.Helpers;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    /// <summary>
    /// Misc module (builtin).
    /// </summary>
    public sealed partial class MiscModule : KalkModuleWithFunctions
    {
        public const string CategoryMisc = "Misc Functions";

        public static readonly Encoding EncodingExtendedAscii = CodePagesEncodingProvider.Instance.GetEncoding(1252);
        
        public MiscModule()
        {
            IsBuiltin = true;
            RegisterFunctionsAuto();
        }

        /// <summary>
        /// Prints the ascii table or convert an input string to an ascii array, or an ascii array to a string.
        /// </summary>
        /// <param name="obj">An optional input (string or array of numbers or directly an integer).</param>
        /// <returns>Depending on the input:
        /// - If no input, it will display the ascii table
        /// - If the input is an integer, it will convert it to the equivalent ascii char.
        /// - If the input is a string, it will convert the string to a byte buffer containing the corresponding ascii bytes.
        /// - If the input is an array of integer, it will convert each element to the equivalent ascii char.
        /// </returns>
        /// <example>
        /// ```kalk
        /// >>> ascii 65
        /// # ascii(65)
        /// out = "A"
        /// >>> ascii 97
        /// # ascii(97)
        /// out = "a"
        /// >>> ascii "A"
        /// # ascii("A")
        /// out = 65
        /// >>> ascii "kalk"
        /// # ascii("kalk")
        /// out = bytebuffer([107, 97, 108, 107])
        /// >>> ascii out
        /// # ascii(out)
        /// out = "kalk"
        /// ```
        /// </example>
        [KalkDoc("ascii", CategoryMisc)]
        public object Ascii(object obj = null)
        {
            if (obj == null && Engine.CurrentNode.Parent is ScriptExpressionStatement)
            {
                var builder = new StringBuilder();

                const int alignControls = -38;
                const int alignStandard = 13;
                const int columnWidth = 3 + 4 + 1;

                for (int y = 0; y < 32; y++)
                {
                    builder.Length = 0;
                    for (int x = 0; x < 8; x++)
                    {
                        var c = x * 32 + y;
                        if (x > 0) builder.Append(" ");

                        var index = $"{c,3}";

                        var valueAsString = StringFunctions.Escape(ConvertAscii(c));
                        var strValue = $"\"{valueAsString}\"";
                        var column = x == 0 ? $"{index} {strValue,-6} {$"({AsciiSpecialCodes[y]})",-27}" : $"{index} {strValue,-4}";

                        OutputColumn(builder, x, column);
                    }

                    if (y == 0)
                    {
                        Engine.WriteHighlightLine($" {"ASCII controls",alignControls} {"ASCII printable characters",-(columnWidth * 2 + alignStandard + 1)} {"Extended ASCII Characters"}");
                    }

                    Engine.WriteHighlightLine(builder.ToString());
                }

                void OutputColumn(StringBuilder output, int columnIndex, string text)
                {
                    output.Append(columnIndex == 0 ? $"{text,-alignControls}" : columnIndex == 3 ? $"{text,-alignStandard}" : $"{text}");
                }


                return null;
            }

            // Otherwise convert the argument.
            return ConvertAscii(Engine, obj);
        }

        /// <summary>
        /// Returns the keys of an object.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns>The keys of the parameter obj.</returns>
        /// <example>
        /// ```kalk
        /// >>> obj = {m: 1, n: 2}; keys obj
        /// # obj = {m: 1, n: 2}; keys(obj)
        /// obj = {m: 1, n: 2}
        /// out = ["m", "n"]
        /// ```
        /// </example>
        [KalkDoc("keys", CategoryMisc)]
        public IEnumerable Keys(object obj)
        {
            return ObjectFunctions.Keys(Engine, obj);
        }

        /// <summary>
        /// Returns a new GUID as a string.
        /// </summary>
        /// <returns>A new GUID as a string.</returns>
        [KalkDoc("guid", CategoryMisc)]
        public string Guid()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Returns the size of the specified object.
        /// </summary>
        /// <param name="obj">The object value.</param>
        /// <returns>The size of the object.</returns>
        /// <example>
        /// ```kalk
        /// >>> size 1
        /// # size(1)
        /// out = 0
        /// >>> size "kalk"
        /// # size("kalk")
        /// out = 4
        /// >>> size float4(1,2,3,4)
        /// # size(float4(1, 2, 3, 4))
        /// out = 4
        /// >>> size [1, 2, 3]
        /// # size([1, 2, 3])
        /// out = 3
        /// ```
        /// </example>
        [KalkDoc("size", CategoryMisc)]
        public int Size(object obj)
        {
            return ObjectFunctions.Size(obj);
        }

        [KalkDoc("values", CategoryMisc)]
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
        
        [KalkDoc("hex", CategoryMisc)]
        public object Hexadecimal(object value, string separator = " ", bool prefix = false)
        {
            return Hexadecimal(value, separator, prefix, false);
        }

        [KalkDoc("utf8", CategoryMisc)]
        public object GetUtf8(object value)
        {
            switch (value)
            {
                case string str:
                {
                    var buffer = Encoding.UTF8.GetBytes(str);
                    return KalkNativeBuffer.AsBytes(buffer.Length, in buffer[0]);
                }
                case IEnumerable it:
                {
                    var bytes = new MemoryStream();
                    foreach (var b in it)
                    {
                        bytes.WriteByte(Engine.ToObject<byte>(0, b));
                    }
                    return Encoding.UTF8.GetString(bytes.GetBuffer(), 0, (int) bytes.Length);
                }
                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }


        [KalkDoc("utf16", CategoryMisc)]
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
                            return KalkNativeBuffer.AsBytes(str.Length * 2, in *(byte*)pBuffer);
                        }
                    }
                }
                case IEnumerable it:
                {
                    var bytes = new MemoryStream();
                    foreach (var b in it)
                    {

                        bytes.WriteByte(Engine.ToObject<byte>(0, b));
                    }
                    unsafe
                    {
                        fixed (void* pBuffer = bytes.GetBuffer())
                            return new string((char*) pBuffer, 0, (int) bytes.Length / 2);
                    }
                }
                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        [KalkDoc("utf32", CategoryMisc)]
        public object GetUtf32(object value)
        {
            switch (value)
            {
                case string str:
                {
                    var buffer = Encoding.UTF32.GetBytes(str);
                    return KalkNativeBuffer.AsBytes(buffer.Length, in buffer[0]);
                }
                case IEnumerable it:
                {
                    var bytes = new MemoryStream();
                    foreach (var b in it)
                    {
                        bytes.WriteByte(Engine.ToObject<byte>(0, b));
                    }
                    return Encoding.UTF32.GetString(bytes.GetBuffer(), 0, (int)bytes.Length);
                }
                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }
        
        [KalkDoc("insert_at", CategoryMisc)]
        public object InsertAt(object value, int index, object item)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (value is string valueStr)
            {
                var itemStr = Engine.ObjectToString(item);

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
                throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        [KalkDoc("remove_at", CategoryMisc)]
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
                throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }
        
        [KalkDoc("contains", CategoryMisc)]
        public KalkBool Contains(object value, object match)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (value is string valueStr)
            {
                var matchStr = Engine.ObjectToString(match);
                return valueStr.Contains(matchStr, StringComparison.Ordinal);
            }

            var composite = new KalkCompositeValue(value);
            bool contains = false;

            // Force the evaluation of the object
            composite.Visit(Engine, Engine.CurrentSpan, input =>
            {
                var result = (bool) ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.CompareEqual, input, match);
                if (result)
                {
                    contains = true;
                    return false;
                }

                return true;
            });

            return contains;
        }

        [KalkDoc("replace", CategoryMisc)]
        public object Replace(object value, object match, object by)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (@by == null) throw new ArgumentNullException(nameof(@by));
            if (value is string valueStr)
            {
                var matchStr = Engine.ObjectToString(match);
                var byStr = Engine.ObjectToString(by);
                return valueStr.Replace(matchStr, byStr);
            }

            var composite = new KalkCompositeValue(value);
            return composite.Transform(Engine, Engine.CurrentSpan, input => ReplaceImpl(input, match, @by), typeof(object));
        }

        [KalkDoc("slice", CategoryMisc)]
        public object Slice(object value, int index, int? length = null)
        {
            if (value is string str)
            {
                return StringFunctions.Slice(str, index, length);
            }

            var list = value as IList;
            if (list == null)
            {
                if (value is IEnumerable it)
                {
                    list = new ScriptRange(it);
                }
                else
                {
                    throw new ArgumentException("The argument is not a string, bytebuffer or array.");
                }
            }
            
            if (index < 0)
            {
                index = index + list.Count;
            }

            length ??= list.Count;

            if (index < 0)
            {
                if (index + length <= 0)
                {
                    return new KalkNativeBuffer(0);
                }
                length = length + index;
                index = 0;
            }

            if (index + length > list.Count)
            {
                length = list.Count - index;
            }
            
            if (value is KalkNativeBuffer nativeBuffer)
            {
                return nativeBuffer.Slice(index, length.Value);
            }

            return new ScriptRange(list.Cast<object>().Skip(index).Take(length.Value));
        }

        [KalkDoc("lines", CategoryMisc)]
        public ScriptRange Lines(string text)
        {
            if (text == null) return new ScriptRange();
            return new ScriptRange(new LineReader(() => new StringReader(text)));
        }
        
        private object ReplaceImpl(object value, object match, object by)
        {
            var result = (bool) ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.CompareEqual, value, match);
            return result ? @by : value;
        }

        private object Hexadecimal(object value, string separator, bool prefix, bool returnString)
        {
            Engine.CheckAbort();
            switch (value)
            {
                case string str when returnString:
                    throw new ArgumentException($"Cannot convert a string to hexadecimal inside a list", nameof(value));
                case string str:
                {
                    var array = new List<byte>();
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
                            throw new ArgumentException($"Invalid character found `{StringFunctions.Escape(c.ToString())}`. Expecting only hexadecimal.", nameof(value));
                        }
                    }

                    if (count > 0)
                    {
                        throw new ArgumentException($"Invalid odd number of hexadecimal character found. Expecting an hexadecimal character.", nameof(value));
                    }

                    if (array.Count <= 8)
                    {
                        long ulongValue = 0;
                        unsafe
                        {
                            for (int i = 0; i < array.Count; i++)
                            {
                                ((byte*)&ulongValue)[i] = array[i];
                            }
                        }
                        return ulongValue;
                    }

                    return new KalkNativeBuffer(array);
                }
                case byte vbyte:
                    return HexaFromBytes(1, vbyte, prefix, separator);
                case sbyte vsbyte:
                    return HexaFromBytes(1, vsbyte, prefix, separator);
                case short vshort:
                {
                    int size = 2;
                    if (vshort >= sbyte.MinValue && vshort <= byte.MaxValue) size = 1; 
                    return HexaFromBytes(size, vshort, prefix, separator);
                }
                case ushort vushort:
                {
                    int size = 2;
                    if (vushort <= byte.MaxValue) size = 1; 
                    return HexaFromBytes(size, vushort, prefix, separator);
                }
                case int vint:
                {
                    int size = 4;
                    if (vint >= sbyte.MinValue && vint <= byte.MaxValue) size = 1; 
                    else if (vint >= short.MinValue && vint <= ushort.MaxValue) size = 2; 
                    return HexaFromBytes(size, vint, prefix, separator);
                }
                case uint vuint:
                {
                    int size = 4;
                    if (vuint <= byte.MaxValue) size = 1; 
                    else if (vuint <= ushort.MaxValue) size = 2; 
                    return HexaFromBytes(size, vuint, prefix, separator);
                }
                case long vlong:
                {
                    int size = 8;
                    if (vlong >= sbyte.MinValue && vlong <= byte.MaxValue) size = 1; 
                    else if (vlong >= short.MinValue && vlong <= ushort.MaxValue) size = 2; 
                    else if (vlong >= int.MinValue && vlong <= uint.MaxValue) size = 4; 
                    return HexaFromBytes(size, vlong, prefix, separator);
                }
                case ulong vulong:
                {
                    int size = 8;
                    if (vulong <= byte.MaxValue) size = 1; 
                    else if (vulong <= ushort.MaxValue) size = 2; 
                    else if (vulong <= uint.MaxValue) size = 4; 
                    return HexaFromBytes(size, vulong, prefix, separator);
                }
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
                        byte byteItem = Engine.ToObject<byte>(0, item);
                        if (prefix) builder.Append("0x");
                        builder.Append(byteItem.ToString("X2"));
                    }
                    return builder.ToString();
                }
                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        [KalkDoc("colors", CategoryMisc)]
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

        private static object ConvertAscii(KalkEngine context, object argument)
        {
            if (argument is string text)
            {
                var bytes = EncodingExtendedAscii.GetBytes(text);
                if (bytes.Length == 1)
                {
                    return bytes[0];
                }

                return new KalkNativeBuffer(bytes);
            }
            else if (argument is KalkNativeBuffer buffer)
            {
                return EncodingExtendedAscii.GetString(buffer.AsSpan());
            }
            else if (argument is IEnumerable it)
            {
                return new ScriptRange(ConvertAsciiIteration(context, it));
            }
            else
            {
                return ConvertAscii(context.ToInt(context.CurrentSpan, argument));
            }
        }

        private static IEnumerable ConvertAsciiIteration(KalkEngine context, IEnumerable it)
        {
            var iterator = it.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return ConvertAscii(context, iterator.Current);
            }
        }

        private static unsafe string ConvertAscii(int c)
        {
            var value = (byte)c;
            return EncodingExtendedAscii.GetString(&value, 1);
        }

        private static readonly string[] AsciiSpecialCodes = new string[32]
        {
            "NUL / Null",
            "SOH / Start of Heading",
            "STX / Start of Text",
            "ETX / End of Text",
            "EOT / End of Transmission",
            "ENQ / Enquiry",
            "ACK / Acknowledgment",
            "BEL / Bell",
            "BS  / Backspace",
            "HT  / Horizontal Tab",
            "LF  / Line Feed",
            "VT  / Vertical Tab",
            "FF  / Form Feed",
            "CR  / Carriage Return",
            "SO  / Shift Out",
            "SI  / Shift In",
            "DLE / Data Link Escape",
            "DC1 / Device Control 1",
            "DC2 / Device Control 2",
            "DC3 / Device Control 3",
            "DC4 / Device Control 4",
            "NAK / Negative Ack",
            "SYN / Synchronous Idle",
            "ETB / End of Trans Block",
            "CAN / Cancel",
            "EM  / End of Medium",
            "SUB / Substitute",
            "ESC / Escape",
            "FS  / File Separator",
            "GS  / Group Separator",
            "RS  / Record Separator",
            "US  / Unit Separator",
        };
    }
}