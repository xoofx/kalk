﻿using System;
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
        
        static unsafe void Main(string[] args)
        {
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
            var app = new KalkApp();
            app.Repl.GetClipboardTextImpl = TextCopy.Clipboard.GetText;
            app.Repl.SetClipboardTextImpl = TextCopy.Clipboard.SetText;
            app.Run();
        }
    }
}
