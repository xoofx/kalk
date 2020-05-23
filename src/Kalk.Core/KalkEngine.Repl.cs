using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Consolus;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private Stopwatch _clockReplInput;

        public ConsoleRepl Repl { get; private set; }

        public int OnErrorToNextLineMaxDelayInMilliseconds { get; set; }

        private void InitializeRepl()
        {
            _clockReplInput = Stopwatch.StartNew();
            OnErrorToNextLineMaxDelayInMilliseconds = 300;

            OnClear = Clear;

            Repl.GetClipboardTextImpl = GetClipboardText;
            Repl.SetClipboardTextImpl = SetClipboardText;

            Repl.BeforeRender = OnBeforeRendering;
            Repl.GetCancellationTokenSource = () => _cancellationTokenSource;
            Repl.TryPreProcessKey = TryPreProcessKey;
            Repl.OnTextValidatingEnter = OnTextValidatingEnter;

            Repl.Prompt.Clear();
            Repl.Prompt.Begin(ConsoleStyle.BrightBlack).Append(">>> ").Append(ConsoleStyle.BrightBlack, false);
        }

        private bool OnTextValidatingEnter(string text, bool hasControl)
        {
            try
            {
                return OnTextValidatingEnterInternal(text, hasControl);
            }
            finally
            {
                _clockReplInput.Restart();
            }
        }

        private bool OnTextValidatingEnterInternal(string text, bool hasControl)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken = _cancellationTokenSource.Token;

            var elapsed = _clockReplInput.ElapsedMilliseconds;
            Template script = null;

            object result = null;
            string error = null;
            int column = -1;
            bool isCancelled = false;
            try
            {
                script = Parse(text);

                if (script.HasErrors)
                {
                    var errorBuilder = new StringBuilder();
                    foreach (var message in script.Messages)
                    {
                        if (errorBuilder.Length > 0) errorBuilder.AppendLine();
                        if (column <= 0 && message.Type == ParserMessageType.Error)
                        {
                            column = message.Span.Start.Column;
                        }
                        errorBuilder.Append(message.Message);
                    }

                    error = errorBuilder.ToString();
                }
                else
                {
                    Repl.AfterEditLine.Clear();
                    HighlightOutput.Clear();

                    result = EvaluatePage(script.Page);

                    if (Repl.ExitOnNextEval)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is ScriptRuntimeException scriptEx)
                {
                    column = scriptEx.Span.Start.Column;
                    error = scriptEx.OriginalMessage;
                    isCancelled = ex is ScriptAbortException;
                }
                else
                {
                    error = ex.Message;
                }
            }

            if (error != null)
            {
                Repl.AfterEditLine.Clear();
                Repl.AfterEditLine.Append('\n');
                Repl.AfterEditLine.Begin(ConsoleStyle.Red);
                Repl.AfterEditLine.Append(error);
                if (column >= 0 && column <= Repl.EditLine.Count)
                {
                    Repl.EnableCursorChanged = false;
                    Repl.CursorIndex = column;
                    Repl.EnableCursorChanged = true;
                }

                bool emitReturnOnError = hasControl || elapsed < OnErrorToNextLineMaxDelayInMilliseconds || isCancelled;
                if (emitReturnOnError)
                {
                    Repl.AfterEditLine.Append('\n');
                }

                return emitReturnOnError;
            }
            else
            {
                if (result != null)
                {
                    Write(script.Page.Span, result);
                }
                var resultStr = Output.ToString();
                var output = Output as StringBuilderOutput;
                if (output != null)
                {
                    output.Builder.Length = 0;
                }

                Repl.AfterEditLine.Clear();
                bool hasOutput = resultStr != string.Empty || HighlightOutput.Count > 0;
                if (!Repl.IsClean || hasOutput)
                {
                    Repl.AfterEditLine.Append('\n');

                    bool hasNextOutput = HighlightOutput.Count > 0;
                    if (hasNextOutput)
                    {
                        Repl.AfterEditLine.AddRange(HighlightOutput);
                        HighlightOutput.Clear();
                    }

                    if (resultStr != string.Empty)
                    {
                        if (hasNextOutput)
                        {
                            Repl.AfterEditLine.AppendLine();
                        }
                        Repl.AfterEditLine.Begin(ConsoleStyle.Bold);
                        Repl.AfterEditLine.Append(resultStr);
                    }

                    if (hasOutput)
                    {
                        Repl.AfterEditLine.AppendLine();
                    }
                }
            }

            return true;
        }


        private void OnEnterNextText(string textToEnter)
        {
            Repl?.EnqueuePendingTextToEnter(textToEnter);
        }

        private bool TryPreProcessKey(ConsoleKeyInfo arg, ref int cursorIndex)
        {
            return OnKey(arg, Repl.EditLine, ref cursorIndex);
        }

        private void OnBeforeRendering()
        {
            UpdateSyntaxHighlighting();
        }

        private void UpdateSyntaxHighlighting()
        {
            if (Repl != null)
            {
                Repl.EditLine.ClearStyles();
                Highlight(Repl.EditLine, Repl.CursorIndex);
            }
        }

        public void Clear()
        {
            Repl?.Clear();
            HighlightOutput.Clear();
        }

        public void ReplExit()
        {
            if (Repl == null) return;
            Repl.ExitOnNextEval = true;
        }

        internal bool OnKey(ConsoleKeyInfo arg, ConsoleText line, ref int cursorIndex)
        {
            try
            {
                if (arg.Key == ConsoleKey.Tab)
                {
                    if (OnCompletionRequested(arg, line, ref cursorIndex))
                    {
                        return true;
                    }
                }

                // Reset any completion if we are getting here
                ResetCompletion();

                KalkConsoleKey kalkKey = arg;
                //Console.Title = $"Key {StringFunctions.Escape(arg.KeyChar.ToString())} {arg.Key} {arg.Modifiers} - parsed {kalkKey}";

                if (cursorIndex >= 0 && cursorIndex <= line.Count)
                {
                    if (_currentShortcutKeyMap.TryGetValue(kalkKey, out var value))
                    {
                        if (value is KalkShortcutKeyMap map)
                        {
                            _currentShortcutKeyMap = map;
                        }
                        else
                        {
                            var expression = (ScriptExpression)value;
                            var result = EvaluateExpression(expression);
                            if (result != null)
                            {
                                var resultStr = result.ToString();
                                line.Insert(cursorIndex, resultStr);
                                cursorIndex += resultStr.Length;
                            }
                        }
                        return true;
                    }
                }


                _currentShortcutKeyMap = Shortcuts.ShortcutKeyMap;
            }
            catch
            {
                // Restore the root key map in case of an error.
                _currentShortcutKeyMap = Shortcuts.ShortcutKeyMap;
                throw;
            }

            return false;
        }

        private bool OnCompletionRequested(ConsoleKeyInfo arg, ConsoleText line, ref int cursorIndex)
        {
            // Nothing to complete
            if (cursorIndex == 0) return false;

            // We expect to have at least:
            // - one letter identifier before the before the cursor
            // - no letter identifier on the cursor (e.g middle of an existing identifier)
            if (cursorIndex < line.Count && IsIdentifierLetter(line[cursorIndex].Value) || !IsIdentifierLetter(line[cursorIndex - 1].Value))
            {
                return false;
            }

            if (!HasPendingCompletion)
            {
                if (!CollectCompletionList(line, cursorIndex))
                {
                    return false;
                }
            }

            return OnCompletionRequested(arg.Modifiers == ConsoleModifiers.Shift, line, ref cursorIndex);
        }

        private void ResetCompletion()
        {
            _currentIndexInCompletionMatchingList = 0;
            _completionMatchingList.Clear();
        }

        private bool CollectCompletionList(ConsoleText line, int cursorIndex)
        {
            var text = line.ToString();
            var lexer = new Lexer(text, options: _lexerOptions);
            var tokens = lexer.ToList();

            // Find that we are in a correct place
            var index = FindTokenIndexFromColumnIndex(cursorIndex, text.Length, tokens);
            if (index >= 0)
            {
                // If we are in the middle of a comment/integer/float/string
                // we don't expect to make any completion
                var token = tokens[index];
                switch (token.Type)
                {
                    case TokenType.Comment:
                    case TokenType.CommentMulti:
                    case TokenType.Identifier:
                    case TokenType.IdentifierSpecial:
                    case TokenType.Integer:
                    case TokenType.HexaInteger:
                    case TokenType.BinaryInteger:
                    case TokenType.Float:
                    case TokenType.String:
                    case TokenType.ImplicitString:
                    case TokenType.VerbatimString:
                        return false;
                }
            }

            // Look for the start of the work to complete
            _startIndexForCompletion = cursorIndex - 1;
            while (_startIndexForCompletion >= 0)
            {
                var c = text[_startIndexForCompletion];
                if (!IsIdentifierLetter(c))
                {
                    break;
                }

                _startIndexForCompletion--;
            }
            _startIndexForCompletion++;

            if (!IsFirstIdentifierLetter(text[_startIndexForCompletion]))
            {
                return false;
            }

            var startTextToFind = text.Substring(_startIndexForCompletion, cursorIndex - _startIndexForCompletion);

            Collect(startTextToFind, ScriptKeywords, _completionMatchingList);
            Collect(startTextToFind, Variables.Keys, _completionMatchingList);
            Collect(startTextToFind, Builtins.Keys, _completionMatchingList);

            // If we are not able to match anything from builtin and user variables/functions
            // continue on units
            if (_completionMatchingList.Count == 0)
            {
                Collect(startTextToFind, Units.Keys, _completionMatchingList);
            }
            return true;
        }

        private bool HasPendingCompletion => _currentIndexInCompletionMatchingList < _completionMatchingList.Count;

        private bool OnCompletionRequested(bool backward, ConsoleText line, ref int cursorIndex)
        {
            if (_currentIndexInCompletionMatchingList >= _completionMatchingList.Count) return false;

            var index = _startIndexForCompletion;
            var newText = _completionMatchingList[_currentIndexInCompletionMatchingList];

            line.RemoveRangeAt(index, cursorIndex - index);
            line.Insert(index, newText);
            cursorIndex = index + newText.Length;

            // Go to next word
            _currentIndexInCompletionMatchingList = (_currentIndexInCompletionMatchingList + (backward ? -1 : 1));

            // Wrap the result
            if (_currentIndexInCompletionMatchingList >= _completionMatchingList.Count) _currentIndexInCompletionMatchingList = 0;
            if (_currentIndexInCompletionMatchingList < 0) _currentIndexInCompletionMatchingList = _completionMatchingList.Count - 1;

            return true;
        }

        private static void Collect(string startText, IEnumerable<string> keys, List<string> matchingList)
        {
            foreach (var key in keys.OrderBy(x => x))
            {
                if (key.StartsWith(startText))
                {
                    matchingList.Add(key);
                }
            }
        }
        private static bool IsIdentifierCharacter(char c)
        {
            var newCategory = GetCharCategory(c);

            switch (newCategory)
            {
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.TitlecaseLetter:
                case UnicodeCategory.ModifierLetter:
                case UnicodeCategory.OtherLetter:
                case UnicodeCategory.NonSpacingMark:
                case UnicodeCategory.DecimalDigitNumber:
                case UnicodeCategory.ModifierSymbol:
                case UnicodeCategory.ConnectorPunctuation:
                    return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsFirstIdentifierLetter(char c)
        {
            return c == '_' || char.IsLetter(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsIdentifierLetter(char c)
        {
            return IsFirstIdentifierLetter(c) || char.IsDigit(c);
        }

        private static UnicodeCategory GetCharCategory(char c)
        {
            if (c == '_' || (c >= '0' && c <= '9')) return UnicodeCategory.LowercaseLetter;
            c = char.ToLowerInvariant(c);
            return char.GetUnicodeCategory(c);
        }
    }
}