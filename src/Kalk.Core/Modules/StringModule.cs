using System;
using System.Collections;
using Scriban.Functions;

namespace Kalk.Core.Modules
{
    public partial class StringModule : KalkModule
    {
        private const string CategoryString = "Text Functions";

        public StringModule() : base("Strings")
        {
            RegisterFunction("escape", new Func<string, string>(StringEscape), CategoryString);
            RegisterFunction("capitalize", new Func<string, string>(StringCapitalize), CategoryString);
            RegisterFunction("capitalize_words", new Func<string, string>(StringCapitalizeWords), CategoryString);
            RegisterFunction("downcase", new Func<string, string>(StringDowncase), CategoryString);
            RegisterFunction("upcase", new Func<string, string>(StringUpcase), CategoryString);
            RegisterFunction("endswith", new Func<string, string, bool>(StringEndsWith), CategoryString);
            RegisterFunction("handleize", new Func<string, string>(StringHandleize), CategoryString);
            RegisterFunction("lstrip", new Func<string, string>(StringLeftStrip), CategoryString);
            RegisterFunction("pluralize", new Func<int, string, string, string>(StringPluralize), CategoryString);
            RegisterFunction("rstrip", new Func<string, string>(StringRightStrip), CategoryString);
            RegisterFunction("split", new Func<string, string, IEnumerable>(StringSplit), CategoryString);
            RegisterFunction("startswith", new Func<string, string, bool>(StringStartsWith), CategoryString);
            RegisterFunction("strip", new Func<string, string>(StringStrip), CategoryString);
            RegisterFunction("strip_newlines", new Func<string, string>(StringStripNewlines), CategoryString);
            RegisterFunction("pad_left", new Func<string, int, string>(StringPadLeft), CategoryString);
            RegisterFunction("pad_right", new Func<string, int, string>(StringPadRight), CategoryString);
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
    }
}