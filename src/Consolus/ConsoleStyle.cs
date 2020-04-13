using System;
using System.IO;

namespace Consolus
{
    public enum ControlStyleKind
    {
        Color,
        Format,
        Reset,
    }


    public readonly struct ConsoleStyle : IEquatable<ConsoleStyle>
    {
        ///  https://en.wikipedia.org/wiki/ANSI_escape_code

        public static readonly ConsoleStyle Black = new ConsoleStyle("\u001b[30m");
        public static readonly ConsoleStyle Red = new ConsoleStyle("\u001b[31m");
        public static readonly ConsoleStyle Green = new ConsoleStyle("\u001b[32m");
        public static readonly ConsoleStyle Yellow = new ConsoleStyle("\u001b[33m");
        public static readonly ConsoleStyle Blue = new ConsoleStyle("\u001b[34m");
        public static readonly ConsoleStyle Magenta = new ConsoleStyle("\u001b[35m");
        public static readonly ConsoleStyle Cyan = new ConsoleStyle("\u001b[36m");
        public static readonly ConsoleStyle White = new ConsoleStyle("\u001b[37m");
        public static readonly ConsoleStyle BrightBlack = new ConsoleStyle("\u001b[30;1m");
        public static readonly ConsoleStyle BrightRed = new ConsoleStyle("\u001b[31;1m");
        public static readonly ConsoleStyle BrightGreen = new ConsoleStyle("\u001b[32;1m");
        public static readonly ConsoleStyle BrightYellow = new ConsoleStyle("\u001b[33;1m");
        public static readonly ConsoleStyle BrightBlue = new ConsoleStyle("\u001b[34;1m");
        public static readonly ConsoleStyle BrightMagenta = new ConsoleStyle("\u001b[35;1m");
        public static readonly ConsoleStyle BrightCyan = new ConsoleStyle("\u001b[36;1m");
        public static readonly ConsoleStyle BrightWhite = new ConsoleStyle("\u001b[37;1m");
        public static readonly ConsoleStyle BackgroundBlack = new ConsoleStyle("\u001b[40m");
        public static readonly ConsoleStyle BackgroundRed = new ConsoleStyle("\u001b[41m");
        public static readonly ConsoleStyle BackgroundGreen = new ConsoleStyle("\u001b[42m");
        public static readonly ConsoleStyle BackgroundYellow = new ConsoleStyle("\u001b[43m");
        public static readonly ConsoleStyle BackgroundBlue = new ConsoleStyle("\u001b[44m");
        public static readonly ConsoleStyle BackgroundMagenta = new ConsoleStyle("\u001b[45m");
        public static readonly ConsoleStyle BackgroundCyan = new ConsoleStyle("\u001b[46m");
        public static readonly ConsoleStyle BackgroundWhite = new ConsoleStyle("\u001b[47m");
        public static readonly ConsoleStyle BackgroundBrightBlack = new ConsoleStyle("\u001b[40;1m");
        public static readonly ConsoleStyle BackgroundBrightRed = new ConsoleStyle("\u001b[41;1m");
        public static readonly ConsoleStyle BackgroundBrightGreen = new ConsoleStyle("\u001b[42;1m");
        public static readonly ConsoleStyle BackgroundBrightYellow = new ConsoleStyle("\u001b[43;1m");
        public static readonly ConsoleStyle BackgroundBrightBlue = new ConsoleStyle("\u001b[44;1m");
        public static readonly ConsoleStyle BackgroundBrightMagenta = new ConsoleStyle("\u001b[45;1m");
        public static readonly ConsoleStyle BackgroundBrightCyan = new ConsoleStyle("\u001b[46;1m");
        public static readonly ConsoleStyle BackgroundBrightWhite = new ConsoleStyle("\u001b[47;1m");
        public static readonly ConsoleStyle Bold = new ConsoleStyle("\u001b[1m", ControlStyleKind.Format);
        public static readonly ConsoleStyle Underline = new ConsoleStyle("\u001b[4m", ControlStyleKind.Format);
        public static readonly ConsoleStyle Reversed = new ConsoleStyle("\u001b[7m", ControlStyleKind.Format);
        public static readonly ConsoleStyle Reset = new ConsoleStyle("\u001b[0m", ControlStyleKind.Reset);

        public ConsoleStyle(string escapeSequence) : this()
        {
            EscapeSequence = escapeSequence;
            Kind = ControlStyleKind.Color;
        }

        public ConsoleStyle(string escapeSequence, ControlStyleKind kind) : this()
        {
            EscapeSequence = escapeSequence;
            Kind = kind;
        }

        public readonly string EscapeSequence;

        public readonly ControlStyleKind Kind;

        public void Render(TextWriter writer)
        {
            writer.Write(EscapeSequence);
        }

#if NETSTANDARD2_0
        public static implicit operator ConsoleStyle(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return Black;
                case ConsoleColor.Blue:
                    return BrightBlue;
                case ConsoleColor.Cyan:
                    return BrightCyan;
                case ConsoleColor.DarkBlue:
                    return Blue;
                case ConsoleColor.DarkCyan:
                    return Cyan;
                case ConsoleColor.DarkGray:
                    return BrightBlack;
                case ConsoleColor.DarkGreen:
                    return Green;
                case ConsoleColor.DarkMagenta:
                    return Magenta;
                case ConsoleColor.DarkRed:
                    return Red;
                case ConsoleColor.DarkYellow:
                    return Yellow;
                case ConsoleColor.Gray:
                    return BrightBlack;
                case ConsoleColor.Green:
                    return BrightGreen;
                case ConsoleColor.Magenta:
                    return BrightMagenta;
                case ConsoleColor.Red:
                    return BrightRed;
                case ConsoleColor.White:
                    return BrightWhite;
                case ConsoleColor.Yellow:
                    return BrightYellow;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }
#endif

        public bool Equals(ConsoleStyle other)
        {
            return EscapeSequence == other.EscapeSequence && Kind == other.Kind;
        }

        public override bool Equals(object obj)
        {
            return obj is ConsoleStyle other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((EscapeSequence?.GetHashCode() ?? 0) * 397) ^ (int) Kind;
            }
        }

        public static bool operator ==(ConsoleStyle left, ConsoleStyle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConsoleStyle left, ConsoleStyle right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return EscapeSequence;
        }
    }
}