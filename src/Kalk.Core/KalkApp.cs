using System;
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
        public KalkApp()
        {
            Repl = new ConsoleRepl();
            Repl.Prompt = ">>> ";
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

            var context = new TemplateContext {StrictVariables = true};

            context.BuiltinObject.Import("exit", new Action(Exit));
            context.BuiltinObject.Import("log", new Func<double, double>(Log));

            object result = null;
            string error = null;
            Template script = null;

            Repl.OnTextValidatingEnter = text =>
            {
                try
                {
                    script = Template.Parse(text, lexerOptions: new LexerOptions() { Mode = ScriptMode.ScriptOnly });

                    if (script.HasErrors)
                    {
                        var errorBuilder = new StringBuilder();
                        foreach (var message in script.Messages)
                        {
                            errorBuilder.Append(message.ToString());
                        }

                        error = errorBuilder.ToString();
                    }
                    else
                    {
                        result = context.Evaluate(script.Page);
                        if (Repl.ExitOnNextEval)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message; 
                }

                return true;
            };


            Repl.OnTextValidatedEnter = text =>
            {
                try
                {
                    if (error != null)
                    {
                        Console.WriteLine(error);
                        error = null;
                        return;
                    }

                    if (result != null)
                    {
                        context.Write(script.Page.Span, result);
                    }
                    var resultStr = context.Output.ToString();
                    var output = context.Output as StringBuilderOutput;
                    if (output != null)
                    {
                        output.Builder.Length = 0;
                    }

                    result = null;

                    if (!string.IsNullOrWhiteSpace(resultStr))
                    {
                        Console.WriteLine($"  {resultStr}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };
            //editor.OnTextValidateEnter += s =>
            //{
            //    Console.WriteLine();
            //}
        }

        public static double Log(double value)
        {
            return Math.Log(value);
        }

        public void Exit()
        {
            Repl.ExitOnNextEval = true;
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

            Console.WriteLine("kalk 1.0.0 - Copyright (c) 2020 Alexandre Mutel");

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
