using System.IO;

namespace Kalk.Core.Modules
{
    public class StandardUnitsModule : KalkModule
    {
        protected override void Initialize()
        {
        }

        protected override void Import()
        {
            var countBeforeImport = Engine.Units.Count;
            Engine.LoadSystemFile(Path.Combine("Modules", "standard_units.kalk"));
            var deltaCount = Engine.Units.Count - countBeforeImport;
            Engine.WriteHighlightLine($"# {deltaCount} units successfully imported.");
        }
    }
}