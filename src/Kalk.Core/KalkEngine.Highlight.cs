using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Consolus;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public const int DefaultLimitToStringNoAuto = 4096;

        private static readonly TokenType[] MatchPairs = new[]
        {
            TokenType.OpenParen,
            TokenType.CloseParen,
            TokenType.OpenBracket,
            TokenType.CloseBracket,
            TokenType.OpenBrace,
            TokenType.CloseBrace,
        };


        private readonly HashSet<string> ScriptKeywords = new HashSet<string>()
        {
            "if",
            "else",
            "end",
            "for",
            "in",
            "case",
            "when",
            "while",
            "break",
            "continue",
            "func",
            "import",
            "readonly",
            "with",
            "capture",
            "ret",
            "wrap",
            "do",
        };
        
        private static List<string> SplitStringBySpaceAndKeepSpace(string text)
        {
            // normalize line endings with \n
            text = text.Replace("\r\n", "\n").Replace("\r", "\n");
            var list = new List<string>();
            var builder = new StringBuilder();
            bool isCurrentWhiteSpace = false;
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (char.IsWhiteSpace(c))
                {
                    if (builder.Length > 0)
                    {
                        list.Add(builder.ToString());
                        builder.Length = 0;
                    }

                    // We put "\n" separately
                    if (c == '\n')
                    {
                        list.Add("\n");
                        continue;
                    }

                    isCurrentWhiteSpace = true;
                }
                else if (isCurrentWhiteSpace)
                {
                    list.Add(builder.ToString());
                    builder.Length = 0;
                    isCurrentWhiteSpace = false;
                }
                builder.Append(c);
            }

            if (builder.Length > 0)
            {
                list.Add(builder.ToString());
            }

            return list;
        }


        private void WriteHighlightVariableAndValueToConsole(string name, object value)
        {
            if (value is ScriptFunction function && !function.IsAnonymous)
            {
                WriteHighlightLine($"{value}");
            }
            else
            {
                int previousLimit = LimitToString;
                try
                {
                    int limit = 0;
                    var limitStr = Config.LimitToString;
                    if (limitStr == "auto")
                    {
                        if (HasInteractiveConsole)
                        {
                            limit = Console.WindowWidth * Console.WindowHeight;
                        }
                        else
                        {
                            limit = DefaultLimitToStringNoAuto;
                        }
                    }
                    else if (limitStr == null || !int.TryParse(limitStr, out limit))
                    {
                        limit = DefaultLimitToStringNoAuto;
                    }

                    if (limit < 0) limit = 0;
                    LimitToString = limit;
                    WriteHighlightLine($"{name} = {ObjectToString(value, true)}");
                }
                finally
                {
                    LimitToString = previousLimit;
                }

                WriteValueWithDisplayMode(value);
            }
        }

        private void WriteValueWithDisplayMode(object value)
        {
            var display = KalkDisplayModeHelper.SafeParse(Config.Display);

            // If the type is displayable
            if (value is IKalkDisplayable displayable)
            {
                displayable.Display(this, display);
                return;
            }
            
            // Otherwise supports the default.
            switch (display)
            {
                case KalkDisplayMode.Standard:
                    return;
                case KalkDisplayMode.Developer:
                    if (value is int i32)
                    {
                        WriteInt32(i32);
                    }
                    else if (value is uint u32)
                    {
                        WriteUInt32(u32);
                    }
                    else if (value is long i64)
                    {
                        WriteInt64(i64);
                    }
                    else if (value is ulong u64)
                    {
                        WriteUInt64(u64);
                    }
                    else if (value is float f32)
                    {
                        WriteFloat(f32);
                    }
                    else if (value is double f64)
                    {
                        WriteDouble(f64, "IEEE 754 - double - 64-bit");
                    }
                    else if (value is decimal dec)
                    {
                        WriteDouble((double)dec, "Decimal 128-bit displayed as IEEE 754 - double - 64-bit");
                    }
                    return;
            }
        }
        
        private void WriteInt32(int i32)
        {
            WriteHighlightLine($"    # int - 32-bit");
            WriteInt32((uint)i32, false);
        }

        private void WriteUInt32(uint u32)
        {
            WriteHighlightLine($"    # uint - 32-bit");
            WriteInt32(u32, false);
        }

        private void WriteInt32(uint u32, bool forFloat)
        {
            WriteHighlightLine($"    = 0x_{u32 >> 16:X4}_{u32 & 0xFFFF:X4}");
            var builder = new StringBuilder();

            // Prints the hexa version
            // # 0x____3____F____F____8____0____0____0____0
            builder.Append("0x");
            for (int i = 7; i >= 0; i--)
            {
                builder.Append("____");

                var v = (byte)(0xF & (u32 >> (i * 4)));
                builder.Append(v.ToString("X1"));
            }
            WriteHighlightLine($"    = {builder}");

            if (forFloat)
            {
                // Prints the float IEE754 mask
                // #    seee eeee efff ffff ffff ffff ffff ffff
                WriteHighlightLine($"    #    seee eeee efff ffff ffff ffff ffff ffff");
            }

            // Prints the binary version
            // # 0b_0011_1111_1111_1000_0000_0000_0000_0000
            builder.Length = 0;
            builder.Append("0b");
            for (int i = 7; i >= 0; i--)
            {
                builder.Append('_');

                var v = (byte)(0xF & (u32 >> (i * 4)));
                var leadingZero = BitOperations.LeadingZeroCount(v) - 28;
                builder.Append('0', leadingZero);
                if (v != 0) builder.Append(Convert.ToString(v, 2));
            }
            WriteHighlightLine($"    = {builder}");
        }

        private void WriteInt64(long i64)
        {
            WriteHighlightLine($"    # long - 64-bit");
            WriteUInt64((ulong)i64, false);
        }

        private void WriteUInt64(ulong u64)
        {
            WriteHighlightLine($"    # ulong - 64-bit");
            WriteUInt64(u64, false);
        }

        private void WriteUInt64(ulong u64, bool forDouble)
        {
            WriteHighlightLine($"    = 0x_{u64 >> 32:X8}_{((uint)u64) & 0xFFFFFFFF:X8}");
            var builder = new StringBuilder();

            // Prints the hexa version
            // # 0x____3____F____F____8____0____0____0____0____0____0____0____0____0____0____0____0
            builder.Append("0x");
            for (int i = 15; i >= 0; i--)
            {
                builder.Append("____");

                var v = (byte)(0xF & (u64 >> (i * 4)));
                builder.Append(v.ToString("X1"));
            }
            WriteHighlightLine($"    = {builder}");

            if (forDouble)
            {
                // Prints the double IEE754 mask
                // #    seee eeee eeee ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff
                WriteHighlightLine($"    #    seee eeee eeee ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff");
            }

            // Prints the binary version
            // # 0b_0011_1111_1111_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            builder.Length = 0;
            builder.Append("0b");
            for (int i = 15; i >= 0; i--)
            {
                builder.Append('_');

                var v = (byte)(0xF & (u64 >> (i * 4)));
                var leadingZero = BitOperations.LeadingZeroCount(v) - 28;
                builder.Append('0', leadingZero);
                if (v != 0) builder.Append(Convert.ToString(v, 2));
            }
            WriteHighlightLine($"    = {builder}");
        }

        private void WriteDouble(double f64, string title)
        {
            var u64 = (ulong)BitConverter.DoubleToInt64Bits(f64);
            WriteHighlightLine($"    # {title}");
            WriteHighlightLine($"    #");
            WriteUInt64(u64, true);

            // Prints the 16 bits indices
            WriteHighlightLine($"    #   63                48                  32                  16                   0");

            // Prints the binary version
            // #   s        eeee               ffffffffffffffffffffffffffffffffffffffffffffffffffff
            WriteHighlightLine($"    #");
            WriteHighlightLine($"    # sign    exponent              |-------------------- fraction --------------------|");
            // #   1 * 2 ^ (1023 - 1023) * 0b1.1000000000000000000000000000000000000000000000000000
            var sign = (u64 >> 63);
            var exponent = (u64 >> 52) & 0b_111_11111111;
            var fraction = (u64 << 12) >> 12;

            var builder = new StringBuilder();
            builder.Append(sign != 0 ? " -1" : "  1");
            builder.Append(" * 2 ^ (");
            // exponent == 0 => subnormals
            builder.Append($"{(exponent == 0 ? 1 : exponent),4} - 1023) * 0b{(exponent == 0 ? '0' : '1')}.");
            var leadingFractionZero = BitOperations.LeadingZeroCount(fraction) - 12;
            builder.Append('0', leadingFractionZero);
            if (fraction != 0) builder.Append(Convert.ToString((long)fraction, 2));
            WriteHighlightLine($"    = {builder}");
        }

        private void WriteFloat(float f32)
        {
            var u32 = (uint)BitConverter.SingleToInt32Bits(f32);
            WriteHighlightLine($"    # IEEE 754 - float - 32-bit");
            WriteHighlightLine($"    #");
            WriteInt32(u32, true);

            // Prints the 16 bits indices
            WriteHighlightLine($"    #   31      24        16         8         0");

            WriteHighlightLine($"    #");
            WriteHighlightLine($"    #  sign   exponent            |------ fraction -----|");
            //                                 #   1 * 2 ^ (127 - 127) * 0b1.10000000000000000000000

            var sign = (u32 >> 31);
            var exponent = (u32 >> 23) & 0b_111_11111111;
            var fraction = (u32 << 9) >> 9;

            var builder = new StringBuilder();
            builder.Append(sign != 0 ? " -1" : "  1");
            builder.Append(" * 2 ^ (");
            // exponent == 0 => subnormals
            builder.Append($"{(exponent == 0 ? 1 : exponent),3} - 127) * 0b{(exponent == 0 ? '0' : '1')}.");
            var leadingFractionZero = BitOperations.LeadingZeroCount(fraction) - 9;
            builder.Append('0', leadingFractionZero);
            if (fraction != 0) builder.Append(Convert.ToString((long)fraction, 2));
            WriteHighlightLine($"    = {builder}f");
        }

        public void WriteHighlightAligned(string prefix, string text, string nextPrefix = null)
        {
            var list = SplitStringBySpaceAndKeepSpace(text);
            if (list.Count == 0) return;

            var builder = new StringBuilder();
            bool lineHasItem = false;

            var maxColumn = Math.Min(Config.HelpMaxColumn, Console.BufferWidth);

            if (nextPrefix == null)
            {
                nextPrefix = prefix.StartsWith("#") ? "#" + new string(' ', prefix.Length - 1) : new string(' ', prefix.Length);
            }

            bool isFirstItem = false;

            int index = 0;
            while(index < list.Count)
            {
                var item = list[index];

                if (builder.Length == 0)
                {
                    lineHasItem = false;
                    builder.Append(prefix);
                    prefix = nextPrefix;
                    isFirstItem = true;
                }

                var nextLineLength = builder.Length + item.Length + 2;

                if (item != "\n" && (nextLineLength < maxColumn || !lineHasItem))
                {
                    if (isFirstItem && string.IsNullOrWhiteSpace(item))
                    {
                        // Don't append a space at the beginning of a line
                    }
                    else
                    {
                        builder.Append(item);
                        lineHasItem = true;
                        isFirstItem = false;
                    }
                    index++;
                }
                else
                {
                    WriteHighlightLine(builder.ToString());
                    if (item == "\n") index++;
                    builder.Length = 0;
                }
            }

            if (builder.Length > 0)
            {
                WriteHighlightLine(builder.ToString());
            }
        }

        internal void WriteErrorLine(string scriptText)
        {
            WriteError(scriptText);
            WriteHighlightLine();
        }

        internal void WriteError(string scriptText)
        {
            if (scriptText == null) throw new ArgumentNullException(nameof(scriptText));

            var output = _isInitializing ? _initializingText : _tempConsoleText;

            if (Writer != null)
            {
                if (output.Count > 0)
                {
                    Writer.Write(output);
                }
                output.Clear();
            }

            output.Append(ConsoleStyle.Red, true);
            output.Append(scriptText);
            output.Append(ConsoleStyle.Red, false);

            if (Writer != null)
            {
                Writer.Write(output);
                output.Clear();
            }
        }

        internal void WriteHighlightLine(string scriptText, bool highlight = true)
        {
            WriteHighlight(scriptText, highlight);
            WriteHighlightLine();
        }

        internal void WriteHighlightLine()
        {
            if (_isFirstWriteForEval)
            {
                Repl.ConsoleWriter.WriteLine();
                _isFirstWriteForEval = false;
            }

            NextOutput.AppendLine();
            NextOutput.Render(Repl.ConsoleWriter);
            Repl.ConsoleWriter.Commit();
            NextOutput.Clear();
            Repl.Reset();
        }

        internal void WriteHighlight(string scriptText, bool highlight = true)
        {
            var output = _isInitializing ? _initializingText : _tempConsoleText;

            if (Writer != null)
            {
                if (output.Count > 0)
                {
                    Writer.Write(output);
                }
                output.Clear();
                output.ClearStyles();
            }

            output.Append(scriptText);

            if (highlight)
            {
                // Highlight line per line
                Highlight(output);
            }

            if (Writer != null)
            {
                Writer.Write(output);

                // Output any errors that happened during initialization
                if (!_isInitializing && _initializingText.Count > 0)
                {
                    Writer.Write(_initializingText);
                }
            }

            if (!_isInitializing && _initializingText.Count > 0)
            {
                _initializingText.Clear();
            }

            output.Clear();
        }

        public void Highlight(ConsoleText text, int cursorIndex = -1)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            var textStr = text.ToString();
            var lexer = new Lexer(textStr, options: _lexerOptions);
            var tokens = lexer.ToList();

            UpdateSyntaxHighlighting(text, textStr, tokens);

            if (cursorIndex >= 0)
            {
                UpdateMatchingBraces(cursorIndex, text, tokens);
            }
        }

        private void UpdateSyntaxHighlighting(ConsoleText text, string textStr, List<Token> tokens)
        {
            if (textStr == null) return;

            bool isPreviousNotDot = true;
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                var styleOpt = GetStyle(i, token, textStr, isPreviousNotDot, tokens);
                isPreviousNotDot = token.Type != TokenType.Dot;

                if (styleOpt.HasValue)
                {
                    var style = styleOpt.Value;
                    var start = token.Start.Offset;
                    var end = token.End.Offset;
                    if (start >= 0 && end >= 0 && start <= end && end < text.Count)
                    {
                        text.EnableStyleAt(start, style);
                        text.DisableStyleAt(end + 1, style);
                    }
                }
            }
        }

        private void UpdateMatchingBraces(int cursorIndex, ConsoleText text, List<Token> tokens)
        {
            // Collect all braces open/close
            List<(int, int)> matchingBraces = null;
            List<int> pendingUnpairedBraces = null;
            List<int> unpairedBraces = null;
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                for (var j = 0; j < MatchPairs.Length; j++)
                {
                    var match = MatchPairs[j];
                    if (match == token.Type)
                    {
                        if (pendingUnpairedBraces == null)
                        {
                            matchingBraces = new List<(int, int)>();
                            pendingUnpairedBraces = new List<int>();
                            unpairedBraces = new List<int>();
                        }

                        bool processed = false;
                        bool isOpening = (j & 1) == 0;
                        if (pendingUnpairedBraces.Count > 0)
                        {
                            var toMatch = isOpening ? MatchPairs[j + 1] : MatchPairs[j - 1];
                            var leftIndex = pendingUnpairedBraces[pendingUnpairedBraces.Count - 1];
                            if (tokens[leftIndex].Type == toMatch)
                            {
                                pendingUnpairedBraces.RemoveAt(pendingUnpairedBraces.Count - 1);
                                matchingBraces.Add((leftIndex, i));
                                processed = true;
                            }
                        }

                        if (!processed)
                        {
                            if (isOpening)
                            {
                                pendingUnpairedBraces.Add(i);
                            }
                            else
                            {
                                // Closing that are not matching will never match, put them at the front of the braces that will never match
                                unpairedBraces.Add(i);
                            }
                        }
                        break;
                    }
                }
            }

            if (matchingBraces == null) return;

            unpairedBraces.AddRange(pendingUnpairedBraces);
            
            var tokenIndex = FindTokenIndexFromColumnIndex(cursorIndex, text.Count, tokens);
            var matchingCurrent = matchingBraces.Where(x => x.Item1 == tokenIndex || x.Item2 == tokenIndex).Select(x => ((int, int)?) x).FirstOrDefault();

            // Color current matching braces
            if (matchingCurrent.HasValue)
            {
                var leftIndex = tokens[matchingCurrent.Value.Item1].Start.Column;
                var rightIndex = tokens[matchingCurrent.Value.Item2].Start.Column;

                text.EnableStyleAt(leftIndex, ConsoleStyle.Underline);
                text.EnableStyleAt(leftIndex, ConsoleStyle.Bold);
                text.DisableStyleAt(leftIndex + 1, ConsoleStyle.Bold);
                text.DisableStyleAt(leftIndex + 1, ConsoleStyle.Underline);

                text.EnableStyleAt(rightIndex, ConsoleStyle.Underline);
                text.EnableStyleAt(rightIndex, ConsoleStyle.Bold);
                text.DisableStyleAt(rightIndex + 1, ConsoleStyle.Bold);
                text.DisableStyleAt(rightIndex + 1, ConsoleStyle.Underline);
            }

            // Color any braces that are not matching
            foreach (var invalid in unpairedBraces)
            {
                var invalidIndex = tokens[invalid].Start.Column;
                if (invalid == tokenIndex) text.EnableStyleAt(invalidIndex, ConsoleStyle.Underline);
                text.EnableStyleAt(invalidIndex, ConsoleStyle.BrightRed);
                text.DisableStyleAt(invalidIndex + 1, ConsoleStyle.BrightRed);
                if (invalid == tokenIndex) text.DisableStyleAt(invalidIndex + 1, ConsoleStyle.Underline);
            }
        }

        private int FindTokenIndexFromColumnIndex(int index, int textCount, List<Token> tokens)
        {
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                var start = token.Start.Column;
                var end = token.End.Column;
                if (start >= 0 && end >= 0 && start <= end && end < textCount)
                {
                    if (index >= start && index <= end)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private ConsoleStyle? GetStyle(int index, Token token, string text, bool isPreviousNotDot, List<Token> tokens)
        {
            switch (token.Type)
            {
                case TokenType.Integer:
                case TokenType.HexaInteger:
                case TokenType.BinaryInteger:
                case TokenType.Float:
                    return ConsoleStyle.Bold;
                case TokenType.String:
                case TokenType.VerbatimString:
                    return ConsoleStyle.BrightCyan;
                case TokenType.Comment:
                case TokenType.CommentMulti:
                    return ConsoleStyle.BrightGreen;
                case TokenType.Identifier:
                    var key = token.GetText(text);

                    if (isPreviousNotDot)
                    {
                        if ((index + 1 < tokens.Count && tokens[index + 1].Type == TokenType.Colon))
                        {
                            return ConsoleStyle.BrightWhite;
                        }

                        if (ScriptKeywords.Contains(key))
                        {
                            // Handle the case where for ... in, the in should be marked as a keyword
                            if (key != "in" || !(index > 1 && tokens[index - 2].GetText(text) == "for"))
                            {
                                return ConsoleStyle.BrightYellow;
                            }
                        }
                        if (Builtins.ContainsKey(key))
                        {
                            return ConsoleStyle.Cyan;
                        }
                        else if (Units.ContainsKey(key))
                        {
                            return ConsoleStyle.Yellow;
                        }
                    }

                    return ConsoleStyle.White;
                default:
                    return null;
            }
        }
    }
}