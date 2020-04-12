using System;
using Kalk.Core;

namespace Kalk
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new KalkApp();
            app.Repl.GetClipboardTextImpl = TextCopy.Clipboard.GetText;
            app.Repl.SetClipboardTextImpl = TextCopy.Clipboard.SetText;
            app.Run();
        }
    }
}
