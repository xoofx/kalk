using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkExpressionWithMembers : KalkExpression
    {
        protected abstract (string, Func<KalkExpressionWithMembers, object> getter)[] Members { get; }

        public override int Count => Members.Length;

        public override IEnumerable<string> GetMembers()
        {
            foreach (var memberPair in Members) yield return memberPair.Item1;
        }

        public override bool Contains(string member)
        {
            foreach (var memberPair in Members)
                if (memberPair.Item1 == member)
                    return true;
            return false;
        }

        public override bool IsReadOnly { get; set; }

        public override bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object value)
        {
            value = null;
            foreach (var memberPair in Members)
            {
                if (memberPair.Item1 == member)
                {
                    value = memberPair.Item2(this);
                    return true;
                }
            }
            return false;
        }

        public override bool CanWrite(string member) => false;

        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly) => false;

        public override bool Remove(string member) => false;

        public override void SetReadOnly(string member, bool readOnly) => throw new NotSupportedException("A member of Unit is readonly by default and cannot be modified");

    }
}