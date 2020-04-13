using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Consolus;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkApp
    {
        private readonly TemplateContext _scriptContext;
        private LexerOptions _lexerOptions;
        private ParserOptions _parserOptions;
        private ScriptObject _builtins;
        private Stopwatch _clockInput;
        private string _lastText;
        private readonly List<Token> _lastTokens;
        private readonly ScriptObject _variables;

        private static readonly TokenType[] MatchPairs = new[]
        {
            TokenType.OpenParent,
            TokenType.CloseParent,
            TokenType.OpenBracket,
            TokenType.CloseBracket,
            TokenType.OpenBrace,
            TokenType.CloseBrace,
        };

        public KalkApp()
        {
            _clockInput = Stopwatch.StartNew();
            OnErrorToNextLineMaxDelayInMilliseconds = 200;

            _lastTokens = new List<Token>();

            NextOutput = new ConsoleText();

            Repl = new ConsoleRepl();
            Repl.BeforeRender = OnBeforeRendering;
            Repl.OnTextCompletion = (text, back) =>
            {
                if (text.StartsWith("s"))
                {
                    return "sin";
                }

                if (text.StartsWith("h"))
                {
                    return "help";
                }

                if (text.StartsWith("tad"))
                {
                    return "tadaboom";
                }

                return null;
            };

            Repl.Prompt.Clear();
            Repl.Prompt.Append(ConsoleStyle.BrightBlack).Append(">>> ").Append(ConsoleStyle.BrightBlack, false);

            //Repl.TextAfterLine.Append('\n');
            //Repl.TextAfterLine.Append(ConsoleStyle.Red);
            //Repl.TextAfterLine.Append("This is a red text right after");

            _scriptContext = new TemplateContext
            {
                EnableRelaxedMemberAccess = false,
                StrictVariables = true
            };

            _scriptContext.BuiltinObject.Import("help", new Action<ScriptExpression>(Help));
            _scriptContext.BuiltinObject.Import("reset", new Action(Reset));
            _scriptContext.BuiltinObject.Import("exit", new Action(Exit));
            _scriptContext.BuiltinObject.Import("clear", new Action(Clear));
            _scriptContext.BuiltinObject.Import("log", new Func<double, double>(Log));
            _scriptContext.BuiltinObject.Import("cos", new Func<double, double>(Math.Cos));
            _scriptContext.BuiltinObject.Import("sin", new Func<double, double>(Math.Sin));

            _scriptContext.BuiltinObject.Import("kb", new Func<object, object>(Kb));
            _scriptContext.BuiltinObject.Import("mb", new Func<object, object>(Mb));
            _scriptContext.BuiltinObject.Import("gb", new Func<object, object>(Gb));
            _scriptContext.BuiltinObject.Import("tb", new Func<object, object>(Tb));
            _scriptContext.BuiltinObject.Import("im", new Func<object, object>(ComplexNumber));

            _variables = new ScriptObject();
            _scriptContext.PushGlobal(_variables);

            _builtins = new ScriptObject();
            foreach (var builtin in _scriptContext.BuiltinObject)
            {
                _builtins[builtin.Key] = builtin.Value;
            }
            
            _parserOptions = new ParserOptions()
            {
                Units = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
                {
                    {"kb", "kb"},
                    {"mb", "mb"},
                    {"gb", "gb"},
                    {"tb", "tb"},
                    { "i", "im"},
                },
                CollectTokens = true,
            };

            _lexerOptions = new LexerOptions() {Mode = ScriptMode.ScriptOnly, Level = ScriptSyntaxLevel.Scientific};

            Template script = null;

            Repl.EditLine.Changed = OnTextChanged;

            Repl.OnTextValidatingEnter = text =>
            {
                var elapsed = _clockInput.ElapsedMilliseconds;
                _clockInput.Restart();

                object result = null;
                string error = null;
                int column = -1;
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
                        NextOutput.Clear();

                        result = _scriptContext.Evaluate(script.Page);

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
                    Repl.AfterEditLine.Append(ConsoleStyle.Red);
                    Repl.AfterEditLine.Append(error);
                    if (column >= 0 && column <= Repl.EditLine.Count)
                    {
                        Repl.EnableCursorChanged = false;
                        Repl.CursorIndex = column;
                        Repl.EnableCursorChanged = true;
                    }

                    if (elapsed < OnErrorToNextLineMaxDelayInMilliseconds)
                    {
                        Repl.AfterEditLine.Append('\n');
                    }

                    return elapsed < OnErrorToNextLineMaxDelayInMilliseconds;
                }
                else
                {
                    if (result != null)
                    {
                        _scriptContext.Write(script.Page.Span, result);
                    }
                    var resultStr = _scriptContext.Output.ToString();
                    var output = _scriptContext.Output as StringBuilderOutput;
                    if (output != null)
                    {
                        output.Builder.Length = 0;
                    }

                    Repl.AfterEditLine.Clear();
                    bool hasOutput = resultStr != string.Empty || NextOutput.Count > 0;
                    if (!Repl.IsClean || hasOutput)
                    {
                        Repl.AfterEditLine.Append('\n');

                        bool hasNextOutput = NextOutput.Count > 0;
                        if (hasNextOutput)
                        {
                            Repl.AfterEditLine.AddRange(NextOutput);
                            NextOutput.Clear();
                        }

                        if (resultStr != string.Empty)
                        {
                            if (hasNextOutput)
                            {
                                Repl.AfterEditLine.AppendLine();
                            }
                            Repl.AfterEditLine.Append(ConsoleStyle.Bold);
                            Repl.AfterEditLine.Append(resultStr);
                        }

                        if (hasOutput)
                        {
                            Repl.AfterEditLine.AppendLine();
                        }
                    }
                }

                return true;
            };
        }

        public ConsoleText NextOutput { get; }


        private void UpdateMatchingBraces()
        {
            if (_lastText == null) return;

            var tokenIndex = FindTokenIndexFromColumnIndex(Repl.CursorIndex);

            if (tokenIndex >= 0)
            {
                var token = _lastTokens[tokenIndex];
                int matchTokenIndex = -1;
                
                // Find there is a pair to match
                int currentType = -1;
                for (var i = 0; i < MatchPairs.Length; i++)
                {
                    var match = MatchPairs[i];
                    if (match == token.Type)
                    {
                        currentType = i;
                        break;
                    }
                }

                if (currentType >= 0)
                {
                    var other = token.Type;
                    var toFind = (currentType & 1) == 0 ? MatchPairs[currentType + 1]: MatchPairs[currentType - 1];

                    int found = -1;
                    var delta = (currentType & 1) == 0 ? 1 : -1;

                    for (int j = tokenIndex + delta; j >= 0 && j < _lastTokens.Count; j += delta)
                    {
                        var nextToken = _lastTokens[j];
                        if (nextToken.Type == toFind)
                        {
                            found++;
                            if (found == 0)
                            {
                                matchTokenIndex = j;
                                break;
                            }
                        }
                        else if (nextToken.Type == other)
                        {
                            found--;
                        }
                    }

                    bool match = matchTokenIndex >= 0;

                    var tokenStart = token.Start.Column;
                    Repl.EditLine.EnableStyleAt(tokenStart, ConsoleStyle.Underline);
                    Repl.EditLine.EnableStyleAt(tokenStart, match ? ConsoleStyle.Bold : ConsoleStyle.BrightRed);
                    Repl.EditLine.DisableStyleAt(tokenStart + 1, match ? ConsoleStyle.Bold : ConsoleStyle.BrightRed);
                    Repl.EditLine.DisableStyleAt(tokenStart + 1, ConsoleStyle.Underline);

                    if (match)
                    {
                        var tokenMatch = _lastTokens[matchTokenIndex].Start.Column;
                        Repl.EditLine.EnableStyleAt(tokenMatch, ConsoleStyle.Underline);
                        Repl.EditLine.EnableStyleAt(tokenMatch, ConsoleStyle.Bold);
                        Repl.EditLine.DisableStyleAt(tokenMatch + 1, ConsoleStyle.Bold);
                        Repl.EditLine.DisableStyleAt(tokenMatch + 1, ConsoleStyle.Underline);
                    }
                }
            }
        }

        private int FindTokenIndexFromColumnIndex(int index)
        {
            for (var i = 0; i < _lastTokens.Count; i++)
            {
                var token = _lastTokens[i];
                var start = token.Start.Column;
                var end = token.End.Column;
                if (start >= 0 && end >= 0 && start <= end && end < Repl.EditLine.Count)
                {
                    if (index >= start && index <= end)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public long OnErrorToNextLineMaxDelayInMilliseconds { get; set; }


        private Template Parse(string text)
        {
            var template = Template.Parse(text, parserOptions: _parserOptions, lexerOptions: _lexerOptions);
            _lastTokens.Clear();
            _lastTokens.AddRange(template.Tokens);
            return template;
        }

        private void OnTextChanged()
        {
            _lastText = Repl.EditLine.ToString();
            Parse(_lastText);
        }

        private void OnBeforeRendering()
        {
            UpdateSyntaxHighlighting();
            UpdateMatchingBraces();
        }
        
        private void UpdateSyntaxHighlighting()
        {
            Repl.EditLine.ClearStyles();

            if (_lastText == null) return;

            bool isPreviousNotDot = true;
            foreach (var token in _lastTokens)
            {
                var styleOpt = GetStyle(token, _lastText, isPreviousNotDot);
                isPreviousNotDot = token.Type != TokenType.Dot;

                if (styleOpt.HasValue)
                {
                    var style = styleOpt.Value;
                    var start = token.Start.Column;
                    var end = token.End.Column;
                    if (start >= 0 && end >= 0 && start <= end && end < Repl.EditLine.Count)
                    {
                        Repl.EditLine.EnableStyleAt(start, style);
                        Repl.EditLine.DisableStyleAt(end + 1, style);
                    }
                }
            }
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
                    
                    if (isPreviousNotDot && _builtins.ContainsKey(key))
                    {
                        return ConsoleStyle.Cyan;
                    }

                    return ConsoleStyle.BrightYellow;
                default:
                    return null;
            }
        }

        public void Clear()
        {
            Repl.Clear();
        }

        public static double Log(double value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), $"Invalid value {value} for log. Expecting >= 0.");

            return Math.Log(value);
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

        public static object ComplexNumber(object value)
        {
            if (value == null) return null;

            if (value is double vFloat64) return new Complex(0, vFloat64);
            if (value is float vFloat32) return new Complex(0, vFloat32);
            if (value is long vInt64) return new Complex(0, vInt64);
            if (value is int vInt32) return new Complex(0, vInt32);

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

        public void Exit()
        {
            Repl.ExitOnNextEval = true;
        }

        public void Reset()
        {
            _variables.Clear();
        }

        public void Help(ScriptExpression expression = null)
        {
            if (NextOutput.Count > 0) NextOutput.AppendLine();
            NextOutput.Append(ConsoleStyle.Green).Append("This is a text").Append("\n");
            if (expression != null)
            {
                NextOutput.Append($"Asking about command : {expression}");
            }
            NextOutput.AppendLine();
            NextOutput.Append(ConsoleStyle.White).Append("This is another text");
        }
        
        public ConsoleRepl Repl { get; }
        
        public void Run()
        {
            try
            {
                if (ConsoleRepl.IsSelf())
                {
                    Console.Title = "kalk 1.0.0";
                }
            }
            catch
            {
                // ignore
            }

            if (ConsoleHelper.SupportEscapeSequences)
            {
                Console.WriteLine($"{ConsoleStyle.BrightRed}k{ConsoleStyle.BrightYellow}a{ConsoleStyle.BrightGreen}l{ConsoleStyle.BrightCyan}k{ConsoleStyle.Reset} 1.0.0 - Copyright (c) 2020 Alexandre Mutel");
            }
            else
            {
                Console.WriteLine("kalk 1.0.0 - Copyright (c) 2020 Alexandre Mutel");
            }

            //Console.CursorVisible = false;
            //Console.Write("test");
            //Console.CursorVisible = true;
            //var key = Console.ReadKey(true);
            //var left = Console.CursorLeft;
            //var top = Console.CursorTop;
            //int count = 0;
            //var clock = Stopwatch.StartNew();
            //while (true)
            //{
            //    var key = Console.ReadKey(true);
            //    if ((key.Modifiers & ConsoleModifiers.Control) != 0 && key.Key == ConsoleKey.C)
            //    {
            //        break;
            //    }
            //    clock.Reset();
            //    Console.SetCursorPosition(left, top);
            //    var builder = new StringBuilder();
            //    for (int i = 0; i < 2048; i++)
            //    {
            //        builder.Append('0' + ((count + i) % 10));
            //        //Console.Write('0' + ((count + i) % 10));
            //    }
            //    Console.Write(builder.ToString());
            //    Console.Title = "Elapsed: " + clock.Elapsed.TotalMilliseconds;
            //    count++;
            //}

            try
            {
                _clockInput.Restart();
                Repl.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception {ex}");
                Console.ReadLine();
            }
        }
    }
}
