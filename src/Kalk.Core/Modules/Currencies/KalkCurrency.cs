using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kalk.Core.Modules;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkCurrency : KalkUnit
    {
        private readonly CurrencyModule _currencyModule;
        private const int CurrencyColumnAlign = 27;

        public KalkCurrency(CurrencyModule currencyModule, string name) : base(name)
        {
            _currencyModule = currencyModule;
            Plural = name;
        }

        public override string TypeName => "currency";

        public override object GetValue() => 1.0m;
        
        public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            var engine = (KalkEngine)context;

            string currencyCmd;
            string currencyDesc;
            if (Value == null)
            {
                currencyCmd = $"currency({Name});";
                currencyDesc = $"Base currency";
            }
            else
            {
                var value = (KalkBinaryExpression) Value;

                var valueToBase = 1.0m / (decimal) value.Value;
                var format = "#0.0###";
                if (valueToBase < 0.0001m)
                {
                    format = null;
                }

                var formattedNumber = valueToBase.ToString(format, CultureInfo.InvariantCulture);

                currencyCmd = $"currency({Name}, {formattedNumber});";
                currencyDesc = $"{formattedNumber,-8} {Name} => 1 {_currencyModule.GetSafeBaseCurrencyFromConfig().Name}";
            }

            engine.WriteHighlightLine($"{currencyCmd, -CurrencyColumnAlign} # {currencyDesc}");

            return null;
        }

        public static void CheckValid(SourceSpan span, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length != 3) throw new ScriptRuntimeException(span, $"Base currency `{name}` must 3 characters long instead of {name.Length}.");
            foreach (var c in name)
            {
                if (!(c >= 'A' && c <= 'Z'))
                {
                    throw new ScriptRuntimeException(span, $"The character `{c}` is invalid for the base currency `{name}`. Only A-Z are allowed");
                }
            }
        }
    }
}