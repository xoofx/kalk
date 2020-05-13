using System;
using System.Collections.Generic;
using System.Text;
using Scriban.Runtime;

namespace Kalk.Core
{
    public sealed class KalkShortcut : ScriptObject
    {
        public KalkShortcut(string name, IEnumerable<KalkShortcutKey> shortcuts, bool isUser)
        {
            if (shortcuts == null) throw new ArgumentNullException(nameof(shortcuts));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Keys = new ScriptArray(shortcuts) {IsReadOnly = true};
            SetValue("name", Name, true);
            SetValue("keys", Keys, true);
            IsReadOnly = true;
            IsUser = isUser;
        }

        public string Name { get; }

        public new ScriptArray Keys { get; }

        public bool IsUser { get; }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();

            builder.Append($"shortcut({Name}, ");
            for (var i = 0; i < Keys.Count; i++)
            {
                var shortcut = (KalkShortcutKey) Keys[i];
                if (i > 0) builder.Append(", ");
                builder.Append($"\"{string.Join(" ", shortcut.Keys)}\", {shortcut.Expression}");
            }
            builder.Append(")");

            const int align = 60;
            if (builder.Length < align)
            {
                builder.Append(new string(' ', align - builder.Length));
            }

            builder.Append(" # ");
            for (var i = 0; i < Keys.Count; i++)
            {
                var shortcut = (KalkShortcutKey)Keys[i];
                if (i > 0) builder.Append(", ");
                builder.Append($"{string.Join(" ", shortcut.Keys)} => {shortcut.Expression}");
            }
            
            return builder.ToString();
        }
    }
}