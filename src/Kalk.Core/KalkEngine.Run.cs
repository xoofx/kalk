using System;
using System.IO;
using System.Text;
using Consolus;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public bool Run(params string[] args)
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected && ConsoleHelper.HasInteractiveConsole)
            {
                Repl = new ConsoleRepl();
                HasInteractiveConsole = true;
                
                InitializeRepl();

                try
                {
                    if (ConsoleRepl.IsSelf())
                    {
                        Console.Title = $"kalk {Version}";
                    }
                }
                catch
                {
                    // ignore
                }
            }

            // Directory.CreateDirectory(KalkUserFolder);

            if (DisplayVersion)
            {
                ShowVersion();
                WriteHighlightLine("# Type `help` for more information and at https://github.com/xoofx/kalk");
                
                WriteHighlightLine($"# Type `exit` or {(OperatingSystem.IsWindows() ? "CTRL+Z" : "CTRL+D")} to exit from kalk");
            }

            // Load user config file after showing the version
            LoadUserConfigFile();

            if (Repl != null)
            {
                return RunInteractive();
            }
            else
            {
                return RunNonInteractive();
            }
        }

        private bool RunInteractive()
        {
            try
            {
                OnAction = InteractiveOnAction;
                _clockReplInput.Restart();
                Repl.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected exception {ex}");
                return false;
            }

            return true;
        }

        private void InteractiveOnAction(KalkAction obj)
        {
            switch (obj)
            {
                case KalkAction.Exit:
                    Repl.Action(ConsoleAction.Exit);
                    break;
                case KalkAction.CursorLeft:
                    Repl.Action(ConsoleAction.CursorLeft);
                    break;
                case KalkAction.CursorRight:
                    Repl.Action(ConsoleAction.CursorRight);
                    break;
                case KalkAction.CursorLeftWord:
                    Repl.Action(ConsoleAction.CursorLeftWord);
                    break;
                case KalkAction.CursorRightWord:
                    Repl.Action(ConsoleAction.CursorRightWord);
                    break;
                case KalkAction.CursorStartOfLine:
                    Repl.Action(ConsoleAction.CursorStartOfLine);
                    break;
                case KalkAction.CursorEndOfLine:
                    Repl.Action(ConsoleAction.CursorEndOfLine);
                    break;
                case KalkAction.HistoryPrevious:
                    Repl.Action(ConsoleAction.HistoryPrevious);
                    break;
                case KalkAction.HistoryNext:
                    Repl.Action(ConsoleAction.HistoryNext);
                    break;
                case KalkAction.DeleteCharacterLeft:
                    Repl.Action(ConsoleAction.DeleteCharacterLeft);
                    break;
                case KalkAction.DeleteCharacterLeftAndCopy:
                    break;
                case KalkAction.DeleteCharacterRight:
                    Repl.Action(ConsoleAction.DeleteCharacterRight);
                    break;
                case KalkAction.DeleteCharacterRightAndCopy:
                    break;
                case KalkAction.DeleteWordLeft:
                    Repl.Action(ConsoleAction.DeleteWordLeft);
                    break;
                case KalkAction.DeleteWordRight:
                    Repl.Action(ConsoleAction.DeleteWordRight);
                    break;
                case KalkAction.Completion:
                    Repl.Action(ConsoleAction.Completion);
                    break;
                case KalkAction.DeleteTextRightAndCopy:
                    break;
                case KalkAction.DeleteWordRightAndCopy:
                    break;
                case KalkAction.DeleteWordLeftAndCopy:
                    break;
                case KalkAction.CopySelection:
                    Repl.Action(ConsoleAction.CopySelection);
                    break;
                case KalkAction.CutSelection:
                    Repl.Action(ConsoleAction.CutSelection);
                    break;
                case KalkAction.PasteClipboard:
                    Repl.Action(ConsoleAction.PasteClipboard);
                    break;
                case KalkAction.ValidateLine:
                    Repl.Action(ConsoleAction.ValidateLine);
                    break;
                case KalkAction.ForceValidateLine:
                    Repl.Action(ConsoleAction.ForceValidateLine);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }

        private bool RunNonInteractive()
        {
            bool success = true;
            string line;
            while ((line = InputReader.ReadLine()) != null)
            {
                if (EchoEnabled && EchoInput) OutputWriter.Write($">>> {line}");

                try
                {
                    var script = Parse(line);

                    if (script.HasErrors)
                    {
                        //throw new ScriptParserRuntimeException();
                        var errorBuilder = new StringBuilder();
                        foreach (var message in script.Messages)
                        {
                            if (errorBuilder.Length > 0) errorBuilder.AppendLine();
                            errorBuilder.Append(message.Message);
                        }

                        var error = errorBuilder.ToString();
                        throw new InvalidOperationException(error);
                    }
                    else
                    {
                        var result = EvaluatePage(script.Page);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ScriptRuntimeException runtimeEx)
                    {
                        WriteErrorLine(runtimeEx.OriginalMessage);
                    }
                    else
                    {
                        WriteErrorLine(ex.Message);
                    }
                    //Console.WriteLine(ex.InnerException);
                    success = false;
                    break;
                }

                if (HasExit) break;
            }
            return success;
        }
    }
}