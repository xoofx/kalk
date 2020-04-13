using System;
using System.Collections.Generic;
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
        private bool _clearBeforeNextDisplay;

        public KalkApp()
        {
            Repl = new ConsoleRepl();
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

            //Repl.TextAfterLine.Append('\n');
            //Repl.TextAfterLine.Append(ConsoleStyle.Red);
            //Repl.TextAfterLine.Append("This is a red text right after");

            var context = new TemplateContext
            {
                EnableRelaxedMemberAccess = false,
                StrictVariables = true
            };

            context.BuiltinObject.Import("exit", new Action(Exit));
            context.BuiltinObject.Import("clear", new Action(Clear));
            context.BuiltinObject.Import("log", new Func<double, double>(Log));

            context.BuiltinObject.Import("kb", new Func<object, object>(Kb));
            context.BuiltinObject.Import("mb", new Func<object, object>(Mb));
            context.BuiltinObject.Import("gb", new Func<object, object>(Gb));
            context.BuiltinObject.Import("tb", new Func<object, object>(Tb));
            context.BuiltinObject.Import("im", new Func<object, object>(ComplexNumber));

            var parserOptions = new ParserOptions()
            {
                Units = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
                {
                    {"kb", "kb"},
                    {"mb", "mb"},
                    {"gb", "gb"},
                    {"tb", "tb"},
                    { "i", "im"},
                }
            };

            Template script = null;

            Repl.OnTextValidatingEnter = text =>
            {
                object result = null;
                string error = null;
                int column = -1;
                try
                {
                    script = Template.Parse(text, parserOptions: parserOptions, lexerOptions: new LexerOptions() { Mode = ScriptMode.ScriptOnly, Level = ScriptSyntaxLevel.Scientific });

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
                        result = context.Evaluate(script.Page);
                        if (Repl.ExitOnNextEval)
                        {
                            return false;
                        }

                        Repl.TextAfterLine.Clear();
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
                    Repl.TextAfterLine.Clear();
                    Repl.TextAfterLine.Append('\n');
                    Repl.TextAfterLine.Append(ConsoleStyle.Red);
                    Repl.TextAfterLine.Append(error);
                    if (column >= 0 && column <= Repl.EditLine.Count)
                    {
                        Repl.CursorIndex = column;
                    }
                    return false;
                }
                else
                {
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

                    Repl.TextAfterLine.Clear();
                    Repl.TextAfterLine.Append('\n');
                    if (resultStr != string.Empty)
                    {
                        Repl.TextAfterLine.Append(resultStr);
                        Repl.TextAfterLine.Append('\n');
                    }
                }

                return true;
            };


            Repl.OnTextValidatedEnter = text =>
            {
                if (_clearBeforeNextDisplay)
                {
                    Repl.Clear();
                    _clearBeforeNextDisplay = false;
                }
            };
        }

        public void Clear()
        {
            _clearBeforeNextDisplay = true;
        }

        public static double Log(double value)
        {
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
