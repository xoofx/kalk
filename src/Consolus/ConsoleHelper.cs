using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Consolus
{
    public class ConsoleHelper
    {
        public static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        private static readonly Lazy<bool> _isConsoleSupportingEscapeSequences = new Lazy<bool>(IsConsoleSupportingEscapeSequencesInternal);
        private static readonly Lazy<bool> _hasInteractiveConsole = new Lazy<bool>(HasInteractiveConsoleInternal);
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static bool SupportEscapeSequences => _isConsoleSupportingEscapeSequences.Value;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static bool HasInteractiveConsole => _hasInteractiveConsole.Value;

        private static bool IsConsoleSupportingEscapeSequencesInternal()
        {
            if (Console.IsOutputRedirected || Console.IsErrorRedirected || !HasInteractiveConsole)
            {
                return false;
            }

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

        private static bool HasInteractiveConsoleInternal() => IsWindows ? WindowsHelper.HasConsoleWindows() : Environment.UserInteractive;
    }
}