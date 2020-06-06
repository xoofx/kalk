using System.IO;
using Kalk.Core;
using NUnit.Framework;

namespace Kalk.Tests
{
    public abstract class KalkTestBase
    {
        protected static void AssertScript(string input, string output)
        {
            var kalk = new KalkEngine
            {
                InputReader = new StringReader(input),
                OutputWriter = new StringWriter(),
                DisplayVersion = false,
                EchoInput = false,
                IsOutputSupportHighlighting = false
            };
            kalk.Run();

            output = output.Replace("\r\n", "\n").Trim();
            var result = kalk.OutputWriter.ToString();
            result = result.Replace("\r\n", "\n").Trim();

            Assert.AreEqual(result, output);
        }
    }

    public partial class KalkAllTests : KalkTestBase
    {
        [TestCase("seed(0); rnd", @"# seed(0); rnd
out = 0.7262432699679598", Category = "General")]
        public static void Test(string input, string output) => AssertScript(input, output);
    }
}