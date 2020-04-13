using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Consolus
{
    using static ConsoleStyle;

    public class ConsoleText : IList<ConsoleChar>
    {
        private readonly List<ConsoleChar> _chars;
        private readonly List<ConsoleStyle> _leadingStyles;
        private readonly List<ConsoleStyle> _trailingStyles;

        public ConsoleText()
        {
            _chars = new List<ConsoleChar>();
            _leadingStyles = new List<ConsoleStyle>();
            _trailingStyles = new List<ConsoleStyle>();
            SelectionEnd = -1;
        }

        public ConsoleText(string text) : this()
        {
            Append(text);
        }

        public void Add(ConsoleChar item)
        {
            Insert(Count, item);
        }

        public void Clear()
        {
            _leadingStyles.Clear();
            _chars.Clear();
            _trailingStyles.Clear();
            ClearSelection();
        }

        public int VisibleCharacterStart { get; internal set; }

        public int VisibleCharacterEnd { get; internal set; }

        public int SelectionStart { get; set; }


        public int SelectionEnd { get; set; }


        public void ClearSelection()
        {
            SelectionStart = 0;
            SelectionEnd = -1;
        }

        public bool HasSelection => SelectionStart >= 0 && SelectionEnd <= Count && SelectionStart <= SelectionEnd;

        public void ClearStyles()
        {
            _leadingStyles.Clear();
            _trailingStyles.Clear();
            for (var i = 0; i < _chars.Count; i++)
            {
                var consoleChar = _chars[i];
                if (consoleChar.Escapes != null)
                {
                    consoleChar.Escapes.Clear();
                    _chars[i] = consoleChar;
                }
            }
        }

        public bool Contains(ConsoleChar item)
        {
            return _chars.Contains(item);
        }

        public void CopyTo(ConsoleChar[] array, int arrayIndex)
        {
            _chars.CopyTo(array, arrayIndex);
        }

        public bool Remove(ConsoleChar item)
        {
            return _chars.Remove(item);
        }

        public int Count => _chars.Count;

        public bool IsReadOnly => false;

        public int IndexOf(ConsoleChar item)
        {
            return _chars.IndexOf(item);
        }

        public void Insert(int index, ConsoleChar item)
        {
            // Copy any leading/trailing escapes
            bool isFirstInsert = index == 0 && Count == 0;
            bool isLastInsert = Count > 0 && index == Count;
            List<ConsoleStyle> copyFrom = isFirstInsert ? _leadingStyles : isLastInsert ? _trailingStyles : null;
            if (copyFrom != null && copyFrom.Count > 0)
            {
                var escapes = item.Escapes;
                if (escapes == null)
                {
                    escapes = new List<ConsoleStyle>();
                    item.Escapes = escapes;
                }

                for (int i = 0; i < copyFrom.Count; i++)
                {
                    escapes.Insert(i, copyFrom[i]);
                }
                copyFrom.Clear();
            }

            _chars.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _chars.RemoveAt(index);
        }

        public ConsoleChar this[int index]
        {
            get => _chars[index];
            set => _chars[index] = value;
        }

        public void Add(ConsoleStyle style)
        {
            Insert(Count, style);
        }

        public ConsoleText Append(char c)
        {
            Add(c);
            return this;
        }

        public ConsoleText Append(ConsoleStyle style)
        {
            Add(style);
            return this;
        }

        public ConsoleText Append(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            foreach (var c in text)
            {
                Add(c);
            }

            return this;
        }

        public void Insert(int index, ConsoleStyle style)
        {
            if ((uint)index > (uint)Count) throw new ArgumentOutOfRangeException($"Invalid character index {index} not within range [0, {Count}]");

            var isFirst = index == 0 && Count == 0;
            var isLast = index == Count;

            List<ConsoleStyle> list;
            if (isFirst)
            {
                list = _leadingStyles;
            }
            else if (isLast)
            {
                list = _trailingStyles;
            }
            else
            {
                var c = this[index];
                list = c.Escapes;
                if (list == null)
                {
                    list = new List<ConsoleStyle>();
                    c.Escapes = list;
                    this[index] = c;
                }
            }

            list.Add(style);
        }

        private void RenderLeadingTrailingStyles(TextWriter writer, bool renderEscape, bool leading, List<ConsoleStyle> runningStyles = null)
        {
            var styles = leading ? _leadingStyles : _trailingStyles;
            foreach (var consoleStyle in styles)
            {
                if (renderEscape)
                {
                    consoleStyle.Render(writer);
                }
                if (runningStyles != null)
                {
                    SquashStyle(consoleStyle, runningStyles);
                }
            }
        }
        
        public void Render(ConsoleTextWriter writer, bool renderEscape = true)
        {
            VisibleCharacterStart = writer.VisibleCharacterCount;

            if (HasSelection)
            {
                RenderWithSelection(writer, renderEscape);
            }
            else
            {
                if (renderEscape) RenderLeadingTrailingStyles(writer, true, true);
                RenderInternal(writer, 0, Count, renderEscape);
                if (renderEscape) RenderLeadingTrailingStyles(writer, true, false);
            }

            VisibleCharacterEnd = writer.VisibleCharacterCount - 1;
        }

        private void RenderWithSelection(ConsoleTextWriter writer, bool renderEscape = true)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            // TODO: TLS cache
            var pendingStyles = renderEscape ? new List<ConsoleStyle>() : null;
            
            if (renderEscape)
            {
                RenderLeadingTrailingStyles(writer, true, true, pendingStyles);
            }

            // Display text before without selection
            RenderInternal(writer, 0, SelectionStart, renderEscape, pendingStyles);

            if (renderEscape)
            {
                // Disable any attribute sequences
                Reset.Render(writer);
                Reversed.Render(writer);
            }

            // Render the string with reverse video
            RenderInternal(writer, SelectionStart, SelectionEnd, false, pendingStyles);

            if (renderEscape)
            {
                // Disable any attribute sequences
                Reset.Render(writer);

                // Restore any styles
                foreach (var style in pendingStyles)
                {
                    style.Render(writer);
                }
            }

            // Display text after without selection
            RenderInternal(writer, SelectionEnd, this.Count, renderEscape);

            if (renderEscape) RenderLeadingTrailingStyles(writer, true, false);
        }

        private void RenderInternal(ConsoleTextWriter writer, int start, int end, bool escape, List<ConsoleStyle> runningStyles = null)
        {
            for(int i = start; i < end; i++)
            {
                var c = this[i];
                if ((escape || runningStyles != null) && c.Escapes != null)
                {
                    foreach (var esc in c.Escapes)
                    {
                        if (escape)
                        {
                            esc.Render(writer);
                        }

                        if (runningStyles != null)
                        {
                            SquashStyle(esc, runningStyles);
                        }
                    }
                }

                var charValue = c.Value;

                // Fill the remaining line with space to clear the space
                if (charValue == '\n')
                {
                    var toComplete = Console.BufferWidth - writer.VisibleCharacterCount % Console.BufferWidth;
                    for (int j = 0; j < toComplete; j++)
                    {
                        writer.Write(' ');
                    }
                    writer.VisibleCharacterCount += toComplete;
                }

                if (charValue == '\n' || charValue >= ' ')
                {
                    writer.Write(charValue);
                }

                if (charValue != '\n' || charValue >= ' ')
                {
                    writer.VisibleCharacterCount++;
                }
            }
        }

        private void SquashStyle(ConsoleStyle style, List<ConsoleStyle> pendingStyles)
        {
            switch (style.Kind)
            {
                case ControlStyleKind.Color:
                    for (var i = 0; i < pendingStyles.Count; i++)
                    {
                        var otherStyle = pendingStyles[i];
                        if (otherStyle.Kind == ControlStyleKind.Color)
                        {
                            pendingStyles[i] = style;
                            return;
                        }
                    }
                    pendingStyles.Add(style);
                    break;
                case ControlStyleKind.Format:
                    for (var i = 0; i < pendingStyles.Count; i++)
                    {
                        var otherStyle = pendingStyles[i];
                        if (otherStyle == style)
                        {
                            return;
                        }
                    }
                    pendingStyles.Add(style);
                    break;
                case ControlStyleKind.Reset:
                    pendingStyles.Clear();
                    pendingStyles.Add(style);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        public static implicit operator ConsoleText(string text)
        {
            return new ConsoleText(text);
        }

        public IEnumerator<ConsoleChar> GetEnumerator()
        {
            return _chars.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var c in this)
            {
                builder.Append(c.Value);
            }
            return builder.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _chars).GetEnumerator();
        }
    }
}