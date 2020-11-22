using System.IO;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Modules that contains standard units.
    /// </summary>
    [KalkExportModule(ModuleName)]
    public partial class StandardUnitsModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "StandardUnits";
        public StandardUnitsModule() : base(ModuleName)
        {
            RegisterFunctionsAuto();
        }

        protected override void Initialize()
        {
        }

        protected override void Import()
        {
            base.Import();

            var countBeforeImport = Engine.Units.Count;
            Engine.LoadSystemFile(Path.Combine("Modules", "standard_units.kalk"));
            var deltaCount = Engine.Units.Count - countBeforeImport;
            Engine.WriteHighlightLine($"# {deltaCount} units successfully imported from module `{Name}`.");
        }
    }
}