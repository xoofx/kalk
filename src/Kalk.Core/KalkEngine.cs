using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Consolus;
using Scriban;
using Scriban.Functions;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine : TemplateContext
    {
        private readonly LexerOptions _lexerOptions;
        private readonly ParserOptions _parserOptions;
        private object _lastResult = null;
        private readonly ConsoleText _tempConsoleText;
        private bool _hasResultOrVariableSet = false;
        private Action _showInputAction = null;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly ConsoleText _initializingText;
        private readonly bool _isInitializing;
        private bool _nextLetterIsSymbolShortcut;
        private int _startIndexForCompletion;
        private readonly List<string> _completionMatchingList;
        private int _currentIndexInCompletionMatchingList;
        private bool _isFirstWriteForEval;
        
        private KalkShortcutKeyMap _currentShortcutKeyMap;

        public KalkEngine() : base(new KalkObjectWithAlias())
        {
            KalkSettings.Initialize();
            KalkEngineFolder = Path.GetDirectoryName(typeof(KalkEngine).Assembly.Location ?? Process.GetCurrentProcess().MainModule?.FileName);

            // Enforce UTF8 encoding
            Console.OutputEncoding = Encoding.UTF8;
            EnableEngineOutput = true;
            Repl = new ConsoleRepl();
            HasInteractiveConsole = Repl.HasInteractiveConsole;
            
            Builtins = BuiltinObject;
            ((KalkObjectWithAlias)Builtins).Engine = this;

            Units = new KalkUnits(this);
            AsciiTable = new KalkAsciiTable();
            Shortcuts = new KalkShortcuts();
            Aliases = new KalkAliases();
            _currentShortcutKeyMap = Shortcuts.ShortcutKeyMap;
            _completionMatchingList = new List<string>();
            Config = new KalkConfig();
            Variables = new ScriptVariables(this);
            Descriptors = new Dictionary<string, KalkDescriptor>();
            EnableRelaxedMemberAccess = false;
            ErrorForStatementFunctionAsExpression = true;
            StrictVariables = true;
            UseScientific = true;
            LoopLimit = int.MaxValue; // no limites for loops
            RecursiveLimit = int.MaxValue; // no limits (still guarded by Scriban)

            _cancellationTokenSource = new CancellationTokenSource();

            RegisterVariable("config", Config, CategoryGeneral);

            PushGlobal(Units);
            PushGlobal(Variables);

            // Put the special history $ object as local
            SetValue(ScriptVariable.Create("", ScriptVariableScope.Local), Builtins["history"]);
            
            _parserOptions = new ParserOptions();

            _lexerOptions = new LexerOptions()
            {
                KeepTrivia = true,
                Mode = ScriptMode.ScriptOnly, 
                Lang = ScriptLang.Scientific
            };
            _tempConsoleText = new ConsoleText();
            _initializingText = new ConsoleText();

            // Init last result with 0
            _lastResult = 0;

            HistoryList = new List<string>();

            _isInitializing = true;
            RegisterFunctions();
            _isInitializing = false;
        }

        public string KalkEngineFolder { get; }

        public bool AllowEscapeSequences { get; set; }

        public ScriptObject Builtins { get; }

        public KalkConfig Config { get; }

        public ScriptObject Variables { get; }

        public KalkAliases Aliases { get; }

        public bool EnableEngineOutput { get; set; }

        public bool HasInteractiveConsole { get; }

        /// <summary>
        /// If used in an expression, returns an object containing all units defined.
        /// Otherwise it will display units in a friendly format.
        /// </summary>
        [KalkDoc("units")]
        public KalkUnits Units { get; }

        [KalkDoc("shortcuts")]
        public KalkShortcuts Shortcuts { get; }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

        public IKalkEngineWriter Writer { get; set; }

        public Action OnClear { get; set; }

        public bool HasExit { get; private set; }

        public List<string> HistoryList { get; }

        private static readonly Regex MatchHistoryRegex = new Regex(@"^\s*!(\d+)\s*");

        public Template Parse(string text, string filePath = null, bool recordHistory = true)
        {
            if (!TryParseSpecialHistoryBangCommand(text, out var template))
            {
                var lexerOptions = _lexerOptions;
                if (filePath != null)
                {
                    // Don't keep trivia when loading from a file as we are not going to format anything
                    // and it will make the parse errors correct (TODO: fix it when also parsing)
                    lexerOptions.KeepTrivia = false;
                }
                template = Template.Parse(text, filePath, parserOptions: _parserOptions, lexerOptions: lexerOptions);
            }

            if (recordHistory && text.Length != 0 && !template.HasErrors)
            {
                if (HistoryList.Count == 0 || HistoryList[^1] != text)
                {
                    HistoryList.Add(text);
                }
            }
            return template;
        }

        public object EvaluatePage(ScriptPage script)
        {
            _isFirstWriteForEval = true;
            RecordInput(script);
            return Evaluate(script);
        }

        public void RecordInput(ScriptPage toRewrite)
        {
            _hasResultOrVariableSet = false;
            _showInputAction = () =>
            {
                var newScript = toRewrite.Format(new ScriptFormatterOptions(this, ScriptLang.Scientific, ScriptFormatterFlags.ExplicitClean));
                var output = newScript.ToString();
                WriteHighlightLine($"# {output}");
            };
        }
        
        protected virtual void RecordSetVariable(string name, object value)
        {
            NotifyResultOrVariable();
            WriteHighlightVariableAndValueToConsole(name, value);
        }

        private void SetLastResult(object textAsObject)
        {
            _lastResult = textAsObject;
            NotifyResultOrVariable();
        }
        
        private void NotifyResultOrVariable()
        {
            if (_hasResultOrVariableSet) return;
            _hasResultOrVariableSet = true;

            _showInputAction?.Invoke();
            _showInputAction = null;
        }

        private bool AcceptUnit(ScriptExpression leftExpression, string unitName)
        {
            return !(leftExpression is ScriptVariable variable) || variable.Name != "help";
        }
        
        public override TemplateContext Write(SourceSpan span, object textAsObject)
        {
            if (EnableEngineOutput)
            {
                SetLastResult(textAsObject);
                WriteHighlightVariableAndValueToConsole("out", textAsObject);
            }
            return this;
        }

        public override string ObjectToString(object value, bool escape = false)
        {
            if (value is float f32)
            {
                if (float.IsNegativeInfinity(f32)) return "-inf";
                if (float.IsInfinity(f32)) return "inf";
                if (float.IsNaN(f32)) return "nan";
            }
            else if (value is double f64)
            {
                if (double.IsNegativeInfinity(f64)) return "-inf";
                if (double.IsInfinity(f64)) return "inf";
                if (double.IsNaN(f64)) return "nan";
            }

            return base.ObjectToString(value, escape);
        }

        protected override IObjectAccessor GetMemberAccessorImpl(object target)
        {
            if (target != null && target.GetType().IsPrimitiveOrDecimal())
            {
                return PrimitiveSwizzleAccessor.Default;
            }

            return base.GetMemberAccessorImpl(target);
        }

        private class ScriptVariables : KalkObjectWithAlias
        {
            public ScriptVariables(KalkEngine engine) : base(engine)
            {
            }

            public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
            {
                if (base.TrySetValue(context, span, member, value, readOnly))
                {
                    if (Engine.EnableEngineOutput)
                    {
                        Engine.RecordSetVariable(member, value);
                    }
                    return true;
                }
                return false;
            }
        }

        private class EmptyObject
        {
            public static readonly EmptyObject Instance = new EmptyObject();
            public override string ToString() => string.Empty;
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
                            var expression = (ScriptExpression) value;
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


        private void Collect(string startText, IEnumerable<string> keys, List<string> matchingList)
        {
            foreach (var key in keys.OrderBy(x => x))
            {
                if (key.StartsWith(startText))
                {
                    matchingList.Add(key);
                }
            }
        }

        public override void Import(IScriptObject obj)
        {
            if (obj is KalkModule module)
            {
                module.InternalImport();
                return;
            }

            base.Import(obj);
        }

        internal void UpdateEdit(ConsoleText text, int cursorIndex)
        {
            //if (_nextLetterIsSymbolShortcut)
            //{
            //    if (cursorIndex >= 0 && cursorIndex < text.Count)
            //    {
                    

            //    }

            //    _nextLetterIsSymbolShortcut = false;
            //}

            //var textStr = text.ToString();
            //var lexer = new Lexer(textStr, options: _lexerOptions);
            //var tokens = lexer.ToList();

            //StringBuilder newText = null;

            //for (int i = tokens.Count - 1; i >= 1; i--)
            //{
            //    var previousToken = tokens[i - 1];
            //    var token = tokens[i];
            //    if (token.Type == TokenType.Integer && previousToken.Type == TokenType.Caret)
            //    {
            //        var value = token.GetText(textStr);
            //        string replacement = null;
            //        switch (value)
            //        {
            //            case "2":
            //                replacement = "²";
            //                break;
            //            case "3":
            //                replacement = "³";
            //                break;
            //        }

            //        if (replacement == null)
            //            continue;

            //        if (newText == null)
            //            newText = new StringBuilder(textStr);

            //        newText.Remove(previousToken.Start.Offset, 2);
            //        newText.Insert(previousToken.Start.Offset, replacement);
            //    }
            //}

            //if (newText != null)
            //{
            //    text.ReplaceBy(newText.ToString());
            //}
        }
        public T ToObject<T>(int argIndex, object value)
        {
            try
            {
                return ToObject<T>(CurrentSpan, value);
            }
            catch (ScriptRuntimeException ex)
            {
                throw new ScriptArgumentException(argIndex, ex.OriginalMessage);
            }
            catch (Exception ex)
            {
                throw new ScriptArgumentException(argIndex, ex.Message);
            }
        }

    }
}