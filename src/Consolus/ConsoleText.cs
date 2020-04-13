using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Consolus
{
    using static ConsoleStyle;


    public struct ConsoleStyleMarker
    {
        public ConsoleStyleMarker(ConsoleStyle style, bool enabled)
        {
            Style = style;
            Enabled = enabled;
        }

        public readonly ConsoleStyle Style;

        public readonly bool Enabled;

        public static implicit operator ConsoleStyleMarker(ConsoleStyle style)
        {
            return new ConsoleStyleMarker(style, true);
        }
    }
    

    public class ConsoleText : IList<ConsoleChar>
    {
        private readonly List<ConsoleChar> _chars;
        private readonly List<ConsoleStyleMarker> _leadingStyles;
        private readonly List<ConsoleStyleMarker> _trailingStyles;
        private bool _changedCalled;

        public ConsoleText()
        {
            _chars = new List<ConsoleChar>();
            _leadingStyles = new List<ConsoleStyleMarker>();
            _trailingStyles = new List<ConsoleStyleMarker>();
            SelectionEnd = -1;
        }

        public ConsoleText(string text) : this()
        {
            Append(text);
        }

        public Action Changed { get; set; }

        public int VisibleCharacterStart { get; internal set; }

        public int VisibleCharacterEnd { get; internal set; }

        public int SelectionStart { get; set; }
        
        public int SelectionEnd { get; set; }


        public void Add(ConsoleChar item)
        {
            Insert(Count, item);
        }

        public void Clear()
        {
            ResetAndSet(null);
            NotifyChanged();
        }

        private void ResetAndSet(string text)
        {
            _leadingStyles.Clear();
            _chars.Clear();
            _trailingStyles.Clear();
            SelectionStart = 0;
            SelectionEnd = -1;
            if (text != null)
            {
                foreach (var c in text)
                {
                    _chars.Add(c);
                }
            }
        }

        public void ReplaceBy(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            ResetAndSet(text);
            NotifyChanged();
        }

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
                if (consoleChar.StyleMarkers != null)
                {
                    consoleChar.StyleMarkers.Clear();
                    _chars[i] = consoleChar;
                }
            }
        }

        public bool ClearStyle(ConsoleStyle style)
        {
            var removed = RemoveStyle(style, _leadingStyles);
            removed = RemoveStyle(style, _trailingStyles) || removed;
            for (var i = 0; i < _chars.Count; i++)
            {
                var consoleChar = _chars[i];
                if (consoleChar.StyleMarkers != null)
                {
                    removed = RemoveStyle(style, consoleChar.StyleMarkers) || removed;
                }
            }
            return removed;
        }

        private static bool RemoveStyle(ConsoleStyle style, List<ConsoleStyleMarker> markers)
        {
            bool styleRemoved = false;
            if (markers == null) return false;
            for (var i = markers.Count - 1; i >= 0; i--)
            {
                var consoleStyleMarker = markers[i];
                if (consoleStyleMarker.Style == style)
                {
                    markers.RemoveAt(i);
                    styleRemoved = true;
                }
            }

            return styleRemoved;
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
            InsertInternal(index, item);
            NotifyChanged();
        }

        private void InsertInternal(int index, ConsoleChar item)
        {
            // Copy any leading/trailing escapes
            bool isFirstInsert = index == 0 && Count == 0;
            bool isLastInsert = Count > 0 && index == Count;
            List<ConsoleStyleMarker> copyFrom = isFirstInsert ? _leadingStyles : isLastInsert ? _trailingStyles : null;
            if (copyFrom != null && copyFrom.Count > 0)
            {
                var escapes = item.StyleMarkers;
                if (escapes == null)
                {
                    escapes = new List<ConsoleStyleMarker>();
                    item.StyleMarkers = escapes;
                }

                for (int i = 0; i < copyFrom.Count; i++)
                {
                    escapes.Insert(i, copyFrom[i]);
                }
                copyFrom.Clear();
            }

            _chars.Insert(index, item);
        }

        public void InsertRange(int index, string text, int textIndex, int length)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            var cursorIndex = index;
            var end = textIndex + length;
            for (int i = textIndex; i < end; i++)
            {
                var c = text[i];
                InsertInternal(cursorIndex, c);
                cursorIndex++;
            }
            NotifyChanged();
        }

        private void NotifyChanged()
        {
            var changed = Changed;

            // Avoid recursive change
            if (changed != null && !_changedCalled)
            {
                _changedCalled = true;
                try
                {
                    changed();
                }
                finally
                {
                    _changedCalled = false;
                }
            }
        }

        public void RemoveAt(int index)
        {
            _chars.RemoveAt(index);
            NotifyChanged();
        }

        public void RemoveRangeAt(int index, int length)
        {
            for (int i = 0; i < length; i++)
            {
                _chars.RemoveAt(index);
            }
            NotifyChanged();
        }

        public ConsoleChar this[int index]
        {
            get => _chars[index];
            set => _chars[index] = value;
        }

        public void Add(ConsoleStyle style)
        {
            Add(style, true);
        }

        public void Add(ConsoleStyle style, bool enabled)
        {
            if (enabled) EnableStyleAt(Count, style);
            else DisableStyleAt(Count, style);
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

        public ConsoleText AppendLine()
        {
            Add('\n');
            return this;
        }

        public void AddRange(ConsoleText text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            foreach(var c in text._leadingStyles)
            {
                InsertInternal(Count, c);
            }

            foreach(var c in text._chars)
            {
                InsertInternal(Count, c);
            }

            foreach (var c in text._trailingStyles)
            {
                InsertInternal(Count, c);
            }
        }

        public ConsoleText Append(ConsoleStyle style, bool enabled)
        {
            Add(style, enabled);
            return this;
        }

        public ConsoleText Append(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            foreach (var c in text)
            {
                InsertInternal(Count, c);
            }

            NotifyChanged();
            return this;
        }

        public void EnableStyleAt(int index, ConsoleStyle style)
        {
            InsertInternal(index, style);
        }

        public void DisableStyleAt(int index, ConsoleStyle style)
        {
            InsertInternal(index, new ConsoleStyleMarker(style, false));
        }

        private void InsertInternal(int index, ConsoleStyleMarker marker)
        {
            if ((uint)index > (uint)Count) throw new ArgumentOutOfRangeException($"Invalid character index {index} not within range [0, {Count}]");

            var isFirst = index == 0 && Count == 0;
            var isLast = index == Count;

            List<ConsoleStyleMarker> list;
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
                list = c.StyleMarkers;
                if (list == null)
                {
                    list = new List<ConsoleStyleMarker>();
                    c.StyleMarkers = list;
                    this[index] = c;
                }
            }

            list.Add(marker);
        }

        private void RenderLeadingTrailingStyles(TextWriter writer, bool displayStyle, bool leading, RunningStyles runningStyles)
        {
            var styles = leading ? _leadingStyles : _trailingStyles;
            foreach (var consoleStyle in styles)
            {
                runningStyles.ApplyStyle(consoleStyle);
                if (displayStyle)
                {
                    runningStyles.Render(writer);
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
                var styles = new RunningStyles();
                if (renderEscape) RenderLeadingTrailingStyles(writer, true, true, styles);
                RenderInternal(writer, 0, Count, renderEscape, styles);
                if (renderEscape) RenderLeadingTrailingStyles(writer, true, false, styles);
            }

            VisibleCharacterEnd = writer.VisibleCharacterCount - 1;
        }

        private void RenderWithSelection(ConsoleTextWriter writer, bool renderEscape = true)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            // TODO: TLS cache
            var pendingStyles = renderEscape ? new RunningStyles() : null;
            
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

                pendingStyles.Render(writer);
            }

            // Display text after without selection
            RenderInternal(writer, SelectionEnd, this.Count, renderEscape, pendingStyles);

            if (renderEscape) RenderLeadingTrailingStyles(writer, true, false, pendingStyles);
        }

        private void RenderInternal(ConsoleTextWriter writer, int start, int end, bool displayStyle, RunningStyles runningStyles)
        {
            for(int i = start; i < end; i++)
            {
                var c = this[i];
                if ((displayStyle || runningStyles != null) && c.StyleMarkers != null)
                {
                    foreach (var esc in c.StyleMarkers)
                    {
                        runningStyles.ApplyStyle(esc);
                        if (displayStyle)
                        {
                            runningStyles.Render(writer);
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

        private class RunningStyles : Dictionary<ConsoleStyleKind, List<ConsoleStyle>>
        {
            public void Render(TextWriter writer)
            {                
                // Disable any attribute sequences
                Reset.Render(writer);
                foreach (var stylePair in this)
                {
                    var list = stylePair.Value;
                    if (stylePair.Key == ConsoleStyleKind.Color)
                    {
                        if (list.Count > 0)
                        {
                            list[list.Count - 1].Render(writer);
                        }
                    }
                    else if (stylePair.Key == ConsoleStyleKind.Format)
                    {
                        foreach (var item in list)
                        {
                            item.Render(writer);
                        }
                    }
                }
            }

            public void ApplyStyle(ConsoleStyleMarker styleMarker)
            {
                var style = styleMarker.Style;
                switch (style.Kind)
                {
                    case ConsoleStyleKind.Color:
                    case ConsoleStyleKind.Format:
                        if (!TryGetValue(style.Kind, out var list))
                        {
                            list = new List<ConsoleStyle>();
                            Add(style.Kind, list);
                        }

                        if (styleMarker.Enabled)
                        {
                            list.Add(style);
                        }
                        else
                        {
                            for (var i = list.Count - 1; i >= 0; i--)
                            {
                                var item = list[i];
                                if (item == style)
                                {
                                    list.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        break;
                    case ConsoleStyleKind.Reset:
                        Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}