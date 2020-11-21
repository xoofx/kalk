using System.Collections.Generic;
using Kalk.Core;

namespace Kalk.CodeGen
{
    internal class KalkModuleToGenerate
    {
        public KalkModuleToGenerate()
        {
            Members = new List<KalkMemberToGenerate>();
        }

        public string Name { get; set; }

        public string Namespace { get; set; }

        public string ClassName { get; set; }

        public string Category { get; set; }

        public List<KalkMemberToGenerate> Members { get; }
    }
    
    public class KalkMemberToGenerate : KalkDescriptor
    {
        public KalkMemberToGenerate()
        {
            Tests = new List<(string, string)>();
        }

        public string Name { get; set; }

        public string XmlId { get; set; }

        public string CSharpName { get; set; }

        public bool IsFunc { get; set; }

        public bool IsAction { get; set; }

        public bool IsConst { get; set; }

        public string Cast { get; set; }

        public List<(string, string)> Tests { get; }
    }
}