using System;
using System.Text;

namespace Kalk.Core
{
    public readonly struct KalkConsoleKey : IEquatable<KalkConsoleKey>
    {
        public KalkConsoleKey(ConsoleModifiers modifiers, ConsoleKey key, char keyChar)
        {
            Modifiers = modifiers;
            Key = key;
            // Normalize keychar, whenever there is a modifier, we don't store the character
            if (modifiers == ConsoleModifiers.Shift && key >= ConsoleKey.A && key <= ConsoleKey.Z)
            {
                Modifiers = 0;
                KeyChar = keyChar;
            }
            else
            {
                KeyChar = Modifiers != 0 ? (char) 0 : keyChar;
            }
        }
        
        public ConsoleModifiers Modifiers { get; }
        
        public ConsoleKey Key { get; }

        public char KeyChar { get; }
        
        public bool Equals(KalkConsoleKey other)
        {
            return Key == other.Key &&
                   KeyChar == other.KeyChar &&
                   Modifiers == other.Modifiers;
        }

        public override bool Equals(object obj)
        {
            return obj is KalkConsoleKey other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = (int)Modifiers;
            hashCode = (hashCode * 397) ^ (int) Key;
            hashCode = (hashCode * 397) ^ (int) KeyChar;
            return hashCode;
        }

        public static bool operator ==(KalkConsoleKey left, KalkConsoleKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(KalkConsoleKey left, KalkConsoleKey right)
        {
            return !left.Equals(right);
        }


        public static KalkConsoleKey Parse(string keyText)
        {
            if (keyText == null) throw new ArgumentNullException(nameof(keyText));

            ConsoleModifiers modifiers = 0;
            ConsoleKey key = 0;
            char keyChar = (char)0;
            int index = 0;
            bool expectingPlus = false;
            while (index < keyText.Length)
            {
                if (expectingPlus)
                {
                    if (keyText[index] != '+')
                    {
                        throw new ArgumentException($"Unexpected character `{keyText[index]}`. Expecting a + between keys.", nameof(keyText));
                    }
                    index++;
                    expectingPlus = false;
                }
                else
                {
                    if (string.Compare(keyText, index, "CTRL", 0, "CTRL".Length) == 0)
                    {
                        if ((modifiers & ConsoleModifiers.Control) != 0) throw new ArgumentException("Cannot have multiple CTRL keys in a shortcut.", nameof(keyText));
                        modifiers |= ConsoleModifiers.Control;
                        index += "CTRL".Length;
                        expectingPlus = true;
                    }
                    else if (string.Compare(keyText, index, "ALT", 0, "ALT".Length) == 0)
                    {
                        if ((modifiers & ConsoleModifiers.Alt) != 0) throw new ArgumentException("Cannot have multiple ALT keys in a shortcut.", nameof(keyText));
                        modifiers |= ConsoleModifiers.Alt;
                        index += "ALT".Length;
                        expectingPlus = true;
                    }
                    else if (string.Compare(keyText, index, "SHIFT", 0, "SHIFT".Length) == 0)
                    {
                        if ((modifiers & ConsoleModifiers.Shift) != 0) throw new ArgumentException("Cannot have multiple SHIFT keys in a shortcut.", nameof(keyText));
                        modifiers |= ConsoleModifiers.Shift;
                        index += "SHIFT".Length;
                        expectingPlus = true;
                    }
                    else
                    {
                        var remainingText = keyText.Substring(index);
                        if (remainingText.Length == 1 && remainingText[0] >= '0' && remainingText[0] <= '9')
                        {
                            keyChar = remainingText[0];
                            key = ConsoleKey.D0 + (keyChar - '0');
                        }
                        else
                        {
                            if (!Enum.TryParse<ConsoleKey>(remainingText, true, out key))
                            {
                                throw new ArgumentException($"Invalid key found `{remainingText}`. Expecting: {string.Join(", ", Enum.GetNames(typeof(ConsoleKey)))}.", nameof(keyText));
                            }

                            if (key >= ConsoleKey.D0 && key <= ConsoleKey.D9)
                            {
                                keyChar = (char) ('0' + (int) key - (int) ConsoleKey.D0);
                            }
                            else if (key >= ConsoleKey.A && key <= ConsoleKey.Z)
                            {
                                keyChar = remainingText[0];
                            }
                        }

                        break;
                    }
                }
            }

            return new KalkConsoleKey(modifiers, key, keyChar);
        }


        public override string ToString()
        {
            var builder = new StringBuilder();
            var modifiers = Modifiers;
            if ((modifiers & ConsoleModifiers.Control) != 0)
            {
                builder.Append("CTRL");
            }
            if ((modifiers & ConsoleModifiers.Alt) != 0)
            {
                if (builder.Length > 0) builder.Append("+");
                builder.Append("ALT");
            }
            if ((modifiers & ConsoleModifiers.Shift) != 0)
            {
                if (builder.Length > 0) builder.Append("+");
                builder.Append("SHIFT");
            }

            if (builder.Length > 0)
            {
                builder.Append("+");
                builder.Append(Key.ToString());
            }
            else
            {
                if (KeyChar >= '0' && KeyChar <= '9' || KeyChar >= 'A' && KeyChar <= 'Z' || KeyChar >= 'a' && KeyChar <= 'z')
                {
                    builder.Append(KeyChar.ToString());
                }
                else
                {
                    builder.Append(Key.ToString());
                }
            }

            return builder.ToString();
        }

        public static implicit operator KalkConsoleKey(ConsoleKeyInfo keyInfo)
        {
            return new KalkConsoleKey(keyInfo.Modifiers, keyInfo.Key, keyInfo.KeyChar);
        }

        public static implicit operator ConsoleKeyInfo(KalkConsoleKey key)
        {
            return new ConsoleKeyInfo(key.KeyChar, key.Key, (key.Modifiers & ConsoleModifiers.Shift) != 0, (key.Modifiers & ConsoleModifiers.Alt) != 0, (key.Modifiers & ConsoleModifiers.Control) != 0);
        }
    }
}