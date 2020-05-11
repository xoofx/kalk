using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkCurrency : KalkSymbol
    {
        private const int CurrencyColumnAlign = 27;

        private const string ExchangeRatesApi = "https://api.exchangeratesapi.io/latest";

        private const string LatestKnownRates =
            "{\"rates\":{\"CAD\":1.5118,\"HKD\":8.4052,\"ISK\":158.5,\"PHP\":54.681,\"DKK\":7.4598,\"HUF\":349.38,\"CZK\":27.251,\"AUD\":1.6613,\"RON\":4.828,\"SEK\":10.5875,\"IDR\":16229.26,\"INR\":81.9615,\"BRL\":6.3074,\"RUB\":79.8383,\"HRK\":7.5573,\"JPY\":115.34,\"THB\":34.958,\"CHF\":1.0529,\"SGD\":1.5326,\"PLN\":4.5482,\"BGN\":1.9558,\"TRY\":7.7252,\"CNY\":7.6719,\"NOK\":11.0695,\"NZD\":1.7668,\"ZAR\":19.997,\"USD\":1.0843,\"MXN\":25.9023,\"ILS\":3.8031,\"GBP\":0.87535,\"KRW\":1322.41,\"MYR\":4.6994},\"base\":\"EUR\",\"date\":\"2020-05-08\"}";

        public KalkCurrency(string name) : base(name)
        {
        }

        public override string Kind => "currency";


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

                var valueToBase = 1.0m / (decimal) value.Left;
                var format = "#0.0###";
                if (valueToBase < 0.0001m)
                {
                    format = null;
                }

                var formattedNumber = valueToBase.ToString(format, CultureInfo.InvariantCulture);

                currencyCmd = $"currency({Name}, {formattedNumber});";
                currencyDesc = $"{formattedNumber,-8} {Name} => 1 {engine.GetSafeBaseCurrencyFromConfig().Name}";
            }

            engine.WriteHighlight($"{currencyCmd, -CurrencyColumnAlign} # {currencyDesc}");

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

        public static void ConfigureCurrencies(KalkEngine engine)
        {
            var rates = DownloadExchangeRates();

            var baseCurrency = (string)rates["base"];
            
            engine.RegisterBaseCurrency(baseCurrency);
            
            var values = (ScriptObject) rates["rates"];

            foreach (var keyPair in values)
            {
                var currencyName = keyPair.Key;
                var currencyValue = engine.ToObject<decimal>(engine.CurrentSpan, keyPair.Value);
                engine.RegisterCurrency(currencyName, currencyValue);
            }
        }

        private static ScriptObject DownloadExchangeRates()
        {
            string rates = LatestKnownRates;
            //try
            //{
            //    using (var client = new HttpClient())
            //    {
            //        var task = Task.Run(async () => await client.GetStringAsync(ExchangeRatesApi));
            //        var result = task.Result;
            //        if (!string.IsNullOrEmpty(result) && result.StartsWith("{"))
            //        {
            //            rates = result;
            //        }
            //    }
            //}
            //catch
            //{
            //    // ignore
            //}

            try
            {
                // Parse the rates returned by the HttpClient
                var expr = Template.Parse(rates, parserOptions: new ParserOptions() { ParseFloatAsDecimal  = true }, lexerOptions: new LexerOptions() { Mode = ScriptMode.ScriptOnly});
                return expr.Evaluate() as ScriptObject;
            }
            catch
            {
                // Parse the rates returned by the HttpClient
                var expr = Template.Parse(LatestKnownRates, parserOptions: new ParserOptions() { ParseFloatAsDecimal = true }, lexerOptions: new LexerOptions() { Mode = ScriptMode.ScriptOnly });
                return expr.Evaluate() as ScriptObject;
            }
        }

    }
}