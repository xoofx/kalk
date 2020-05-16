using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkConfig : ScriptObject
    {
        public const int DefaultHelpMinColumn = 30;
        public const int DefaultHelpMaxColumn = 100;
        public const string DefaultBaseCurrency = "EUR";
        public const string DefaultDisplay = "std";

        public const string BaseCurrencyProp = "base_currency";
        public const string DisplayProp = "display";

        public KalkConfig()
        {
            HelpMaxColumn = DefaultHelpMaxColumn;
            Display = DefaultDisplay;
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

        public string Display
        {
            get
            {
                var mode = GetSafeValue<string>(DisplayProp, DefaultDisplay);
                // Normalize the display in case it was messed up in config
                if (!KalkDisplayMode.TryNormalize(mode, out _))
                {
                    mode = KalkDisplayMode.Standard;
                    this[DisplayProp] = mode;
                }
                return mode;
            }
            set
            {
                if (value == null) value = DefaultDisplay;
                SetValue(DisplayProp, value, false);
            }
        }

        public string BaseCurrency
        {
            get => GetSafeValue<string>(BaseCurrencyProp, DefaultBaseCurrency);
            set
            {
                if (value == null) value = DefaultBaseCurrency;
                SetValue(BaseCurrencyProp, value, false);
            }
        }

        internal bool RegisteringBaseCurrency { get; set; }

        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            if (member == BaseCurrencyProp)
            {
                var engine = (KalkEngine) context;
                if (engine != null && !RegisteringBaseCurrency)
                {
                    engine.RegisterBaseCurrency(value?.ToString());
                }
                else
                {
                    ValidateCurrency(context, span, member, value);
                }
            }
            else if (member == DisplayProp)
            {
                ValidateDisplay(context, span, member, value);
            }

            return base.TrySetValue(context, span, member, value, readOnly);
        }

        private static void ValidateCurrency(TemplateContext context, SourceSpan span, string member, object value)
        {
            if (value == null) throw new ScriptRuntimeException(span, "Base currency must be non null.");
            var valueStr = value.ToString();
            KalkCurrency.CheckValid(span, valueStr);
        }
        
        private static void ValidateDisplay(TemplateContext context, SourceSpan span, string member, object value)
        {
            if (value == null) throw new ScriptRuntimeException(span, "Display must be non null.");
            var mode = value.ToString();
            if (!KalkDisplayMode.TryNormalize(mode, out _))
            {
                throw new ScriptRuntimeException(span, $"Invalid display name `{mode}`. Expecting `std` or `dev`.");
            }
        }
    }
}