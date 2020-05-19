using System.Collections.Generic;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class PrimitiveSwizzleAccessor : IObjectAccessor
    {
        public static readonly PrimitiveSwizzleAccessor Default = new PrimitiveSwizzleAccessor();

        private PrimitiveSwizzleAccessor()
        {
        }

        public int GetMemberCount(TemplateContext context, SourceSpan span, object target)
        {
            return 0;
        }

        public IEnumerable<string> GetMembers(TemplateContext context, SourceSpan span, object target)
        {
            yield break;
        }

        public bool HasMember(TemplateContext context, SourceSpan span, object target, string member)
        {
            return IsSwizzle(member);
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, object target, string member, out object value)
        {
            var targetFloat = context.ToObject<float>(span, target);

            if (member.Length == 1)
            {
                value = targetFloat;
                return true;
            }

            var vector = new KalkVector<float>(member.Length);
            int index = 0;
            for(int i = 0; i < member.Length; i++)
            {
                var c = member[i];
                switch (c)
                {
                    case 'x':
                        vector[index] = targetFloat;
                        break;
                    case 'y':
                        vector[index] = targetFloat;
                        break;
                    case 'z':
                        vector[index] = targetFloat;
                        break;
                    case 'w':
                        vector[index] = targetFloat;
                        break;
                }
                index++;
            }

            value = vector;
            return true;
        }

        public bool TrySetValue(TemplateContext context, SourceSpan span, object target, string member, object value)
        {
            throw new ScriptRuntimeException(span, "Cannot set a member on a primitive");
        }

        private static bool IsSwizzle(string text)
        {
            if (text.Length > 4) return false;

            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                switch (c)
                {
                    case 'x':
                    case 'y':
                    case 'z':
                    case 'w':
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }
    }
}