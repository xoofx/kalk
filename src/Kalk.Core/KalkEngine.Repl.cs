using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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

            Repl.BeforeRender = OnBeforeRendering;
            Repl.GetCancellationTokenSource = () => _cancellationTokenSource;
            Repl.TryPreProcessKey = TryPreProcessKey;
            Repl.EditLine.Changed = OnTextChanged;
            Repl.OnTextValidatingEnter = OnTextValidatingEnter;

            Repl.Prompt.Clear();
            Repl.Prompt.Begin(ConsoleStyle.BrightBlack).Append(">>> ").Append(ConsoleStyle.BrightBlack, false);

            AllowEscapeSequences = Repl.SupportEscapeSequences;
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
                    NextOutput.Clear();

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
            Repl?.EnqueuePendingTextToEnter(textToEnter);
        }

        private bool TryPreProcessKey(ConsoleKeyInfo arg, ref int cursorIndex)
        {
            return OnKey(arg, Repl.EditLine, ref cursorIndex);
        }

        private void OnTextChanged()
        {
            UpdateEdit(Repl.EditLine, Repl.CursorIndex);
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
            NextOutput.Clear();
        }

        public void ReplExit()
        {
            if (Repl == null) return;
            Repl.ExitOnNextEval = true;
        }

        public void Run()
        {
            if (!Console.IsInputRedirected && ConsoleHelper.HasInteractiveConsole)
            {
                Repl = new ConsoleRepl();
                HasInteractiveConsole = true;
                
                InitializeRepl();

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
            }

            Version();
            WriteHighlightLine();
            WriteHighlightLine("# Type `help` for more information and at https://github.com/xoofx/kalk");

            if (Repl != null)
            {
                try
                {
                    _clockReplInput.Restart();
                    Repl.Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected exception {ex}");
                }
            }
            else
            {
                string line;
                while ((line = InputReader.ReadLine()) != null)
                {
                    if (EchoEnabled) OutputWriter.WriteLine($">>> {line}");
                    EvaluateText(line, true);
                }
            }
        }
    }
}