﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
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
        private readonly LexerOptions _lexerInterpolatedOptions;
        private readonly ParserOptions _parserOptions;
        private object _lastResult = null;
        private readonly ConsoleText _tempOutputHighlight;
        private bool _hasResultOrVariableSet = false;
        private Action _showInputAction = null;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly bool _isInitializing;
        private int _startIndexForCompletion;
        private readonly List<string> _completionMatchingList;
        private int _currentIndexInCompletionMatchingList;
        private bool _isFirstWriteForEval;
        private readonly Dictionary<Type, KalkModule> _modules;
        private string _localClipboard;
        private bool _formatting;
        private readonly CultureInfo _integersCultureInfoWithUnderscore;
        
        private KalkShortcutKeyMap _currentShortcutKeyMap;

        public KalkEngine() : base(new KalkObjectWithAlias())
        {
            _integersCultureInfoWithUnderscore = new CultureInfo(CultureInfo.InvariantCulture.LCID)
            {
                NumberFormat =
                {
                    NumberGroupSeparator = "_",
                    NumberDecimalDigits = 0
                }
            };

            FileService = new DefaultFileService();
            KalkSettings.Initialize();
            KalkEngineFolder = AppContext.BaseDirectory;

            // Enforce UTF8 encoding
            Console.OutputEncoding = Encoding.UTF8;
            EnableEngineOutput = true;
            EchoEnabled = true;
            DisplayVersion = true;
            CurrentDisplay = KalkDisplayMode.Standard;
            KalkUserFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile, Environment.SpecialFolderOption.DoNotVerify), ".kalk");

            HighlightOutput = new ConsoleText();
            InputReader = Console.In;
            OutputWriter = Console.Out;
            ErrorWriter = Console.Error;
            IsOutputSupportHighlighting = ConsoleHelper.SupportEscapeSequences;

            // Fetch version
            var assemblyInfoVersion = (AssemblyInformationalVersionAttribute)typeof(KalkEngine).Assembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));
            Version = assemblyInfoVersion.InformationalVersion;

            Builtins = BuiltinObject;
            ((KalkObjectWithAlias)Builtins).Engine = this;

            Units = new KalkUnits(this);
            Shortcuts = new KalkShortcuts();
            Aliases = new KalkAliases();
            _currentShortcutKeyMap = Shortcuts.ShortcutKeyMap;
            _completionMatchingList = new List<string>();
            Config = new KalkConfig();
            Variables = new ScriptVariables(this);
            Descriptors = new Dictionary<string, KalkDescriptor>();
            EnableRelaxedMemberAccess = false;
            _modules = new Dictionary<Type, KalkModule>();
            TryConverters = new List<TryToObjectDelegate>();
            ErrorForStatementFunctionAsExpression = true;
            StrictVariables = true;
            UseScientific = true;
            LoopLimit = int.MaxValue; // no limits for loops
            RecursiveLimit = int.MaxValue; // no limits (still guarded by Scriban)

            // Setup default clipboard methods
            _localClipboard = string.Empty;
            GetClipboardText = GetClipboardTextImpl;
            SetClipboardText = SetClipboardTextImpl;

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
            _lexerInterpolatedOptions = new LexerOptions()
            {
                KeepTrivia = true,
                Mode = ScriptMode.Default,
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

        private void SetClipboardTextImpl(string obj)
        {
            _localClipboard = obj ?? string.Empty;
        }

        private string GetClipboardTextImpl()
        {
            return _localClipboard;
        }

        private ConsoleText HighlightOutput { get; }

        public IFileService FileService { get; set; }

        public bool DisplayVersion { get; set; }

        public string Version { get;  }

        public string KalkUserFolder { get; set; }

        /// <summary>
        /// The engine is in testing mode.
        /// </summary>
        public bool IsTesting { get; set; }

        public string KalkEngineFolder { get; }

        public Func<string, Stream> GetAppContentStream;

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

        public bool EchoInput { get; set; }

        public ScriptObject Builtins { get; }

        /// <summary>
        /// Gets the config object.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> config
        /// # config
        /// out = {help_max_column: 100, limit_to_string: "auto"}
        /// ```
        /// </example>
        [KalkExport("config", CategoryGeneral)]
        public KalkConfig Config { get; }

        public Action<string> SetClipboardText { get; set; }

        public Func<string> GetClipboardText { get; set; }
        
        public ScriptObject Variables { get; }

        /// <summary>
        /// Displays all built-in and user-defined aliases.
        /// </summary>
        /// <remarks>Aliases are usually used to define equivalent variable names for equivalent mathematical symbols. To create an alias, see the command `alias`.</remarks>
        /// <example>
        /// ```kalk
        /// >>> aliases
        /// # Builtin Aliases
        /// alias(alpha, Α, α)
        /// alias(beta, Β, β)
        /// alias(chi, Χ, χ)
        /// alias(delta, Δ, δ)
        /// alias(epsilon, Ε, ε)
        /// alias(eta, Η, η)
        /// alias(gamma, Γ, γ)
        /// alias(iota, Ι, ι)
        /// alias(kappa, Κ, κ)
        /// alias(lambda, Λ, λ)
        /// alias(mu, Μ, μ)
        /// alias(nu, Ν, ν)
        /// alias(omega, Ω, ω)
        /// alias(omicron, Ο, ο)
        /// alias(phi, Φ, φ, ϕ)
        /// alias(pi, Π, π)
        /// alias(psi, Ψ, ψ)
        /// alias(rho, Ρ, ρ)
        /// alias(sigma, Σ, σ)
        /// alias(tau, Τ, τ)
        /// alias(theta, Θ, θ, ϑ)
        /// alias(upsilon, Υ, υ)
        /// alias(xi, Ξ, ξ)
        /// alias(zeta, Ζ, ζ)
        /// ```
        /// </example>
        [KalkExport("aliases", CategoryGeneral)]
        public KalkAliases Aliases { get; }

        private bool EnableEngineOutput { get; set; }

        public bool IsOutputSupportHighlighting { get; set; }

        public bool HasInteractiveConsole { get; private set; }

        /// <summary>
        /// Displays all built-in and user-defined keyboard shortcuts.
        /// </summary>
        /// <remarks>To create an keyboard shortcut, see the command `shortcut`.</remarks>
        /// <example>
        /// ```kalk
        /// >>> clear shortcuts
        /// >>> shortcut(tester, "ctrl+d", '"' + date + '"')
        /// >>> shortcuts
        /// # User-defined Shortcuts
        /// shortcut(tester, "ctrl+d", '"' + date + '"')                 # ctrl+d => '"' + date + '"'
        /// ```
        /// </example>
        [KalkExport("shortcuts", CategoryGeneral)]
        public KalkShortcuts Shortcuts { get; }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

        public Action OnClearScreen { get; set; }

        public bool HasExit { get; private set; }

        public List<string> HistoryList { get; }

        public List<TryToObjectDelegate> TryConverters { get; }


        private static readonly Regex MatchHistoryRegex = new Regex(@"^\s*!(\d+)\s*");

        public Template Parse(string text, string filePath = null, bool recordHistory = true, bool interpolated = false)
        {
            if (!TryParseSpecialHistoryBangCommand(text, out var template))
            {
                var lexerOptions = interpolated ? _lexerInterpolatedOptions : _lexerOptions;
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
            // If we are in formatting mode, we use the normal output
            if (_formatting) return base.Write(span, textAsObject);

            SetLastResult(textAsObject);
            if (EnableEngineOutput && EchoEnabled)
            {
                WriteHighlightVariableAndValueToConsole("out", textAsObject);
            }
            return this;
        }

        public override string ObjectToString(object value, bool nested = false)
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
            else if (value is DateTime && _miscModule != null)
            {
                // Output DateTime only if we have the date builtin object accessible (that provides the implementation of the ToString method)
                return _miscModule.DateObject.ToString((DateTime)value, _miscModule.DateObject.Format, CurrentCulture);
            }
            
            if (CurrentDisplay != KalkDisplayMode.Raw && (value is int || value is uint || value is ulong || value is long || value is BigInteger || value is short || value is ushort))
            {
                return ((IFormattable)value).ToString("N", _integersCultureInfoWithUnderscore);
            }

            return base.ObjectToString(value, nested);
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

        public object ToObject(int argIndex, object value, Type destinationType)
        {
            try
            {
                return ToObject(CurrentSpan, value, destinationType);
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

        public override object ToObject(SourceSpan span, object value, Type destinationType)
        {
            var converters = TryConverters;
            if (converters.Count > 0)
            {
                foreach (var converter in converters)
                {
                    if (converter(span, value, destinationType, out var newValue))
                    {
                        return newValue;
                    }
                }
            }

            if (destinationType == typeof(KalkHalf))
            {
                return KalkHalf.FromObject(this, span, value);
            }

            return base.ToObject(span, value, destinationType);
        }

        public override bool ToBool(SourceSpan span, object value)
        {
            if (value is KalkBool kb) { return kb; }
            return base.ToBool(span, value);
        }
    }

    public delegate bool TryToObjectDelegate(SourceSpan span, object value, Type destinationType, out object newValue);
}