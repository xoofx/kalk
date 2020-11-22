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

        /// <summary>
        /// Removes any whitespace characters on the **left** side of the input string.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string without any left whitespace characters</returns>
        /// <example>
        /// ```kalk
        /// >>> '   too many spaces' |> lstrip
        /// # '   too many spaces' |> lstrip
        /// out = "too many spaces"
        /// ```
        /// </example>
        [KalkExport("lstrip", CategoryString)]
        public string StringLeftStrip(string text) => StringFunctions.LStrip(text);

        /// <summary>
        /// Outputs the singular or plural version of a string based on the value of a number.
        /// </summary>
        /// <param name="number">The number to check</param>
        /// <param name="singular">The singular string to return if number is == 1</param>
        /// <param name="plural">The plural string to return if number is != 1</param>
        /// <returns>The singular or plural string based on number</returns>
        /// <example>
        /// ```kalk
        /// >>> 3 |> pluralize('product', 'products')
        /// # 3 |> pluralize('product', 'products')
        /// out = "products"
        /// ```
        /// </example>
        [KalkExport("pluralize", CategoryString)]
        public string StringPluralize(int number, string singular, string plural) => StringFunctions.Pluralize(number, singular, plural);

        /// <summary>
        /// Removes any whitespace characters on the **right** side of the input string.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string without any left whitespace characters</returns>
        /// <example>
        /// ```kalk
        /// >>> '   too many spaces           ' |> rstrip
        /// # '   too many spaces           ' |> rstrip
        /// out = "   too many spaces"
        /// ```
        /// </example>
        [KalkExport("rstrip", CategoryString)]
        public string StringRightStrip(string text) => StringFunctions.RStrip(text);

        /// <summary>
        /// The `split` function takes on a substring as a parameter.
        /// The substring is used as a delimiter to divide a string into an array. You can output different parts of an array using `array` functions.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <param name="match">The string used to split the input `text` string</param>
        /// <returns>An enumeration of the substrings</returns>
        /// <example>
        /// ```kalk
        /// >>> "Hi, how are you today?" |> split ' '
        /// # "Hi, how are you today?" |> split(' ')
        /// out = ["Hi,", "how", "are", "you", "today?"]
        /// ```
        /// </example>
        [KalkExport("split", CategoryString)]
        public IEnumerable StringSplit(string text, string match) => StringFunctions.Split(text, match);

        /// <summary>
        /// Returns a boolean indicating whether the input string starts with the specified string `value`.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <param name="start">The string to look for</param>
        /// <returns><c>true</c> if `text` starts with the specified string `value`</returns>
        /// <example>
        /// ```kalk
        /// >>> "This is easy" |> startswith "This"
        /// # "This is easy" |> startswith("This")
        /// out = true
        /// >>> "This is easy" |> startswith "easy"
        /// # "This is easy" |> startswith("easy")
        /// out = false
        /// ```
        /// </example>
        [KalkExport("startswith", CategoryString)]
        public KalkBool StringStartsWith(string text, string start) => StringFunctions.StartsWith(text, start);

        /// <summary>
        /// Removes any whitespace characters on the **left** and **right** side of the input string.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string without any left and right whitespace characters</returns>
        /// <example>
        /// ```kalk
        /// >>> '   too many spaces           ' |> strip
        /// # '   too many spaces           ' |> strip
        /// out = "too many spaces"
        /// ```
        /// </example>
        [KalkExport("strip", CategoryString)]
        public string StringStrip(string text) => StringFunctions.Strip(text);

        /// <summary>Removes any line breaks/newlines from a string.</summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string without any breaks/newlines characters</returns>
        /// <example>
        /// ```kalk
        /// >>> "This is a string.\r\n With \nanother \rstring" |> strip_newlines
        /// # "This is a string.\r\n With \nanother \rstring" |> strip_newlines
        /// out = "This is a string. With another string"
        /// ```
        /// </example>
        [KalkExport("strip_newlines", CategoryString)]
        public string StringStripNewlines(string text) => StringFunctions.StripNewlines(text);

        /// <summary>
        /// Pads a string with leading spaces to a specified total length.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <param name="width">The number of characters in the resulting string</param>
        /// <returns>The input string padded</returns>
        /// <example>
        /// ```kalk
        /// >>> "world" |> pad_left 10
        /// # "world" |> pad_left(10)
        /// out = "     world"
        /// ```
        /// </example>
        [KalkExport("pad_left", CategoryString)]
        public string StringPadLeft(string text, int width) => StringFunctions.PadLeft(text, width);

        /// <summary>
        /// Pads a string with trailing spaces to a specified total length.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <param name="width">The number of characters in the resulting string</param>
        /// <returns>The input string padded</returns>
        /// <example>
        /// ```kalk
        /// >>> "hello" |> pad_right 10
        /// # "hello" |> pad_right(10)
        /// out = "hello     "
        /// ```
        /// </example>
        [KalkExport("pad_right", CategoryString)]
        public string StringPadRight(string text, int width) => StringFunctions.PadRight(text, width);

        /// <summary>
        /// Escapes a minimal set of characters (`\`, `*`, `+`, `?`, `|`, `{`, `[`, `(`,`)`, `^`, `$`,`.`, `#`, and white space)
        /// by replacing them with their escape codes.
        /// This instructs the regular expression engine to interpret these characters literally rather than as metacharacters.
        /// </summary>
        /// <param name="text">The input string that contains the text to convert.</param>
        /// <returns>A string of characters with metacharacters converted to their escaped form.</returns>
        /// <example>
        /// ```kalk
        /// >>> "(abc.*)" |> regex_escape
        /// # "(abc.*)" |> regex_escape
        /// out = "\\(abc\\.\\*\\)"
        /// ```
        /// </example>
        [KalkExport("regex_escape", CategoryString)]
        public string RegexEscape(string text) => RegexFunctions.Escape(text);

        /// <summary>
        /// Searches an input string for a substring that matches a regular expression pattern and returns an array with the match occurences.
        /// </summary>
        /// <param name="text">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A string with regex options, that can contain the following option characters (default is `null`):
        /// - `i`: Specifies case-insensitive matching.
        /// - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
        /// - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
        /// - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.
        /// </param>
        /// <returns>An array that contains all the match groups. The first group contains the entire match. The other elements contain regex matched groups `(..)`. An empty array returned means no match.</returns>
        /// <example>
        /// ```kalk
        /// >>> "this is a text123" |> regex_match `(\w+) a ([a-z]+\d+)`
        /// # "this is a text123" |> regex_match(`(\w+) a ([a-z]+\d+)`)
        /// out = ["is a text123", "is", "text123"]
        /// ```
        /// </example>
        [KalkExport("regex_match", CategoryString)]
        public ScriptArray RegexMatch(string text, string pattern, string options = null) => RegexFunctions.Match(Engine, text, pattern, options);

        /// <summary>
        /// Searches an input string for multiple substrings that matches a regular expression pattern and returns an array with the match occurences.
        /// </summary>
        /// <param name="text">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A string with regex options, that can contain the following option characters (default is `null`):
        /// - `i`: Specifies case-insensitive matching.
        /// - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
        /// - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
        /// - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.
        /// </param>
        /// <returns>An array of matches that contains all the match groups. The first group contains the entire match. The other elements contain regex matched groups `(..)`. An empty array returned means no match.</returns>
        /// <example>
        /// ```kalk
        /// >>> "this is a text123" |> regex_matches `(\w+)`
        /// # "this is a text123" |> regex_matches(`(\w+)`)
        /// out = [["this", "this"], ["is", "is"], ["a", "a"], ["text123", "text123"]]
        /// ```
        /// </example>
        [KalkExport("regex_matches", CategoryString)]
        public ScriptArray RegexMatches(string text, string pattern, string options = null) => RegexFunctions.Matches(Engine, text, pattern, options);

        /// <summary>
        /// In a specified input string, replaces strings that match a regular expression pattern with a specified replacement string.
        /// </summary>
        /// <param name="text">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replace">The replacement string.</param>
        /// <param name="options">A string with regex options, that can contain the following option characters (default is `null`):
        /// - `i`: Specifies case-insensitive matching.
        /// - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
        /// - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
        /// - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.
        /// </param>
        /// <returns>A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <example>
        /// ```kalk
        /// >>> "abbbbcccd" |> regex_replace("b+c+","-Yo-")
        /// # "abbbbcccd" |> regex_replace("b+c+", "-Yo-")
        /// out = "a-Yo-d"
        /// ```
        /// </example>
        [KalkExport("regex_replace", CategoryString)]
        public string RegexReplace(string text, string pattern, string replace, string options = null) => RegexFunctions.Replace(Engine, text, pattern, replace, options);

        /// <summary>
        /// Splits an input string into an array of substrings at the positions defined by a regular expression match.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A string with regex options, that can contain the following option characters (default is `null`):
        /// - `i`: Specifies case-insensitive matching.
        /// - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
        /// - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
        /// - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.
        /// </param>
        /// <returns>A string array.</returns>
        /// <example>
        /// ```kalk
        /// >>> "a, b   , c,    d" |> regex_split `\s*,\s*`
        /// # "a, b   , c,    d" |> regex_split(`\s*,\s*`)
        /// out = ["a", "b", "c", "d"]
        /// ```
        /// </example>
        [KalkExport("regex_split", CategoryString)]
        public ScriptArray RegexSplit(string text, string pattern, string options = null) => RegexFunctions.Split(Engine, text, pattern, options);

        /// <summary>Converts any escaped characters in the input string.</summary>
        /// <param name="text">The input string containing the text to convert.</param>
        /// <returns>A string of characters with any escaped characters converted to their unescaped form.</returns>
        /// <example>
        /// ```kalk
        /// >>> "\\(abc\\.\\*\\)" |> regex_unescape
        /// # "\\(abc\\.\\*\\)" |> regex_unescape
        /// out = "(abc.*)"
        /// ```
        /// </example>
        [KalkExport("regex_unescape", CategoryString)]
        public string RegexUnescape(string text) => RegexFunctions.Unescape(text);
    }
}