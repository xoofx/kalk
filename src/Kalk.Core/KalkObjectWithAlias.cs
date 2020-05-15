using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Kalk.Core
{
    public class KalkObjectWithAlias : ScriptObject
    {
        public KalkObjectWithAlias()
        {
        }

        public KalkObjectWithAlias(KalkEngine engine)
        {
            Engine = engine;
        }

        public KalkEngine Engine { get; set; }

        public override bool Contains(string member)
        {
            member = Alias(member);
            return base.Contains(member);
        }

        public override bool CanWrite(string member)
        {
            member = Alias(member);
            return base.CanWrite(member);
        }

        public override bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object value)
        {
            member = Alias(member);
            return base.TryGetValue(context, span, member, out value);
        }

        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            member = Alias(member);
            return base.TrySetValue(context, span, member, value, readOnly);
        }

        private string Alias(string name)
        {
            // Replace with an alias
            if (Engine.Aliases.TryGetAlias(name, out var alias))
            {
                name = alias;
            }

            return name;
        }
    }
}