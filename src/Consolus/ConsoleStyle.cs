using System;
using System.Collections.Generic;
using System.IO;

namespace Consolus
{
    public enum ConsoleStyleKind
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
        public static readonly ConsoleStyle Bold = new ConsoleStyle("\u001b[1m", ConsoleStyleKind.Format);
        public static readonly ConsoleStyle Underline = new ConsoleStyle("\u001b[4m", ConsoleStyleKind.Format);
        public static readonly ConsoleStyle Reversed = new ConsoleStyle("\u001b[7m", ConsoleStyleKind.Format);
        public static readonly ConsoleStyle Reset = new ConsoleStyle("\u001b[0m", ConsoleStyleKind.Reset);

        private static readonly Dictionary<string, ConsoleStyle> MapKnownEscapeToConsoleStyle = new Dictionary<string, ConsoleStyle>(StringComparer.OrdinalIgnoreCase);

        static ConsoleStyle()
        {
            MapKnownEscapeToConsoleStyle.Add(Black.EscapeSequence, Black);
            MapKnownEscapeToConsoleStyle.Add(Red.EscapeSequence, Red);
            MapKnownEscapeToConsoleStyle.Add(Green.EscapeSequence, Green);
            MapKnownEscapeToConsoleStyle.Add(Yellow.EscapeSequence, Yellow);
            MapKnownEscapeToConsoleStyle.Add(Blue.EscapeSequence, Blue);
            MapKnownEscapeToConsoleStyle.Add(Magenta.EscapeSequence, Magenta);
            MapKnownEscapeToConsoleStyle.Add(Cyan.EscapeSequence, Cyan);
            MapKnownEscapeToConsoleStyle.Add(White.EscapeSequence, White);
            MapKnownEscapeToConsoleStyle.Add(BrightBlack.EscapeSequence, BrightBlack);
            MapKnownEscapeToConsoleStyle.Add(BrightRed.EscapeSequence, BrightRed);
            MapKnownEscapeToConsoleStyle.Add(BrightGreen.EscapeSequence, BrightGreen);
            MapKnownEscapeToConsoleStyle.Add(BrightYellow.EscapeSequence, BrightYellow);
            MapKnownEscapeToConsoleStyle.Add(BrightBlue.EscapeSequence, BrightBlue);
            MapKnownEscapeToConsoleStyle.Add(BrightMagenta.EscapeSequence, BrightMagenta);
            MapKnownEscapeToConsoleStyle.Add(BrightCyan.EscapeSequence, BrightCyan);
            MapKnownEscapeToConsoleStyle.Add(BrightWhite.EscapeSequence, BrightWhite);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBlack.EscapeSequence, BackgroundBlack);
            MapKnownEscapeToConsoleStyle.Add(BackgroundRed.EscapeSequence, BackgroundRed);
            MapKnownEscapeToConsoleStyle.Add(BackgroundGreen.EscapeSequence, BackgroundGreen);
            MapKnownEscapeToConsoleStyle.Add(BackgroundYellow.EscapeSequence, BackgroundYellow);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBlue.EscapeSequence, BackgroundBlue);
            MapKnownEscapeToConsoleStyle.Add(BackgroundMagenta.EscapeSequence, BackgroundMagenta);
            MapKnownEscapeToConsoleStyle.Add(BackgroundCyan.EscapeSequence, BackgroundCyan);
            MapKnownEscapeToConsoleStyle.Add(BackgroundWhite.EscapeSequence, BackgroundWhite);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightBlack.EscapeSequence, BackgroundBrightBlack);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightRed.EscapeSequence, BackgroundBrightRed);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightGreen.EscapeSequence, BackgroundBrightGreen);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightYellow.EscapeSequence, BackgroundBrightYellow);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightBlue.EscapeSequence, BackgroundBrightBlue);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightMagenta.EscapeSequence, BackgroundBrightMagenta);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightCyan.EscapeSequence, BackgroundBrightCyan);
            MapKnownEscapeToConsoleStyle.Add(BackgroundBrightWhite.EscapeSequence, BackgroundBrightWhite);
            MapKnownEscapeToConsoleStyle.Add(Bold.EscapeSequence, Bold);
            MapKnownEscapeToConsoleStyle.Add(Underline.EscapeSequence, Underline);
            MapKnownEscapeToConsoleStyle.Add(Reversed.EscapeSequence, Reversed);
            MapKnownEscapeToConsoleStyle.Add(Reset.EscapeSequence, Reset);
        }

        public ConsoleStyle(string escapeSequence) : this()
        {
            EscapeSequence = escapeSequence;
            Kind = ConsoleStyleKind.Color;
        }

        public ConsoleStyle(string escapeSequence, ConsoleStyleKind kind) : this()
        {
            EscapeSequence = escapeSequence;
            Kind = kind;
        }

        private ConsoleStyle(string escapeSequence, ConsoleStyleKind kind, bool isInline)
        {
            EscapeSequence = escapeSequence;
            Kind = kind;
            IsInline = isInline;
        }

        public static ConsoleStyle Inline(string escape, ConsoleStyleKind kind = ConsoleStyleKind.Color)
        {
            if (escape == null) throw new ArgumentNullException(nameof(escape));
            if (kind == ConsoleStyleKind.Color)
            {
                if (MapKnownEscapeToConsoleStyle.TryGetValue(escape, out var style))
                {
                    kind = style.Kind;
                }
            }
            return new ConsoleStyle(escape, kind, true);
        }

        public static ConsoleStyle Rgb(int r, int g, int b)
        {
            return new ConsoleStyle($"\x1b[38;2;{r};{g};{b}m", ConsoleStyleKind.Color);
        }

        public static ConsoleStyle BackgroundRgb(int r, int g, int b)
        {
            return new ConsoleStyle($"\x1b[48;2;{r};{g};{b}m", ConsoleStyleKind.Color);
        }
        
        public readonly string EscapeSequence;

        public readonly ConsoleStyleKind Kind;

        public readonly bool IsInline;


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
            return EscapeSequence == other.EscapeSequence && Kind == other.Kind && IsInline == other.IsInline;
        }

        public override bool Equals(object obj)
        {
            return obj is ConsoleStyle other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((((EscapeSequence?.GetHashCode() ?? 0) * 397) ^ (int) Kind) * 397) & IsInline.GetHashCode();
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