using System;
using System.Globalization;
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
        private const string ExchangeRatesApi = "http://www.floatrates.com/daily/eur.json";
        private const string ConfigBaseCurrencyProp = "base_currency";
        private const string DefaultBaseCurrency = "EUR";
        private const string LatestKnownRates =
            "{\"usd\":{\"code\":\"USD\",\"alphaCode\":\"USD\",\"numericCode\":\"840\",\"name\":\"U.S. Dollar\",\"rate\":1.1032706064866,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.9063959414133},\"gbp\":{\"code\":\"GBP\",\"alphaCode\":\"GBP\",\"numericCode\":\"826\",\"name\":\"U.K. Pound Sterling\",\"rate\":0.82740924942066,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":1.2085917587943},\"jpy\":{\"code\":\"JPY\",\"alphaCode\":\"JPY\",\"numericCode\":\"392\",\"name\":\"Japanese Yen\",\"rate\":127.17640518783,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0078630937753202},\"aud\":{\"code\":\"AUD\",\"alphaCode\":\"AUD\",\"numericCode\":\"036\",\"name\":\"Australian Dollar\",\"rate\":1.5034989486269,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.66511519739555},\"chf\":{\"code\":\"CHF\",\"alphaCode\":\"CHF\",\"numericCode\":\"756\",\"name\":\"Swiss Franc\",\"rate\":1.0139379355867,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.98625366001452},\"cad\":{\"code\":\"CAD\",\"alphaCode\":\"CAD\",\"numericCode\":\"124\",\"name\":\"Canadian Dollar\",\"rate\":1.4036871230505,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.71240947044295},\"idr\":{\"code\":\"IDR\",\"alphaCode\":\"IDR\",\"numericCode\":\"360\",\"name\":\"Indonesian Rupiah\",\"rate\":15844.343171938,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":6.3114007892174e-5},\"tnd\":{\"code\":\"TND\",\"alphaCode\":\"TND\",\"numericCode\":\"788\",\"name\":\"Tunisian Dinar\",\"rate\":3.28682793685,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.30424470620703},\"twd\":{\"code\":\"TWD\",\"alphaCode\":\"TWD\",\"numericCode\":\"901\",\"name\":\"New Taiwan Dollar \",\"rate\":31.067477896638,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.032188000690852},\"iqd\":{\"code\":\"IQD\",\"alphaCode\":\"IQD\",\"numericCode\":\"368\",\"name\":\"Iraqi dinar\",\"rate\":1653.9686721342,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00060460637305158},\"bob\":{\"code\":\"BOB\",\"alphaCode\":\"BOB\",\"numericCode\":\"068\",\"name\":\"Bolivian Boliviano\",\"rate\":7.6369788237054,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.13094183224601},\"lrd\":{\"code\":\"LRD\",\"alphaCode\":\"LRD\",\"numericCode\":\"430\",\"name\":\"Liberian dollar\",\"rate\":172.40075562571,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0058004386139179},\"sdg\":{\"code\":\"SDG\",\"alphaCode\":\"SDG\",\"numericCode\":\"938\",\"name\":\"Sudanese pound\",\"rate\":499.42899310127,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0020022866389682},\"top\":{\"code\":\"TOP\",\"alphaCode\":\"TOP\",\"numericCode\":\"776\",\"name\":\"Tongan pa\u02bbanga\",\"rate\":2.5439590574398,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.393088087277},\"vuv\":{\"code\":\"VUV\",\"alphaCode\":\"VUV\",\"numericCode\":\"548\",\"name\":\"Vanuatu vatu\",\"rate\":126.04296170372,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0079338027802827},\"dkk\":{\"code\":\"DKK\",\"alphaCode\":\"DKK\",\"numericCode\":\"208\",\"name\":\"Danish Krone\",\"rate\":7.4076493573313,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.13499559060666},\"kwd\":{\"code\":\"KWD\",\"alphaCode\":\"KWD\",\"numericCode\":\"414\",\"name\":\"Kuwaiti Dinar\",\"rate\":0.33616517194772,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":2.9747281498736},\"czk\":{\"code\":\"CZK\",\"alphaCode\":\"CZK\",\"numericCode\":\"203\",\"name\":\"Czech Koruna\",\"rate\":25.089268962247,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.039857677858401},\"ngn\":{\"code\":\"NGN\",\"alphaCode\":\"NGN\",\"numericCode\":\"566\",\"name\":\"Nigerian Naira\",\"rate\":462.17065498729,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0021637029292297},\"tmt\":{\"code\":\"TMT\",\"alphaCode\":\"TMT\",\"numericCode\":\"934\",\"name\":\"New Turkmenistan Manat\",\"rate\":3.9646679544332,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.25222793219842},\"etb\":{\"code\":\"ETB\",\"alphaCode\":\"ETB\",\"numericCode\":\"230\",\"name\":\"Ethiopian birr\",\"rate\":57.398829775857,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.017421957972053},\"ttd\":{\"code\":\"TTD\",\"alphaCode\":\"TTD\",\"numericCode\":\"780\",\"name\":\"Trinidad Tobago Dollar\",\"rate\":7.5908198575407,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.13173807556592},\"lak\":{\"code\":\"LAK\",\"alphaCode\":\"LAK\",\"numericCode\":\"418\",\"name\":\"Lao kip\",\"rate\":12816.035008154,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":7.8027252528862e-5},\"bwp\":{\"code\":\"BWP\",\"alphaCode\":\"BWP\",\"numericCode\":\"072\",\"name\":\"Botswana Pula\",\"rate\":13.096678110524,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.076355239974667},\"mad\":{\"code\":\"MAD\",\"alphaCode\":\"MAD\",\"numericCode\":\"504\",\"name\":\"Moroccan Dirham\",\"rate\":10.720491318486,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.093279306917181},\"ron\":{\"code\":\"RON\",\"alphaCode\":\"RON\",\"numericCode\":\"946\",\"name\":\"Romanian New Leu\",\"rate\":4.9172255451706,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.2033667137726},\"byn\":{\"code\":\"BYN\",\"alphaCode\":\"BYN\",\"numericCode\":\"933\",\"name\":\"Belarussian Ruble\",\"rate\":3.0138736755389,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.33179890986015},\"tjs\":{\"code\":\"TJS\",\"alphaCode\":\"TJS\",\"numericCode\":\"972\",\"name\":\"Tajikistan Ruble\",\"rate\":12.8000125766,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.078124923238604},\"gmd\":{\"code\":\"GMD\",\"alphaCode\":\"GMD\",\"numericCode\":\"270\",\"name\":\"Gambian dalasi\",\"rate\":59.734417177341,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.016740767672198},\"cve\":{\"code\":\"CVE\",\"alphaCode\":\"CVE\",\"numericCode\":\"132\",\"name\":\"Cape Verde escudo\",\"rate\":111.8813217802,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0089380424193108},\"aoa\":{\"code\":\"AOA\",\"alphaCode\":\"AOA\",\"numericCode\":\"973\",\"name\":\"Angolan kwanza\",\"rate\":556.83462449223,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0017958653359817},\"khr\":{\"code\":\"KHR\",\"alphaCode\":\"KHR\",\"numericCode\":\"116\",\"name\":\"Cambodian riel\",\"rate\":4548.7898902183,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00021983868768052},\"bhd\":{\"code\":\"BHD\",\"alphaCode\":\"BHD\",\"numericCode\":\"048\",\"name\":\"Bahrain Dinar\",\"rate\":0.41757397848666,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":2.3947852393105},\"omr\":{\"code\":\"OMR\",\"alphaCode\":\"OMR\",\"numericCode\":\"512\",\"name\":\"Omani Rial\",\"rate\":0.42661405454072,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":2.3440390426813},\"ils\":{\"code\":\"ILS\",\"alphaCode\":\"ILS\",\"numericCode\":\"376\",\"name\":\"Israeli New Sheqel\",\"rate\":3.5774874765223,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.27952578634101},\"lyd\":{\"code\":\"LYD\",\"alphaCode\":\"LYD\",\"numericCode\":\"434\",\"name\":\"Libyan Dinar\",\"rate\":5.2190748071308,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.19160484127066},\"clp\":{\"code\":\"CLP\",\"alphaCode\":\"CLP\",\"numericCode\":\"152\",\"name\":\"Chilean Peso\",\"rate\":883.80709017458,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.001131468632824},\"bsd\":{\"code\":\"BSD\",\"alphaCode\":\"BSD\",\"numericCode\":\"044\",\"name\":\"Bahamian Dollar\",\"rate\":1.1187615429039,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.8938455261917},\"xpf\":{\"code\":\"XPF\",\"alphaCode\":\"XPF\",\"numericCode\":\"953\",\"name\":\"CFP Franc\",\"rate\":120.38321239209,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0083068060747785},\"hnl\":{\"code\":\"HNL\",\"alphaCode\":\"HNL\",\"numericCode\":\"340\",\"name\":\"Honduran Lempira\",\"rate\":27.556662304223,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.03628886506501},\"scr\":{\"code\":\"SCR\",\"alphaCode\":\"SCR\",\"numericCode\":\"690\",\"name\":\"Seychelles rupee\",\"rate\":16.115972165944,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.06205024367771},\"bdt\":{\"code\":\"BDT\",\"alphaCode\":\"BDT\",\"numericCode\":\"050\",\"name\":\"Bangladeshi taka\",\"rate\":97.060316838881,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.010302871787035},\"qar\":{\"code\":\"QAR\",\"alphaCode\":\"QAR\",\"numericCode\":\"634\",\"name\":\"Qatari Rial\",\"rate\":4.0412692099689,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.24744701430264},\"myr\":{\"code\":\"MYR\",\"alphaCode\":\"MYR\",\"numericCode\":\"458\",\"name\":\"Malaysian Ringgit\",\"rate\":4.6522223443567,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.21495103328693},\"kzt\":{\"code\":\"KZT\",\"alphaCode\":\"KZT\",\"numericCode\":\"398\",\"name\":\"Kazakhstani Tenge\",\"rate\":488.68592312671,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0020463040834117},\"htg\":{\"code\":\"HTG\",\"alphaCode\":\"HTG\",\"numericCode\":\"332\",\"name\":\"Haitian gourde\",\"rate\":116.69893991919,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0085690581310546},\"bnd\":{\"code\":\"BND\",\"alphaCode\":\"BND\",\"numericCode\":\"096\",\"name\":\"Brunei Dollar\",\"rate\":1.5209761806796,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.65747249214197},\"kmf\":{\"code\":\"KMF\",\"alphaCode\":\"KMF\",\"numericCode\":\"174\",\"name\":\"\tComoro franc\",\"rate\":494.43368371938,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0020225159266608},\"lsl\":{\"code\":\"LSL\",\"alphaCode\":\"LSL\",\"numericCode\":\"426\",\"name\":\"Lesotho loti\",\"rate\":17.332598329454,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.057694754184701},\"tzs\":{\"code\":\"TZS\",\"alphaCode\":\"TZS\",\"numericCode\":\"834\",\"name\":\"Tanzanian shilling\",\"rate\":2592.0070803009,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00038580141528159},\"hkd\":{\"code\":\"HKD\",\"alphaCode\":\"HKD\",\"numericCode\":\"344\",\"name\":\"Hong Kong Dollar\",\"rate\":8.6189367588068,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.11602359177055},\"thb\":{\"code\":\"THB\",\"alphaCode\":\"THB\",\"numericCode\":\"764\",\"name\":\"Thai Baht\",\"rate\":36.523263637285,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.027379809480639},\"xof\":{\"code\":\"XOF\",\"alphaCode\":\"XOF\",\"numericCode\":\"952\",\"name\":\"West African CFA Franc\",\"rate\":662.84665352902,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0015086445630765},\"irr\":{\"code\":\"IRR\",\"alphaCode\":\"IRR\",\"numericCode\":\"364\",\"name\":\"Iranian rial\",\"rate\":47584.195314359,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":2.1015381123787e-5},\"uyu\":{\"code\":\"UYU\",\"alphaCode\":\"UYU\",\"numericCode\":\"858\",\"name\":\"Uruguayan Peso\",\"rate\":47.367215284241,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.021111648510456},\"jmd\":{\"code\":\"JMD\",\"alphaCode\":\"JMD\",\"numericCode\":\"388\",\"name\":\"Jamaican Dollar\",\"rate\":173.01647261009,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0057797964836193},\"ssp\":{\"code\":\"SSP\",\"alphaCode\":\"SSP\",\"numericCode\":\"728\",\"name\":\"South Sudanese pound\",\"rate\":481.22193633481,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0020780432571641},\"mru\":{\"code\":\"MRU\",\"alphaCode\":\"MRU\",\"numericCode\":\"929\",\"name\":\"Mauritanian ouguiya\",\"rate\":40.709758261198,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.024564135055382},\"mnt\":{\"code\":\"MNT\",\"alphaCode\":\"MNT\",\"numericCode\":\"496\",\"name\":\"Mongolian togrog\",\"rate\":3229.640822055,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0003096319544796},\"jod\":{\"code\":\"JOD\",\"alphaCode\":\"JOD\",\"numericCode\":\"400\",\"name\":\"Jordanian Dinar\",\"rate\":0.7850570951584,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":1.2737927039539},\"bgn\":{\"code\":\"BGN\",\"alphaCode\":\"BGN\",\"numericCode\":\"975\",\"name\":\"Bulgarian Lev\",\"rate\":1.9433716837914,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.51456960515604},\"pgk\":{\"code\":\"PGK\",\"alphaCode\":\"PGK\",\"numericCode\":\"598\",\"name\":\"Papua New Guinean kina\",\"rate\":3.890090380445,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.25706343611626},\"uzs\":{\"code\":\"UZS\",\"alphaCode\":\"UZS\",\"numericCode\":\"860\",\"name\":\"Uzbekistan Sum\",\"rate\":12247.905614327,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":8.1646612203662e-5},\"mga\":{\"code\":\"MGA\",\"alphaCode\":\"MGA\",\"numericCode\":\"969\",\"name\":\"Malagasy ariary\",\"rate\":4469.0601781204,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00022376069243726},\"srd\":{\"code\":\"SRD\",\"alphaCode\":\"SRD\",\"numericCode\":\"968\",\"name\":\"Surinamese dollar\",\"rate\":22.905254057128,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.043658105581624},\"ghs\":{\"code\":\"GHS\",\"alphaCode\":\"GHS\",\"numericCode\":\"936\",\"name\":\"Ghanaian Cedi\",\"rate\":7.7214874610815,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.12950872549367},\"cup\":{\"code\":\"CUP\",\"alphaCode\":\"CUP\",\"numericCode\":\"192\",\"name\":\"Cuban peso\",\"rate\":1.1187615429039,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.8938455261917},\"lkr\":{\"code\":\"LKR\",\"alphaCode\":\"LKR\",\"numericCode\":\"144\",\"name\":\"Sri Lanka Rupee\",\"rate\":224.42933387966,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0044557455244965},\"pln\":{\"code\":\"PLN\",\"alphaCode\":\"PLN\",\"numericCode\":\"985\",\"name\":\"Polish Zloty\",\"rate\":4.6971953149782,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.21289299953341},\"rub\":{\"code\":\"RUB\",\"alphaCode\":\"RUB\",\"numericCode\":\"643\",\"name\":\"Russian Rouble\",\"rate\":112.2524684184,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0089084900678773},\"azn\":{\"code\":\"AZN\",\"alphaCode\":\"AZN\",\"numericCode\":\"944\",\"name\":\"Azerbaijan Manat\",\"rate\":1.9217854409915,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.52034945143723},\"nio\":{\"code\":\"NIO\",\"alphaCode\":\"NIO\",\"numericCode\":\"558\",\"name\":\"Nicaraguan C\u00f3rdoba\",\"rate\":40.003808695975,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.024997619791653},\"sbd\":{\"code\":\"SBD\",\"alphaCode\":\"SBD\",\"numericCode\":\"090\",\"name\":\"Solomon Islands dollar\",\"rate\":9.1508523480968,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.109279437801},\"zmw\":{\"code\":\"ZMW\",\"alphaCode\":\"ZMW\",\"numericCode\":\"967\",\"name\":\"Zambian kwacha\",\"rate\":19.960697293294,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.050098450234801},\"yer\":{\"code\":\"YER\",\"alphaCode\":\"YER\",\"numericCode\":\"886\",\"name\":\"Yemeni rial\",\"rate\":280.0428483197,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0035708821203617},\"sek\":{\"code\":\"SEK\",\"alphaCode\":\"SEK\",\"numericCode\":\"752\",\"name\":\"Swedish Krona\",\"rate\":10.716784379067,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.093311572261666},\"nzd\":{\"code\":\"NZD\",\"alphaCode\":\"NZD\",\"numericCode\":\"554\",\"name\":\"New Zealand Dollar\",\"rate\":1.6167076709453,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.61854101268368},\"hrk\":{\"code\":\"HRK\",\"alphaCode\":\"HRK\",\"numericCode\":\"191\",\"name\":\"Croatian Kuna\",\"rate\":7.5019674708265,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.13329836524735},\"dzd\":{\"code\":\"DZD\",\"alphaCode\":\"DZD\",\"numericCode\":\"012\",\"name\":\"Algerian Dinar\",\"rate\":158.87364595816,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0062943101353849},\"ars\":{\"code\":\"ARS\",\"alphaCode\":\"ARS\",\"numericCode\":\"032\",\"name\":\"Argentine Peso\",\"rate\":119.75532770356,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0083503591796379},\"stn\":{\"code\":\"STN\",\"alphaCode\":\"STN\",\"numericCode\":\"930\",\"name\":\"S\u00e3o Tom\u00e9 and Pr\u00edncipe Dobra\",\"rate\":24.984328174742,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.040025090649064},\"bif\":{\"code\":\"BIF\",\"alphaCode\":\"BIF\",\"numericCode\":\"108\",\"name\":\"Burundian franc\",\"rate\":2237.6264356039,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00044690212096556},\"all\":{\"code\":\"ALL\",\"alphaCode\":\"ALL\",\"numericCode\":\"008\",\"name\":\"Albanian lek\",\"rate\":122.73780676673,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.008147448828873},\"mur\":{\"code\":\"MUR\",\"alphaCode\":\"MUR\",\"numericCode\":\"480\",\"name\":\"Mauritian Rupee\",\"rate\":49.686781877768,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.020126077041175},\"dop\":{\"code\":\"DOP\",\"alphaCode\":\"DOP\",\"numericCode\":\"214\",\"name\":\"Dominican Peso\",\"rate\":60.996752759965,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.016394315348806},\"ang\":{\"code\":\"ANG\",\"alphaCode\":\"ANG\",\"numericCode\":\"532\",\"name\":\"Neth. Antillean Guilder\",\"rate\":1.9909819074203,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.50226473493959},\"pkr\":{\"code\":\"PKR\",\"alphaCode\":\"PKR\",\"numericCode\":\"586\",\"name\":\"Pakistani Rupee\",\"rate\":199.63261999344,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00500920140222},\"mxn\":{\"code\":\"MXN\",\"alphaCode\":\"MXN\",\"numericCode\":\"484\",\"name\":\"Mexican Peso\",\"rate\":22.812327362328,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.04383594817473},\"uah\":{\"code\":\"UAH\",\"alphaCode\":\"UAH\",\"numericCode\":\"980\",\"name\":\"Ukrainian Hryvnia\",\"rate\":32.639225671888,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.030637981735618},\"crc\":{\"code\":\"CRC\",\"alphaCode\":\"CRC\",\"numericCode\":\"188\",\"name\":\"Costa Rican Col\u00f3n\",\"rate\":716.91590555507,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0013948637382034},\"bzd\":{\"code\":\"BZD\",\"alphaCode\":\"BZD\",\"numericCode\":\"084\",\"name\":\"Belize dollar\",\"rate\":2.255860876872,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.44328974816329},\"gnf\":{\"code\":\"GNF\",\"alphaCode\":\"GNF\",\"numericCode\":\"324\",\"name\":\"Guinean franc\",\"rate\":10050.749446229,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":9.9495068039445e-5},\"szl\":{\"code\":\"SZL\",\"alphaCode\":\"SZL\",\"numericCode\":\"748\",\"name\":\"Swazi lilangeni\",\"rate\":17.332598329454,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.057694754184701},\"sos\":{\"code\":\"SOS\",\"alphaCode\":\"SOS\",\"numericCode\":\"706\",\"name\":\"Somali shilling\",\"rate\":647.39559442503,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0015446506102472},\"egp\":{\"code\":\"EGP\",\"alphaCode\":\"EGP\",\"numericCode\":\"818\",\"name\":\"Egyptian Pound\",\"rate\":17.354669214651,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.05762138059974},\"sgd\":{\"code\":\"SGD\",\"alphaCode\":\"SGD\",\"numericCode\":\"702\",\"name\":\"Singapore Dollar\",\"rate\":1.4967455127111,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.66811625056332},\"xaf\":{\"code\":\"XAF\",\"alphaCode\":\"XAF\",\"numericCode\":\"950\",\"name\":\"Central African CFA Franc\",\"rate\":662.62462485895,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0015091500715248},\"amd\":{\"code\":\"AMD\",\"alphaCode\":\"AMD\",\"numericCode\":\"051\",\"name\":\"Armenia Dram\",\"rate\":547.56996563906,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0018262506396473},\"pyg\":{\"code\":\"PYG\",\"alphaCode\":\"PYG\",\"numericCode\":\"600\",\"name\":\"Paraguayan Guaran\u00ed\",\"rate\":7755.7085640874,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00012893728429024},\"gyd\":{\"code\":\"GYD\",\"alphaCode\":\"GYD\",\"numericCode\":\"328\",\"name\":\"Guyanese dollar\",\"rate\":234.14505718137,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0042708567587886},\"rwf\":{\"code\":\"RWF\",\"alphaCode\":\"RWF\",\"numericCode\":\"646\",\"name\":\"Rwandan franc\",\"rate\":1135.3319036988,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00088079969984295},\"ern\":{\"code\":\"ERN\",\"alphaCode\":\"ERN\",\"numericCode\":\"232\",\"name\":\"Eritrean nakfa\",\"rate\":16.873776499765,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.059263556087396},\"wst\":{\"code\":\"WST\",\"alphaCode\":\"WST\",\"numericCode\":\"882\",\"name\":\"Samoan tala\",\"rate\":2.8820639140238,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.34697356818984},\"inr\":{\"code\":\"INR\",\"alphaCode\":\"INR\",\"numericCode\":\"356\",\"name\":\"Indian Rupee\",\"rate\":83.733511017801,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0119426498166},\"try\":{\"code\":\"TRY\",\"alphaCode\":\"TRY\",\"numericCode\":\"949\",\"name\":\"Turkish Lira\",\"rate\":15.583999834619,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.064168378504379},\"vnd\":{\"code\":\"VND\",\"alphaCode\":\"VND\",\"numericCode\":\"704\",\"name\":\"Vietnamese Dong\",\"rate\":25428.905917151,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":3.9325325409519e-5},\"kgs\":{\"code\":\"KGS\",\"alphaCode\":\"KGS\",\"numericCode\":\"417\",\"name\":\"Kyrgyzstan Som\",\"rate\":96.091302357937,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.01040676913999},\"afn\":{\"code\":\"AFN\",\"alphaCode\":\"AFN\",\"numericCode\":\"971\",\"name\":\"Afghan afghani\",\"rate\":101.98865753858,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0098050118918542},\"nad\":{\"code\":\"NAD\",\"alphaCode\":\"NAD\",\"numericCode\":\"516\",\"name\":\"Namibian dollar\",\"rate\":17.326399259952,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.057715396314997},\"syp\":{\"code\":\"SYP\",\"alphaCode\":\"SYP\",\"numericCode\":\"760\",\"name\":\"Syrian pound\",\"rate\":2849.6830782838,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00035091621507689},\"mop\":{\"code\":\"MOP\",\"alphaCode\":\"MOP\",\"numericCode\":\"446\",\"name\":\"Macanese pataca\",\"rate\":9.0129511313165,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.11095145035519},\"bam\":{\"code\":\"BAM\",\"alphaCode\":\"BAM\",\"numericCode\":\"977\",\"name\":\"Bosnia and Herzegovina convertible mark\",\"rate\":1.979269992271,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.50523678118951},\"lbp\":{\"code\":\"LBP\",\"alphaCode\":\"LBP\",\"numericCode\":\"422\",\"name\":\"Lebanese Pound\",\"rate\":1701.7386732283,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00058763429175816},\"huf\":{\"code\":\"HUF\",\"alphaCode\":\"HUF\",\"numericCode\":\"348\",\"name\":\"Hungarian Forint\",\"rate\":371.83632857316,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0026893552973624},\"pen\":{\"code\":\"PEN\",\"alphaCode\":\"PEN\",\"numericCode\":\"604\",\"name\":\"Peruvian Nuevo Sol\",\"rate\":4.1375016780429,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.24169174487756},\"rsd\":{\"code\":\"RSD\",\"alphaCode\":\"RSD\",\"numericCode\":\"941\",\"name\":\"Serbian Dinar\",\"rate\":119.34335455424,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0083791846117877},\"svc\":{\"code\":\"SVC\",\"alphaCode\":\"SVC\",\"numericCode\":\"222\",\"name\":\"Salvadoran colon\",\"rate\":9.7966860123005,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.10207533432677},\"xcd\":{\"code\":\"XCD\",\"alphaCode\":\"XCD\",\"numericCode\":\"951\",\"name\":\"East Caribbean Dollar\",\"rate\":3.0334760382483,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.32965482086928},\"mwk\":{\"code\":\"MWK\",\"alphaCode\":\"MWK\",\"numericCode\":\"454\",\"name\":\"Malawian kwacha\",\"rate\":913.70449511176,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0010944457484339},\"gtq\":{\"code\":\"GTQ\",\"alphaCode\":\"GTQ\",\"numericCode\":\"320\",\"name\":\"Guatemalan Quetzal\",\"rate\":8.6400236010031,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.11574042458448},\"nok\":{\"code\":\"NOK\",\"alphaCode\":\"NOK\",\"numericCode\":\"578\",\"name\":\"Norwegian Krone\",\"rate\":9.8675945121825,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.10134182132894},\"npr\":{\"code\":\"NPR\",\"alphaCode\":\"NPR\",\"numericCode\":\"524\",\"name\":\"Nepalese Rupee\",\"rate\":135.08133826849,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0074029470896443},\"isk\":{\"code\":\"ISK\",\"alphaCode\":\"ISK\",\"numericCode\":\"352\",\"name\":\"Icelandic Krona\",\"rate\":145.42178085889,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0068765489880114},\"gip\":{\"code\":\"GIP\",\"alphaCode\":\"GIP\",\"numericCode\":\"292\",\"name\":\"Gibraltar pound\",\"rate\":0.83401360623645,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":1.1990212060359},\"gel\":{\"code\":\"GEL\",\"alphaCode\":\"GEL\",\"numericCode\":\"981\",\"name\":\"Georgian lari\",\"rate\":3.4674761112656,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.28839420025161},\"mkd\":{\"code\":\"MKD\",\"alphaCode\":\"MKD\",\"numericCode\":\"807\",\"name\":\"Macedonian denar\",\"rate\":62.194592937435,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.016078568132216},\"awg\":{\"code\":\"AWG\",\"alphaCode\":\"AWG\",\"numericCode\":\"533\",\"name\":\"Aruban florin\",\"rate\":2.025530473338,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.49369783035258},\"mmk\":{\"code\":\"MMK\",\"alphaCode\":\"MMK\",\"numericCode\":\"104\",\"name\":\"Myanma Kyat\",\"rate\":1990.3291836822,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0005024294514689},\"mvr\":{\"code\":\"MVR\",\"alphaCode\":\"MVR\",\"numericCode\":\"462\",\"name\":\"Maldivian rufiyaa\",\"rate\":17.301647261009,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.057797964836193},\"ves\":{\"code\":\"VES\",\"alphaCode\":\"VES\",\"numericCode\":\"928\",\"name\":\"Venezuelan Bolivar\",\"rate\":4.854954651134,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.20597514742314},\"aed\":{\"code\":\"AED\",\"alphaCode\":\"AED\",\"numericCode\":\"784\",\"name\":\"U.A.E Dirham\",\"rate\":4.1321028781617,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.24200752727746},\"php\":{\"code\":\"PHP\",\"alphaCode\":\"PHP\",\"numericCode\":\"608\",\"name\":\"Philippine Peso\",\"rate\":57.308438938117,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.017449437090405},\"krw\":{\"code\":\"KRW\",\"alphaCode\":\"KRW\",\"numericCode\":\"410\",\"name\":\"South Korean Won\",\"rate\":1336.5796096044,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00074817840464885},\"mro\":{\"code\":\"MRO\",\"alphaCode\":\"MRO\",\"numericCode\":\"478\",\"name\":\"Mauritanian Ouguiya\",\"rate\":40.147839510106,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.024907940556758},\"cop\":{\"code\":\"COP\",\"alphaCode\":\"COP\",\"numericCode\":\"170\",\"name\":\"Colombian Peso\",\"rate\":4286.4925092498,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00023329097107766},\"bbd\":{\"code\":\"BBD\",\"alphaCode\":\"BBD\",\"numericCode\":\"052\",\"name\":\"Barbadian Dollar\",\"rate\":2.2596488796505,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.44254663147253},\"djf\":{\"code\":\"DJF\",\"alphaCode\":\"DJF\",\"numericCode\":\"262\",\"name\":\"Djiboutian franc\",\"rate\":199.22936474266,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0050193404034172},\"sll\":{\"code\":\"SLL\",\"alphaCode\":\"SLL\",\"numericCode\":\"694\",\"name\":\"Sierra Leonean leone\",\"rate\":13022.745250222,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":7.6788724710937e-5},\"kes\":{\"code\":\"KES\",\"alphaCode\":\"KES\",\"numericCode\":\"404\",\"name\":\"Kenyan shilling\",\"rate\":127.46904967984,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.0078450416199983},\"cny\":{\"code\":\"CNY\",\"alphaCode\":\"CNY\",\"numericCode\":\"156\",\"name\":\"Chinese Yuan\",\"rate\":6.9711838496557,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.14344765847043},\"sar\":{\"code\":\"SAR\",\"alphaCode\":\"SAR\",\"numericCode\":\"682\",\"name\":\"Saudi Riyal\",\"rate\":4.1418413733054,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.24143850762733},\"zar\":{\"code\":\"ZAR\",\"alphaCode\":\"ZAR\",\"numericCode\":\"710\",\"name\":\"South African Rand\",\"rate\":16.868867158398,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.05928080354241},\"mdl\":{\"code\":\"MDL\",\"alphaCode\":\"MDL\",\"numericCode\":\"498\",\"name\":\"Moldova Lei\",\"rate\":19.921033341756,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.050198199202042},\"pab\":{\"code\":\"PAB\",\"alphaCode\":\"PAB\",\"numericCode\":\"590\",\"name\":\"Panamanian Balboa\",\"rate\":1.1110160746952,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.90007698608169},\"fjd\":{\"code\":\"FJD\",\"alphaCode\":\"FJD\",\"numericCode\":\"242\",\"name\":\"Fiji Dollar\",\"rate\":2.3778830967862,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.42054212057419},\"cdf\":{\"code\":\"CDF\",\"alphaCode\":\"CDF\",\"numericCode\":\"976\",\"name\":\"Congolese franc\",\"rate\":2239.6954383183,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00044648927835959},\"mzn\":{\"code\":\"MZN\",\"alphaCode\":\"MZN\",\"numericCode\":\"943\",\"name\":\"Mozambican metical\",\"rate\":71.769796045668,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.013933437951582},\"ugx\":{\"code\":\"UGX\",\"alphaCode\":\"UGX\",\"numericCode\":\"800\",\"name\":\"Ugandan shilling\",\"rate\":3954.6622310877,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.00025286609615834},\"brl\":{\"code\":\"BRL\",\"alphaCode\":\"BRL\",\"numericCode\":\"986\",\"name\":\"Brazilian Real\",\"rate\":5.7249491318243,\"date\":\"Sun, 6 Mar 2022 11:55:01 GMT\",\"inverseRate\":0.17467404110914}}";

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
        /// # Builtin Currencies (Last Update: 06 Mar 2022)
        /// currency(AED, 4.1321);      # 4.1321   AED => 1 EUR
        /// currency(AFN, 101.9887);    # 101.9887 AFN => 1 EUR
        /// currency(ALL, 122.7378);    # 122.7378 ALL => 1 EUR
        /// currency(AMD, 547.57);      # 547.57   AMD => 1 EUR
        /// currency(ANG, 1.991);       # 1.991    ANG => 1 EUR
        /// currency(AOA, 556.8346);    # 556.8346 AOA => 1 EUR
        /// currency(ARS, 119.7553);    # 119.7553 ARS => 1 EUR
        /// currency(AUD, 1.5035);      # 1.5035   AUD => 1 EUR
        /// currency(AWG, 2.0255);      # 2.0255   AWG => 1 EUR
        /// currency(AZN, 1.9218);      # 1.9218   AZN => 1 EUR
        /// currency(BAM, 1.9793);      # 1.9793   BAM => 1 EUR
        /// currency(BBD, 2.2596);      # 2.2596   BBD => 1 EUR
        /// currency(BDT, 97.0603);     # 97.0603  BDT => 1 EUR
        /// currency(BGN, 1.9434);      # 1.9434   BGN => 1 EUR
        /// currency(BHD, 0.4176);      # 0.4176   BHD => 1 EUR
        /// currency(BIF, 2237.6264);   # 2237.6264 BIF => 1 EUR
        /// currency(BND, 1.521);       # 1.521    BND => 1 EUR
        /// currency(BOB, 7.637);       # 7.637    BOB => 1 EUR
        /// currency(BRL, 5.7249);      # 5.7249   BRL => 1 EUR
        /// currency(BSD, 1.1188);      # 1.1188   BSD => 1 EUR
        /// currency(BWP, 13.0967);     # 13.0967  BWP => 1 EUR
        /// currency(BYN, 3.0139);      # 3.0139   BYN => 1 EUR
        /// currency(BZD, 2.2559);      # 2.2559   BZD => 1 EUR
        /// currency(CAD, 1.4037);      # 1.4037   CAD => 1 EUR
        /// currency(CDF, 2239.6954);   # 2239.6954 CDF => 1 EUR
        /// currency(CHF, 1.0139);      # 1.0139   CHF => 1 EUR
        /// currency(CLP, 883.8071);    # 883.8071 CLP => 1 EUR
        /// currency(CNY, 6.9712);      # 6.9712   CNY => 1 EUR
        /// currency(COP, 4286.4925);   # 4286.4925 COP => 1 EUR
        /// currency(CRC, 716.9159);    # 716.9159 CRC => 1 EUR
        /// currency(CUP, 1.1188);      # 1.1188   CUP => 1 EUR
        /// currency(CVE, 111.8813);    # 111.8813 CVE => 1 EUR
        /// currency(CZK, 25.0893);     # 25.0893  CZK => 1 EUR
        /// currency(DJF, 199.2294);    # 199.2294 DJF => 1 EUR
        /// currency(DKK, 7.4076);      # 7.4076   DKK => 1 EUR
        /// currency(DOP, 60.9968);     # 60.9968  DOP => 1 EUR
        /// currency(DZD, 158.8736);    # 158.8736 DZD => 1 EUR
        /// currency(EGP, 17.3547);     # 17.3547  EGP => 1 EUR
        /// currency(ERN, 16.8738);     # 16.8738  ERN => 1 EUR
        /// currency(ETB, 57.3988);     # 57.3988  ETB => 1 EUR
        /// currency(EUR);              # Base currency
        /// currency(FJD, 2.3779);      # 2.3779   FJD => 1 EUR
        /// currency(GBP, 0.8274);      # 0.8274   GBP => 1 EUR
        /// currency(GEL, 3.4675);      # 3.4675   GEL => 1 EUR
        /// currency(GHS, 7.7215);      # 7.7215   GHS => 1 EUR
        /// currency(GIP, 0.834);       # 0.834    GIP => 1 EUR
        /// currency(GMD, 59.7344);     # 59.7344  GMD => 1 EUR
        /// currency(GNF, 10050.7494);  # 10050.7494 GNF => 1 EUR
        /// currency(GTQ, 8.64);        # 8.64     GTQ => 1 EUR
        /// currency(GYD, 234.1451);    # 234.1451 GYD => 1 EUR
        /// currency(HKD, 8.6189);      # 8.6189   HKD => 1 EUR
        /// currency(HNL, 27.5567);     # 27.5567  HNL => 1 EUR
        /// currency(HRK, 7.502);       # 7.502    HRK => 1 EUR
        /// currency(HTG, 116.6989);    # 116.6989 HTG => 1 EUR
        /// currency(HUF, 371.8363);    # 371.8363 HUF => 1 EUR
        /// currency(IDR, 15844.3432);  # 15844.3432 IDR => 1 EUR
        /// currency(ILS, 3.5775);      # 3.5775   ILS => 1 EUR
        /// currency(INR, 83.7335);     # 83.7335  INR => 1 EUR
        /// currency(IQD, 1653.9687);   # 1653.9687 IQD => 1 EUR
        /// currency(IRR, 47584.1953);  # 47584.1953 IRR => 1 EUR
        /// currency(ISK, 145.4218);    # 145.4218 ISK => 1 EUR
        /// currency(JMD, 173.0165);    # 173.0165 JMD => 1 EUR
        /// currency(JOD, 0.7851);      # 0.7851   JOD => 1 EUR
        /// currency(JPY, 127.1764);    # 127.1764 JPY => 1 EUR
        /// currency(KES, 127.469);     # 127.469  KES => 1 EUR
        /// currency(KGS, 96.0913);     # 96.0913  KGS => 1 EUR
        /// currency(KHR, 4548.7899);   # 4548.7899 KHR => 1 EUR
        /// currency(KMF, 494.4337);    # 494.4337 KMF => 1 EUR
        /// currency(KRW, 1336.5796);   # 1336.5796 KRW => 1 EUR
        /// currency(KWD, 0.3362);      # 0.3362   KWD => 1 EUR
        /// currency(KZT, 488.6859);    # 488.6859 KZT => 1 EUR
        /// currency(LAK, 12816.035);   # 12816.035 LAK => 1 EUR
        /// currency(LBP, 1701.7387);   # 1701.7387 LBP => 1 EUR
        /// currency(LKR, 224.4293);    # 224.4293 LKR => 1 EUR
        /// currency(LRD, 172.4008);    # 172.4008 LRD => 1 EUR
        /// currency(LSL, 17.3326);     # 17.3326  LSL => 1 EUR
        /// currency(LYD, 5.2191);      # 5.2191   LYD => 1 EUR
        /// currency(MAD, 10.7205);     # 10.7205  MAD => 1 EUR
        /// currency(MDL, 19.921);      # 19.921   MDL => 1 EUR
        /// currency(MGA, 4469.0602);   # 4469.0602 MGA => 1 EUR
        /// currency(MKD, 62.1946);     # 62.1946  MKD => 1 EUR
        /// currency(MMK, 1990.3292);   # 1990.3292 MMK => 1 EUR
        /// currency(MNT, 3229.6408);   # 3229.6408 MNT => 1 EUR
        /// currency(MOP, 9.013);       # 9.013    MOP => 1 EUR
        /// currency(MRO, 40.1478);     # 40.1478  MRO => 1 EUR
        /// currency(MRU, 40.7098);     # 40.7098  MRU => 1 EUR
        /// currency(MUR, 49.6868);     # 49.6868  MUR => 1 EUR
        /// currency(MVR, 17.3016);     # 17.3016  MVR => 1 EUR
        /// currency(MWK, 913.7045);    # 913.7045 MWK => 1 EUR
        /// currency(MXN, 22.8123);     # 22.8123  MXN => 1 EUR
        /// currency(MYR, 4.6522);      # 4.6522   MYR => 1 EUR
        /// currency(MZN, 71.7698);     # 71.7698  MZN => 1 EUR
        /// currency(NAD, 17.3264);     # 17.3264  NAD => 1 EUR
        /// currency(NGN, 462.1707);    # 462.1707 NGN => 1 EUR
        /// currency(NIO, 40.0038);     # 40.0038  NIO => 1 EUR
        /// currency(NOK, 9.8676);      # 9.8676   NOK => 1 EUR
        /// currency(NPR, 135.0813);    # 135.0813 NPR => 1 EUR
        /// currency(NZD, 1.6167);      # 1.6167   NZD => 1 EUR
        /// currency(OMR, 0.4266);      # 0.4266   OMR => 1 EUR
        /// currency(PAB, 1.111);       # 1.111    PAB => 1 EUR
        /// currency(PEN, 4.1375);      # 4.1375   PEN => 1 EUR
        /// currency(PGK, 3.8901);      # 3.8901   PGK => 1 EUR
        /// currency(PHP, 57.3084);     # 57.3084  PHP => 1 EUR
        /// currency(PKR, 199.6326);    # 199.6326 PKR => 1 EUR
        /// currency(PLN, 4.6972);      # 4.6972   PLN => 1 EUR
        /// currency(PYG, 7755.7086);   # 7755.7086 PYG => 1 EUR
        /// currency(QAR, 4.0413);      # 4.0413   QAR => 1 EUR
        /// currency(RON, 4.9172);      # 4.9172   RON => 1 EUR
        /// currency(RSD, 119.3434);    # 119.3434 RSD => 1 EUR
        /// currency(RUB, 112.2525);    # 112.2525 RUB => 1 EUR
        /// currency(RWF, 1135.3319);   # 1135.3319 RWF => 1 EUR
        /// currency(SAR, 4.1418);      # 4.1418   SAR => 1 EUR
        /// currency(SBD, 9.1509);      # 9.1509   SBD => 1 EUR
        /// currency(SCR, 16.116);      # 16.116   SCR => 1 EUR
        /// currency(SDG, 499.429);     # 499.429  SDG => 1 EUR
        /// currency(SEK, 10.7168);     # 10.7168  SEK => 1 EUR
        /// currency(SGD, 1.4967);      # 1.4967   SGD => 1 EUR
        /// currency(SLL, 13022.7453);  # 13022.7453 SLL => 1 EUR
        /// currency(SOS, 647.3956);    # 647.3956 SOS => 1 EUR
        /// currency(SRD, 22.9053);     # 22.9053  SRD => 1 EUR
        /// currency(SSP, 481.2219);    # 481.2219 SSP => 1 EUR
        /// currency(STN, 24.9843);     # 24.9843  STN => 1 EUR
        /// currency(SVC, 9.7967);      # 9.7967   SVC => 1 EUR
        /// currency(SYP, 2849.6831);   # 2849.6831 SYP => 1 EUR
        /// currency(SZL, 17.3326);     # 17.3326  SZL => 1 EUR
        /// currency(THB, 36.5233);     # 36.5233  THB => 1 EUR
        /// currency(TJS, 12.8);        # 12.8     TJS => 1 EUR
        /// currency(TMT, 3.9647);      # 3.9647   TMT => 1 EUR
        /// currency(TND, 3.2868);      # 3.2868   TND => 1 EUR
        /// currency(TOP, 2.544);       # 2.544    TOP => 1 EUR
        /// currency(TRY, 15.584);      # 15.584   TRY => 1 EUR
        /// currency(TTD, 7.5908);      # 7.5908   TTD => 1 EUR
        /// currency(TWD, 31.0675);     # 31.0675  TWD => 1 EUR
        /// currency(TZS, 2592.0071);   # 2592.0071 TZS => 1 EUR
        /// currency(UAH, 32.6392);     # 32.6392  UAH => 1 EUR
        /// currency(UGX, 3954.6622);   # 3954.6622 UGX => 1 EUR
        /// currency(USD, 1.1033);      # 1.1033   USD => 1 EUR
        /// currency(UYU, 47.3672);     # 47.3672  UYU => 1 EUR
        /// currency(UZS, 12247.9056);  # 12247.9056 UZS => 1 EUR
        /// currency(VES, 4.855);       # 4.855    VES => 1 EUR
        /// currency(VND, 25428.9059);  # 25428.9059 VND => 1 EUR
        /// currency(VUV, 126.043);     # 126.043  VUV => 1 EUR
        /// currency(WST, 2.8821);      # 2.8821   WST => 1 EUR
        /// currency(XAF, 662.6246);    # 662.6246 XAF => 1 EUR
        /// currency(XCD, 3.0335);      # 3.0335   XCD => 1 EUR
        /// currency(XOF, 662.8467);    # 662.8467 XOF => 1 EUR
        /// currency(XPF, 120.3832);    # 120.3832 XPF => 1 EUR
        /// currency(YER, 280.0428);    # 280.0428 YER => 1 EUR
        /// currency(ZAR, 16.8689);     # 16.8689  ZAR => 1 EUR
        /// currency(ZMW, 19.9607);     # 19.9607  ZMW => 1 EUR
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
        /// currency(USD, 1.1033);      # 1.1033   USD => 1 EUR
        /// >>> 2 USD
        /// # 2 * USD
        /// out = 1.8127918828265197793338250828 * EUR
        /// >>> currency(GBP) # Defines GBP as the default currency instead of EUR
        /// # currency(GBP) # Defines GBP as the default currency instead of EUR
        /// out = GBP
        /// >>> USD
        /// currency(USD, 1.3334);      # 1.3334   USD => 1 GBP
        /// >>> 2 USD |> to EUR # Convert 2 dollars to EUR
        /// # 2 * USD |> to(EUR) # Convert 2 dollars to EUR
        /// out = 1.8127918828265266 * EUR
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
            var rates = rootObject.Values.OfType<ScriptObject>().ToList();
            var baseCurrency = "EUR";

            Currencies.Clear();

            RegisterBaseCurrency(baseCurrency);
            bool lastUpdate = false;
            LastUpdate = new DateTime(2022, 3, 6);
            foreach (var rate in rates)
            {
                var currencyName = rate["code"] as string;

                // Try to parse the date
                if (!lastUpdate && rate.ContainsKey("date") && rate["date"] is string dateAsString)
                {
                    if (DateTime.TryParse(dateAsString, CultureInfo.InvariantCulture, DateTimeStyles.AllowInnerWhite, out var dateTime))
                    {
                        LastUpdate = dateTime;
                        lastUpdate = true;
                    }
                }

                var currencyValue = Engine.ToObject<decimal>(Engine.CurrentSpan, rate["rate"]);
                if (currencyName is not null && currencyValue != 0)
                {
                    RegisterCurrency(currencyName, currencyValue);
                }
            }

            Engine.WriteHighlightLine($"# Using rates defined as of {LastUpdate:yyyy-MM-dd}.");
        }

        private static ScriptObject DownloadExchangeRates(KalkEngine engine)
        {
            ScriptObject rates;
            var predefinedRates = ParseRates(LatestKnownRates);
            try
            {
                using (var client = new HttpClient())
                {
                    engine.WriteHighlightLine($"# Downloading rates from {ExchangeRatesApi}");

                    var task = Task.Run(async () => await client.GetStringAsync(ExchangeRatesApi));
                    var result = task.Result;
                    rates = ParseRates(result);

                    foreach (var rate in rates.Values.OfType<ScriptObject>().ToList())
                    {
                        var currencyName = rate["code"] as string;
                        if (currencyName is null)
                        {
                            engine.WriteHighlightLine($"# Invalid rates downloaded. Using predefined rates.");
                            return predefinedRates;
                        }
                    }

                    engine.WriteHighlightLine($"# {rates.Count} rates successfully updated.");

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

            return predefinedRates;
        }

        private static ScriptObject ParseRates(string text)
        {
            // Parse the rates returned by the HttpClient
            var expr = Template.Parse(text, parserOptions: new ParserOptions() { ParseFloatAsDecimal = true }, lexerOptions: new LexerOptions() { Mode = ScriptMode.ScriptOnly });
            return expr.Evaluate() as ScriptObject;
        }
    }
}