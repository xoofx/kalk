using System;
using System.IO;
using System.Runtime.InteropServices;
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

            bool hasFiles = false;

            if (modules.Length > 0)
            {
                input = $"print '{ModuleSplit}'\n{input}";
                foreach (var module in modules)
                {
                    input = $"import {module}\n{input}";
                    if (module == "Files") hasFiles = true;
                }
            }

            var kalk = new KalkEngine
            {
                InputReader = new StringReader(input),
                OutputWriter = singleOutput,
                ErrorWriter = singleOutput,
                DisplayVersion = false,
                EchoInput = false,
                IsOutputSupportHighlighting = false,
                IsTesting = true // put the engine in special testing mode
            };
            kalk.Run();

            expectedOutput = expectedOutput.Replace("\r\n", "\n").Trim();
            var result = kalk.OutputWriter.ToString();
            result = result.Replace("\r\n", "\n").Trim();

            // Replace paths for all file operations
            if (hasFiles) 
            { 
                var pathToReplace = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? @"C:\\code\\kalk\\tests" : "/code/kalk/tests";
                result = result.Replace(Environment.CurrentDirectory.Replace("\\", "\\\\"), pathToReplace);
                expectedOutput = expectedOutput.Replace("/code/kalk/tests", pathToReplace);

                string LocalDirReplace(string input)
                {
                    var strToReplace = Path.DirectorySeparatorChar == '/' ? "/" : "\\\\";
                    input = Regex.Replace(input, "\\+", strToReplace);
                    input = input.Replace("/", strToReplace);
                    return input;
                }

                result = LocalDirReplace(result);
                expectedOutput = LocalDirReplace(expectedOutput);
            }

            var match = $"{ModuleSplit}\n";
            var indexOfSplit = result.IndexOf(match);
            if (indexOfSplit > 0)
            {
                result = result.Substring(indexOfSplit + match.Length);
            }

            // Remove any spaces at the end of each line
            result = Regex.Replace(result, @"\s+$", string.Empty, RegexOptions.Multiline);
            expectedOutput = Regex.Replace(expectedOutput, @"\s+$", string.Empty, RegexOptions.Multiline);

            if (expectedOutput != result)
            {
                Console.WriteLine("Result");
                Console.WriteLine("----------");
                Console.WriteLine(result);
                Console.WriteLine();
                Console.WriteLine("Expected");
                Console.WriteLine("----------");
                Console.WriteLine(expectedOutput);
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