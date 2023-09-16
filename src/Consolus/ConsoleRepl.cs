using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Consolus
{
    public class ConsoleRepl : ConsoleRenderer
    {
        // http://ascii-table.com/ansi-escape-sequences-vt-100.php

        private int _stackIndex;
        private readonly BlockingCollection<ConsoleKeyInfo> _keys;
        private Thread _thread;
        
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
            HasInteractiveConsole = ConsoleHelper.HasInteractiveConsole;
            Prompt.Append(">>> ");
            _stackIndex = -1;
            History = new List<string>();
            ExitOnNextEval = false;
            PendingTextToEnter = new Queue<string>();
            _keys = new BlockingCollection<ConsoleKeyInfo>();

            if (HasInteractiveConsole)
            {
                Console.TreatControlCAsInput = true;
                Console.CursorVisible = true;
            }
        }

        public bool HasInteractiveConsole { get; }

        public bool ExitOnNextEval { get; set; }

        public Func<CancellationTokenSource> GetCancellationTokenSource { get; set; }
        
        public PreProcessKeyDelegate TryPreProcessKey { get; set; }

        public delegate bool PreProcessKeyDelegate(ConsoleKeyInfo key, ref int cursorIndex);
        
        public Action<ConsoleKeyInfo> PostProcessKey { get; set; }

        public List<string> History { get; }

        public Action<string> SetClipboardTextImpl { get; set; }

        public Func<string> GetClipboardTextImpl { get; set; }

        public string LocalClipboard { get; set; }

        public Func<string, bool, bool> OnTextValidatingEnter { get; set; }

        public Action<string> OnTextValidatedEnter { get; set; }

        private Queue<string> PendingTextToEnter { get; }

        public bool Evaluating { get; private set; }

        public void Begin()
        {
            CursorIndex = 0;
            Render();
        }

        public void End()
        {
            CursorIndex = EditLine.Count;
            Render();
        }

        public void EnqueuePendingTextToEnter(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            PendingTextToEnter.Enqueue(text);
        }

        public void UpdateSelection()
        {
            if (SelectionIndex >= 0)
            {
                Render();
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
            Render();
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
            Render();
        }
        
        private void CopySelectionToClipboard()
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


        private void Backspace(bool word)
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
                var length = cursorIndex - CursorIndex;
                EditLine.RemoveRangeAt(newCursorIndex, length);
                cursorIndex = newCursorIndex;
            }
            else
            {
                cursorIndex--;
                EditLine.RemoveAt(cursorIndex);
            }

            Render(cursorIndex);
        }

        private void Delete(bool word)
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
                    EditLine.RemoveRangeAt(cursorIndex, count);
                }
                else
                {
                    EditLine.RemoveAt(cursorIndex);
                }

                Render();
            }
        }

        public void SetLine(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            EndSelection();

            // Don't update if it is already empty
            if (EditLine.Count == 0 && string.IsNullOrEmpty(text)) return;

            EditLine.ReplaceBy(text);
            Render(EditLine.Count);
        }

        public void Write(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            Write(text, 0, text.Length);
        }

        public void Write(string text, int index, int length)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            var cursorIndex = CursorIndex + length;
            EditLine.InsertRange(CursorIndex, text, index, length);
            Render(cursorIndex);
        }

        public void Write(ConsoleStyle style)
        {
            var cursorIndex = CursorIndex;
            EditLine.EnableStyleAt(cursorIndex, style);
            Render(cursorIndex);
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
            Render(cursorIndex);
        }

        private bool Enter(bool force)
        {
            if (EnterInternal(force))
            {
                while (PendingTextToEnter.Count > 0)
                {
                    var newTextToEnter = PendingTextToEnter.Dequeue();
                    EditLine.Clear();
                    EditLine.Append(newTextToEnter);
                    if (!EnterInternal(force)) return false;
                }
                return true;
            }

            return false;
        }

        private bool EnterInternal(bool hasControl)
        {
            if (HasSelection)
            {
                EndSelection();
            }
            End();

            var text = EditLine.Count == 0 ? string.Empty : EditLine.ToString();
            
            // Try to validate the string
            if (OnTextValidatingEnter != null)
            {
                bool isValid = false;
                try
                {
                    Evaluating = true;
                    isValid = OnTextValidatingEnter(text, hasControl);
                }
                finally
                {
                    Evaluating = false;
                }

                if (!isValid)
                {
                    Render();
                    return false;
                }
            }

            bool isNotEmpty = !IsClean || EditLine.Count > 0 || AfterEditLine.Count > 0;
            if (isNotEmpty)
            {
                Render(reset: true);
            }

            // Propagate enter validation
            OnTextValidatedEnter?.Invoke(text);

            if (!string.IsNullOrEmpty(text))
            {
                History.Add(text);
            }

            _stackIndex = -1;

            if (!ExitOnNextEval)
            {
                Render(0);
            }

            return true;
        }

        public void Clear()
        {
            Reset();
            Console.Clear();
        }

        private void Exit()
        {
            End();

            Render(reset: true);

            Console.Write($"{ConsoleStyle.BrightRed}{(OperatingSystem.IsWindows()? "^Z" : "^D")}");
            Console.ResetColor();

            if (!ConsoleHelper.IsWindows)
            {
                Console.WriteLine();
            }

            ExitOnNextEval = true;
        }

        private static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public void Run()
        {
            if (IsWindows)
            {
                // Clear any previous running thread
                if (_thread != null)
                {
                    try
                    {
                        _thread.Abort();
                    }
                    catch
                    {
                        // ignore
                    }

                    _thread = null;
                }

                _thread = new Thread(ThreadReadKeys) {IsBackground = true, Name = "Consolus.ThreadReadKeys"};
                _thread.Start();
            }

            _stackIndex = -1;

            // https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences

            Render();
            while (!ExitOnNextEval)
            {
                try
                {
                    ConsoleKeyInfo key;
                    key = IsWindows ? _keys.Take() : Console.ReadKey(true);

                    ProcessKey(key);
                }
                catch (Exception ex)
                {
                    AfterEditLine.Clear();
                    AfterEditLine.Append("\n");
                    AfterEditLine.Begin(ConsoleStyle.Red);
                    AfterEditLine.Append(ex.Message);
                    Render(); // re-display the current line with the exception

                    // Display the next line
                    //Render();
                }
            }
        }
        
        private void ThreadReadKeys()
        {
            while (!ExitOnNextEval)
            {
                var key = Console.ReadKey(true);
                if (Evaluating && (key.Modifiers & ConsoleModifiers.Control) != 0 && key.Key == ConsoleKey.C)
                {
                    GetCancellationTokenSource()?.Cancel();
                }
                else
                {
                    _keys.Add(key);
                }
            }
        }

        private void PasteClipboard()
        {
            var clipboard = GetClipboardText();
            if (clipboard != null)
            {
                clipboard = clipboard.TrimEnd();
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
                        Enter(true);
                    }
                }
            }
        }

        protected virtual void ProcessKey(ConsoleKeyInfo key)
        {
            _isStandardAction = false;
            _hasShift = (key.Modifiers & ConsoleModifiers.Shift) != 0;

            // Only support selection if we have support for escape sequences
            if (SupportEscapeSequences && _hasShift)
            {
                BeginSelection();
            }

            // Try to pre-process key
            var cursorIndex = CursorIndex;
            if (TryPreProcessKey != null && TryPreProcessKey(key, ref cursorIndex))
            {
                if (!_isStandardAction)
                {
                    if (SelectionIndex >= 0)
                    {
                        RemoveSelection();
                    }

                    EndSelection();

                    Render(cursorIndex);
                }
            }
            else if (key.KeyChar >= ' ')
            {
                Write(key.KeyChar);
            }

            // Remove selection if shift is no longer selected
            if (!_hasShift)
            {
                EndSelection();
            }

            // Post-process key
            if (PostProcessKey != null)
            {
                PostProcessKey(key);
            }
        }

        private void DebugCursorPosition(string text = null)
        {
            Console.Title = $"x:{Console.CursorLeft} y:{Console.CursorTop} (Size w:{Console.BufferWidth} h:{Console.BufferHeight}){(text == null ? string.Empty: " " + text)}";
        }

        private void GoHistory(bool next)
        {
            var newStackIndex = _stackIndex + (next ? -1 : 1);
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


        private bool _hasShift;
        private bool _isStandardAction;
        
        public void Action(ConsoleAction action)
        {
            _isStandardAction = true;
            switch (action)
            {
                case ConsoleAction.Exit:
                    Exit();
                    break;
                case ConsoleAction.CursorLeft:
                    MoveLeft(false);
                    break;
                case ConsoleAction.CursorRight:
                    MoveRight(false);
                    break;
                case ConsoleAction.CursorLeftWord:
                    MoveLeft(true);
                    break;
                case ConsoleAction.CursorRightWord:
                    MoveRight(true);
                    break;
                case ConsoleAction.CursorStartOfLine:
                    Begin();
                    break;
                case ConsoleAction.CursorEndOfLine:
                    End();
                    break;
                case ConsoleAction.HistoryPrevious:
                    GoHistory(false);
                    break;
                case ConsoleAction.HistoryNext:
                    GoHistory(true);
                    break;
                case ConsoleAction.DeleteCharacterLeft:
                    Backspace(false);
                    _stackIndex = -1;
                    _hasShift = false;
                    break;
                case ConsoleAction.DeleteCharacterLeftAndCopy:
                    break;
                case ConsoleAction.DeleteCharacterRight:
                    Delete(false);
                    _stackIndex = -1;
                    _hasShift = false;
                    break;
                case ConsoleAction.DeleteCharacterRightAndCopy:
                    break;
                case ConsoleAction.DeleteWordLeft:
                    Backspace(true);
                    _stackIndex = -1;
                    _hasShift = false;
                    break;
                case ConsoleAction.DeleteWordRight:
                    Delete(true);
                    _stackIndex = -1;
                    _hasShift = false;
                    break;
                case ConsoleAction.Completion:
                    break;
                case ConsoleAction.DeleteTextRightAndCopy:
                    break;
                case ConsoleAction.DeleteWordRightAndCopy:
                    break;
                case ConsoleAction.DeleteWordLeftAndCopy:
                    break;
                case ConsoleAction.CopySelection:
                    CopySelectionToClipboard();
                    break;
                case ConsoleAction.CutSelection:
                    CopySelectionToClipboard();
                    RemoveSelection();
                    break;
                case ConsoleAction.PasteClipboard:
                    PasteClipboard();
                    break;
                case ConsoleAction.ValidateLine:
                    Enter(false);
                    break;
                case ConsoleAction.ForceValidateLine:
                    Enter(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, $"Invalid action {action}");
            }
        }
    }


    public enum ConsoleAction
    {
        Exit,
        CursorLeft,
        CursorRight,
        CursorLeftWord,
        CursorRightWord,
        CursorStartOfLine,
        CursorEndOfLine,
        HistoryPrevious,
        HistoryNext,
        DeleteCharacterLeft,
        DeleteCharacterLeftAndCopy,
        DeleteCharacterRight,
        DeleteCharacterRightAndCopy,
        DeleteWordLeft,
        DeleteWordRight,
        Completion,
        DeleteTextRightAndCopy,
        DeleteWordRightAndCopy,
        DeleteWordLeftAndCopy,
        CopySelection,
        CutSelection,
        PasteClipboard,
        ValidateLine,
        ForceValidateLine,
    }

}