using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Scriban.Runtime;

namespace Kalk.Core
{
    public readonly struct KalkConsoleKey : IEquatable<KalkConsoleKey>
    {
        // Maps of name to ConsoleKey
        private static readonly Dictionary<string, ConsoleKey> MapNameToConsoleKey = new Dictionary<string, ConsoleKey>(StringComparer.OrdinalIgnoreCase);

        // Maps of ConsoleKey to name
        private static readonly Dictionary<ConsoleKey, string> MapConsoleKeyToName = new Dictionary<ConsoleKey, string>();

        static KalkConsoleKey()
        {
            var names = Enum.GetNames<ConsoleKey>();
            var values = Enum.GetValues<ConsoleKey>();

            for (var i = 0; i < names.Length; i++)
            {
                var name = StandardMemberRenamer.Rename(names[i]);
                var key = values[i];
                if (key >= ConsoleKey.D0 && key <= ConsoleKey.D9)
                {
                    name = ('0' + (key - ConsoleKey.D0)).ToString(CultureInfo.InvariantCulture);
                }
                MapKey(name, key);
            }

            MapKey("left", ConsoleKey.LeftArrow);
            MapKey("right", ConsoleKey.RightArrow);
            MapKey("up", ConsoleKey.UpArrow);
            MapKey("down", ConsoleKey.DownArrow);
        }

        private static void MapKey(string name, ConsoleKey key)
        {
            MapNameToConsoleKey.Add(name, key);
            MapConsoleKeyToName[key] = name;
        }

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
                // We need to force char to 0 when backspace, as it is not consistent between Windows and macOS/Linux
                KeyChar = Modifiers != 0 || key == ConsoleKey.Backspace ? (char)0 : keyChar;
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
                    if (string.Compare(keyText, index, "CTRL", 0, "CTRL".Length, true) == 0)
                    {
                        if ((modifiers & ConsoleModifiers.Control) != 0) throw new ArgumentException("Cannot have multiple CTRL keys in a shortcut.", nameof(keyText));
                        modifiers |= ConsoleModifiers.Control;
                        index += "CTRL".Length;
                        expectingPlus = true;
                    }
                    else if (string.Compare(keyText, index, "ALT", 0, "ALT".Length, true) == 0)
                    {
                        if ((modifiers & ConsoleModifiers.Alt) != 0) throw new ArgumentException("Cannot have multiple ALT keys in a shortcut.", nameof(keyText));
                        modifiers |= ConsoleModifiers.Alt;
                        index += "ALT".Length;
                        expectingPlus = true;
                    }
                    else if (string.Compare(keyText, index, "SHIFT", 0, "SHIFT".Length, true) == 0)
                    {
                        // Skip the shift but don't expect it's modifiers
                        index += "SHIFT".Length;
                        expectingPlus = true;
                    }
                    else
                    {
                        var remainingText = keyText.Substring(index);
                        expectingPlus = false;
                        if (!MapNameToConsoleKey.TryGetValue(remainingText, out key))
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
                        else
                        {
                            keyChar = key switch
                            {
                                ConsoleKey.Add => '+',
                                ConsoleKey.Attention => '!',
                                ConsoleKey.Divide => '/',
                                ConsoleKey.Multiply => '*',
                                ConsoleKey.Subtract => '-',
                                ConsoleKey.OemPlus => '=',
                                ConsoleKey.OemMinus => '-',
                                ConsoleKey.OemPeriod => ';',
                                ConsoleKey.OemComma => ',',
                                ConsoleKey.Tab => '\t',
                                ConsoleKey.Enter => '\r',
                                ConsoleKey.Spacebar => ' ',
                                ConsoleKey.Backspace => (char)0,
                                ConsoleKey.Escape => (char) 0x1b,
                                _ => keyChar
                            };
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
                builder.Append("ctrl");
            }
            if ((modifiers & ConsoleModifiers.Alt) != 0)
            {
                if (builder.Length > 0) builder.Append('+');
                builder.Append("alt");
            }
            if ((modifiers & ConsoleModifiers.Shift) != 0)
            {
                if (builder.Length > 0) builder.Append('+');
                builder.Append("shift");
            }

            if (builder.Length > 0)
            {
                builder.Append('+');
            }

            if (Key >= ConsoleKey.A && Key <= ConsoleKey.Z && KeyChar != 0)
            {
                builder.Append(KeyChar);
            }
            else
            {
                builder.Append(MapConsoleKeyToName[Key]);
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