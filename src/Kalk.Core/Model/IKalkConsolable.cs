using Consolus;

namespace Kalk.Core
{
    public interface IKalkConsolable
    {
        void ToConsole(KalkEngine engine, ConsoleText text);
    }
}