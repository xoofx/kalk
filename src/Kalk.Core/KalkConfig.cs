using Scriban.Runtime;

namespace Kalk.Core
{
    public class KalkConfig : ScriptObject
    {
        public const int DefaultHelpMinColumn = 30;
        public const int DefaultHelpMaxColumn = 100;

        public KalkConfig()
        {
            HelpMaxColumn = DefaultHelpMaxColumn;
        }
        
        public int HelpMaxColumn
        {
            get => GetSafeValue<int>("help_max_column", DefaultHelpMaxColumn);
            set
            {
                if (value < DefaultHelpMinColumn) value = DefaultHelpMinColumn;
                SetValue("help_max_column", value, false);
            }
        }

        public bool Sponsoring
        {
            get => GetSafeValue<bool>("sponsoring");
            set => SetValue("sponsoring", value, false);
        }
    }
}