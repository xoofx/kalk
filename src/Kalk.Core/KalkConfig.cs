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

        public const string BaseCurrencyProp = "base_currency";

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

            return base.TrySetValue(context, span, member, value, readOnly);
        }

        private static void ValidateCurrency(TemplateContext context, SourceSpan span, string member, object value)
        {
            if (value == null) throw new ScriptRuntimeException(span, "Base currency must be non null.");
            var valueStr = value.ToString();
            KalkCurrency.CheckValid(span, valueStr);
        }

        public void Validate(TemplateContext context)
        {
            //
        }
    }
}