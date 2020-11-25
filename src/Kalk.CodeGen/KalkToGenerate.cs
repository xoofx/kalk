using System.Collections.Generic;
using Kalk.Core;

namespace Kalk.CodeGen
{
    public abstract class KalkDescriptorToGenerate : KalkDescriptor
    {
        protected KalkDescriptorToGenerate()
        {
            Tests = new List<(string, string)>();
        }

        public bool IsModule { get; set; }

        public bool IsBuiltin { get; set; }

        public List<(string, string)> Tests { get; }
    }


    public class KalkModuleToGenerate : KalkDescriptorToGenerate
    {
        public KalkModuleToGenerate()
        {
            Members = new List<KalkMemberToGenerate>();
            IsModule = true;
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Namespace { get; set; }

        public string ClassName { get; set; }

        public List<KalkMemberToGenerate> Members { get; }
    }
    
    public class KalkMemberToGenerate : KalkDescriptorToGenerate
    {
        public KalkMemberToGenerate()
        {
        }

        public string Name { get; set; }

        public string XmlId { get; set; }

        public string CSharpName { get; set; }

        public bool IsFunc { get; set; }

        public bool IsAction { get; set; }

        public bool IsConst { get; set; }

        public string Cast { get; set; }

        public KalkModuleToGenerate Module { get; set; }
    }
}