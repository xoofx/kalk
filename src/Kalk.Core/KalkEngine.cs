using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Consolus;
using Scriban;
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
        private Dictionary<string, string> _mapUnitNameToFunctionName;
        private bool _hasResultOrVariableSet = false;
        private Action _showInputAction = null;
        private CancellationTokenSource _cancellationTokenSource;

        public KalkEngine(bool tokens = false) : base(new ScriptObject())
        {
            Builtins = BuiltinObject;
            Descriptors = new Dictionary<string, KalkDescriptor>();
            EnableRelaxedMemberAccess = false;
            ErrorForStatementFunctionAsExpression = true;
            StrictVariables = true;
            UseScientific = true;
            RecursiveLimit = int.MaxValue; // no limits (still guarded by Scriban)

            _cancellationTokenSource = new CancellationTokenSource();

            RegisterFunctions();

            Config = new KalkConfig();
            RegisterVariable("config", Config, CategoryGeneral);

            Variables = new ScriptVariables(this);
            PushGlobal(Variables);

            // Put the special history $ object as local
            SetValue(ScriptVariable.Create("", ScriptVariableScope.Local), Builtins["history"]);


            _parserOptions = new ParserOptions();

            _mapUnitNameToFunctionName = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"kb", "kb"},
                {"mb", "mb"},
                {"gb", "gb"},
                {"tb", "tb"},
                {"i", "i"},
            };

            _lexerOptions = new LexerOptions()
            {
                KeepTrivia = true,
                Mode = ScriptMode.ScriptOnly, 
                Lang = ScriptLang.Scientific
            };
            _tempConsoleText = new ConsoleText();

            // Init last result with 0
            _lastResult = 0;

            HistoryList = new List<string>();
        }

        private void DeleteVariable(ScriptVariable variable)
        {
            if (variable == null) throw new ArgumentNullException(nameof(variable));
            Variables.Remove(variable.Name);
        }

        private object Last()
        {
            return _lastResult;
        }

        public ScriptObject Builtins { get; }

        public KalkConfig Config { get; }

        public ScriptObject Variables { get; }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

        public IKalkEngineWriter Writer { get; set; }

        public Action OnExit { get; set; }

        public Action OnClear { get; set; }

        public bool HasExit { get; private set; }

        public List<string> HistoryList { get; }

        public Action<string> OnEnterNextText { get; set; }


        private static readonly Regex MatchHistoryRegex = new Regex(@"^\s*!(\d+)\s*");
        
        public Template Parse(string text)
        {
            if (!TryParseSpecialHistoryBangCommand(text, out var template))
            {
                template = Template.Parse(text, parserOptions: _parserOptions, lexerOptions: _lexerOptions);
            }

            if (text.Length != 0 && !template.HasErrors)
            {
                if (HistoryList.Count == 0 || HistoryList[HistoryList.Count - 1] != text)
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

        public void Reset()
        {
            Variables.Clear();
        }

        protected virtual void RecordSetVariable(string name, object value)
        {
            NotifyResultOrVariable();
            WriteHighlightVariableAndValueToConsole(name, value);
        }


        public void ClearHistory()
        {
            HistoryList.Clear();
        }
        
        public void History(object line = null)
        {
            // Always remove the history command (which is the command being executed
            HistoryList.RemoveAt(HistoryList.Count - 1);

            if (HistoryList.Count == 0)
            {
                WriteHighlight("# History empty");
                return;
            }

            if (line != null)
            {
                int lineNumber;
                try
                {
                    lineNumber = ToInt(new SourceSpan(), line);
                }
                catch
                {
                    throw new ArgumentException("Invalid history line number. Must be an integer.", nameof(line));
                }

                if (lineNumber >= 0 && lineNumber < HistoryList.Count)
                {
                    OnEnterNextText?.Invoke(HistoryList[lineNumber]);
                }
                else if (lineNumber < 0)
                {
                    lineNumber = HistoryList.Count + lineNumber;
                    if (lineNumber < 0) lineNumber = 0;
                    for (int i = lineNumber; i < HistoryList.Count; i++)
                    {
                        WriteHighlight($"{i}: {HistoryList[i]}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid history index. Check with `history` command.", nameof(line));
                }
            }
            else
            {
                for (int i = 0; i < HistoryList.Count; i++)
                {
                    WriteHighlight($"{i}: {HistoryList[i]}");
                }
            }
        }

        public static object Kb(object value)
        {
            if (value == null) return null;
            if (value is int vInt32) return (long)vInt32 * 1024;
            if (value is long vInt64) return vInt64 * 1024;

            throw new ArgumentOutOfRangeException(nameof(value));
        }

        public static object Mb(object value)
        {
            if (value == null) return null;
            if (value is int vInt32)
            {
                return (long)vInt32 * 1024 * 1024;
            }
            if (value is long vInt64) return vInt64 * 1024 * 1024;

            throw new ArgumentOutOfRangeException(nameof(value));
        }

        public static object Gb(object value)
        {
            if (value == null) return null;
            if (value is int vInt32) return (long)vInt32 * 1024 * 1024 * 1024;
            if (value is long vInt64) return vInt64 * 1024 * 1024 * 1024;

            throw new ArgumentOutOfRangeException(nameof(value));
        }

        public static object ComplexNumber(object value = null)
        {
            if (value == null) return new KalkComplex(0, 1);

            if (value is BigInteger bigInt) return new KalkComplex(0, (double)bigInt);
            if (value is double vFloat64) return new KalkComplex(0, vFloat64);
            if (value is float vFloat32) return new KalkComplex(0, vFloat32);
            if (value is long vInt64) return new KalkComplex(0, vInt64);
            if (value is int vInt32) return new KalkComplex(0, vInt32);

            throw new ArgumentOutOfRangeException(nameof(value));
        }

        public static object Tb(object value)
        {
            if (value == null) return null;
            if (value is int vInt32)
            {
                return new BigInteger(vInt32) * 1024 * 1024 * 1024 * 1024;
            }

            if (value is long vInt64)
            {
                return new BigInteger(vInt64) * 1024 * 1024 * 1024 * 1024;
            }

            return value;
        }

        private void Exit()
        {
            HasExit = true;
            OnExit?.Invoke();
        }

        /// <summary>
        /// Clears the screen (by default) or the history (e.g clear history).
        /// </summary>
        /// <param name="what">An optional argument specifying what to clear. Can be of the following value:
        /// * screen: to clear the screen (default if not passed)
        /// * history: to clear the history
        /// </param>
        [KalkDoc("cls")]
        public void Clear(ScriptExpression what = null)
        {
            if (what != null)
            {
                if (what is ScriptVariableGlobal variable)
                {
                    switch (variable.Name)
                    {
                        case "history": ClearHistory();
                            return;
                        case "screen": goto clearScreen;
                    }
                }
                throw new ArgumentException("Unexpected argument. `clear` command accepts only `screen` or `history` arguments.");
            }

            clearScreen:

            OnClear?.Invoke();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        public void Help(ScriptExpression expression = null)
        {
            if (Writer == null) return;

            var name = expression?.ToString();
            if (name != null && name != "help")
            {
                if (Descriptors.TryGetValue(name, out var descriptor))
                {
                    WriteHelpForDescriptor(descriptor);
                    return;
                }

                throw new ArgumentException($"The builtin function `{name}` does not exist", nameof(expression));
            }


            var random = new Random();
            WriteHighlight($"# help [name]");
            if (name == "help")
            {
                WriteHighlight($"#");
                WriteHighlight($"# Example");
                WriteHighlight($"  help # Display a list of function and topic names to get help from.");
                WriteHighlight($"  help {Descriptors.Select(x => x.Key).ElementAt(random.Next(0, Descriptors.Count - 1))} # Display the help for the specific function or topic.");
            }

            if (name == null)
            {
                var categoryToDescriptors = Descriptors.GroupBy(x => x.Value.Category).ToDictionary(x => x.Key, y => y.Select(x => x.Value).Distinct().ToList());
                WriteHighlight($"#");
                foreach (var categoryPair in categoryToDescriptors.OrderBy(x => x.Key))
                {
                    var list = categoryPair.Value;
                    WriteHighlight($"# {categoryPair.Key}");

                    var builder = new StringBuilder();
                    var names = list.SelectMany(x => x.Names).OrderBy(x => x).ToList();

                    WriteHighlightAligned("    - ", string.Join(", ", names));
                    WriteHighlight("");
                }
            }
        }

        private static List<string> SplitStringBySpaceAndKeepSpace(string text)
        {
            // normalize line endings with \n
            text = text.Replace("\r\n", "\n").Replace("\r", "\n");
            var list = new List<string>();
            var builder = new StringBuilder();
            bool isCurrentWhiteSpace = false;
            for(int i = 0; i < text.Length; i++)
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

        private void WriteHighlightAligned(string prefix, string text, string nextPrefix = null)
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
            foreach (var item in list)
            {
                while (true)
                {
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
                        break;
                    }
                    else
                    {
                        WriteHighlight(builder.ToString());
                        builder.Length = 0;
                        break;
                    }
                }
            }

            if (builder.Length > 0)
            {
                WriteHighlight(builder.ToString());
            }
        }

        private void ListVariables()
        {
            if (Writer == null) return;
            
            // Highlight line per line
            if (Variables.Count == 0)
            {
                WriteHighlight("# No variables");
                return;
            }

            bool writeHeading = true;

            List<KeyValuePair<string, object>> functions = null;

            // Write variables
            foreach (var variableKeyPair in Variables)
            {
                if (variableKeyPair.Value is ScriptFunction function && !function.IsAnonymous)
                {
                    if (functions == null) functions = new List<KeyValuePair<string, object>>();
                    functions.Add(variableKeyPair);
                    continue;

                }
                if (writeHeading)
                {
                    WriteHighlight("# Variables");
                    writeHeading = false;
                }
                WriteHighlightVariableAndValueToConsole(variableKeyPair.Key, variableKeyPair.Value);
            }

            // Write functions
            if (functions != null)
            {
                WriteHighlight("# Functions");
                foreach (var variableKeyPair in functions)
                {
                    WriteHighlightVariableAndValueToConsole(variableKeyPair.Key, variableKeyPair.Value);
                }
            }
        }

        internal void WriteHighlight(string scriptText)
        {
            _tempConsoleText.Clear();

            _tempConsoleText.Append(scriptText);

            // Highlight line per line
            Highlight(_tempConsoleText);
            Writer.Write(_tempConsoleText);
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

        private void WriteHighlightVariableAndValueToConsole(string name, object value)
        {
            if (value is string)
            {
                value = $"\"{value}\"";
            }

            if (value is ScriptFunction function && !function.IsAnonymous)
            {
                WriteHighlight($"{value}");
            }
            else
            {
                WriteHighlight($"{name} = {ObjectToString(value)}");
            }
        }

        public void Version()
        {
            if (Writer == null) return;

            var text = new ConsoleText();
            text.Begin(ConsoleStyle.BrightRed).Append('k').End(ConsoleStyle.BrightRed);
            text.Begin(ConsoleStyle.BrightYellow).Append('a').End(ConsoleStyle.BrightYellow);
            text.Begin(ConsoleStyle.BrightGreen).Append('l').End(ConsoleStyle.BrightGreen);
            text.Begin(ConsoleStyle.BrightCyan).Append('k').End(ConsoleStyle.BrightCyan);
            text.Append($" 1.0.0 - Copyright (c) 2020 Alexandre Mutel");

            Writer.Write(text);
        }

        private bool AcceptUnit(ScriptExpression leftExpression, string unitName)
        {
            return !(leftExpression is ScriptVariable variable) || variable.Name != "help";
        }
        
        public override TemplateContext Write(SourceSpan span, object textAsObject)
        {
            SetLastResult(textAsObject);
            WriteHighlightVariableAndValueToConsole("out", textAsObject);
            return this;
        }

        public override string ObjectToString(object value)
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

            return base.ObjectToString(value);
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
                    _engine.RecordSetVariable(member, value);
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

        /// <summary>
        /// Parse !0 history command.
        /// </summary>
        private bool TryParseSpecialHistoryBangCommand(string text, out Template template)
        {
            template = null;
            var matchHistory = MatchHistoryRegex.Match(text);
            if (matchHistory.Success)
            {
                var historyCmd = $"history({matchHistory.Groups[1].Value})";
                template = Template.Parse(historyCmd, null, _parserOptions, _lexerOptions);
                return true;
            }

            return false;
        }

        //ParseExpressionResult ICustomParser.TryParseFirstExpression(Parser parser, out ScriptExpression leftOperand, int precedence)
        //{
        //    if (parser.CurrentToken.Type == TokenType.Exclamation && parser.PeekToken().Type == TokenType.Integer)
        //    {
        //        var exclamationSpan = parser.CurrentSpan;
        //        var call = parser.Open<ScriptFunctionCall>();
        //        call.Target = new ScriptVariableGlobal("history");

        //        parser.NextToken(); // Skip exclamation

        //        var historyArg = parser.ParseInteger();
        //        call.Arguments.Add(historyArg);

        //        parser.Close(call);

        //        if (parser.ExpressionLevel > 1)
        //        {
        //            parser.LogError(exclamationSpan, $"The history command cannot be nested.");
        //        }

        //        leftOperand = call;

        //        return ParseExpressionResult.Return;
        //    }
        //    else
        //    {
        //        leftOperand = null;
        //    }

        //    return ParseExpressionResult.Continue;
        //}

        private void WriteHelpForDescriptor(KalkDescriptor descriptor)
        {
            var parentless = descriptor.IsCommand && descriptor.Params.Count <= 1;
            var args = string.Join(", ", descriptor.Params.Select(x => x.IsOptional ? $"[{x.Name}]" :x.Name));

            var syntax = string.Join("/", descriptor.Names);

            if (!string.IsNullOrEmpty(args))
            {
                syntax += parentless ? $" {args}" : $"({args})";
            }

            WriteHighlight($"# {syntax}");
            WriteHighlight($"#");
            if (string.IsNullOrEmpty(descriptor.Description))
            {
                WriteHighlight($"#   No documentation available.");
            }
            else
            {
                WriteHighlightAligned($"#   ", descriptor.Description);
                if (descriptor.Params.Count > 0)
                {
                    WriteHighlight($"#");
                    WriteHighlight($"# Parameters");
                    foreach (var par in descriptor.Params)
                    {
                        WriteHighlightAligned($"#   - {par.Name}: ", par.Description);
                    }
                }
                if (!string.IsNullOrEmpty(descriptor.Returns))
                {
                    WriteHighlight($"#");
                    WriteHighlight($"# Returns");
                    WriteHighlightAligned($"#   ", descriptor.Returns);
                }
            }
        }

        internal void UpdateEdit(ConsoleText text)
        {
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