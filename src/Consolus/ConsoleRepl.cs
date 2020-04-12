using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Consolus
{
    public class ConsoleRepl
    {
        // http://ascii-table.com/ansi-escape-sequences-vt-100.php

        private int _stackIndex;
        private readonly ConsoleTextWriter _consoleWriter;
        private int _previousDisplayLength;
        private int _cursorIndex;
        private int _promptSize;
        private ConsoleText _prompt;

        
        public static bool IsSelf()
        {
            if (ConsoleHelper.IsWindows)
            {
                return WindowsHelper.IsSelfConsoleWindows();
            }
            return false;
        }

        public ConsoleRepl()
        {
            SupportEscapeSequences = ConsoleHelper.SupportEscapeSequences;
            Console.TreatControlCAsInput = true;
            _consoleWriter = new ConsoleTextWriter(Console.Out);
            _stackIndex = -1;
            Line = new ConsoleText();
            History = new List<string>();
            Prompt = "> ";
            SelectionIndex = -1;
            Console.CursorVisible = true;
            ExitOnNextEval = false;
        }

        public bool SupportEscapeSequences { get; }

        public int CursorIndex
        {
            get => _cursorIndex;
            set
            {
                var lineTop = LineTop;
                _cursorIndex = value;
                UpdateCursorPosition(lineTop);
            }
        }

        public bool ExitOnNextEval { get; set; }

        public List<string> History { get; }

        public Action<string> SetClipboardTextImpl { get; set; }

        public Func<string> GetClipboardTextImpl { get; set; }

        public string LocalClipboard { get; set; }

        public ConsoleText Line { get; }

        public ConsoleText Prompt
        {
            get => _prompt;
            set => _prompt = value ?? throw new ArgumentNullException();
        }

        public Func<string, bool> OnTextValidatingEnter { get; set; }

        public Action<string> OnTextValidatedEnter { get; set; }

        public Func<string, bool, string> OnTextCompletion { get; set; }

        public bool HasSelection => SelectionIndex >= 0 && CursorIndex != SelectionIndex;

        public int SelectionStartIndex => HasSelection ? SelectionIndex < CursorIndex ? SelectionIndex : CursorIndex : -1;

        public int SelectionEndIndex => HasSelection ? SelectionIndex < CursorIndex ? CursorIndex : SelectionIndex : -1;

        public int SelectionIndex { get; private set; }

        public int LineTop
        {
            get
            {
                var currentLine = (_promptSize + CursorIndex) / Console.BufferWidth;
                return Console.CursorTop - currentLine;
            }
        }
       
        public void Begin()
        {
            CursorIndex = 0;
            UpdateSelection();
        }

        public void End()
        {
            CursorIndex = Line.Count;
            UpdateSelection();
        }

        public void UpdateSelection()
        {
            if (SelectionIndex >= 0)
            {
                Display();
            }
        }
        
        private static UnicodeCategory GetCharCategory(char c)
        {
            if (c == '_' || (c >= '0' && c <= '9')) return UnicodeCategory.LowercaseLetter;
            c = char.ToLowerInvariant(c);
            return char.GetUnicodeCategory(c);
        }
        
        public void MoveLeft(bool word = false)
        {
            var cursorIndex = CursorIndex;
            if (cursorIndex > 0)
            {
                if (word)
                {
                    UnicodeCategory? category = null;

                    // Remove any space before
                    while (cursorIndex > 0)
                    {
                        cursorIndex--;
                        var newCategory = GetCharCategory(Line[cursorIndex].Value);
                        if (newCategory != UnicodeCategory.SpaceSeparator)
                        {
                            category = newCategory;
                            break;
                        }
                    }

                    while (cursorIndex > 0)
                    {
                        cursorIndex--;
                        var newCategory = GetCharCategory(Line[cursorIndex].Value);
                        
                        if (category.HasValue)
                        {
                            if (newCategory != category.Value)
                            {
                                cursorIndex++;
                                break;
                            }
                        }
                        else
                        {
                            category = newCategory;
                        }
                    }
                }
                else
                {
                    cursorIndex--;
                }
            }

            CursorIndex = cursorIndex;
            UpdateSelection();
        }


        private int FindNextWordRight(int cursorIndex)
        {
            var category = GetCharCategory(Line[cursorIndex].Value);

            while (cursorIndex < Line.Count)
            {
                var newCategory = GetCharCategory(Line[cursorIndex].Value);
                if (newCategory != category)
                {
                    break;
                }
                cursorIndex++;
            }

            while (cursorIndex < Line.Count)
            {
                var newCategory = GetCharCategory(Line[cursorIndex].Value);
                if (newCategory != UnicodeCategory.SpaceSeparator)
                {
                    break;
                }
                cursorIndex++;
            }

            return cursorIndex;
        }

        public void MoveRight(bool word = false)
        {
            var cursorIndex = CursorIndex;
            if (cursorIndex < Line.Count)
            {
                if (word)
                {
                    cursorIndex = FindNextWordRight(cursorIndex);
                }
                else
                {
                    cursorIndex++;
                }
            }
            CursorIndex = cursorIndex;
            UpdateSelection();
        }
        
        public void CopySelectionToClipboard()
        {
            if (!HasSelection) return;

            var text = new StringBuilder();
            var from = SelectionIndex < CursorIndex ? SelectionIndex : CursorIndex;
            var to = SelectionIndex < CursorIndex ? CursorIndex - 1 : SelectionIndex - 1;

            for (int i = from; i <= to; i++)
            {
                text.Append(Line[i].Value);
            }

            bool useLocalClipboard = true;

            var textToClip = text.ToString();

            if (SetClipboardTextImpl != null)
            {
                try
                {
                    SetClipboardTextImpl(textToClip);
                    useLocalClipboard = false;
                }
                catch
                {
                    // ignore
                }
            }

            if (useLocalClipboard)
            {
                LocalClipboard = textToClip;
            }
        }

        public string GetClipboardText()
        {
            if (LocalClipboard != null) return LocalClipboard;

            if (GetClipboardTextImpl != null)
            {
                try
                {
                    return GetClipboardTextImpl();
                }
                catch 
                {
                    // ignore
                }
            }

            return null;
        }

        public void BeginSelection()
        {
            if (SelectionIndex >= 0) return;
            SelectionIndex = CursorIndex;
        }

        public void EndSelection()
        {
            if (SelectionIndex < 0) return;
            SelectionIndex = -1;
            Display();
        }

        public void RemoveSelection()
        {
            if (!HasSelection) return;

            var start = SelectionStartIndex;
            var count = SelectionEndIndex - start;

            for (int i = 0; i < count; i++)
            {
                Line.RemoveAt(start);
            }

            var cursorIndex = start;
            SelectionIndex = -1;
            Display(cursorIndex);
        }

        public void Backspace(bool word)
        {
            if (HasSelection)
            {
                RemoveSelection();
                return;
            }

            var cursorIndex = CursorIndex;
            if (cursorIndex == 0) return;

            if (word)
            {
                MoveLeft(true);
                var newCursorIndex = CursorIndex;
                while (cursorIndex > 0 && cursorIndex > newCursorIndex)
                {
                    cursorIndex--;
                    Line.RemoveAt(cursorIndex);
                }
            }
            else
            {
                cursorIndex--;
                Line.RemoveAt(cursorIndex);
            }

            Display(cursorIndex);
        }

        public void Delete(bool word)
        {
            if (HasSelection)
            {
                RemoveSelection();
                return;
            }

            var cursorIndex = CursorIndex;
            if (cursorIndex < Line.Count)
            {
                if (word)
                {
                    var count = FindNextWordRight(cursorIndex) - cursorIndex;
                    while (count > 0)
                    {
                        Line.RemoveAt(cursorIndex);
                        count--;
                    }
                }
                else
                {
                    Line.RemoveAt(cursorIndex);
                }

                Display();
            }
        }

        public void SetLine(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            EndSelection();

            // Don't update if it is already empty
            if (Line.Count == 0 && string.IsNullOrEmpty(text)) return;

            Line.Clear();
            foreach (var c in text)
            {
                Line.Add(c);
            }
            Display(Line.Count);
        }

        public void Write(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            Write(text, 0, text.Length);
        }

        public void Write(string text, int index, int length)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            var cursorIndex = CursorIndex;
            var end = index + length;
            for(int i = index; i < end; i++)
            {
                var c = text[i];
                Line.Insert(cursorIndex, c);
                cursorIndex++;
            }
            Display(cursorIndex);
        }

        public void Write(ConsoleStyle style)
        {
            var cursorIndex = CursorIndex;
            Line.Insert(cursorIndex, style);
            Display(cursorIndex);
        }

        public void Write(char c)
        {
            if (SelectionIndex >= 0)
            {
                RemoveSelection();
            }
            EndSelection();

            var cursorIndex = CursorIndex;
            Line.Insert(cursorIndex, c);
            cursorIndex++;
            Display(cursorIndex);
        }

        public string Enter()
        {
            if (HasSelection)
            {
                EndSelection();
            }
            End();

            var text = Line.Count == 0 ? string.Empty : Line.ToString();

            // Try to validate the string
            if (OnTextValidatingEnter != null && !OnTextValidatingEnter(text))
            {
                return text;
            }
            
            Line.Clear();

            if (!string.IsNullOrEmpty(text))
            {
                History.Add(text);
            }
            _stackIndex = -1;

            Console.WriteLine();
            _promptSize = 0;
            _cursorIndex = 0;
            _previousDisplayLength = 0;

            // Propagate enter validation
            OnTextValidatedEnter?.Invoke(text);

            if (!ExitOnNextEval)
            {
                Display(0);
            }
            return text;
        }

        public void Completion(bool backward)
        {
            if (OnTextCompletion == null) return;

            var cursorIndex = CursorIndex;
            UnicodeCategory? category = null;
            bool hasValidText = false;

            while (cursorIndex > 0)
            {
                cursorIndex--;
                var newCategory = GetCharCategory(Line[cursorIndex].Value);
                
                if (category.HasValue)
                {
                    if (newCategory != category.Value)
                    {
                        cursorIndex++;
                        break;
                    }
                }
                else
                {
                    category = newCategory;
                }

                switch (newCategory)
                {
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.TitlecaseLetter:
                    case UnicodeCategory.ModifierLetter:
                    case UnicodeCategory.OtherLetter:
                    case UnicodeCategory.NonSpacingMark:
                    case UnicodeCategory.DecimalDigitNumber:
                    case UnicodeCategory.ModifierSymbol:
                    case UnicodeCategory.ConnectorPunctuation:
                        break;
                    default:
                        return;
                }
            }

            var builder = new StringBuilder();
            for (int i = cursorIndex; i < CursorIndex; i++)
            {
                builder.Append(Line[i].Value);
            }
            var text = builder.ToString();

            var newText = OnTextCompletion(text, backward);
            if (newText != null && newText != text)
            {
                int length = text.Length;
                while (length > 0)
                {
                    Line.RemoveAt(cursorIndex);
                    length--;
                }

                CursorIndex = cursorIndex;
                Write(newText);
            }
        }

        private ConsoleKeyInfo ReadKey()
        {
            var key = Console.ReadKey(true);
            return key;
        }

        public void Exit()
        {
            End();
            var text = new ConsoleText();
            text.Append(ConsoleStyle.BrightRed).Append("^C");
            text.Render(Console.Out);
            if (!ConsoleHelper.IsWindows)
            {
                Console.WriteLine();
            }

            ExitOnNextEval = true;
        }
        
        public void Run()
        {
            _stackIndex = -1;

            // https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences

            Display();

            while (!ExitOnNextEval)
            {
                var key = ReadKey();

                bool hasControl = (key.Modifiers & ConsoleModifiers.Control) != 0;
                bool hasShift = (key.Modifiers & ConsoleModifiers.Shift) != 0;

                // Only support selection if we have support for escape sequences
                if (SupportEscapeSequences && hasShift)
                {
                    BeginSelection();
                }

                bool hasCopyPaste = false;
                if (HasSelection && hasControl)
                {
                    if (key.Key == ConsoleKey.C || key.Key == ConsoleKey.X)
                    {
                        hasCopyPaste = true;
                        CopySelectionToClipboard();
                    }
                    if (key.Key == ConsoleKey.X)
                    {
                        RemoveSelection();
                    }
                }

                if (!hasCopyPaste && hasControl && key.Key == ConsoleKey.C)
                {
                    Exit();
                    continue;
                }

                if (hasControl && key.Key == ConsoleKey.V)
                {
                    var clipboard = GetClipboardText();
                    if (clipboard != null)
                    {
                        int previousIndex = 0;
                        while (true)
                        {
                            int matchIndex = clipboard.IndexOf('\n', previousIndex);
                            int index = matchIndex;
                            bool exit = false;
                            if (index < 0)
                            {
                                index = clipboard.Length;
                                exit = true;
                            }

                            while (index > 0 && index < clipboard.Length && clipboard[index - 1] == '\r')
                            {
                                index--;
                            }
                            Write(clipboard, previousIndex, index - previousIndex);
                            
                            if (exit)
                            {
                                break;
                            }
                            else
                            {
                                previousIndex = matchIndex + 1;
                                // Otherwise we have a new line
                                Enter(); 
                            }
                        }
                    }
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    Backspace(hasControl);
                    _stackIndex = -1;
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    Delete(hasControl);
                    _stackIndex = -1;
                }
                else if (hasControl && key.Key == ConsoleKey.R)
                {
                    Write(ConsoleStyle.BrightRed);
                }
                else if (hasControl && key.Key == ConsoleKey.U)
                {
                    Write(ConsoleStyle.Underline);
                }
                else if (hasControl && key.Key == ConsoleKey.B)
                {
                    Write(ConsoleStyle.BrightYellow);
                }
                else if (hasControl && key.Key == ConsoleKey.N)
                {
                    Write(ConsoleStyle.Reset);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    MoveLeft(hasControl);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    MoveRight(hasControl);
                }
                else if (key.Key == ConsoleKey.Home)
                {
                    Begin();
                }
                else if (key.Key == ConsoleKey.End || (hasShift && key.Key == ConsoleKey.F)) // Case for WSL?
                {
                    End();
                }
                else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    var newStackIndex = _stackIndex + (key.Key == ConsoleKey.DownArrow ? -1 : 1);
                    if (newStackIndex < 0 || newStackIndex >= History.Count)
                    {
                        if (newStackIndex < 0)
                        {
                            SetLine(string.Empty);
                            _stackIndex = -1;
                        }
                    }
                    else
                    {
                        _stackIndex = newStackIndex;
                        var index = (History.Count - 1) - _stackIndex;

                        SetLine(History[index]);
                    }
                }
                //else if (hasControl && key.Key == ConsoleKey.R)
                //{
                //    Console.WriteLine(string.Concat(Esc, Header1, "Yo, this is a header", Esc, EndSequence));
                //}
                else if (key.Key == ConsoleKey.Enter)
                {
                    Enter();
                }
                else if (key.Key == ConsoleKey.Tab)
                {
                    Completion(hasShift);
                }
                else if (key.KeyChar >= ' ')
                {
                    //Console.Title = $"{key.Modifiers} {key.Key} {key.KeyChar} {(int)key.KeyChar:x}";
                    Write(key.KeyChar);
                }

                // Remove selection if shift is no longer selected
                if (!hasShift)
                {
                    EndSelection();
                }
            }
        }

        private void ResetStyle()
        {
            if (SupportEscapeSequences)
            {
                ConsoleStyle.Reset.Render(_consoleWriter);
            }
            else
            {
                Console.ResetColor();
            }
        }

        public void Display(int? newCursorIndex = null)
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

            Prompt.Render(_consoleWriter);

            Line.SelectionStart = SelectionStartIndex;
            Line.SelectionEnd = SelectionEndIndex;

            Line.Render(_consoleWriter, SupportEscapeSequences);

            // Fill remaining space with space
            var newLength = Prompt.Count + Line.Count;
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

            _consoleWriter.WriteBatch();

            if (!SupportEscapeSequences)
            {
                Console.ResetColor();
            }

            _previousDisplayLength = newLength;

            // Calculate the current line based on the visual
            var lineTop = Console.CursorTop - (visualLength - 1)  / Console.BufferWidth;

            _promptSize = Prompt.Count;
            if (newCursorIndex.HasValue)
            {
                _cursorIndex = newCursorIndex.Value;
            }

            UpdateCursorPosition(lineTop);
            Console.CursorVisible = true;
        }

        private void DebugCursorPosition(string text = null)
        {
            Console.Title = $"x:{Console.CursorLeft} y:{Console.CursorTop} (Size w:{Console.BufferWidth} h:{Console.BufferHeight}){(text == null ? string.Empty: " " + text)}";
        }

        private void UpdateCursorPosition(int lineTop)
        {
            var position = _promptSize + _cursorIndex;

            var deltaX = position % Console.BufferWidth;
            var deltaY = position / Console.BufferWidth;
            Console.SetCursorPosition(deltaX, lineTop + deltaY);
        }
    }
}