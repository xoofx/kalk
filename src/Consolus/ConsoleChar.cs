using System.Collections.Generic;

namespace Consolus
{
    public struct ConsoleChar
    {
        public ConsoleChar(char value)
        {
            Value = value;
            Escapes = null;
        }

        public List<ConsoleStyle> Escapes;

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