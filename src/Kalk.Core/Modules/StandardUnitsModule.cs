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
            Engine.LoadSystemFile(Path.Combine("Modules", "standard_units.kalk"));
        }
    }
}