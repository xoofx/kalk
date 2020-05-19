using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Consolus;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private const string CategoryString = "String Functions";

        private void RegisterStringFunctions()
        {
            RegisterFunction("escape", DelegateCustomFunction.CreateFunc<string, string>(StringEscape), CategoryString);
            RegisterFunction("capitalize", DelegateCustomFunction.CreateFunc<string, string>(StringCapitalize), CategoryString);
            RegisterFunction("capitalize_words", DelegateCustomFunction.CreateFunc<string, string>(StringCapitalizeWords), CategoryString);
            RegisterFunction("downcase", DelegateCustomFunction.CreateFunc<string, string>(StringDowncase), CategoryString);
            RegisterFunction("upcase", DelegateCustomFunction.CreateFunc<string, string>(StringUpcase), CategoryString);
            RegisterFunction("endswith", DelegateCustomFunction.CreateFunc<string, string, bool>(StringEndsWith), CategoryString);
            RegisterFunction("handleize", DelegateCustomFunction.CreateFunc<string, string>(StringHandleize), CategoryString);
            RegisterFunction("lstrip", DelegateCustomFunction.CreateFunc<string, string>(StringLeftStrip), CategoryString);
            RegisterFunction("pluralize", DelegateCustomFunction.CreateFunc<int, string, string, string>(StringPluralize), CategoryString);
            RegisterFunction("rstrip", DelegateCustomFunction.CreateFunc<string, string>(StringRightStrip), CategoryString);
            RegisterFunction("split", DelegateCustomFunction.CreateFunc<string, string, IEnumerable>(StringSplit), CategoryString);
            RegisterFunction("startswith", DelegateCustomFunction.CreateFunc<string, string, bool>(StringStartsWith), CategoryString);
            RegisterFunction("strip", DelegateCustomFunction.CreateFunc<string, string>(StringStrip), CategoryString);
            RegisterFunction("strip_newlines", DelegateCustomFunction.CreateFunc<string, string>(StringStripNewlines), CategoryString);
            RegisterFunction("pad_left", DelegateCustomFunction.CreateFunc<string, int, string>(StringPadLeft), CategoryString);
            RegisterFunction("pad_right", DelegateCustomFunction.CreateFunc<string, int, string>(StringPadRight), CategoryString);
        }

        [KalkDoc("escape")]
        public string StringEscape(string text) => StringFunctions.Escape(text);

        [KalkDoc("capitalize")]
        public string StringCapitalize(string text) => StringFunctions.Capitalize(text);
        
        [KalkDoc("capitalize_words")]
        public string StringCapitalizeWords(string text) => StringFunctions.Capitalizewords(text);

        [KalkDoc("downcase")]
        public string StringDowncase(string text) => StringFunctions.Downcase(text);

        [KalkDoc("upcase")]
        public string StringUpcase(string text) => StringFunctions.Upcase(text);

        [KalkDoc("endswith")]
        public bool StringEndsWith(string text, string end) => StringFunctions.EndsWith(text, end);

        [KalkDoc("handleize")]
        public string StringHandleize(string text) => StringFunctions.Handleize(text);

        [KalkDoc("lstrip")]
        public string StringLeftStrip(string text) => StringFunctions.LStrip(text);

        [KalkDoc("pluralize")]
        public string StringPluralize(int number, string singular, string plural) => StringFunctions.Pluralize(number, singular, plural);

        [KalkDoc("rstrip")]
        public string StringRightStrip(string text) => StringFunctions.RStrip(text);

        [KalkDoc("split")]
        public IEnumerable StringSplit(string text, string match) => StringFunctions.Split(text, match);

        [KalkDoc("startswith")]
        public bool StringStartsWith(string text, string start) => StringFunctions.StartsWith(text, start);

        [KalkDoc("strip")]
        public string StringStrip(string text) => StringFunctions.Strip(text);

        [KalkDoc("strip_newlines")]
        public string StringStripNewlines(string text) => StringFunctions.StripNewlines(text);

        [KalkDoc("pad_left")]
        public string StringPadLeft(string text, int width) => StringFunctions.PadLeft(text, width);

        [KalkDoc("pad_right")]
        public string StringPadRight(string text, int width) => StringFunctions.PadRight(text, width);
    }
}