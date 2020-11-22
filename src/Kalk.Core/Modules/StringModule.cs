using System;
using System.Collections;
using Scriban.Functions;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Modules that provides string functions (e.g `upcase`, `downcase`, `regex_escape`...).
    /// </summary>
    [KalkExportModule(ModuleName)]
    public partial class StringModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "Strings";
        public const string CategoryString = "Text Functions";

        public StringModule() : base(ModuleName)
        {
            RegisterFunctionsAuto();
        }

        /// <summary>Escapes a string with escape characters.</summary>
        /// <param name="text">The input string</param>
        /// <returns>The two strings concatenated</returns>
        /// <example>
        /// ```kalk
        /// >>> "Hel\tlo\n\"W\\orld" |> escape
        /// # "Hel\tlo\n\"W\\orld" |> escape
        /// out = "Hel\\tlo\\n\\\"W\\\\orld"
        /// ```
        /// </example>
        [KalkExport("escape", CategoryString)]
        public string StringEscape(string text) => StringFunctions.Escape(text);

        /// <summary>
        /// Converts the first character of the passed string to a upper case character.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The capitalized input string</returns>
        /// <example>
        /// ```kalk
        /// >>> "test" |> capitalize
        /// # "test" |> capitalize
        /// out = "Test"
        /// ```
        /// </example>
        [KalkExport("capitalize", CategoryString)]
        public string StringCapitalize(string text) => StringFunctions.Capitalize(text);

        /// <summary>
        /// Converts the first character of each word in the passed string to a upper case character.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The capitalized input string</returns>
        /// <example>
        /// ```kalk
        /// >>> "This is easy" |> capitalize_words
        /// # "This is easy" |> capitalize_words
        /// out = "This Is Easy"
        /// ```
        /// </example>
        [KalkExport("capitalize_words", CategoryString)]
        public string StringCapitalizeWords(string text) => StringFunctions.Capitalizewords(text);

        /// <summary>Converts the string to lower case.</summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string lower case</returns>
        /// <example>
        /// ```kalk
        /// >>> "TeSt" |> downcase
        /// # "TeSt" |> downcase
        /// out = "test"
        /// ```
        /// </example>
        [KalkExport("downcase", CategoryString)]
        public string StringDowncase(string text) => StringFunctions.Downcase(text);

        /// <summary>Converts the string to uppercase</summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string upper case</returns>
        /// <example>
        /// ```kalk
        /// >>> "test" |> upcase
        /// # "test" |> upcase
        /// out = "TEST"
        /// ```
        /// </example>
        [KalkExport("upcase", CategoryString)]
        public string StringUpcase(string text) => StringFunctions.Upcase(text);

        /// <summary>
        /// Returns a boolean indicating whether the input string ends with the specified string `value`.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <param name="end">The string to look for</param>
        /// <returns><c>true</c> if `text` ends with the specified string `value`</returns>
        /// <example>
        /// ```kalk
        /// >>> "This is easy" |> endswith "easy"
        /// # "This is easy" |> endswith("easy")
        /// out = true
        /// >>> "This is easy" |> endswith "none"
        /// # "This is easy" |> endswith("none")
        /// out = false
        /// ```
        /// </example>
        [KalkExport("endswith", CategoryString)]
        public KalkBool StringEndsWith(string text, string end) => StringFunctions.EndsWith(text, end);

        /// <summary>Returns a url handle from the input string.</summary>
        /// <param name="text">The input string</param>
        /// <returns>A url handle</returns>
        /// <example>
        /// ```kalk
        /// >>> '100% M @ Ms!!!' |> handleize
        /// # '100% M @ Ms!!!' |> handleize
        /// out = "100-m-ms"
        /// ```
        /// </example>
        [KalkExport("handleize", CategoryString)]
        public string StringHandleize(string text) => StringFunctions.Handleize(text);

        [KalkExport("lstrip", CategoryString)]
        public string StringLeftStrip(string text) => StringFunctions.LStrip(text);

        [KalkExport("pluralize", CategoryString)]
        public string StringPluralize(int number, string singular, string plural) => StringFunctions.Pluralize(number, singular, plural);

        [KalkExport("rstrip", CategoryString)]
        public string StringRightStrip(string text) => StringFunctions.RStrip(text);

        [KalkExport("split", CategoryString)]
        public IEnumerable StringSplit(string text, string match) => StringFunctions.Split(text, match);

        [KalkExport("startswith", CategoryString)]
        public KalkBool StringStartsWith(string text, string start) => StringFunctions.StartsWith(text, start);

        [KalkExport("strip", CategoryString)]
        public string StringStrip(string text) => StringFunctions.Strip(text);

        [KalkExport("strip_newlines", CategoryString)]
        public string StringStripNewlines(string text) => StringFunctions.StripNewlines(text);

        [KalkExport("pad_left", CategoryString)]
        public string StringPadLeft(string text, int width) => StringFunctions.PadLeft(text, width);

        [KalkExport("pad_right", CategoryString)]
        public string StringPadRight(string text, int width) => StringFunctions.PadRight(text, width);

        [KalkExport("regex_escape", CategoryString)]
        public string RegexEscape(string text) => RegexFunctions.Escape(text);

        [KalkExport("regex_match", CategoryString)]
        public ScriptArray RegexMatch(string text, string pattern, string options = null) => RegexFunctions.Match(Engine, text, pattern, options);

        [KalkExport("regex_matches", CategoryString)]
        public ScriptArray RegexMatches(string text, string pattern, string options = null) => RegexFunctions.Matches(Engine, text, pattern, options);
        
        [KalkExport("regex_replace", CategoryString)]
        public string RegexReplace(string text, string pattern, string replace, string options = null) => RegexFunctions.Replace(Engine, text, pattern, replace, options);

        [KalkExport("regex_split", CategoryString)]
        public ScriptArray RegexSplit(string text, string pattern, string options = null) => RegexFunctions.Split(Engine, text, pattern, options);

        [KalkExport("regex_unescape", CategoryString)]
        public string RegexUnescape(string text) => RegexFunctions.Unescape(text);

    }
}