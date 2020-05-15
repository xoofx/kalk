using System;
using System.Collections.Generic;
using System.Text;
using Scriban.Runtime;

namespace Kalk.Core
{
    public sealed class KalkAlias : ScriptObject
    {
        public KalkAlias(string name, IEnumerable<string> aliases, bool isUser)
        {
            if (aliases == null) throw new ArgumentNullException(nameof(aliases));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Aliases = new ScriptArray(aliases) {IsReadOnly = true};
            SetValue("name", Name, true);
            SetValue("aliases", Aliases, true);
            IsReadOnly = true;
            IsUser = isUser;
        }

        public string Name { get; }

        public ScriptArray Aliases { get; }

        public bool IsUser { get; }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();

            builder.Append($"alias({Name}, ");
            for (var i = 0; i < Aliases.Count; i++)
            {
                var alias = Aliases[i];
                if (i > 0) builder.Append(", ");
                builder.Append(alias);
            }
            builder.Append(")");
            
            return builder.ToString();
        }
    }
}