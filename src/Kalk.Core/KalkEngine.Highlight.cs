using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consolus;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private static readonly TokenType[] MatchPairs = new[]
        {
            TokenType.OpenParen,
            TokenType.CloseParen,
            TokenType.OpenBracket,
            TokenType.CloseBracket,
            TokenType.OpenBrace,
            TokenType.CloseBrace,
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
                WriteHighlightLine($"{name} = {ObjectToString(value, true)}", value as IKalkConsolable);
            }
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

        internal void WriteHighlightLine(string scriptText, IKalkConsolable consolable = null)
        {
            WriteHighlight(scriptText, consolable);
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

        internal void WriteHighlight(string scriptText, IKalkConsolable consolable = null)
        {
            var output = _isInitializing ? _initializingText : _tempConsoleText;

            if (Writer != null)
            {
                if (output.Count > 0)
                {
                    Writer.Write(output);
                }
                output.Clear();
            }

            output.Append(scriptText);

            // Highlight line per line
            Highlight(output);

            if (consolable != null)
            {
                consolable.ToConsole(this, output);
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
            text.ClearStyles();

            if (textStr == null) return;

            bool isPreviousNotDot = true;
            foreach (var token in tokens)
            {
                var styleOpt = GetStyle(token, textStr, isPreviousNotDot);
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
            List<int> unpairedBraces = null;
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                for (var j = 0; j < MatchPairs.Length; j++)
                {
                    var match = MatchPairs[j];
                    if (match == token.Type)
                    {
                        if (unpairedBraces == null)
                        {
                            matchingBraces = new List<(int, int)>();
                            unpairedBraces = new List<int>();
                        }

                        bool processed = false;
                        bool isOpening = (j & 1) == 0;
                        if (unpairedBraces.Count > 0)
                        {
                            var toMatch = isOpening ? MatchPairs[j + 1] : MatchPairs[j - 1];
                            var leftIndex = unpairedBraces[unpairedBraces.Count - 1];
                            if (tokens[leftIndex].Type == toMatch)
                            {
                                unpairedBraces.RemoveAt(unpairedBraces.Count - 1);
                                matchingBraces.Add((leftIndex, i));
                                processed = true;
                            }
                        }

                        if (!processed)
                        {
                            if (isOpening)
                            {
                                unpairedBraces.Add(i);
                            }
                            else
                            {
                                // Closing that are not matching will never match, put them at the front of the braces that will never match
                                unpairedBraces.Insert(0, i);
                            }
                        }
                        break;
                    }
                }
            }

            if (matchingBraces == null) return;

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

        private ConsoleStyle? GetStyle(Token token, string text, bool isPreviousNotDot)
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
                        if (Builtins.ContainsKey(key))
                        {
                            return ConsoleStyle.Cyan;
                        }
                        else if (Units.ContainsKey(key))
                        {
                            return ConsoleStyle.Yellow;
                        }
                    }

                    return ConsoleStyle.BrightYellow;
                default:
                    return null;
            }
        }
    }
}