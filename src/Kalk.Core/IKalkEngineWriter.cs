using Consolus;
using Scriban.Parsing;

namespace Kalk.Core
{
    public interface IKalkEngineWriter
    {
        void Write(SourceSpan span, object result);

        void Write(ConsoleText text);
    }
}