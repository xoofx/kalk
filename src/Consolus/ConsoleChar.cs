using System.Collections.Generic;

namespace Consolus
{
    public struct ConsoleChar
    {
        public ConsoleChar(char value)
        {
            Value = value;
            StyleMarkers = null;
        }

        public List<ConsoleStyleMarker> StyleMarkers;

        public char Value;

        public static implicit operator ConsoleChar(char c)
        {
            return new ConsoleChar(c);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}