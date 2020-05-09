using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Consolus;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkConsoleRepl : IKalkEngineWriter
    {
        private readonly KalkEngine _engine;
        private readonly Stopwatch _clockInput;
        private CancellationTokenSource _cancellationTokenSource;

        public KalkConsoleRepl() : this(new KalkEngine(true))
        {
        }
        
        public KalkConsoleRepl(KalkEngine engine)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _engine.Writer = this;
            _clockInput = Stopwatch.StartNew();
            OnErrorToNextLineMaxDelayInMilliseconds = 300;

            _engine.OnClear = Clear;
            _engine.OnExit = Exit;

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
            Repl.Prompt.Begin(ConsoleStyle.BrightBlack).Append(">>> ").Append(ConsoleStyle.BrightBlack, false);
            Repl.GetCancellationTokenSource = () => _cancellationTokenSource;

            //Repl.TextAfterLine.Append('\n');
            //Repl.TextAfterLine.Append(ConsoleStyle.Red);
            //Repl.TextAfterLine.Append("This is a red text right after");



            Repl.EditLine.Changed = OnTextChanged;

            Repl.OnTextValidatingEnter = OnTextValidatingEnter;
            _engine.OnEnterNextText = OnEnterNextText;
        }

        private bool OnTextValidatingEnter(string text, bool hasControl)
        {
            try
            {
                return OnTextValidatingEnterInternal(text, hasControl);
            }
            finally
            {
                _clockInput.Restart();
            }
        }
        
        private bool OnTextValidatingEnterInternal(string text, bool hasControl)
        {
            _cancellationTokenSource  = new CancellationTokenSource();
            _engine.CancellationToken = _cancellationTokenSource.Token;

            var elapsed = _clockInput.ElapsedMilliseconds;
            Template script = null;

            object result = null;
            string error = null;
            int column = -1;
            bool isCancelled = false;
            try
            {
                script = _engine.Parse(text);

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

                    result = _engine.EvaluatePage(script.Page);

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
                    _engine.Write(script.Page.Span, result);
                }
                var resultStr = _engine.Output.ToString();
                var output = _engine.Output as StringBuilderOutput;
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
            Repl.EnqueuePendingTextToEnter(textToEnter);
        }

        public ConsoleText NextOutput { get; }

        public long OnErrorToNextLineMaxDelayInMilliseconds { get; set; }

        private void OnTextChanged()
        {
            _engine.UpdateEdit(Repl.EditLine);
        }

        private void OnBeforeRendering()
        {
            UpdateSyntaxHighlighting();
        }
        
        private void UpdateSyntaxHighlighting()
        {
            _engine.Highlight(Repl.EditLine, Repl.CursorIndex);
        }

        public void Clear()
        {
            Repl.Clear();
            NextOutput.Clear();
        }

        public void Exit()
        {
            Repl.ExitOnNextEval = true;
        }
        
        public ConsoleRepl Repl { get; }

        private void WriteHighlight(string text)
        {
            _engine.WriteHighlight(text);
            FlushWrite();
        }

        private void FlushWrite()
        {
            NextOutput.AppendLine();
            NextOutput.Render(Repl.ConsoleWriter);
            Repl.ConsoleWriter.Commit();
            NextOutput.Clear();
            Repl.Reset();
        }

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

            _engine.Version();
            FlushWrite();
            
            WriteHighlight("# Type `help` for more information and at https://github.com/xoofx/kalk");

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

        void IKalkEngineWriter.Write(SourceSpan span, object textAsObject)
        {
            if (NextOutput.Count > 0) NextOutput.AppendLine();
            NextOutput.Append(_engine.ObjectToString(textAsObject));
        }

        void IKalkEngineWriter.Write(ConsoleText text)
        {
            if (NextOutput.Count > 0) NextOutput.AppendLine();
            NextOutput.AddRange(text);
        }
    }
}
