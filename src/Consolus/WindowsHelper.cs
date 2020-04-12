using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Consolus
{
    internal static class WindowsHelper
    {
        private const int STD_OUTPUT_HANDLE = -11;
        private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

        public static void EnableAnsiEscapeOnWindows()
        {
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            if (iStdOut != IntPtr.Zero && GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                SetConsoleMode(iStdOut, outConsoleMode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);
            }
        }

        [DllImport("kernel32")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32")]
        private static extern IntPtr GetConsoleWindow();
        
        [DllImport("kernel32")]
        private static extern IntPtr GetCurrentProcessId();

        [DllImport("user32")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref IntPtr ProcessId);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsSelfConsoleWindows()
        {
            try
            {
                IntPtr hConsole = GetConsoleWindow();
                IntPtr hProcessId = IntPtr.Zero;
                GetWindowThreadProcessId(hConsole, ref hProcessId);
                var processId = GetCurrentProcessId();
                return processId == hProcessId;
            }
            catch
            {
                return true;
            }
        }
    }
}