using System;
using System.Collections.Generic;

namespace Consolus
{
    public class ConsoleRenderer
    {
        private readonly ConsoleTextWriter _consoleWriter;
        private int _previousDisplayLength;
        private int _cursorIndex;
        private int _beforeEditLineSize;

        public ConsoleRenderer()
        {
            SupportEscapeSequences = ConsoleHelper.SupportEscapeSequences;
            _consoleWriter = new ConsoleTextWriter(Console.Out);
            BeforeEditLine = new ConsoleText();
            EditLine = new ConsoleText();
            AfterEditLine = new ConsoleText();
            SelectionIndex = -1;
        }

        public bool SupportEscapeSequences { get; set; }

        public int LineTop
        {
            get
            {
                var currentLine = (_beforeEditLineSize + CursorIndex) / Console.BufferWidth;
                return Console.CursorTop - currentLine;
            }
        }

        public int CursorIndex
        {
            get => _cursorIndex;
            set
            {
                if (value < 0 || value > EditLine.Count) throw new ArgumentOutOfRangeException(nameof(value), $"Value must be >= 0 and <= {EditLine.Count}");

                var lineTop = LineTop;
                _cursorIndex = value;
                UpdateCursorPosition(lineTop);
            }
        }

        public bool HasSelection => SelectionIndex >= 0 && CursorIndex != SelectionIndex;

        public int SelectionStartIndex => HasSelection ? SelectionIndex < CursorIndex ? SelectionIndex : CursorIndex : -1;

        public int SelectionEndIndex => HasSelection ? SelectionIndex < CursorIndex ? CursorIndex : SelectionIndex : -1;

        public int SelectionIndex { get; private set; }
        
        public ConsoleText BeforeEditLine { get; }

        public ConsoleText EditLine { get; }

        public ConsoleText AfterEditLine { get; }

        public void BeginSelection()
        {
            if (SelectionIndex >= 0) return;
            SelectionIndex = CursorIndex;
        }

        public void EndSelection()
        {
            if (SelectionIndex < 0) return;
            SelectionIndex = -1;
            Render();
        }

        public void RemoveSelection()
        {
            if (!HasSelection) return;

            var start = SelectionStartIndex;
            var count = SelectionEndIndex - start;

            for (int i = 0; i < count; i++)
            {
                if (start >= EditLine.Count) break;
                EditLine.RemoveAt(start);
            }

            var cursorIndex = start;
            SelectionIndex = -1;
            Render(cursorIndex);
        }

        public void Reset()
        {
            AfterEditLine.Clear();
            EditLine.Clear();
            _cursorIndex = 0;
            _beforeEditLineSize = 0;
            _previousDisplayLength = 0;
        }

        public void Render(int? newCursorIndex = null, bool reset = false)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, LineTop);

            if (SupportEscapeSequences)
            {
                ConsoleStyle.Reset.Render(_consoleWriter);
            }
            else
            {
                Console.ResetColor();
            }

            BeforeEditLine.Render(_consoleWriter);

            EditLine.SelectionStart = SelectionStartIndex;
            EditLine.SelectionEnd = SelectionEndIndex;
            EditLine.Render(_consoleWriter, SupportEscapeSequences);

            AfterEditLine.Render(_consoleWriter);

            // Fill remaining space with space
            var newLength = _consoleWriter.VisibleCharacterCount;
            var visualLength = newLength;
            if (newLength < _previousDisplayLength)
            {
                if (SupportEscapeSequences)
                {
                    ConsoleStyle.Reset.Render(_consoleWriter);
                }

                for (int i = newLength; i < _previousDisplayLength; i++)
                {
                    _consoleWriter.Write(' ');
                }
                visualLength = _previousDisplayLength;
            }

            if (SupportEscapeSequences)
            {
                ConsoleStyle.Reset.Render(_consoleWriter);
            }

            _consoleWriter.Commit();

            if (!SupportEscapeSequences)
            {
                Console.ResetColor();
            }

            _previousDisplayLength = newLength;

            if (!reset)
            {
                // Calculate the current line based on the visual
                var lineTop = Console.CursorTop - (visualLength - 1) / Console.BufferWidth;

                _beforeEditLineSize = EditLine.VisibleCharacterStart;
                if (newCursorIndex.HasValue)
                {
                    _cursorIndex = newCursorIndex.Value;
                }

                UpdateCursorPosition(lineTop);
            }
            else
            {
                Reset();
            }

            Console.CursorVisible = true;
        }
        
        private void UpdateCursorPosition(int lineTop)
        {
            var position = _beforeEditLineSize + _cursorIndex;

            var deltaX = position % Console.BufferWidth;
            var deltaY = position / Console.BufferWidth;
            Console.SetCursorPosition(deltaX, lineTop + deltaY);
        }
    }
}