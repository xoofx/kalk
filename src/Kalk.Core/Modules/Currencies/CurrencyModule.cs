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
    [KalkExportModule(ModuleName)]
    public partial class CurrencyModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "Currencies";
        private const string ExchangeRatesApi = "https://api.exchangeratesapi.io/latest";
        private const string ConfigBaseCurrencyProp = "base_currency";
        private const string DefaultBaseCurrency = "EUR";
        private const string LatestKnownRates =
            "{\"rates\":{\"CAD\":1.5118,\"HKD\":8.4052,\"ISK\":158.5,\"PHP\":54.681,\"DKK\":7.4598,\"HUF\":349.38,\"CZK\":27.251,\"AUD\":1.6613,\"RON\":4.828,\"SEK\":10.5875,\"IDR\":16229.26,\"INR\":81.9615,\"BRL\":6.3074,\"RUB\":79.8383,\"HRK\":7.5573,\"JPY\":115.34,\"THB\":34.958,\"CHF\":1.0529,\"SGD\":1.5326,\"PLN\":4.5482,\"BGN\":1.9558,\"TRY\":7.7252,\"CNY\":7.6719,\"NOK\":11.0695,\"NZD\":1.7668,\"ZAR\":19.997,\"USD\":1.0843,\"MXN\":25.9023,\"ILS\":3.8031,\"GBP\":0.87535,\"KRW\":1322.41,\"MYR\":4.6994},\"base\":\"EUR\",\"date\":\"2020-05-08\"}";

        private const string CategoryUnitsAndCurrencies = "Unit Functions";

        public CurrencyModule() : base(ModuleName)
        {
            Currencies = new KalkCurrencies(this);
            BaseCurrency = DefaultBaseCurrency;
            RegisterFunctionsAuto();
        }


        /// <summary>
        /// Gets all the defined currencies. The default base currency is EUR.
        /// </summary>
        /// <returns>All the defined currencies.</returns>
        /// <example>
        /// ```kalk
        /// >>> currencies
        /// # Builtin Currencies (Last Update: 08-May-20 00:00:00)
        /// currency(AUD, 1.6613);      # 1.6613   AUD => 1 EUR
        /// currency(BGN, 1.9558);      # 1.9558   BGN => 1 EUR
        /// currency(BRL, 6.3074);      # 6.3074   BRL => 1 EUR
        /// currency(CAD, 1.5118);      # 1.5118   CAD => 1 EUR
        /// currency(CHF, 1.0529);      # 1.0529   CHF => 1 EUR
        /// currency(CNY, 7.6719);      # 7.6719   CNY => 1 EUR
        /// currency(CZK, 27.251);      # 27.251   CZK => 1 EUR
        /// currency(DKK, 7.4598);      # 7.4598   DKK => 1 EUR
        /// currency(EUR);              # Base currency
        /// currency(GBP, 0.8754);      # 0.8754   GBP => 1 EUR
        /// currency(HKD, 8.4052);      # 8.4052   HKD => 1 EUR
        /// currency(HRK, 7.5573);      # 7.5573   HRK => 1 EUR
        /// currency(HUF, 349.38);      # 349.38   HUF => 1 EUR
        /// currency(IDR, 16229.26);    # 16229.26 IDR => 1 EUR
        /// currency(ILS, 3.8031);      # 3.8031   ILS => 1 EUR
        /// currency(INR, 81.9615);     # 81.9615  INR => 1 EUR
        /// currency(ISK, 158.5);       # 158.5    ISK => 1 EUR
        /// currency(JPY, 115.34);      # 115.34   JPY => 1 EUR
        /// currency(KRW, 1322.41);     # 1322.41  KRW => 1 EUR
        /// currency(MXN, 25.9023);     # 25.9023  MXN => 1 EUR
        /// currency(MYR, 4.6994);      # 4.6994   MYR => 1 EUR
        /// currency(NOK, 11.0695);     # 11.0695  NOK => 1 EUR
        /// currency(NZD, 1.7668);      # 1.7668   NZD => 1 EUR
        /// currency(PHP, 54.681);      # 54.681   PHP => 1 EUR
        /// currency(PLN, 4.5482);      # 4.5482   PLN => 1 EUR
        /// currency(RON, 4.828);       # 4.828    RON => 1 EUR
        /// currency(RUB, 79.8383);     # 79.8383  RUB => 1 EUR
        /// currency(SEK, 10.5875);     # 10.5875  SEK => 1 EUR
        /// currency(SGD, 1.5326);      # 1.5326   SGD => 1 EUR
        /// currency(THB, 34.958);      # 34.958   THB => 1 EUR
        /// currency(TRY, 7.7252);      # 7.7252   TRY => 1 EUR
        /// currency(USD, 1.0843);      # 1.0843   USD => 1 EUR
        /// currency(ZAR, 19.997);      # 19.997   ZAR => 1 EUR
        /// ```
        /// </example>
        [KalkExport("currencies", CategoryUnitsAndCurrencies)]
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

        /// <summary>
        /// Gets or sets the default currency. The default base currency is EUR.
        /// </summary>
        /// <param name="name">If not null, name of the currency to set.</param>
        /// <param name="value">If name is not null, value of the currency </param>
        /// <returns>The default defined currency.</returns>
        /// <example>
        /// ```kalk
        /// >>> USD
        /// currency(USD, 1.0843);      # 1.0843   USD => 1 EUR
        /// >>> 2 USD
        /// # 2 * USD
        /// out = 1.8445079774970026745365673706 * EUR
        /// >>> currency(GBP) # Defines GBP as the default currency instead of EUR
        /// # currency(GBP) # Defines GBP as the default currency instead of EUR
        /// out = GBP
        /// >>> USD
        /// currency(USD, 1.2387);      # 1.2387   USD => 1 GBP
        /// >>> 2 USD |> to EUR # Convert 2 dollars to EUR
        /// # 2 * USD |> to(EUR) # Convert 2 dollars to EUR
        /// out = 1.844507977497004 * EUR
        /// ```
        /// </example>
        [KalkExport("currency", CategoryUnitsAndCurrencies)]
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
                    var baseCurrency = GetSafeBaseCurrencyFromConfig();
                    if (baseCurrency == currency)
                    {
                        throw new ScriptRuntimeException(Engine.CurrentSpan, $"Cannot change the rate of the base currency `{name}`.");
                    }
                    currency.Value = new KalkBinaryExpression(1.0m / value, ScriptBinaryOperator.Multiply, baseCurrency);
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
                    var values = (ScriptObject) rates["rates"];
                    if (values == null) throw new InvalidOperationException("Unable to find `rates` from returned JSON.");
                    engine.WriteHighlightLine($"# {values.Count} rates successfully updated.");

                    // If the engine is in testing, return only the latest known rates
                    if (!engine.IsTesting)
                    {
                        return rates;
                    }
                }
            }
            catch (Exception ex)
            {
                engine.WriteErrorLine($"Unable to download rates. Reason: {ex.Message}");
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