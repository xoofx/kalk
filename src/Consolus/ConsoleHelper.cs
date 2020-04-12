using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Consolus
{
    public class ConsoleHelper
    {
        private static readonly Lazy<bool> _isConsoleSupportingEscapeSequences = new Lazy<bool>(IsConsoleSupportingEscapeSequencesInternal);

        public static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static bool SupportEscapeSequences => _isConsoleSupportingEscapeSequences.Value;

        private static bool IsConsoleSupportingEscapeSequencesInternal()
        {
            if (IsWindows)
            {
                WindowsHelper.EnableAnsiEscapeOnWindows();
            }

            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            ConsoleStyle.Reset.Render(Console.Out);
            bool support = true;
            if (left != Console.CursorLeft || top != Console.CursorTop)
            {
                support = false;
                // Remove previous sequence
                Console.SetCursorPosition(left, top);
                Console.Write("    "); // Clear \x1b[0m = 4 characters
                Console.SetCursorPosition(left, top);
            }
            return support;
        }
    }
}