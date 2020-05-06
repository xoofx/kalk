using System;

namespace Kalk.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class KalkFunctionAttribute : System.Attribute
    {
        public KalkFunctionAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; }

        public string Category { get; set; }
    }
}