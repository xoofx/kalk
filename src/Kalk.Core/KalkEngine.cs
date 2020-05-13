using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
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

        private KalkShortcutKeyMap _currentShortcutKeyMap;

        public KalkEngine(bool tokens = false) : base(new ScriptObject())
        {
            KalkSettings.Initialize();
            KalkEngineFolder = Path.GetDirectoryName(typeof(KalkEngine).Assembly.Location ?? Process.GetCurrentProcess().MainModule?.FileName);

            // Enforce UTF8 encoding
            Console.OutputEncoding = Encoding.UTF8;
            EnableEngineOutput = true;
            Builtins = BuiltinObject;
            Units = new KalkUnits();
            Currencies = new KalkCurrencies(Units);
            AsciiTable = new KalkAsciiTable();
            Shortcuts = new KalkShortcuts();
            _currentShortcutKeyMap = Shortcuts.ShortcutKeyMap;
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
            InitializeFromConfig();
            _isInitializing = false;
        }

        public string KalkEngineFolder { get; }

        public bool AllowEscapeSequences { get; set; }

        public ScriptObject Builtins { get; }

        public KalkConfig Config { get; }

        public ScriptObject Variables { get; }

        public bool EnableEngineOutput { get; set; }

        /// <summary>
        /// If used in an expression, returns an object containing all units defined.
        /// Otherwise it will display units in a friendly format.
        /// </summary>
        [KalkDoc("units")]
        public KalkUnits Units { get; }
        
        [KalkDoc("currencies")]
        public KalkCurrencies Currencies { get; }

        [KalkDoc("shortcuts")]
        public KalkShortcuts Shortcuts { get; }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

        public IKalkEngineWriter Writer { get; set; }

        public Action OnExit { get; set; }

        public Action OnClear { get; set; }

        public bool HasExit { get; private set; }

        public List<string> HistoryList { get; }

        public Action<string> OnEnterNextText { get; set; }


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
                WriteHighlight($"# {output}");
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

        private class ScriptVariables : ScriptObject
        {
            private readonly KalkEngine _engine;

            public ScriptVariables(KalkEngine engine)
            {
                _engine = engine;
            }

            public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
            {
                if (base.TrySetValue(context, span, member, value, readOnly))
                {
                    if (_engine.EnableEngineOutput)
                    {
                        _engine.RecordSetVariable(member, value);
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


        private void InitializeFromConfig()
        {
            KalkCurrency.ConfigureCurrencies(this);
        }

        internal bool OnKey(ConsoleKeyInfo arg, ConsoleText line, ref int cursorIndex)
        {
            try
            {
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
    }

}