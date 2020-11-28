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