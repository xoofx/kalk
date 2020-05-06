using System;
using System.Collections.Generic;
using System.Linq;
using Consolus;
using Scriban.Parsing;
using Scriban.Runtime;

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

            var tokenIndex = FindTokenIndexFromColumnIndex(cursorIndex, text, tokens);
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

        private int FindTokenIndexFromColumnIndex(int index, ConsoleText text, List<Token> tokens)
        {
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                var start = token.Start.Column;
                var end = token.End.Column;
                if (start >= 0 && end >= 0 && start <= end && end < text.Count)
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

                    if (isPreviousNotDot && Builtins.ContainsKey(key))
                    {
                        return ConsoleStyle.Cyan;
                    }

                    return ConsoleStyle.BrightYellow;
                default:
                    return null;
            }
        }
    }
}