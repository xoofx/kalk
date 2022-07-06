using System;

namespace Kalk.Core
{
    public static class KalkDisplayModeHelper
    {
        public const string Raw = "raw";

        public const string Standard = "std";

        public const string Developer = "dev";


        public static string ToText(this KalkDisplayMode mode)
        {
            switch (mode)
            {
                case KalkDisplayMode.Raw:
                    return Raw;
                case KalkDisplayMode.Standard:
                    return Standard;
                case KalkDisplayMode.Developer:
                    return Developer;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public static bool TryParse(string mode, out KalkDisplayMode fullMode)
        {
            fullMode = KalkDisplayMode.Standard;
            switch (mode)
            {
                case Raw:
                    fullMode = KalkDisplayMode.Raw;
                    return true;
                case Standard:
                    fullMode = KalkDisplayMode.Standard;
                    return true;
                case Developer:
                    fullMode = KalkDisplayMode.Developer;
                    return true;
            }
            return false;
        }

        public static KalkDisplayMode SafeParse(string text)
        {
            return TryParse(text, out var mode) ? mode : KalkDisplayMode.Standard;
        }
    }
}