using System;
using System.Collections;
using Scriban.Functions;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    public partial class StringModule : KalkModuleWithFunctions
    {
        private const string CategoryString = "Text Functions";

        public StringModule() : base("Strings")
        {
            RegisterFunctionsAuto();
        }

        [KalkDoc("escape", CategoryString)]
        public string StringEscape(string text) => StringFunctions.Escape(text);

        [KalkDoc("capitalize", CategoryString)]
        public string StringCapitalize(string text) => StringFunctions.Capitalize(text);
        
        [KalkDoc("capitalize_words", CategoryString)]
        public string StringCapitalizeWords(string text) => StringFunctions.Capitalizewords(text);

        [KalkDoc("downcase", CategoryString)]
        public string StringDowncase(string text) => StringFunctions.Downcase(text);

        [KalkDoc("upcase", CategoryString)]
        public string StringUpcase(string text) => StringFunctions.Upcase(text);

        [KalkDoc("endswith", CategoryString)]
        public bool StringEndsWith(string text, string end) => StringFunctions.EndsWith(text, end);

        [KalkDoc("handleize", CategoryString)]
        public string StringHandleize(string text) => StringFunctions.Handleize(text);

        [KalkDoc("lstrip", CategoryString)]
        public string StringLeftStrip(string text) => StringFunctions.LStrip(text);

        [KalkDoc("pluralize", CategoryString)]
        public string StringPluralize(int number, string singular, string plural) => StringFunctions.Pluralize(number, singular, plural);

        [KalkDoc("rstrip", CategoryString)]
        public string StringRightStrip(string text) => StringFunctions.RStrip(text);

        [KalkDoc("split", CategoryString)]
        public IEnumerable StringSplit(string text, string match) => StringFunctions.Split(text, match);

        [KalkDoc("startswith", CategoryString)]
        public bool StringStartsWith(string text, string start) => StringFunctions.StartsWith(text, start);

        [KalkDoc("strip", CategoryString)]
        public string StringStrip(string text) => StringFunctions.Strip(text);

        [KalkDoc("strip_newlines", CategoryString)]
        public string StringStripNewlines(string text) => StringFunctions.StripNewlines(text);

        [KalkDoc("pad_left", CategoryString)]
        public string StringPadLeft(string text, int width) => StringFunctions.PadLeft(text, width);

        [KalkDoc("pad_right", CategoryString)]
        public string StringPadRight(string text, int width) => StringFunctions.PadRight(text, width);

        [KalkDoc("regex_escape", CategoryString)]
        public string RegexEscape(string text) => RegexFunctions.Escape(text);

        [KalkDoc("regex_match", CategoryString)]
        public ScriptArray RegexMatch(string text, string pattern, string options = null) => RegexFunctions.Match(Engine, text, pattern, options);

        [KalkDoc("regex_matches", CategoryString)]
        public ScriptArray RegexMatches(string text, string pattern, string options = null) => RegexFunctions.Matches(Engine, text, pattern, options);
        
        [KalkDoc("regex_replace", CategoryString)]
        public string RegexReplace(string text, string pattern, string replace, string options = null) => RegexFunctions.Replace(Engine, text, pattern, replace, options);

        [KalkDoc("regex_split", CategoryString)]
        public ScriptArray RegexSplit(string text, string pattern, string options = null) => RegexFunctions.Split(Engine, text, pattern, options);

        [KalkDoc("regex_unescape", CategoryString)]
        public string RegexUnescape(string text) => RegexFunctions.Unescape(text);

    }
}