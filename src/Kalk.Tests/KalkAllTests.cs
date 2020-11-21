using System.IO;
using System.Text.RegularExpressions;
using Kalk.Core;
using NUnit.Framework;

namespace Kalk.Tests
{
    public abstract class KalkTestBase
    {
        private const string ModuleSplit = "%%%%%%";

        protected static void AssertScript(string input, string expectedOutput, params string[] modules)
        {
            var singleOutput = new StringWriter();

            if (modules.Length > 0)
            {
                input = $"print '{ModuleSplit}'\n{input}";
                foreach (var module in modules)
                {
                    input = $"import {module}\n{input}";
                }
            }

            var kalk = new KalkEngine
            {
                InputReader = new StringReader(input),
                OutputWriter = singleOutput,
                ErrorWriter = singleOutput,
                DisplayVersion = false,
                EchoInput = false,
                IsOutputSupportHighlighting = false
            };
            kalk.Run();

            expectedOutput = expectedOutput.Replace("\r\n", "\n").Trim();
            var result = kalk.OutputWriter.ToString();
            result = result.Replace("\r\n", "\n").Trim();

            var match = $"{ModuleSplit}\n";
            var indexOfSplit = result.IndexOf(match);
            if (indexOfSplit > 0)
            {
                result = result.Substring(indexOfSplit + match.Length);
            }
            Assert.AreEqual(expectedOutput, result);
        }
    }

    public partial class KalkAllTests : KalkTestBase
    {
        [TestCase("seed(0); rnd", @"# seed(0); rnd
out = 0.7262432699679598", Category = "General")]
        public static void Test(string input, string output) => AssertScript(input, output);
    }
}