using System;

namespace Kalk.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public class KalkDocAttribute : System.Attribute
    {
        public KalkDocAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}