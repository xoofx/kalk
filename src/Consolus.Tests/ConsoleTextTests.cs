using System.IO;

namespace Consolus.Tests
{
    public class ConsoleTextTests
    {
        [Test]
        public void TestImplicit()
        {
            var consoleText = new ConsoleText();
            consoleText.Append(ConsoleStyle.Red, true);
            consoleText.Append("a");
            consoleText.Append(ConsoleStyle.Rgb(10, 20, 30).ToString());
            consoleText.Append("b");
            consoleText.Append(ConsoleStyle.Reset.ToString());
            consoleText.Append("c");


            var output = new StringWriter();
            var writer = new ConsoleTextWriter(output);
            consoleText.Render(writer);
            writer.Commit();

            Assert.AreEqual("\x1b[0m\x1b[31ma\x1b[0m\x1b[38;2;10;20;30mb\x1b[0m\x1b[31mc", output.ToString());
        }
    }
}