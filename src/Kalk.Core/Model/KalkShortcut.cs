using System;
using System.Collections.Generic;
using System.Text;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public sealed class KalkShortcut : ScriptObject
    {
        public KalkShortcut(string name, IEnumerable<KalkShortcutKeySequence> shortcuts, bool isUser)
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

            var mapExpressionToKeySequences = new Dictionary<ScriptExpression, List<KalkShortcutKeySequence>>();

            for (var i = 0; i < Keys.Count; i++)
            {
                var shortcut = (KalkShortcutKeySequence)Keys[i];
                if (!mapExpressionToKeySequences.TryGetValue(shortcut.Expression, out var list))
                {
                    list = new List<KalkShortcutKeySequence>();
                    mapExpressionToKeySequences.Add(shortcut.Expression, list);
                }
                list.Add(shortcut);
            }

            int seqIndex = 0;
            foreach (var exprToSequence in mapExpressionToKeySequences)
            {
                var expr = exprToSequence.Key;
                var sequences = exprToSequence.Value;
                if (seqIndex > 0) builder.Append(", ");
                builder.Append('"');
                for (var j = 0; j < sequences.Count; j++)
                {
                    var sequence = sequences[j];
                    if (j > 0) builder.Append(", ");
                    builder.Append($"{string.Join(" ", sequence.Keys)}");
                }

                builder.Append($"\", {expr}");
                seqIndex++;
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
                var shortcut = (KalkShortcutKeySequence)Keys[i];
                if (i > 0) builder.Append(", ");
                builder.Append($"{string.Join(" ", shortcut.Keys)} => {shortcut.Expression}");
            }
            
            return builder.ToString();
        }
    }
}