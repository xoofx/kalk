using System;
using System.IO;
using Kalk.Core;
#if KALK_WINDOWS_STOREAPP
using Windows.Storage;
using Windows.System;
#endif

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

#if KALK_WINDOWS_STOREAPP
            SetupWindowsStoreApp(app);
#endif

            if (!app.Run(args))
            {
                Environment.ExitCode = 1;
            }
        }

#if KALK_WINDOWS_STOREAPP
        private static void SetupWindowsStoreApp(KalkEngine app)
        {
            try
            {
                app.KalkUserFolder = Path.Combine(UserDataPaths.GetDefault().Profile, ".kalk");
            }
            catch
            {
                // ignore;
            }
        }
#endif
    }
}
