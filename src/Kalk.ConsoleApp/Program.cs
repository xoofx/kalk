using System;
using Kalk.Core;

namespace kalk
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new KalkEngine
            {
                GetClipboardText = TextCopy.ClipboardService.GetText,
                SetClipboardText = TextCopy.ClipboardService.SetText,
            };

            if (!app.Run(args))
            {
                Environment.ExitCode = 1;
            }
        }
    }
}
