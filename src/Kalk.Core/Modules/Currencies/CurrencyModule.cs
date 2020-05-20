using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class CurrencyModule : KalkModule
    {
        private const string ExchangeRatesApi = "https://api.exchangeratesapi.io/latest";
        private const string ConfigBaseCurrencyProp = "base_currency";
        private const string DefaultBaseCurrency = "EUR";
        private const string LatestKnownRates =
            "{\"rates\":{\"CAD\":1.5118,\"HKD\":8.4052,\"ISK\":158.5,\"PHP\":54.681,\"DKK\":7.4598,\"HUF\":349.38,\"CZK\":27.251,\"AUD\":1.6613,\"RON\":4.828,\"SEK\":10.5875,\"IDR\":16229.26,\"INR\":81.9615,\"BRL\":6.3074,\"RUB\":79.8383,\"HRK\":7.5573,\"JPY\":115.34,\"THB\":34.958,\"CHF\":1.0529,\"SGD\":1.5326,\"PLN\":4.5482,\"BGN\":1.9558,\"TRY\":7.7252,\"CNY\":7.6719,\"NOK\":11.0695,\"NZD\":1.7668,\"ZAR\":19.997,\"USD\":1.0843,\"MXN\":25.9023,\"ILS\":3.8031,\"GBP\":0.87535,\"KRW\":1322.41,\"MYR\":4.6994},\"base\":\"EUR\",\"date\":\"2020-05-08\"}";

        private const string CategoryUnitsAndCurrencies = "Unit Functions";

        public CurrencyModule() : base("Currencies")
        {
            Currencies = new KalkCurrencies(this);
            RegisterVariable("currencies", Currencies, CategoryUnitsAndCurrencies);
            RegisterFunction("currency", new Func<ScriptVariable, decimal?, KalkCurrency>(Currency), CategoryUnitsAndCurrencies);
            BaseCurrency = DefaultBaseCurrency;
        }
        
        [KalkDoc("currencies", CategoryUnitsAndCurrencies)]
        public KalkCurrencies Currencies { get; }

        public DateTime LastUpdate { get; private set; }

        public string BaseCurrency { get; set; }
        
        protected override void Initialize()
        {
            Currencies.Initialize(Engine);
        }

        protected override void Import()
        {
            base.Import();
            UpdateCurrencies();
        }

        [KalkDoc("currency", CategoryUnitsAndCurrencies)]
        public KalkCurrency Currency(ScriptVariable name = null, decimal? value = null)
        {
            return GetOrSetCurrency(name?.Name, value);
        }

        public KalkCurrency GetSafeBaseCurrencyFromConfig()
        {
            if (Engine.Units.TryGetValue(BaseCurrency, out var symbol))
            {
                if (symbol is KalkCurrency currency) return currency;
                throw new ScriptRuntimeException(Engine.CurrentSpan, $"Invalid base currency `{BaseCurrency}` defined. The symbol `{BaseCurrency}` defined from is already attached to a different unit: {symbol}.");
            }
            throw new ScriptRuntimeException(Engine.CurrentSpan, $"Unable to find base currency `{BaseCurrency}`.");
        }

        public KalkCurrency GetOrSetCurrency(string name = null, decimal? value = null)
        {
            if (name == null)
            {
                return GetSafeBaseCurrencyFromConfig();
            }

            if (value == null)
            {
                return RegisterBaseCurrency(name);
            }

            // Verify that the currency name is valid
            KalkCurrency.CheckValid(Engine.CurrentSpan, name);

            if (Engine.Units.TryGetValue(name, out var symbol))
            {
                if (symbol is KalkCurrency currency)
                {
                    currency.Value = new KalkBinaryExpression(1.0m / value, ScriptBinaryOperator.Multiply, GetSafeBaseCurrencyFromConfig());
                    return currency;
                }
                throw new ScriptRuntimeException(Engine.CurrentSpan, $"Unable to define currency `{name}` as it is already attached to a different unit: {symbol}.");
            }

            // New currency
            return RegisterCurrency(name, value.Value, true);
        }

        public KalkCurrency RegisterBaseCurrency(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            KalkCurrency.CheckValid(Engine.CurrentSpan, name);

            KalkCurrency baseCurrency;
            if (Engine.Units.TryGetValue(name, out var unit))
            {
                baseCurrency = unit as KalkCurrency;
                if (baseCurrency != null)
                {
                    // It is already the default unit
                    if (unit.Value == null) return baseCurrency;

                    var existingBase = GetSafeBaseCurrencyFromConfig();
                    var existingConvert = (KalkBinaryExpression) unit.Value;
                    unit.Value = null;

                    // ratio USD = 1.1 EUR
                    var ratio = Engine.ToObject<decimal>(Engine.CurrentSpan, existingConvert.Value);

                    existingBase.Value = new KalkBinaryExpression(1.0m, ScriptBinaryOperator.Multiply, baseCurrency);

                    foreach (var currency in Engine.Units.Values.OfType<KalkCurrency>())
                    {
                        if (currency == baseCurrency) continue;

                        var existingRatio = Engine.ToObject<decimal>(Engine.CurrentSpan, ((KalkBinaryExpression) currency.Value).Value);
                        currency.Value = new KalkBinaryExpression(existingRatio / ratio, ScriptBinaryOperator.Multiply, baseCurrency);
                    }
                }
                else
                {
                    throw new ArgumentException($"Cannot create a new base currency for the existing unity `{unit}`.", nameof(name));
                }
            }
            else
            {
                if (Currencies.Count > 0)
                {
                    throw new ArgumentException($"Cannot create a new base currency when there are already currencies. You need to first create this currency relative to the existing base `{GetSafeBaseCurrencyFromConfig().Name}` currency", nameof(name));
                }

                baseCurrency = new KalkCurrency(this, name)
                {
                    Description = "Default Currency"
                };
                Engine.Units.Add(name, baseCurrency);
            }

            BaseCurrency = name;
            return baseCurrency;
        }

        public KalkCurrency RegisterCurrency(string name, decimal value, bool isUser = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (value <= 0 || KalkValue.AlmostEqual(value, 0.0f)) throw new ArgumentOutOfRangeException(nameof(value), "The currency value must be > 0");
            return (KalkCurrency)Engine.RegisterUnit(new KalkCurrency(this, name), $"Currency {name}", null, new KalkBinaryExpression(1.0m/value, ScriptBinaryOperator.Multiply, GetSafeBaseCurrencyFromConfig()), isUser: isUser);
        }

        private void UpdateCurrencies()
        {
            var rootObject = DownloadExchangeRates(Engine);
            LastUpdate = DateTime.Parse((string)rootObject["date"]);
            var baseCurrency = (string)rootObject["base"];
            var rates = (ScriptObject)rootObject["rates"];

            Engine.WriteHighlightLine($"# Using rates defined as of {LastUpdate:yyyy-MM-dd}.");

            Currencies.Clear();

            RegisterBaseCurrency(baseCurrency);
            foreach (var keyPair in rates)
            {
                var currencyName = keyPair.Key;
                var currencyValue = Engine.ToObject<decimal>(Engine.CurrentSpan, keyPair.Value);
                RegisterCurrency(currencyName, currencyValue);
            }

            // If we have a different base currency from config and it is available, change it immediately
            if (Engine.Config.TryGetValue(ConfigBaseCurrencyProp, out var configBaseCurrency))
            {
                if (configBaseCurrency is string configBaseCurrencyStr)
                {
                    if (configBaseCurrencyStr != baseCurrency)
                    {
                        if (rates.ContainsKey(configBaseCurrencyStr))
                        {
                            RegisterBaseCurrency(configBaseCurrencyStr);
                        }
                        else
                        {
                            Engine.WriteErrorLine($"The config.{ConfigBaseCurrencyProp} = \"{configBaseCurrencyStr}\" does not exist in the defined rates and cannot be used as default.");
                        }
                    }
                }
                else
                {
                    Engine.WriteErrorLine($"Invalid value for config.{ConfigBaseCurrencyProp} = {configBaseCurrency}, Expecting a string instead of {Engine.GetTypeName(configBaseCurrency)}.");
                }
            }
        }

        private static ScriptObject DownloadExchangeRates(KalkEngine engine)
        {
            ScriptObject rates;
            try
            {
                using (var client = new HttpClient())
                {
                    engine.WriteHighlightLine($"# Downloading rates from {ExchangeRatesApi}");

                    var task = Task.Run(async () => await client.GetStringAsync(ExchangeRatesApi));
                    var result = task.Result;
                    rates = ParseRates(result);
                    var values = (ScriptObject)rates["rates"];
                    if (values == null) throw new InvalidOperationException("Unable to find `rates` from returned JSON.");
                    engine.WriteHighlightLine($"# {values.Count} rates successfully updated.");
                    return rates;
                }
            }
            catch (Exception ex)
            {
                engine.WriteError($"Unable to download rates. Reason: {ex.Message}");
                engine.WriteHighlightLine();
                // ignore
            }

            rates = ParseRates(LatestKnownRates);
            return rates;
        }

        private static ScriptObject ParseRates(string text)
        {
            // Parse the rates returned by the HttpClient
            var expr = Template.Parse(text, parserOptions: new ParserOptions() { ParseFloatAsDecimal = true }, lexerOptions: new LexerOptions() { Mode = ScriptMode.ScriptOnly });
            return expr.Evaluate() as ScriptObject;
        }
    }
}