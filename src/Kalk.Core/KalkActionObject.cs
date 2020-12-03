using System;
using Scriban.Runtime;

namespace Kalk.Core
{
    /// <summary>
    /// An action object returned by <see cref="KalkEngine.Action"/> and used when evaluating shortcuts.
    /// </summary>
    public class KalkActionObject : ScriptObject
    {
        public KalkActionObject(string action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public string Action
        {
            get => GetSafeValue<string>("action");
            set => SetValue("action", value, false);
        }

        public void Call(Action<KalkAction> run)
        {
            var action = Action;
            if (action == null) return;
            switch (action)
            {
                case "cursor_left":
                    run(KalkAction.CursorLeft);
                    break;
                case "cursor_right":
                    run(KalkAction.CursorRight);
                    break;
                case "history_previous":
                    run(KalkAction.HistoryPrevious);
                    break;
                case "history_next":
                    run(KalkAction.HistoryNext);
                    break;
                case "copy":
                    run(KalkAction.CopySelection);
                    break;
                case "cut":
                    run(KalkAction.CutSelection);
                    break;
                case "paste":
                    run(KalkAction.PasteClipboard);
                    break;
                case "cursor_word_left":
                    run(KalkAction.CursorLeftWord);
                    break;
                case "cursor_word_right":
                    run(KalkAction.CursorRightWord);
                    break;
                case "cursor_line_start":
                    run(KalkAction.CursorStartOfLine);
                    break;
                case "cursor_line_end":
                    run(KalkAction.CursorEndOfLine);
                    break;
                case "completion":
                    run(KalkAction.Completion);
                    break;
                case "delete_left":
                    run(KalkAction.DeleteCharacterLeft);
                    break;
                case "delete_right":
                    run(KalkAction.DeleteCharacterRight);
                    break;
                case "delete_word_left":
                    run(KalkAction.DeleteWordLeft);
                    break;
                case "delete_word_right":
                    run(KalkAction.DeleteWordRight);
                    break;
                case "validate_line":
                    run(KalkAction.ValidateLine);
                    break;
                case "force_validate_line":
                    run(KalkAction.ForceValidateLine);
                    break;
                case "exit":
                    run(KalkAction.Exit);
                    break;
                case "copy_or_exit":
                    run(KalkAction.CopySelectionOrExit);
                    break;
                default:
                    throw new ArgumentException($"Action `{action}` is not supported", nameof(action));
            }
        }
    }
}