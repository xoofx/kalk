using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Consolus;
using Kalk.Core;
using Microsoft.Win32.SafeHandles;

namespace kalk
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        private const int STD_INPUT_HANDLE = -10;


        public class ConsoleWaitHandle : WaitHandle
        {
            public ConsoleWaitHandle(IntPtr handle)
            {
                this.SafeWaitHandle = new SafeWaitHandle(handle, false);
            }
        }
        private static bool IsMSYS2() =>
            Environment.GetEnvironmentVariable("MSYSCON") != null;

        public static void Setup()
        {
            // workaround for:
            // https://github.com/dotnet/corefx/issues/36761
            // https://github.com/dotnet/corefx/issues/25916
            if (IsMSYS2() || !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                TrySetSttyParameters("-echo -icanon min 1 time 0");
                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                    TrySetSttyParameters("sane");
            }
        }

        private static void TrySetSttyParameters(string param)
        {
            try
            {
                Process.Start("stty", param).WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"stty : {ex}");
            }
        }


        static unsafe void Main(string[] args)
        {
            Setup();
            //var renderer = new ConsoleRenderer();

            //renderer.BeforeEditLine.Append("This is a prompt: ");
            //renderer.BeforeEditLine.Append('\n');
            //renderer.EditLine.Append("This is a line");

            //renderer.AfterEditLine.Append('\n');
            //renderer.AfterEditLine.Append(ConsoleStyle.Red);
            //renderer.AfterEditLine.Append("This is a red text right after");


            //while (true)
            //{
            //    renderer.Render();

            //    var key = Console.ReadKey(true);
            //    if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
            //    {
            //        renderer.EditLine.RemoveAt(renderer.EditLine.Count - 1);
            //    }
            //    else
            //    {
            //        renderer.EditLine.Append("x");
            //    }
            //}

            //return;
            var app = new KalkConsoleRepl();
            app.Repl.GetClipboardTextImpl = TextCopy.Clipboard.GetText;
            app.Repl.SetClipboardTextImpl = TextCopy.Clipboard.SetText;
            app.Run();
        }
    }
}
