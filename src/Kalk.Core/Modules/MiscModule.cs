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
            DateObject = new DateTimeFunctions {Format = "%D %T"};
            RegisterFunctionsAuto();
        }

        /// <summary>
        /// The date object used by the <see cref="Date"/> function.
        /// </summary>
        public DateTimeFunctions DateObject { get; }

        /// <summary>
        /// Gets the current date, parse the input date or return the date object, depending on use cases.
        /// - If this function doesn't have any parameter and is not used to index a member, it returns the current date. It is equivalent of `date.now`
        ///
        ///   The return date object has the following properties:
        ///
        ///   | Name             | Description
        ///   |--------------    |-----------------
        ///   | `.year`          | Gets the year of a date object
        ///   | `.month`         | Gets the month of a date object
        ///   | `.day`           | Gets the day in the month of a date object
        ///   | `.day_of_year`   | Gets the day within the year
        ///   | `.hour`          | Gets the hour of the date object
        ///   | `.minute`        | Gets the minute of the date object
        ///   | `.second`        | Gets the second of the date object
        ///   | `.millisecond`   | Gets the millisecond of the date object
        /// 
        /// - If this function has a string parameter, it will try to parse the string as a date
        /// - Otherwise, if this function provides the following sub functions and members:
        ///   - `date.add_days`: Example `'2016/01/05' |> date |> date.add_days 1`
        ///   - `date.add_months`: Example `'2016/01/05' |> date |> date.add_months 1`
        ///   - `date.add_years`: Example `'2016/01/05' |> date |> date.add_years 1`
        ///   - `date.add_hours`
        ///   - `date.add_minutes`
        ///   - `date.add_seconds`
        ///   - `date.add_milliseconds`
        ///   - `date.to_string`: Converts a datetime object to a textual representation using the specified format string.
        /// 
        ///      By default, if you are using a date, it will use the format specified by `date.format` which defaults to `date.default_format` (readonly) which default to `%d %b %Y`
        ///      
        ///      You can override the format used for formatting all dates by assigning the a new format: `date.format = '%a %b %e %T %Y';`
        ///      
        ///      You can recover the default format by using `date.format = date.default_format;`
        ///      
        ///      By default, the to_string format is using the **current culture**, but you can switch to an invariant culture by using the modifier `%g`
        ///      
        ///      For example, using `%g %d %b %Y` will output the date using an invariant culture.
        ///      
        ///      If you are using `%g` alone, it will output the date with `date.format` using an invariant culture.
        ///      
        ///      Suppose that `date.now` would return the date `2013-09-12 22:49:27 +0530`, the following table explains the format modifiers:
        ///      
        ///      | Format | Result            | Description
        ///      |--------|-------------------|--------------------------------------------
        ///      | `"%a"` |  `"Thu"`          | Name of week day in short form of the
        ///      | `"%A"` |  `"Thursday"`     | Week day in full form of the time
        ///      | `"%b"` |  `"Sep"`          | Month in short form of the time
        ///      | `"%B"` |  `"September"`    | Month in full form of the time
        ///      | `"%c"` |                   | Date and time (%a %b %e %T %Y)
        ///      | `"%C"` |  `"20"`           | Century of the time
        ///      | `"%d"` |  `"12"`           | Day of the month of the time
        ///      | `"%D"` |  `"09/12/13"`     | Date (%m/%d/%y)
        ///      | `"%e"` |  `"12"`           | Day of the month, blank-padded ( 1..31)
        ///      | `"%F"` |  `"2013-09-12"`   | ISO 8601 date (%Y-%m-%d)
        ///      | `"%h"` |  `"Sep"`          | Alias for %b
        ///      | `"%H"` |  `"22"`           | Hour of the time in 24 hour clock format
        ///      | `"%I"` |  `"10"`           | Hour of the time in 12 hour clock format
        ///      | `"%j"` |  `"255"`          | Day of the year (001..366) (3 digits, left padded with zero)
        ///      | `"%k"` |  `"22"`           | Hour of the time in 24 hour clock format, blank-padded ( 0..23)
        ///      | `"%l"` |  `"10"`           | Hour of the time in 12 hour clock format, blank-padded ( 0..12)
        ///      | `"%L"` |  `"000"`          | Millisecond of the time (3 digits, left padded with zero)
        ///      | `"%m"` |  `"09"`           | Month of the time
        ///      | `"%M"` |  `"49"`           | Minutes of the time (2 digits, left padded with zero e.g 01 02)
        ///      | `"%n"` |                   | Newline character (\n)
        ///      | `"%N"` |  `"000000000"`    | Nanoseconds of the time (9 digits, left padded with zero)
        ///      | `"%p"` |  `"PM"`           | Gives AM / PM of the time
        ///      | `"%P"` |  `"pm"`           | Gives am / pm of the time
        ///      | `"%r"` |  `"10:49:27 PM"`  | Long time in 12 hour clock format (%I:%M:%S %p)
        ///      | `"%R"` |  `"22:49"`        | Short time in 24 hour clock format (%H:%M)
        ///      | `"%s"` |                   | Number of seconds since 1970-01-01 00:00:00 +0000
        ///      | `"%S"` |  `"27"`           | Seconds of the time
        ///      | `"%t"` |                   | Tab character (\t)
        ///      | `"%T"` |  `"22:49:27"`     | Long time in 24 hour clock format (%H:%M:%S)
        ///      | `"%u"` |  `"4"`            | Day of week of the time (from 1 for Monday to 7 for Sunday)
        ///      | `"%U"` |  `"36"`           | Week number of the current year, starting with the first Sunday as the first day of the first week (00..53)
        ///      | `"%v"` |  `"12-SEP-2013"`  | VMS date (%e-%b-%Y) (culture invariant)
        ///      | `"%V"` |  `"37"`           | Week number of the current year according to ISO 8601 (01..53)
        ///      | `"%W"` |  `"36"`           | Week number of the current year, starting with the first Monday as the first day of the first week (00..53)
        ///      | `"%w"` |  `"4"`            | Day of week of the time (from 0 for Sunday to 6 for Saturday)
        ///      | `"%x"` |                   | Preferred representation for the date alone, no time
        ///      | `"%X"` |                   | Preferred representation for the time alone, no date
        ///      | `"%y"` |  `"13"`           | Gives year without century of the time
        ///      | `"%Y"` |  `"2013"`         | Year of the time
        ///      | `"%Z"` |  `"IST"`          | Gives Time Zone of the time
        ///      | `"%%"` |  `"%"`            | Output the character `%`
        ///      
        ///      Note that the format is using a good part of the ruby format ([source](http://apidock.com/ruby/DateTime/strftime))
        /// </summary>
        /// <returns>The current date, parse the input date or return the date object, depending on use cases.</returns>
        /// <example>
        /// ```kalk
        /// >>> today = date
        /// # today = date
        /// today = 11/22/20 10:13:00
        /// >>> today.year
        /// # today.year
        /// out = 2020
        /// >>> today.month
        /// # today.month
        /// out = 11
        /// >>> "30 Nov 2020" |> date
        /// # "30 Nov 2020" |> date
        /// out = 11/30/20 00:00:00
        /// >>> out |> date.add_days 4
        /// # out |> date.add_days(4)
        /// out = 12/04/20 00:00:00
        /// >>> date.format = "%F"
        /// >>> date
        /// # date
        /// out = 2020-11-22
        /// ```
        /// </example>
        [KalkExport("date", CategoryMisc)]
        public object Date(string date = null)
        {
            if (!string.IsNullOrEmpty(date))
            {
                return DateTimeFunctions.Parse(Engine, date);
            }

            // If we are used in the context an expression that doesn't use a member of the date object
            // then return the current date
            var parentNode = Engine.CurrentNode.Parent;
            if (parentNode != null && !(parentNode is ScriptMemberExpression || parentNode is ScriptIndexerExpression))
            {
                // In testing, we return a fake method
                return Engine.IsTesting ? new DateTime(2020, 11, 22, 10, 13, 00) : DateTimeFunctions.Now();
            }

            return DateObject;
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
        [KalkExport("ascii", CategoryMisc)]
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
        /// Returns the keys of the specified object.
        /// </summary>
        /// <param name="obj">An object to get the keys from.</param>
        /// <returns>The keys of the parameter obj.</returns>
        /// <example>
        /// ```kalk
        /// >>> obj = {m: 1, n: 2}; keys obj
        /// # obj = {m: 1, n: 2}; keys(obj)
        /// obj = {m: 1, n: 2}
        /// out = ["m", "n"]
        /// ```
        /// </example>
        [KalkExport("keys", CategoryMisc)]
        public IEnumerable Keys(object obj)
        {
            return ObjectFunctions.Keys(Engine, obj);
        }

        /// <summary>
        /// Returns a new GUID as a string.
        /// </summary>
        /// <returns>A new GUID as a string.</returns>
        /// <example>
        /// ```kalk
        /// >>> guid
        /// # guid
        /// out = "0deafe30-de4d-47c3-9631-2d3292afbb8e"
        /// ```
        /// </example>
        [KalkExport("guid", CategoryMisc)]
        public string Guid()
        {
            return Engine.IsTesting ? "0deafe30-de4d-47c3-9631-2d3292afbb8e" : System.Guid.NewGuid().ToString();
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
        [KalkExport("size", CategoryMisc)]
        public int Size(object obj)
        {
            return ObjectFunctions.Size(obj);
        }

        /// <summary>
        /// Returns the values of the specified object.
        /// </summary>
        /// <param name="obj">An object to get the values from.</param>
        /// <returns>The values of the parameter obj.</returns>
        /// <example>
        /// ```kalk
        /// >>> obj = {m: 1, n: 2}; values obj
        /// # obj = {m: 1, n: 2}; values(obj)
        /// obj = {m: 1, n: 2}
        /// out = [1, 2]
        /// ```
        /// </example>
        [KalkExport("values", CategoryMisc)]
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

        /// <summary>
        /// Converts an integral/bytebuffer input to an hexadecimal representation or convert an hexadecimal input string
        /// to an integral/bytebuffer representation.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="separator">The character used to separate hexadecimal bytes when converting
        /// from integral to hexadecimal.</param>
        /// <param name="prefix">Output the prefix `0x` in front of each hexadecimal bytes when converting
        /// from integral to hexadecimal.</param>
        /// <returns>The hexadecimal representation of the input or convert the hexadecimal input string
        /// to an integral representation.</returns>
        /// <remarks> When converting from a hexadecimal string to an integral representation, this method
        /// will skip any white-space characters, comma `,`, colon `:`, semi-colon `;`, underscore `_` and
        /// dash `-`.
        /// When the hexadecimal input string can be converted to an integral less than or equal 8 bytes (64 bits)
        /// it will convert it to a single integral result, otherwise it will convert to a bytebuffer.
        /// See the following examples.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> hex 10
        /// # hex(10)
        /// out = "0A"
        /// >>> hex "12c"
        /// # hex("12c")
        /// out = 300
        /// >>> hex "0a"
        /// # hex("0a")
        /// out = 10
        /// >>> hex "0xff030201"
        /// # hex("0xff030201")
        /// out = 4278387201
        /// >>> hex out
        /// # hex(out)
        /// out = "01 02 03 FF"
        /// >>> hex "01:02:03:04:05:06:07:08:09:0A:0B:0C:0D:0E:0F"
        /// # hex("01:02:03:04:05:06:07:08:09:0A:0B:0C:0D:0E:0F")
        /// out = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])
        /// >>> hex(out, true, ",")
        /// # hex(out, true, ",")
        /// out = "0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0A,0x0B,0x0C,0x0D,0x0E,0x0F"
        /// >>> hex out
        /// # hex(out)
        /// out = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])
        /// >>> hex("1a,2b;3c 4d-5e_6f")
        /// # hex("1a,2b;3c 4d-5e_6f")
        /// out = 103832130169626
        /// >>> hex out
        /// # hex(out)
        /// out = "1A 2B 3C 4D 6F 5E 00 00"
        /// >>> hex float4(1,2,3,4)
        /// # hex(float4(1, 2, 3, 4))
        /// out = "00 00 80 3F 00 00 00 40 00 00 40 40 00 00 80 40"
        /// ```
        /// </example>
        /// <test>
        /// ```kalk
        /// >>> hex short(12345)
        /// # hex(short(12345))
        /// out = "39 30"
        /// >>> hex int (12345789)
        /// # hex(int(12345789))
        /// out = "BD 61 BC 00"
        /// ```
        /// </test>
        [KalkExport("hex", CategoryMisc)]
        public object Hexadecimal(object value, bool prefix = false, string separator = " ")
        {
            return Hexadecimal(value, prefix, separator, false);
        }

        /// <summary>
        /// Converts an integral/bytebuffer input to a binary representation or convert a binary input string
        /// to an integral/bytebuffer representation.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="prefix">Output the prefix `0x` in front of each binary bytes when converting
        ///     from integral to binary.</param>
        /// <param name="separator">The character used to separate binary bytes when converting
        ///     from integral to binary.</param>
        /// <returns>The binary representation of the input or convert the binary input string
        /// to an integral representation.</returns>
        /// <remarks> When converting from a binary string to an integral representation, this method
        /// will skip any white-space characters, comma `,`, colon `:`, semi-colon `;`, underscore `_` and
        /// dash `-`.
        /// When the binary input string can be converted to an integral less than or equal 8 bytes (64 bits)
        /// it will convert it to a single integral result, otherwise it will convert to a bytebuffer.
        /// See the following examples.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> bin 13
        /// # bin(13)
        /// out = "00001101 00000000 00000000 00000000"
        /// >>> bin out
        /// # bin(out)
        /// out = 13
        /// >>> bin "111111111011"
        /// # bin("111111111011")
        /// out = 4091
        /// >>> bin 0xff030201
        /// # bin(-16580095)
        /// out = "00000001 00000010 00000011 11111111"
        /// >>> bin out
        /// # bin(out)
        /// out = 4278387201
        /// >>> bin "11111111000000110000001000000001"
        /// # bin("11111111000000110000001000000001")
        /// out = 4278387201
        /// >>> bin(byte(5))
        /// # bin(byte(5))
        /// out = "00000101"
        /// >>> bin(long(6))
        /// # bin(long(6))
        /// out = "00000110 00000000 00000000 00000000 00000000 00000000 00000000 00000000"
        /// >>> bin(out)
        /// # bin(out)
        /// out = 6
        /// >>> kind(out)
        /// # kind(out)
        /// out = "long"
        /// ```
        /// </example>
        [KalkExport("bin", CategoryMisc)]
        public object Binary(object value, bool prefix = false, string separator = " ")
        {
            return Binary(value, prefix, separator, false);
        }

        /// <summary>
        /// Converts a string to an UTF8 bytebuffer or convert a bytebuffer of UTF8 bytes to a string.
        /// </summary>
        /// <param name="value">The specified input.</param>
        /// <returns>The UTF8 bytebuffer representation of the input string or the string representation of the input UTF8 bytebuffer.</returns>
        /// <example>
        /// ```kalk
        /// >>> utf8 "kalk"
        /// # utf8("kalk")
        /// out = bytebuffer([107, 97, 108, 107])
        /// >>> utf8 out
        /// # utf8(out)
        /// out = "kalk"
        /// ```
        /// </example>
        [KalkExport("utf8", CategoryMisc)]
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

        /// <summary>
        /// Converts a string to an UTF16 bytebuffer or convert a bytebuffer of UTF16 bytes to a string.
        /// </summary>
        /// <param name="value">The specified input.</param>
        /// <returns>The UTF16 bytebuffer representation of the input string or the string representation of the input UTF16 bytebuffer.</returns>
        /// <example>
        /// ```kalk
        /// >>> utf16 "kalk"
        /// # utf16("kalk")
        /// out = bytebuffer([107, 0, 97, 0, 108, 0, 107, 0])
        /// >>> utf16 out
        /// # utf16(out)
        /// out = "kalk"
        /// ```
        /// </example>
        [KalkExport("utf16", CategoryMisc)]
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

        /// <summary>
        /// Converts a string to an UTF32 bytebuffer or convert a bytebuffer of UTF32 bytes to a string.
        /// </summary>
        /// <param name="value">The specified input.</param>
        /// <returns>The UTF32 bytebuffer representation of the input string or the string representation of the input UTF32 bytebuffer.</returns>
        /// <example>
        /// ```kalk
        /// >>> utf32 "kalk"
        /// # utf32("kalk")
        /// out = bytebuffer([107, 0, 0, 0, 97, 0, 0, 0, 108, 0, 0, 0, 107, 0, 0, 0])
        /// >>> utf32 out
        /// # utf32(out)
        /// out = "kalk"
        /// ```
        /// </example>
        [KalkExport("utf32", CategoryMisc)]
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

        /// <summary>
        /// Inserts an item into a string or list at the specified index.
        /// </summary>
        /// <param name="list">A string or list to insert an item into.</param>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item">The item to insert.</param>
        /// <returns>A new string with the item inserted, or a new list with the item inserted at the specified index.</returns>
        /// <remarks>The index is adjusted at the modulo of the length of the input value.
        /// If the index is &lt; 0, then the index starts from the end of the string/list length + 1. A value of -1 for the index would insert the item at the end, after the last element of the string or list.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> insert_at("kalk", 0, "YES")
        /// # insert_at("kalk", 0, "YES")
        /// out = "YESkalk"
        /// >>> insert_at("kalk", -1, "YES")
        /// # insert_at("kalk", -1, "YES")
        /// out = "kalkYES"
        /// >>> insert_at(0..10, 1, 50)
        /// # insert_at(0..10, 1, 50)
        /// out = [0, 50, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
        /// >>> insert_at(0..9, 21, 50) # final index is 21 % 10 = 1
        /// # insert_at(0..9, 21, 50) # final index is 21 % 10 = 1
        /// out = [0, 50, 1, 2, 3, 4, 5, 6, 7, 8, 9]
        /// >>> insert_at([], 3, 1)
        /// # insert_at([], 3, 1)
        /// out = [1]
        /// ```
        /// </example>
        [KalkExport("insert_at", CategoryMisc)]
        public object InsertAt(object list, int index, object item)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (list is string valueStr)
            {
                var itemStr = Engine.ObjectToString(item);
                index = valueStr.Length == 0 ? 0 : index < 0 ? valueStr.Length + (index + 1) % valueStr.Length : index % valueStr.Length;

                var builder = new StringBuilder(valueStr.Substring(0, index));
                builder.Append(itemStr);
                if (index < valueStr.Length)
                {
                    builder.Append(valueStr.Substring(index));
                }
                return builder.ToString();
            }
            else if (list is KalkNativeBuffer buffer)
            {
                var byteItem = Engine.ToObject<byte>(2, item);
                index = buffer.Count == 0 ? 0 : index < 0 ? buffer.Count + (index + 1) % buffer.Count : index % buffer.Count;

                var newBuffer = new KalkNativeBuffer(buffer.Count + 1);
                for (int i = 0; i < index; i++) newBuffer[i] = buffer[i];
                newBuffer[index] = byteItem;
                for (int i = index + 1; i < newBuffer.Count; i++) newBuffer[i] = buffer[i - 1];
                return newBuffer;
            }
            else if (list is IList listCollection)
            {
                index = listCollection.Count == 0 ? 0 : index < 0 ? listCollection.Count + (index + 1) % listCollection.Count : index % listCollection.Count;
                listCollection.Insert(index, item);
                return listCollection;
            }
            else
            {
                throw new ArgumentException($"The type {Engine.GetTypeName(list)} is not supported ", nameof(list));
            }
        }

        /// <summary>
        /// Removes an item from a string or list at the specified index.
        /// </summary>
        /// <param name="list">A string or list to remove an item from.</param>
        /// <param name="index">The index at which to remove the item.</param>
        /// <returns>A new string/list with the item at the specified index removed.</returns>
        /// <remarks>The index is adjusted at the modulo of the length of the input value.
        /// If the index is &lt; 0, then the index starts from the end of the string/list length. A value of -1 for the index would remove the last element.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> remove_at("kalk", 0)
        /// # remove_at("kalk", 0)
        /// out = "alk"
        /// >>> remove_at("kalk", -1)
        /// # remove_at("kalk", -1)
        /// out = "kal"
        /// >>> remove_at(0..9, 5)
        /// # remove_at(0..9, 5)
        /// out = [0, 1, 2, 3, 4, 6, 7, 8, 9]
        /// >>> remove_at(0..9, -1)
        /// # remove_at(0..9, -1)
        /// out = [0, 1, 2, 3, 4, 5, 6, 7, 8]
        /// >>> remove_at(asbytes(0x04030201), 1)
        /// # remove_at(asbytes(67305985), 1)
        /// out = bytebuffer([1, 3, 4])
        /// ```
        /// </example>
        [KalkExport("remove_at", CategoryMisc)]
        public object RemoveAt(object list, int index)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list is string valueStr)
            {
                if (valueStr == string.Empty) return valueStr;
                index = index < 0 ? valueStr.Length + index  % valueStr.Length : index % valueStr.Length;

                var builder = new StringBuilder(valueStr.Substring(0, index));
                if (index < valueStr.Length)
                {
                    builder.Append(valueStr.Substring(index + 1));
                }
                return builder.ToString();
            }
            else if (list is KalkNativeBuffer buffer)
            {
                if (buffer.Count == 0) return buffer;

                index = index < 0 ? buffer.Count + index % buffer.Count : index % buffer.Count;
                var newBuffer = new KalkNativeBuffer(buffer.Count - 1);

                for (int i = 0; i < index; i++) newBuffer[i] = buffer[i];
                for (int i = index; i < newBuffer.Count; i++) newBuffer[i] = buffer[i + 1];
                return newBuffer;
            }
            else if (list is IList listCollection)
            {
                if (listCollection.Count == 0) return listCollection;

                index = index < 0 ? listCollection.Count + index % listCollection.Count : index % listCollection.Count;
                listCollection.RemoveAt(index);
                return listCollection;
            }
            else
            {
                throw new ArgumentException($"The type {Engine.GetTypeName(list)} is not supported ", nameof(list));
            }
        }

        /// <summary>
        /// Checks if an object (string, list, vector types, bytebuffer...) is containing the specified value.
        /// </summary>
        /// <param name="list">The list to search into.</param>
        /// <param name="value">The value to search into the list.</param>
        /// <returns>true if value was found in the list input; otherwise false.</returns>
        /// <example>
        /// ```kalk
        /// >>> contains("kalk", "l")
        /// # contains("kalk", "l")
        /// out = true
        /// >>> contains("kalk", "e")
        /// # contains("kalk", "e")
        /// out = false
        /// >>> contains([1,2,3,4,5], 3)
        /// # contains([1,2,3,4,5], 3)
        /// out = true
        /// >>> contains([1,2,3,4,5], 6)
        /// # contains([1,2,3,4,5], 6)
        /// out = false
        /// >>> contains(float4(1,2,3,4), 3)
        /// # contains(float4(1, 2, 3, 4), 3)
        /// out = true
        /// >>> contains(float4(1,2,3,4), 6)
        /// # contains(float4(1, 2, 3, 4), 6)
        /// out = false
        /// ```
        /// </example>
        [KalkExport("contains", CategoryMisc)]
        public KalkBool Contains(object list, object value)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (list is string valueStr)
            {
                var matchStr = Engine.ObjectToString(value);
                return valueStr.Contains(matchStr, StringComparison.Ordinal);
            }

            var composite = new KalkCompositeValue(list);
            bool contains = false;

            // Force the evaluation of the object
            composite.Visit(Engine, Engine.CurrentSpan, input =>
            {
                var result = (bool) ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.CompareEqual, input, value);
                if (result)
                {
                    contains = true;
                    return false;
                }

                return true;
            });

            return contains;
        }

        /// <summary>
        /// Replaces in an object (string, list, vector types, bytebuffer...) an item of the specified value by another value.
        /// </summary>
        /// <param name="list">The list to search into to replace an element.</param>
        /// <param name="value">The item to replace.</param>
        /// <param name="by">The value to replace with.</param>
        /// <returns>The modified object.</returns>
        /// <example>
        /// ```kalk
        /// >>> replace("kalk", "k", "woo")
        /// # replace("kalk", "k", "woo")
        /// out = "wooalwoo"
        /// >>> replace([1,2,3,4], 3, 5)
        /// # replace([1,2,3,4], 3, 5)
        /// out = [1, 2, 5, 4]
        /// >>> replace(float4(1,2,3,4), 3, 5)
        /// # replace(float4(1, 2, 3, 4), 3, 5)
        /// out = float4(1, 2, 5, 4)
        /// ```
        /// </example>
        [KalkExport("replace", CategoryMisc)]
        public object Replace(object list, object value, object by)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (@by == null) throw new ArgumentNullException(nameof(@by));
            if (list is string valueStr)
            {
                var matchStr = Engine.ObjectToString(value);
                var byStr = Engine.ObjectToString(by);
                return valueStr.Replace(matchStr, byStr);
            }

            var composite = new KalkCompositeValue(list);
            return composite.Transform(Engine, Engine.CurrentSpan, input => ReplaceImpl(input, value, @by), typeof(object));
        }

        /// <summary>
        /// Creates a slice of an object (string, list, vector types, bytebuffer...) starting at the specified index and with the specified length;
        /// </summary>
        /// <param name="list">The object to create a slice from.</param>
        /// <param name="index">The index into the object.</param>
        /// <param name="length">The optional length of the slice. If the length is not defined, the length will start from index with the remaining elements.</param>
        /// <returns>A slice of the input object.</returns>
        /// <remarks>The index is adjusted at the modulo of the specified length of the input object.
        /// If the index is &lt; 0, then the index starts from the end of the input object length. A value of -1 for the index would take a slice with the only the last element.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> slice("kalk", 1)
        /// # slice("kalk", 1)
        /// out = "alk"
        /// >>> slice("kalk", -2)
        /// # slice("kalk", -2)
        /// out = "lk"
        /// >>> slice("kalk", 1, 2)
        /// # slice("kalk", 1, 2)
        /// out = "al"
        /// >>> slice([1,2,3,4], 1)
        /// # slice([1,2,3,4], 1)
        /// out = [2, 3, 4]
        /// >>> slice([1,2,3,4], -1)
        /// # slice([1,2,3,4], -1)
        /// out = [4]
        /// >>> slice([1,2,3,4], -1, 3) # length is bigger than expected, no errors
        /// # slice([1,2,3,4], -1, 3) # length is bigger than expected, no errors
        /// out = [4]
        /// >>> slice(asbytes(0x04030201), 1, 2)
        /// # slice(asbytes(67305985), 1, 2)
        /// out = slice(bytebuffer([2, 3]), 1, 2)
        /// ```
        /// </example>
        [KalkExport("slice", CategoryMisc)]
        public object Slice(object list, int index, int? length = null)
        {
            if (list is string str)
            {
                return StringFunctions.Slice(str, index, length);
            }

            var listCollection = list as IList;
            if (listCollection == null)
            {
                if (list is IEnumerable it)
                {
                    listCollection = new ScriptRange(it);
                }
                else
                {
                    throw new ArgumentException("The argument is not a string, bytebuffer or array.", nameof(list));
                }
            }

            // Wrap index
            index = index < 0 ? listCollection.Count + index % listCollection.Count : index % listCollection.Count;

            // Compute length
            length ??= listCollection.Count;
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be >= 0");
            }

            // Trim length if required
            if (index + length > listCollection.Count)
            {
                length = listCollection.Count - index;
            }
            
            if (list is KalkNativeBuffer nativeBuffer)
            {
                return nativeBuffer.Slice(index, length.Value);
            }

            return new ScriptRange(listCollection.Cast<object>().Skip(index).Take(length.Value));
        }

        /// <summary>
        /// Extract lines from the specified string.
        /// </summary>
        /// <param name="text">A string to extract lines from.</param>
        /// <returns>Lines extracted from the input string.</returns>
        /// <example>
        /// ```kalk
        /// >>> lines("k\na\nl\nk")
        /// # lines("k\na\nl\nk")
        /// out = ["k", "a", "l", "k"]
        /// ```
        /// </example>
        [KalkExport("lines", CategoryMisc)]
        public ScriptRange Lines(string text)
        {
            if (text == null) return new ScriptRange();
            return new ScriptRange(new LineReader(() => new StringReader(text)));
        }

        /// <summary>
        /// Display or returns the known CSS colors.
        /// </summary>
        /// <returns>Prints known CSS colors or return a list if this function is used in an expression.</returns>
        /// <example>
        /// ```kalk
        /// >>> colors[0]
        /// # colors[0]
        /// out = rgb(240, 248, 255) ## F0F8FF AliceBlue ##
        /// >>> mycolor = colors["AliceBlue"]; mycolor.name
        /// # mycolor = colors["AliceBlue"]; mycolor.name
        /// mycolor = rgb(240, 248, 255) ## F0F8FF AliceBlue ##
        /// out = "AliceBlue"
        /// ```
        /// </example>
        [KalkExport("colors", CategoryMisc)]
        public object Colors()
        {
            var knownColorsInternal = KalkColorRgb.GetKnownColors();
            if (!(Engine?.CurrentNode is ScriptVariable) || !(Engine?.CurrentNode?.Parent is ScriptExpressionStatement))
            {
                var colors = new ScriptArray(knownColorsInternal);
                foreach (var color in knownColorsInternal)
                {
                    colors.SetValue(color.Name, color, false);
                }
                return colors;
            }

            var builder = new StringBuilder();
            int count = 0;
            const int PerColumn = 2;
            foreach (var knownColor in knownColorsInternal)
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


        private object ReplaceImpl(object value, object match, object by)
        {
            var result = (bool)ScriptBinaryExpression.Evaluate(Engine, Engine.CurrentSpan, ScriptBinaryOperator.CompareEqual, value, match);
            return result ? @by : value;
        }

        private object Hexadecimal(object value, bool prefix, string separator, bool returnString)
        {
            Engine.CheckAbort();
            switch (value)
            {
                case string str when returnString:
                    throw new ArgumentException($"Cannot convert a string to hexadecimal inside a list", nameof(value));
                case string str:
                {
                    var array = new List<byte>();
                    var temp = new List<byte>();
                    int count = 0;
                    bool hasPrefix = false;
                    int hexa = 0;

                    void FlushBytes()
                    {
                        bool isOdd = count > 0;
                        if (isOdd)
                        {
                            temp.Add((byte)(hexa << 4));
                        }
                        count = 0;

                        if (temp.Count > 0)
                        {
                            if (isOdd)
                            {
                                for (int j = temp.Count - 1; j >= 0; j--)
                                {
                                    var hb  = j - 1 >= 0 ? (temp[j - 1] & 0xF) << 4 : 0;
                                    var lb = temp[j] >> 4;
                                    var fullByte = (byte)(hb | lb);
                                    array.Add(fullByte);
                                }
                            }
                            else
                            {
                                for (int j = temp.Count - 1; j >= 0; j--)
                                {
                                    array.Add(temp[j]);
                                }
                            }

                            temp.Clear();
                        }
                    }

                    for (int i = 0; i < str.Length; i++)
                    {
                        var c = str[i];
                        if (char.IsWhiteSpace(c) || c == ',' || c == ':' || c == ';' || c == '_' || c == '-')
                        {
                            if (c != '_')
                            {
                                FlushBytes();
                            }
                            hasPrefix = c == '_' && hasPrefix; // reset prefix after parsing but not for `_`
                            continue;
                        }

                        // Skip 0x prefix
                        if (!hasPrefix && c == '0' && i + 1 < str.Length && str[i + 1] == 'x')
                        {
                            FlushBytes();
                            hasPrefix = true;
                            i++;
                            continue;
                        }

                        //if (c >= '0' && c <= '9' || c >= 'A' && c <= 'F' || c )
                        if (CharHelper.TryHexaToInt(c, out var n))
                        {
                            // TODO: Add parsing for 0x00
                            hexa = (hexa << 4) | n;
                            if (count == 1)
                            {
                                temp.Add((byte)hexa);
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

                    FlushBytes();

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

        private object Binary(object value, bool prefix, string separator, bool returnString)
        {
            Engine.CheckAbort();
            switch (value)
            {
                case string str when returnString:
                    throw new ArgumentException($"Cannot convert a string to binary inside a list", nameof(value));
                case string str:
                {
                    var array = new List<byte>();
                    var temp = new List<byte>();
                    int count = 0;
                    bool hasPrefix = false;
                    int bin = 0;

                    void FlushBytes()
                    {
                        bool isOdd = count > 0;
                        var shift = 8 - count;
                        if (count > 0)
                        {
                            temp.Add((byte)(bin << shift));
                        }
                        bin = 0;

                        if (temp.Count > 0)
                        {
                            if (isOdd)
                            {
                                for (int j = temp.Count - 1; j >= 0; j--)
                                {
                                    var hb = j - 1 >= 0 ? (byte)((temp[j - 1]) << shift) : (byte)0;
                                    var lb = temp[j] >> count;
                                    var fullByte = (byte)(hb | lb);
                                    array.Add(fullByte);
                                }
                            }
                            else
                            {
                                for (int j = temp.Count - 1; j >= 0; j--)
                                {
                                    array.Add(temp[j]);
                                }
                            }

                            temp.Clear();
                        }

                        count = 0;
                    }

                        for (int i = 0; i < str.Length; i++)
                    {
                        var c = str[i];
                        if (char.IsWhiteSpace(c) || c == ',' || c == ':' || c == ';' || c == '_' || c == '-')
                        {
                            if (c != '_')
                            {
                                FlushBytes();
                            }
                            hasPrefix = c == '_' && hasPrefix; // reset prefix after parsing but not for `_`
                            continue;
                        }

                        // Skip 0b prefix
                        if (!hasPrefix && c == '0' && i + 1 < str.Length && str[i + 1] == 'b')
                        {
                            FlushBytes();
                            hasPrefix = true;
                            i++;
                            continue;
                        }

                        if (c == '0' || c == '1')
                        {
                            bin = (bin << 1) | (c - '0');
                            if (count == 7)
                            {
                                temp.Add((byte)bin);
                                bin = 0;
                                count = 0;
                            }
                            else
                            {
                                count++;
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid character found `{StringFunctions.Escape(c.ToString())}`. Expecting only binary 0 or 1.", nameof(value));
                        }
                    }

                    FlushBytes();

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
                    return BinaryFromBytes(1, vbyte, prefix, separator);
                case sbyte vsbyte:
                    return BinaryFromBytes(1, vsbyte, prefix, separator);
                case short vshort:
                {
                    int size = 2;
                    return BinaryFromBytes(size, vshort, prefix, separator);
                }
                case ushort vushort:
                {
                    int size = 2;
                    return BinaryFromBytes(size, vushort, prefix, separator);
                }
                case int vint:
                {
                    int size = 4;
                    return BinaryFromBytes(size, vint, prefix, separator);
                }
                case uint vuint:
                {
                    int size = 4;
                    return BinaryFromBytes(size, vuint, prefix, separator);
                }
                case long vlong:
                {
                    int size = 8;
                    return BinaryFromBytes(size, vlong, prefix, separator);
                }
                case ulong vulong:
                {
                    int size = 8;
                    return BinaryFromBytes(size, vulong, prefix, separator);
                }
                case float vfloat:
                {
                    var floatAsInt = BitConverter.SingleToInt32Bits(vfloat);
                    return BinaryFromBytes(4, floatAsInt, prefix, separator);
                }
                case double vdouble:
                {
                    var doubleAsLong = BitConverter.DoubleToInt64Bits(vdouble);
                    return BinaryFromBytes(8, doubleAsLong, prefix, separator);
                }
                case BigInteger bigInt:
                {
                    var array = bigInt.ToByteArray();
                    return BinaryFromBytes(array.Length, array[0], prefix, separator);
                }
                case KalkValue kalkValue:
                {
                    var span = kalkValue.AsSpan();
                    return BinaryFromBytes(span.Length, span[0], prefix, separator);
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
                        if (prefix) builder.Append("0b");
                        AppendBinaryByte(builder, byteItem);
                    }
                    return builder.ToString();
                }
                default:
                    throw new ArgumentException($"The type {Engine.GetTypeName(value)} is not supported ", nameof(value));
            }
        }

        private static void AppendBinaryByte(StringBuilder builder, byte byteItem)
        {
            for (int i = 0; i < 8; i++)
            {
                var b = (byteItem >> (7 - i)) & 1;
                builder.Append(b == 1 ? '1' : '0');
            }
        }

        private static string BinaryFromBytes<T>(int byteCount, in T element, bool prefix, string separator)
        {
            var builder = new StringBuilder(byteCount * 8);
            for (int i = 0; i < byteCount; i++)
            {
                if (i > 0) builder.Append(separator);
                var b = Unsafe.As<T, byte>(ref Unsafe.AddByteOffset(ref Unsafe.AsRef(element), new IntPtr(i)));
                if (prefix) builder.Append("0b");
                AppendBinaryByte(builder, b);
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