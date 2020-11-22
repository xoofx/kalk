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

        [KalkExport("escape", CategoryString)]
        public string StringEscape(string text) => StringFunctions.Escape(text);

        [KalkExport("capitalize", CategoryString)]
        public string StringCapitalize(string text) => StringFunctions.Capitalize(text);
        
        [KalkExport("capitalize_words", CategoryString)]
        public string StringCapitalizeWords(string text) => StringFunctions.Capitalizewords(text);

        [KalkExport("downcase", CategoryString)]
        public string StringDowncase(string text) => StringFunctions.Downcase(text);

        [KalkExport("upcase", CategoryString)]
        public string StringUpcase(string text) => StringFunctions.Upcase(text);

        [KalkExport("endswith", CategoryString)]
        public KalkBool StringEndsWith(string text, string end) => StringFunctions.EndsWith(text, end);

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