using System.Collections.Generic;

namespace Kalk.Core
{
    public class KalkShortcutKeyMap : Dictionary<KalkConsoleKey, object>
    {
        public bool TryGetShortcut(KalkConsoleKey key, out object next)
        {
            return TryGetValue(key, out next);
        }
    }
}