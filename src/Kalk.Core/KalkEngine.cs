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
        private readonly ConsoleText _tempOutputHighlight;
        private bool _hasResultOrVariableSet = false;
        private Action _showInputAction = null;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly bool _isInitializing;
        private bool _nextLetterIsSymbolShortcut;
        private int _startIndexForCompletion;
        private readonly List<string> _completionMatchingList;
        private int _currentIndexInCompletionMatchingList;
        private bool _isFirstWriteForEval;
        private readonly Dictionary<Type, KalkModule> _modules;
        
        private KalkShortcutKeyMap _currentShortcutKeyMap;

        public KalkEngine() : base(new KalkObjectWithAlias())
        {
            KalkSettings.Initialize();
            KalkEngineFolder = Path.GetDirectoryName(typeof(KalkEngine).Assembly.Location ?? Process.GetCurrentProcess().MainModule?.FileName);

            // Enforce UTF8 encoding
            Console.OutputEncoding = Encoding.UTF8;
            EnableEngineOutput = true;
            EchoEnabled = true;

            HighlightOutput = new ConsoleText();
            InputReader = Console.In;
            OutputWriter = Console.Out;
            ErrorWriter = Console.Error;
            IsOutputSupportHighlighting = ConsoleHelper.SupportEscapeSequences;

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
            _modules = new Dictionary<Type, KalkModule>();
            ErrorForStatementFunctionAsExpression = true;
            StrictVariables = true;
            UseScientific = true;
            LoopLimit = int.MaxValue; // no limits for loops
            RecursiveLimit = int.MaxValue; // no limits (still guarded by Scriban)

            _cancellationTokenSource = new CancellationTokenSource();

            PushGlobal(Units);
            PushGlobal(Variables);

            _parserOptions = new ParserOptions();

            _lexerOptions = new LexerOptions()
            {
                KeepTrivia = true,
                Mode = ScriptMode.ScriptOnly, 
                Lang = ScriptLang.Scientific
            };
            _tempOutputHighlight = new ConsoleText();

            // Init last result with 0
            _lastResult = 0;

            HistoryList = new List<string>();

            _isInitializing = true;
            RegisterFunctions();
            _isInitializing = false;
        }

        private ConsoleText HighlightOutput { get; }

        public string KalkEngineFolder { get; }

        internal ConsoleTextWriter BufferedOutputWriter { get; private set; }

        internal ConsoleTextWriter BufferedErrorWriter { get; private set; }

        public TextReader InputReader { get; set; }

        public TextWriter OutputWriter
        {
            get => BufferedOutputWriter?.Backend;
            set => BufferedOutputWriter = value == null ? null : new ConsoleTextWriter(value);
        }

        public TextWriter ErrorWriter
        {
            get => BufferedErrorWriter?.Backend;
            set => BufferedErrorWriter = value == null ? null : new ConsoleTextWriter(value);
        }

        public bool EchoEnabled { get; set; }

        public ScriptObject Builtins { get; }

        [KalkDoc("config", CategoryGeneral)]
        public KalkConfig Config { get; }

        public ScriptObject Variables { get; }

        public KalkAliases Aliases { get; }

        private bool EnableEngineOutput { get; set; }

        public bool IsOutputSupportHighlighting { get; set; }

        public bool HasInteractiveConsole { get; private set; }

        /// <summary>
        /// If used in an expression, returns an object containing all units defined.
        /// Otherwise it will display units in a friendly format.
        /// </summary>
        [KalkDoc("units", CategoryUnits)]
        public KalkUnits Units { get; }

        [KalkDoc("shortcuts", CategoryGeneral)]
        public KalkShortcuts Shortcuts { get; }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

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
            if (EnableEngineOutput && EchoEnabled)
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

        public override void Import(SourceSpan span, object objectToImport)
        {
            if (objectToImport is KalkModule module)
            {
                ImportModule(module);
                return;
            }

            base.Import(span, objectToImport);
        }

        protected void ImportModule(KalkModule module)
        {
            module.InternalImport();
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