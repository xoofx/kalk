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
        private readonly ConsoleRenderer _consoleRenderer;
        
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
            _consoleRenderer = new ConsoleRenderer();
            _stackIndex = -1;
            EditLine = _consoleRenderer.EditLine;
            History = new List<string>();
            Prompt = _consoleRenderer.BeforeEditLine;
            Prompt.Append(">>> ");
            TextAfterLine = _consoleRenderer.AfterEditLine;
            Console.CursorVisible = true;
            ExitOnNextEval = false;
        }

        public bool SupportEscapeSequences { get; }

        public int CursorIndex
        {
            get => _consoleRenderer.CursorIndex;
            set => _consoleRenderer.CursorIndex = value;
        }

        public bool ExitOnNextEval { get; set; }

        public List<string> History { get; }

        public Action<string> SetClipboardTextImpl { get; set; }

        public Func<string> GetClipboardTextImpl { get; set; }

        public string LocalClipboard { get; set; }

        public ConsoleText EditLine { get; }

        public ConsoleText Prompt { get; }

        public ConsoleText TextAfterLine { get; }

        public Func<string, bool> OnTextValidatingEnter { get; set; }

        public Action<string> OnTextValidatedEnter { get; set; }

        public Func<string, bool, string> OnTextCompletion { get; set; }

        public bool HasSelection => _consoleRenderer.HasSelection;

        public int SelectionIndex => _consoleRenderer.SelectionIndex;

        public void Begin()
        {
            CursorIndex = 0;
            UpdateSelection();
        }

        public void End()
        {
            CursorIndex = EditLine.Count;
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
                        var newCategory = GetCharCategory(EditLine[cursorIndex].Value);
                        if (newCategory != UnicodeCategory.SpaceSeparator)
                        {
                            category = newCategory;
                            break;
                        }
                    }

                    while (cursorIndex > 0)
                    {
                        cursorIndex--;
                        var newCategory = GetCharCategory(EditLine[cursorIndex].Value);
                        
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
            var category = GetCharCategory(EditLine[cursorIndex].Value);

            while (cursorIndex < EditLine.Count)
            {
                var newCategory = GetCharCategory(EditLine[cursorIndex].Value);
                if (newCategory != category)
                {
                    break;
                }
                cursorIndex++;
            }

            while (cursorIndex < EditLine.Count)
            {
                var newCategory = GetCharCategory(EditLine[cursorIndex].Value);
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
            if (cursorIndex < EditLine.Count)
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
                text.Append(EditLine[i].Value);
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
            _consoleRenderer.BeginSelection();
        }

        public void EndSelection()
        {
            _consoleRenderer.EndSelection();
        }

        public void RemoveSelection()
        {
            _consoleRenderer.RemoveSelection();
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
                    EditLine.RemoveAt(cursorIndex);
                }
            }
            else
            {
                cursorIndex--;
                EditLine.RemoveAt(cursorIndex);
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
            if (cursorIndex < EditLine.Count)
            {
                if (word)
                {
                    var count = FindNextWordRight(cursorIndex) - cursorIndex;
                    while (count > 0)
                    {
                        EditLine.RemoveAt(cursorIndex);
                        count--;
                    }
                }
                else
                {
                    EditLine.RemoveAt(cursorIndex);
                }

                Display();
            }
        }

        public void SetLine(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            EndSelection();

            // Don't update if it is already empty
            if (EditLine.Count == 0 && string.IsNullOrEmpty(text)) return;

            EditLine.Clear();
            foreach (var c in text)
            {
                EditLine.Add(c);
            }
            Display(EditLine.Count);
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
                EditLine.Insert(cursorIndex, c);
                cursorIndex++;
            }
            Display(cursorIndex);
        }

        public void Write(ConsoleStyle style)
        {
            var cursorIndex = CursorIndex;
            EditLine.Insert(cursorIndex, style);
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
            EditLine.Insert(cursorIndex, c);
            cursorIndex++;
            Display(cursorIndex);
        }

        public void Enter()
        {
            if (HasSelection)
            {
                EndSelection();
            }
            End();

            var text = EditLine.Count == 0 ? string.Empty : EditLine.ToString();

            // Try to validate the string
            if (OnTextValidatingEnter != null && !OnTextValidatingEnter(text))
            {
                Display();
            }
            else
            {
                Display(reset: true);

                // Propagate enter validation
                OnTextValidatedEnter?.Invoke(text);

                if (!string.IsNullOrEmpty(text))
                {
                    History.Add(text);
                }

                _stackIndex = -1;

                if (!ExitOnNextEval)
                {
                    Display(0);
                }
            }
        }

        public void Clear()
        {
            _consoleRenderer.Reset();
            Console.Clear();
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
                var newCategory = GetCharCategory(EditLine[cursorIndex].Value);
                
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
                builder.Append(EditLine[i].Value);
            }
            var text = builder.ToString();

            var newText = OnTextCompletion(text, backward);
            if (newText != null && newText != text)
            {
                int length = text.Length;
                while (length > 0)
                {
                    EditLine.RemoveAt(cursorIndex);
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

            Display(reset: true);

            Console.Write($"{ConsoleStyle.BrightRed}^C");
            Console.ResetColor();

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

                try
                {
                    ProcessKey(key);
                }
                catch (Exception ex)
                {
                    TextAfterLine.Clear();
                    TextAfterLine.Append("\n");
                    TextAfterLine.Append(ConsoleStyle.Red);
                    TextAfterLine.Append(ex.ToString());
                    Display(reset: true); // re-display the current line with the exception

                    // Display the next line
                    Display();
                }
            }
        }

        protected virtual void ProcessKey(ConsoleKeyInfo key)
        {
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
                return;
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
                hasShift = false;
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                Delete(hasControl);
                _stackIndex = -1;
                hasShift = false;
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

        public void Display(int? newCursorIndex = null, bool reset = false)
        {
            _consoleRenderer.Render(newCursorIndex, reset);
        }

        private void DebugCursorPosition(string text = null)
        {
            Console.Title = $"x:{Console.CursorLeft} y:{Console.CursorTop} (Size w:{Console.BufferWidth} h:{Console.BufferHeight}){(text == null ? string.Empty: " " + text)}";
        }
    }
}