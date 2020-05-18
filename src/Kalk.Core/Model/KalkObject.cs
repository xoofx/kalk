using System.Collections.Generic;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Kalk.Core
{
    public abstract class KalkObject : IScriptObject
    {
        public abstract int Count { get; }
        public abstract IEnumerable<string> GetMembers();
        public abstract bool Contains(string member);
        public abstract bool IsReadOnly { get; set; }
        public abstract bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object value);
        public abstract bool CanWrite(string member);
        public abstract bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly);
        public abstract bool Remove(string member);
        public abstract void SetReadOnly(string member, bool readOnly);
        public abstract IScriptObject Clone(bool deep);
        public abstract string TypeName { get; }
    }
}