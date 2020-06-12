using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kalk.Core.Helpers;
using Scriban.Functions;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    public partial class CsvModule : KalkModuleWithFunctions
    {
        public CsvModule() : base("Csv")
        {
            RegisterFunctionsAuto();
        }
        
        [KalkExport("parse_csv", StringModule.CategoryString)]
        public ScriptRange ParseCsv(string text, bool headers = true)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            return new ScriptRange(new KalkCsvReader(() => new StringReader(text), headers));
        }

        [KalkExport("load_csv", FileModule.CategoryMiscFile)]
        public ScriptRange LoadCsv(string path, bool headers = true)
        {
            var fullPath = FileModule.AssertReadFile(path);
            return new ScriptRange(new KalkCsvReader(() =>
            {
                var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return new StreamReader(stream);
            }, headers));
        }
   }
}