using System;

namespace Kalk.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    public class KalkDocAttribute : System.Attribute
    {
        public KalkDocAttribute(string alias, string category)
        {
            Alias = alias;
            Category = category;
        }

        public string Alias { get; }

        public string Category { get; }
    }
}