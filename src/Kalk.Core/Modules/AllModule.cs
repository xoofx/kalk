using System.Collections.Generic;

namespace Kalk.Core.Modules
{
    public class AllModule : KalkModule
    {
        public AllModule()
        {
            Modules = new List<KalkModule>();
        }
        
        public List<KalkModule> Modules { get; }

        protected override void Import()
        {
            foreach (var module in Modules)
            {
                module.InternalImport();
            }
        }
    }
}