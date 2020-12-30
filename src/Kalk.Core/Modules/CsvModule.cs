using System;
using System.IO;
using Kalk.Core.Helpers;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Module for loading/parsing CSV text/files.
    /// </summary>
    [KalkExportModule(ModuleName)]
    public partial class CsvModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "Csv";

        public CsvModule() : base(ModuleName)
        {
            RegisterFunctionsAuto();
        }

        /// <summary>
        /// Parse the specified text as a CSV, returning each CSV line in an array.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="headers"><c>true</c> if the text to parse has CSV headers. Default is fault.</param>
        /// <returns>An array of CSV columns values.</returns>
        /// <example>
        /// ```kalk
        /// >>> items = parse_csv("a,b,c\n1,2,3\n4,5,6\n")
        /// # items = parse_csv("a,b,c\n1,2,3\n4,5,6\n")
        /// items = [[1, 2, 3], [4, 5, 6]]
        /// >>> items[0].a
        /// # items[0].a
        /// out = 1
        /// >>> items[0].b
        /// # items[0].b
        /// out = 2
        /// >>> items[0].c
        /// # items[0].c
        /// out = 3
        /// ```
        /// </example>
        [KalkExport("parse_csv", StringModule.CategoryString)]
        public ScriptRange ParseCsv(string text, bool headers = true)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            return new ScriptRange(new KalkCsvReader(() => new StringReader(text), headers));
        }

        /// <summary>
        /// Loads the specified file as a CSV, returning each CSV line in an array.
        /// </summary>
        /// <param name="path">The file path to load and parse as CSV.</param>
        /// <param name="headers"><c>true</c> if the file to parse has CSV headers. Default is fault.</param>
        /// <returns>An array of CSV columns values.</returns>
        /// <example>
        /// ```kalk
        /// >>> items = load_csv("test.csv")
        /// # items = load_csv("test.csv")
        /// items = [[1, 2, 3], [4, 5, 6]]
        /// >>> items[0].a
        /// # items[0].a
        /// out = 1
        /// >>> items[1].a
        /// # items[1].a
        /// out = 4
        /// >>> items[1].c
        /// # items[1].c
        /// out = 6
        /// ```
        /// </example>
        [KalkExport("load_csv", FileModule.CategoryMiscFile)]
        public ScriptRange LoadCsv(string path, bool headers = true)
        {
            var fullPath = Engine.FileModule.AssertReadFile(path);
            return new ScriptRange(new KalkCsvReader(() =>
            {
                var stream = Engine.FileService.FileOpen(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return new StreamReader(stream);
            }, headers));
        }
   }
}