using Scriban.Runtime;

namespace Kalk.Core
{
    public class KalkConfig : ScriptObject
    {
        public const int DefaultHelpMinColumn = 30;
        public const int DefaultHelpMaxColumn = 100;
        public const string DefaultLimitToString = "auto";
        public const string DefaultEncoding = "utf-8";

        public const string LimitToStringProp = "limit_to_string";
        public const string EncodingProp = "encoding";

        public KalkConfig()
        {
            HelpMaxColumn = DefaultHelpMaxColumn;
            LimitToString = DefaultLimitToString;
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

        public string LimitToString
        {
            get => GetSafeValue(LimitToStringProp, DefaultLimitToString);
            set => SetValue(LimitToStringProp, value, false);
        }

        public string Encoding
        {
            get => GetSafeValue(EncodingProp, DefaultEncoding);
            set => SetValue(EncodingProp, value, false);
        }
    }
}