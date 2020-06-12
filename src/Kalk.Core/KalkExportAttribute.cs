using System;

namespace Kalk.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    public class KalkExportAttribute : System.Attribute
    {
        public KalkExportAttribute(string alias, string category)
        {
            Alias = alias;
            Category = category;
        }

        public string Alias { get; }

        public string Category { get; }

        public bool Functor { get; set; }
    }
}