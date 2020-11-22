using System.Collections.Generic;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Import all modules.
    /// </summary>
    [KalkExportModule("All")]
    public partial class AllModule : KalkModule
    {
        public AllModule()
        {
            Modules = new List<KalkModule>();
            RegisterDocumentationAuto();
        }

        public List<KalkModule> Modules { get; }

        protected override void Import()
        {
            base.Import();
            foreach (var module in Modules)
            {
                module.InternalImport();
            }
        }
    }
}