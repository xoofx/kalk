using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Consolus;
using Kalk.Core.Modules;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private const string CategoryGeneral = "General";

        private int _evalDepth;

        public KalkDisplayMode CurrentDisplay { get; private set; }

        public Action<KalkAction> OnAction { get; set; }
        
        public T GetOrCreateModule<T>() where T : KalkModule, new()
        {
            var typeOfT = typeof(T);
            if (_modules.TryGetValue(typeOfT, out var module))
            {
                return (T) module;
            }
            var moduleT = new T();
            module = moduleT;
            _modules.Add(typeOfT, module);

            if (!module.IsBuiltin)
            {
                Builtins.SetValue(module.Name, module, true);
                // Register the module descriptor
                Descriptors.Add(module.Name, module.Descriptor);
            }

            module.Initialize(this);

            if (module.IsBuiltin)
            {
                module.InternalImport();
            }

            return moduleT;
        }

        /// <summary>
        /// Return an environment object that provides access to os (windows, linux, macos), os_version and cpu.
        /// </summary>
        /// <returns>An object with the properties `os`, `os_version`, and `cpu`.</returns>
        [KalkExport("env", CategoryGeneral)]
        public ScriptObject Env
        {
            get
            {
                string os = OperatingSystem.IsWindows() ? "windows"
                    : OperatingSystem.IsLinux() ? "linux"
                    : OperatingSystem.IsMacOS() ? "macos" : "unknown";

                var env = new ScriptObject
                {
                    ["os"] = os,
                    ["os_version"] = System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                    ["cpu"] = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant()
                };
                env.SetReadOnly("os", true);
                env.SetReadOnly("os_version", true);
                env.SetReadOnly("cpu", true);
                return env;
            }
        }

        /// <summary>
        /// Creates an action for the command line editor experience related to
        /// cursor/text manipulation. This action can then be used by the `shortcut` command.
        /// </summary>
        /// <param name="action">The name of the action to create. This name must be
        ///
        /// {.table}
        /// | Action                | Description               |
        /// |-----------------------|---------------------------|
        /// | `cursor_left`         | Move the cursor to the left
        /// | `cursor_right`        | Move the cursor to the right
        /// | `history_previous`    | Bring the previous command from the history
        /// | `history_next`        | Bring the next command from the history
        /// | `copy`                | Copy the selection to the clipboard 
        /// | `cut`                 | Cut the selection to the clipboard 
        /// | `paste`               | Paste the content of the clipboard at the position of the cursor
        /// | `cursor_word_left`    | Move the cursor to the left by one word boundary
        /// | `cursor_word_right`   | Move the cursor to the right by one word boundary
        /// | `cursor_line_start`   | Move the cursor to the beginning of the line
        /// | `cursor_line_end`     | Move the cursor to the end of the line
        /// | `completion`          | Trigger a completion at the cursor's position
        /// | `delete_left`         | Delete the character to the left of the cursor
        /// | `delete_right`        | Delete the character to the right of the cursor
        /// | `delete_word_left`    | Delete a word to the left of the cursor
        /// | `delete_word_right`   | Delete a word to the right of the cursor
        /// | `validate_line`       | Validate the current line
        /// | `force_validate_line` | Validate the current line and force a new line even in case of a syntax error
        /// | `exit`                | Exit the program
        /// | `copy`                | Copy the content of the selection to the clipboard
        /// </param>
        /// <returns>An action object.</returns>
        /// <remarks>
        /// This function is not meant to be used directly but in conjunction with the `shortcut` command.
        /// </remarks>
        /// <example>
        /// ```kalk 
        /// >>> shortcut(cursor_left, "left, ctrl+b", action("cursor_left"))
        /// ```
        /// </example>
        [KalkExport("action", CategoryGeneral)]
        public KalkActionObject Action(string action)
        {
            if (action == null) return null;
            return new KalkActionObject(action);
        }

        /// <summary>
        /// Displays the license
        /// </summary>
        [KalkExport("license", CategoryGeneral)]
        public void License()
        {
            var stream = typeof(KalkEngine).Assembly.GetManifestResourceStream($"{typeof(KalkEngine).Namespace}.license.txt");
            var reader = new StreamReader(stream);
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                WriteHighlightLine($"# {line}");
            }
        }

        /// <summary>
        /// Gets or sets the current content of the clipboard.
        /// </summary>
        /// <param name="value">Value to set the clipboard to. If not set, this function returns the current content of the clipboard.</param>
        /// <returns>Returns the content of the clipboard.</returns>
        /// <remarks>On Unix platform, if you are running from WSL or from raw console, the clipboard is not supported.</remarks>
        /// <example>
        /// ```kalk
        /// >>> clipboard "text"
        /// # clipboard("text")
        /// out = "text"
        /// >>> clipboard
        /// # clipboard
        /// out = "text"
        /// ```
        /// </example>
        [KalkExport("clipboard", CategoryGeneral)]
        public object Clipboard(object value = null)
        {
            if (value == null)
            {
                return GetClipboardText?.Invoke();
            }

            var newclip = ObjectToString(value);
            SetClipboardText?.Invoke(newclip);
            return newclip;
        }

        /// <summary>
        /// Gets or sets the display mode.
        ///
        /// - `raw` for raw mode, where integers are displayed as raw integers.
        /// - `std` for standard mode, integers are displayed with _ separator every 3 digits. This is the default.
        /// - `dev` for developer mode to display advanced details about integers, vectors and floating point values.
        /// </summary>
        /// <param name="name">An optional parameter to set the display mode. Default is `std`. If this parameter is not set, this function will display the display mode currently used.</param>
        /// <example>
        /// ```kalk
        /// >>> display
        /// # Display mode: std (Standard)
        /// >>> display dev
        /// # Display mode: dev (Developer)
        /// >>> 1.5
        /// # 1.5
        /// out = 1.5
        ///     # IEEE 754 - double - 64-bit
        ///     #
        ///     = 0x_3FF80000_00000000
        ///     = 0x____3____F____F____8____0____0____0____0____0____0____0____0____0____0____0____0
        ///     #    seee eeee eeee ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff
        ///     = 0b_0011_1111_1111_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
        ///     #   63                48                  32                  16                   0
        ///     #
        ///     # sign    exponent              |-------------------- fraction --------------------|
        ///     =   1 * 2 ^ (1023 - 1023) * 0b1.1000000000000000000000000000000000000000000000000000
        /// >>> display invalid
        /// Invalid display name `invalid`. Expecting `std`, `dev` or `raw`. (Parameter 'name')
        /// ```
        /// </example>
        [KalkExport("display", CategoryGeneral)]
        public void Display(ScriptVariable name = null)
        {
            var mode = name?.Name;
            if (mode != null)
            {
                if (!KalkDisplayModeHelper.TryParse(mode, out var fullMode))
                {
                    throw new ArgumentException($"Invalid display name `{mode}`. Expecting `std`, `dev` or `raw`.", nameof(name));
                }
                CurrentDisplay = fullMode;
            }

            WriteHighlightLine($"# Display mode: {CurrentDisplay.ToText()} ({CurrentDisplay})");
        }

        /// <summary>
        /// Gets or sets the current echo mode. 
        /// </summary>
        /// <param name="value">An optional `true`/`on` or `false`/`off` value to enable or disable the echo. A value of `false` will disable any output generated by a command except for the print commands. If this parameter is not set, this function will display the current display mode.</param>
        /// <example>
        /// ```kalk
        /// >>> echo
        /// # Echo is on.
        /// >>> 1 + 2
        /// # 1 + 2
        /// out = 3
        /// >>> echo off
        /// >>> 1 + 2
        /// >>> echo
        /// >>> echo on
        /// # Echo is on.
        /// >>> 1 + 2
        /// # 1 + 2
        /// out = 3
        /// ```
        /// </example>
        [KalkExport("echo", CategoryGeneral)]
        public void Echo(ScriptVariable value = null)
        {
            if (value == null)
            {
                WriteHighlightLine($"# Echo is {(EchoEnabled ? "on":"off")}.");
                return;
            }
            var mode = value.Name;
            switch (mode)
            {
                case "true":
                case "on":
                    EchoEnabled = true;
                    WriteHighlightLine($"# Echo is on.");
                    break;
                case "false":
                case "off":
                    EchoEnabled = false;
                    break;
                default:
                    throw new ArgumentException($"Invalid parameter. Only on/true or off/false are valid for echo.", nameof(value));
            }
        }

        /// <summary>
        /// Prints the specified value to the output.
        /// </summary>
        /// <param name="value">A value to print to the output.</param>
        /// <remarks>When the `echo` is off, this method will still output.</remarks>
        /// <example>
        /// ```kalk
        /// >>> print "kalk"
        /// kalk
        /// >>> echo off
        /// >>> print "kalk2"
        /// kalk2
        /// ```
        /// </example>
        [KalkExport("print", CategoryGeneral)]
        public void Print(object value)
        {
            var previousEcho = EchoEnabled;
            try
            {
                EchoEnabled = true;
                WriteHighlightLine(ObjectToString(value), highlight: false);
            }
            finally
            {
                EchoEnabled = previousEcho;
            }
        }

        /// <summary>
        /// Prints a formatted string where values to format are embraced by `{{` and `}}`.
        /// </summary>
        /// <param name="value">A template string to the output. Values to format must be embraced by `{{` and `}}`.</param>
        /// <remarks>When the `echo` is off, this method will still output.</remarks>
        /// <example>
        /// ```kalk
        /// >>> x = 1; y = "yes"
        /// # x = 1; y = "yes"
        /// x = 1
        /// y = "yes"
        /// >>> printf "Hello {{x}} World and {{y}}"
        /// Hello 1 World and yes
        /// ```
        /// </example>
        [KalkExport("printf", CategoryGeneral)]
        public void PrintFormatted(object value)
        {
            var previousEcho = EchoEnabled;
            try
            {
                EchoEnabled = true;
                var result = EvaluateTextImpl(ObjectToString(value), null, false, true);
                WriteHighlightLine(ObjectToString(result), highlight: false);
            }
            finally
            {
                EchoEnabled = previousEcho;
            }
        }

        /// <summary>
        /// Formats a formatted string where values to format are embraced by `{{` and `}}`.
        /// </summary>
        /// <param name="value">A template string to the output. Values to format must be embraced by `{{` and `}}`.</param>
        /// <returns>A string formatted with the specified embedded values.</returns>
        /// <example>
        /// ```kalk
        /// >>> x = 1; y = "yes"
        /// # x = 1; y = "yes"
        /// x = 1
        /// y = "yes"
        /// >>> sprintf "Hello {{x}} World and {{y}}"
        /// # sprintf("Hello {{x}} World and {{y}}")
        /// out = "Hello 1 World and yes"
        /// ```
        /// </example>
        [KalkExport("sprintf", CategoryGeneral)]
        public string StringPrintFormatted(object value)
        {
            return ObjectToString(EvaluateTextImpl(ObjectToString(value), null, false, true));
        }

        /// <summary>
        /// Prints the specified value to the output formatted with kalk syntax highlighting.
        /// </summary>
        /// <param name="value">A value to print to the output.</param>
        /// <remarks>When the `echo` is off, this method will still output.</remarks>
        /// <example>
        /// ```kalk
        /// >>> printh "# This is a kalk comment"
        /// # This is a kalk comment
        /// ```
        /// </example>
        [KalkExport("printh", CategoryGeneral)]
        public void Printh(object value)
        {
            var previousEcho = EchoEnabled;
            try
            {
                EchoEnabled = true;
                WriteHighlightLine(ObjectToString(value), highlight: true);
            }
            finally
            {
                EchoEnabled = previousEcho;
            }
        }

        /// <summary>
        /// Displays the documentation of the specified topic or function name.
        /// </summary>
        /// <param name="expression">An optional topic or function name. If this parameter is not set, it will display all available topics and functions.</param>
        /// <example>
        /// ```kalk
        /// >>> help cls
        /// # cls
        /// #
        /// #   Clears the screen.
        /// #
        /// # Example
        /// .   >>> cls
        /// ```
        /// </example>
        [KalkExport("help", CategoryGeneral)]
        public void Help(ScriptExpression expression = null)
        {
            var name = expression?.ToString();
            if (name != null)
            {
                if (Descriptors.TryGetValue(name, out var descriptor))
                {
                    WriteHelpForDescriptor(descriptor);
                    return;
                }

                throw new ArgumentException($"The builtin function `{name}` does not exist", nameof(expression));
            }

            WriteHighlightLine($"# help [name]");

            // Verify that all function/modules belong to a category
            var invalidRegistered = Descriptors.FirstOrDefault(x => x.Value.Category == null);
            if (invalidRegistered.Value != null)
            {
                throw new InvalidOperationException($"The function or module `{invalidRegistered.Key}` doesn't have a category. This is an invalid state of the program");
            }

            var categoryToDescriptors = Descriptors.GroupBy(x => x.Value.Category).ToDictionary(x => x.Key, y => y.Select(x => x.Value).Distinct().ToList());
            WriteHighlightLine($"#");
            foreach (var categoryPair in categoryToDescriptors.OrderBy(x => x.Key))
            {
                var list = categoryPair.Value;

                // Exclude from the list modules that have been already imported
                var names = list.SelectMany(x => x.Names).Where(funcName =>
                    Builtins.TryGetValue(funcName, out var funcObj) && (!(funcObj is KalkModuleWithFunctions module) || !module.IsImported)
                ).OrderBy(x => x).ToList();

                if (names.Count > 0)
                {
                    WriteHighlightLine($"# {categoryPair.Key}");

                    WriteHighlightAligned("    - ", string.Join(", ", names));
                    WriteHighlightLine("");
                }
            }
        }

        /// <summary>
        /// Removes all user-defined variables and functions.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> x = 5; y = 2
        /// # x = 5; y = 2
        /// x = 5
        /// y = 2
        /// >>> list
        /// # Variables
        /// x = 5
        /// y = 2
        /// >>> reset
        /// >>> list
        /// # No variables
        /// ```
        /// </example>
        [KalkExport("reset", CategoryGeneral)]
        public new void Reset()
        {
            Variables.Clear();
        }

        /// <summary>
        /// Prints the version of kalk.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> version
        /// kalk 1.0.0 - Copyright (c) 2020 Alexandre Mutel
        /// ```
        /// </example>
        [KalkExport("version", CategoryGeneral)]
        public void ShowVersion()
        {
            var dateRange = "2020";
            var currentYear = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            if (!IsTesting && currentYear != dateRange)
            {
                dateRange = $"{dateRange}-{currentYear}";
            }
            var kalkName = IsOutputSupportHighlighting ? $"{ConsoleStyle.BrightRed}k{ConsoleStyle.BrightYellow}a{ConsoleStyle.BrightGreen}l{ConsoleStyle.BrightCyan}k{ConsoleStyle.Reset}" : "kalk";
            var text = $"{kalkName} {(IsTesting ? "1.0.0" : Version)} - Copyright (c) {dateRange} Alexandre Mutel";
            WriteHighlightLine(text, false);
        }

        /// <summary>
        /// Lists all user-defined variables and functions.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> x = 5; y = 2; f(x) = x + 5
        /// # x = 5; y = 2; f(x) = x + 5
        /// x = 5
        /// y = 2
        ///  f(x) = x + 5
        /// >>> list
        /// # Variables
        /// x = 5
        /// y = 2
        /// # Functions
        ///  f(x) = x + 5
        /// ```
        /// </example>
        [KalkExport("list", CategoryGeneral)]
        public void List()
        {
            // Highlight line per line
            if (Variables.Count == 0)
            {
                WriteHighlightLine("# No variables");
                return;
            }

            bool writeHeading = true;

            List<KeyValuePair<string, object>> functions = null;

            // Write variables
            foreach (var variableKeyPair in Variables)
            {
                if (variableKeyPair.Value is ScriptFunction function && !function.IsAnonymous)
                {
                    if (functions == null) functions = new List<KeyValuePair<string, object>>();
                    functions.Add(variableKeyPair);
                    continue;

                }
                if (writeHeading)
                {
                    WriteHighlightLine("# Variables");
                    writeHeading = false;
                }
                WriteHighlightVariableAndValueToConsole(variableKeyPair.Key, variableKeyPair.Value);
            }

            // Write functions
            if (functions != null)
            {
                WriteHighlightLine("# Functions");
                foreach (var variableKeyPair in functions)
                {
                    WriteHighlightVariableAndValueToConsole(variableKeyPair.Key, variableKeyPair.Value);
                }
            }
        }

        /// <summary>
        /// Deletes a user defined variable or function.
        /// </summary>
        /// <param name="variable">Name of the variable or function to delete.</param>
        /// <example>
        /// ```kalk
        /// >>> x = 5; y = 2
        /// # x = 5; y = 2
        /// x = 5
        /// y = 2
        /// >>> del x
        /// # Variable `x == 5` deleted.
        /// >>> list
        /// # Variables
        /// y = 2
        /// >>> del y
        /// # Variable `y == 2` deleted.
        /// >>> f(x) = x + 5
        /// # f(x) = x + 5
        /// f(x) = x + 5
        /// >>> list
        /// # Functions
        /// f(x) = x + 5
        /// >>> del f
        /// # Function `f(x) = x + 5` deleted.
        /// >>> list
        /// # No variables
        /// ```
        /// </example>
        [KalkExport("del", CategoryGeneral)]
        public void DeleteVariable(ScriptVariable variable)
        {
            if (variable == null) throw new ArgumentNullException(nameof(variable));
            
            if (((IDictionary<string, object>)Variables).TryGetValue(variable.Name, out var previousValue))
            {
                Variables.Remove(variable.Name);
                if (previousValue is ScriptFunction function && !function.IsAnonymous)
                {
                    WriteHighlightLine($"# Function `{function}` deleted.");
                }
                else
                {
                    WriteHighlightLine($"# Variable `{variable.Name} == {ObjectToString(previousValue, true)}` deleted.");
                }
            }
            else
            {
                WriteHighlightLine($"# Variable `{variable.Name}` not found");
            }
        }

        /// <summary>
        /// Exits kalk.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> exit
        /// ```
        /// </example>
        [KalkExport("exit", CategoryGeneral)]
        public void Exit()
        {
            HasExit = true;
            ReplExit();
        }

        /// <summary>
        /// Clears the history.
        /// </summary>
        public void ClearHistory()
        {
            HistoryList.Clear();
        }
        
        /// <summary>
        /// Parse !0 history command.
        /// </summary>
        private bool TryParseSpecialHistoryBangCommand(string text, out Template template)
        {
            template = null;
            var matchHistory = MatchHistoryRegex.Match(text);
            if (matchHistory.Success)
            {
                var historyCmd = $"history({matchHistory.Groups[1].Value})";
                template = Template.Parse(historyCmd, null, _parserOptions, _lexerOptions);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Displays the command history.
        /// </summary>
        /// <param name="line">An optional parameter that indicates:
        ///
        /// - if it is &gt;= 0, the index of the history command to re-run. (e.g `history 1` to re-run the command 1 in the history)
        /// - if it is &lt; 0, how many recent lines to display. (e.g `history -3` would display the last 3 lines in the history)
        /// </param>
        /// <example>
        /// ```kalk
        /// >>> 1 + 5
        /// # 1 + 5
        /// out = 6
        /// >>> abs(out)
        /// # abs(out)
        /// out = 6
        /// >>> history
        /// 0: 1 + 5
        /// 1: abs(out)
        /// ```
        /// </example>
        [KalkExport("history", CategoryGeneral)]
        public void History(object line = null)
        {
            // Always remove the history command (which is the command being executed
            HistoryList.RemoveAt(HistoryList.Count - 1);

            if (HistoryList.Count == 0)
            {
                WriteHighlightLine("# History empty");
                return;
            }

            if (line != null)
            {
                int lineNumber;
                try
                {
                    lineNumber = ToInt(new SourceSpan(), line);
                }
                catch
                {
                    throw new ArgumentException("Invalid history line number. Must be an integer.", nameof(line));
                }

                if (lineNumber >= 0 && lineNumber < HistoryList.Count)
                {
                    OnEnterNextText(HistoryList[lineNumber]);
                }
                else if (lineNumber < 0)
                {
                    lineNumber = HistoryList.Count + lineNumber;
                    if (lineNumber < 0) lineNumber = 0;
                    for (int i = lineNumber; i < HistoryList.Count; i++)
                    {
                        WriteHighlightLine($"{i}: {HistoryList[i]}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid history index. Check with `history` command.", nameof(line));
                }
            }
            else
            {
                for (int i = 0; i < HistoryList.Count; i++)
                {
                    WriteHighlightLine($"{i}: {HistoryList[i]}");
                }
            }
        }

        /// <summary>
        /// Evaluates dynamically the input string as an expression.
        /// </summary>
        /// <param name="text">The text of the expression to evaluate.</param>
        /// <param name="output">An optional parameter to output intermediate results of nested expressions. Default is `false`.</param>
        /// <returns>The result of the evaluation.</returns>
        /// <example>
        /// ```kalk
        /// >>> eval "1+5"
        /// # eval("1+5")
        /// out = 6
        /// >>> eval "eval '1+5'"
        /// # eval("eval '1+5'")
        /// out = 6
        /// ```
        /// </example>
        [KalkExport("eval", CategoryGeneral)]
        public object EvaluateText(string text, bool output = false)
        {
            return EvaluateTextImpl(text, null, output);
        }

        /// <summary>
        /// Loads and evaluates the specified script from a file location on a disk.
        /// </summary>
        /// <param name="path">The file location of the script to load and evaluate.</param>
        /// <param name="output">An optional parameter to output intermediate results of nested expressions. Default is `false`.</param>
        /// <returns>The result of the evaluation.</returns>
        /// <example>
        /// ```kalk
        /// >>> import Files
        /// # 14 functions successfully imported from module `Files`.
        /// >>> save_text("x = 1\ny = 2\nx + y", "test.kalk")
        /// >>> load "test.kalk"
        /// # load("test.kalk")
        /// x = 1
        /// y = 2
        /// out = 3
        /// ```
        /// </example>
        [KalkExport("load", CategoryGeneral)]
        public object LoadFile(string path, bool output = false)
        {
            var fullPath = FileModule.AssertReadFile(path);
            var text = FileService.FileReadAllText(fullPath);
            return EvaluateTextImpl(text, path, output);
        }

        /// <summary>
        /// Clears the screen (by default) or the history (e.g clear history).
        /// </summary>
        /// <param name="what">An optional argument specifying what to clear. Can be of the following value:
        /// * screen: to clear the screen (default if not passed)
        /// * history: to clear the history
        /// * shortcuts: to clear all shortcuts defined. WARNING, clearing shortcuts is removing all common shortcuts, including basic navigation and edition mode!
        /// </param>
        /// <example>
        /// ```kalk
        /// >>> 1 + 2
        /// # 1 + 2
        /// out = 3
        /// >>> history
        /// 0: 1 + 2
        /// >>> clear history
        /// >>> history
        /// # History empty
        /// ```
        /// </example>
        [KalkExport("clear", CategoryGeneral)]
        public void Clear(ScriptExpression what = null)
        {
            if (what != null)
            {
                if (what is ScriptVariableGlobal variable)
                {
                    switch (variable.Name)
                    {
                        case "history":
                            ClearHistory();
                            return;
                        case "shortcuts":
                            Shortcuts.Clear();
                            return;
                        case "screen": goto clearScreen;
                    }
                }
                throw new ArgumentException("Unexpected argument. `clear` command accepts only `screen` or `history` or `shortcuts`.");
            }

            clearScreen:

            OnClearScreen?.Invoke();
        }

        /// <summary>
        /// Clears the screen.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> cls
        /// ```
        /// </example>
        [KalkExport("cls", CategoryGeneral)]
        public void Cls()
        {
            Clear(null);
        }

        /// <summary>
        /// Returns the last evaluated result.
        /// </summary>
        /// <returns>The last evaluated result as an object.</returns>
        /// <example>
        /// ```kalk
        /// >>> 1 + 2
        /// # 1 + 2
        /// out = 3
        /// >>> out + 1
        /// # out + 1
        /// out = 4
        /// ```
        /// </example>
        [KalkExport("out", CategoryGeneral)]
        public object Last()
        {
            return _lastResult;
        }

        /// <summary>
        /// Copies the last evaluated content to the clipboard.
        ///
        /// This is equivalent to `out |> clipboard`.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> 1 + 2
        /// # 1 + 2
        /// out = 3
        /// >>> out2clipboard
        /// >>> clipboard
        /// # clipboard
        /// out = "3"
        /// ```
        /// </example>
        [KalkExport("out2clipboard", CategoryGeneral)]
        public void LastToClipboard()
        {
            Clipboard(Last());
        }

        /// <summary>
        /// Creates a keyboard shortcut associated with an expression or remove a keyboard shortcut.
        /// </summary>
        /// <param name="name">Name of the shortcut</param>
        /// <param name="shortcuts">A collection of pair of shortcut description (e.g `ctrl+a`) and associated shortcut expression (e.g `1 + 2`).</param>
        /// <remarks>See the command `shortcuts` to list the shortcuts currently defined. By default several shortcuts for common mathematical symbols are defined (e.g for the symbol pi: `shortcut(pi, "ctrl+g p", "Π", "ctrl+g p", "π")`).
        ///
        /// If no shortcuts are associated to the name, the existing shortcuts for this name will be removed.
        /// </remarks>
        /// <example>
        /// ```kalk
        /// >>> # Creates a shortcut that will print 3 when pressing ctrl+R.
        /// >>> shortcut(myshortcut, "ctrl+g", 1 + 2)
        /// >>> # Overrides the previous shortcut that will print the text
        /// >>> # `kalk` when pressing ctrl+g.
        /// >>> shortcut(myshortcut, "ctrl+g", "kalk")
        /// >>> # Overrides the previous shortcut that will print the text
        /// >>> # `kalk` when pressing ctrl+g or the text `kalk2` when pressing
        /// >>> # ctrl+e and r key.
        /// >>> shortcut(myshortcut, "ctrl+g", "kalk", "ctrl+e r", "kalk2")
        /// >>> # Remove the previous defined shortcuts
        /// >>> shortcut(myshortcut)
        /// ```
        /// </example>
        [KalkExport("shortcut", CategoryGeneral)]
        public void Shortcut(ScriptVariable name, params ScriptExpression[] shortcuts)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (shortcuts.Length == 0)
            {
                Shortcuts.RemoveShortcut(name.Name);
            }
            else
            {

                if ((shortcuts.Length % 2) != 0)
                {
                    throw new ArgumentException("Invalid arguments. Missing a symbol associated to a key.", nameof(shortcuts));
                }

                var keyList = new List<KalkShortcutKeySequence>();
                for (int i = 0; i < shortcuts.Length; i += 2)
                {
                    var keyExpr = shortcuts[i];
                    var valueExpr = shortcuts[i + 1];
                    keyList.AddRange(KalkShortcutKeySequence.Parse(keyExpr, valueExpr));
                }

                var shortcut = new KalkShortcut(name.Name, keyList, !_registerAsSystem);
                Shortcuts.SetSymbolShortcut(shortcut);
            }
        }

        /// <summary>
        /// Creates an alias between variable names.
        /// </summary>
        /// <param name="name">Name of the original alias name.</param>
        /// <param name="aliases">Variable names that are all equivalent to the alias name.</param>
        /// <remarks>See the command `aliases` to list the aliases currently defined. Several aliases are defined by default for common mathematical symbols (e.g `alias(pi, Π, π)`).</remarks>
        /// <example>
        /// ```kalk
        /// >>> alias(var1, var2, var3)
        /// >>> var1 = 2
        /// # var1 = 2
        /// var1 = 2
        /// >>> var2
        /// # var2
        /// out = 2
        /// >>> var3
        /// # var3
        /// out = 2
        /// >>> list
        /// # Variables
        /// var1 = 2
        /// >>> var2 = 1
        /// # var2 = 1
        /// var2 = 1
        /// >>> list
        /// # Variables
        /// var1 = 1
        /// ```kalk
        /// </example>
        [KalkExport("alias", CategoryGeneral)]
        public void Alias(ScriptVariable name, params ScriptVariable[] aliases)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (aliases.Length == 0)
            {
                throw new ArgumentException("Invalid arguments. Missing a key associated to a symbol.", nameof(aliases));
            }

            var names = new List<string>();
            for (int i = 0; i < aliases.Length; i++)
            {
                names.Add(aliases[i].Name);
            }

            var alias = new KalkAlias(name.Name, names, !_registerAsSystem);
            Aliases.AddAlias(alias);
        }

        /// <summary>
        /// Gets the kind of a value.
        /// </summary>
        /// <param name="value">A value to inspect the kind</param>
        /// <example>
        /// ```kalk
        /// >>> kind 1
        /// # kind(1)
        /// out = "int"
        /// >>> kind "a"
        /// # kind("a")
        /// out = "string"
        /// >>> kind byte (1)
        /// # kind(byte(1))
        /// out = "byte"
        /// >>> kind []
        /// # kind([])
        /// out = "array"
        /// >>> kind {}
        /// # kind({})
        /// out = "object"
        /// ```
        /// </example>
        [KalkExport("kind", CategoryGeneral)]
        public string Kind(object value)
        {
            if (value == null) return "null";
            return GetTypeName(value);
        }

        private object EvaluateTextImpl(string text, string path, bool output = false, bool formatted = false)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            _evalDepth++;
            var shouldOutput = true;

            if (!(CurrentNode?.Parent is ScriptExpressionStatement))
            {
                shouldOutput = _evalDepth <= 1 || output;
            }
            var previous = EnableEngineOutput;
            var previousOutput = EnableOutput;
            var previousFormatting = _formatting;
            try
            {
                EnableEngineOutput = shouldOutput;
                EnableOutput = formatted;
                _formatting = formatted;
                var evaluate = Parse(text, path, false, formatted);
                if (evaluate.HasErrors)
                    throw new ArgumentException("This script has errors. Messages:\n" + string.Join("\n", evaluate.Messages), path != null ? nameof(path) : nameof(text));

                if (formatted)
                {
                    var scriptOutput = new StringBuilderOutput();
                    PushOutput(scriptOutput);
                    try
                    {
                        Evaluate(evaluate.Page);
                    }
                    finally
                    {
                        PopOutput();
                    }
                    return scriptOutput.Builder.ToString();
                }
                else
                {
                    return Evaluate(evaluate.Page);
                }
            }
            finally
            {
                _evalDepth--;
                EnableOutput = previousOutput;
                EnableEngineOutput = previous;
                _formatting = previousFormatting;
            }
        }

        private object EvaluateExpression(ScriptExpression expression, bool noOutput = false)
        {
            var previousEngineOutput = EnableEngineOutput;
            var previousOutput = EnableOutput;
            try
            {
                EnableEngineOutput = false;
                EnableOutput = false;
                if (noOutput)
                {
                    var scriptOutput = new StringBuilderOutput();
                    PushOutput(scriptOutput);
                    try
                    {
                        return Evaluate(expression);
                    }
                    finally
                    {
                        PopOutput();
                    }
                }
                else
                {
                    return Evaluate(expression);
                }
            }
            finally
            {
                EnableOutput = previousOutput;
                EnableEngineOutput = previousEngineOutput;
            }
        }

        private void WriteHelpForDescriptor(KalkDescriptor descriptor)
        {
            var parentless = descriptor.IsCommand && descriptor.Params.Count <= 1;
            var args = string.Join(", ", descriptor.Params.Select(x => x.IsOptional ? $"{x.Name}?" : x.Name));

            var syntax = string.Join("/", descriptor.Names);

            if (!string.IsNullOrEmpty(args))
            {
                syntax += parentless ? $" {args}" : $"({args})";
            }

            WriteHighlightLine($"# {syntax}");
            WriteHighlightLine($"#");
            if (string.IsNullOrEmpty(descriptor.Description))
            {
                WriteHighlightLine($"#   No documentation available.");
            }
            else
            {
                WriteHighlightAligned($"#   ", descriptor.Description);
                if (descriptor.Params.Count > 0)
                {
                    WriteHighlightLine($"#");
                    WriteHighlightLine($"# Parameters");
                    foreach (var par in descriptor.Params)
                    {
                        WriteHighlightAligned($"#   - {par.Name}: ", par.Description);
                    }
                }
                if (!string.IsNullOrEmpty(descriptor.Returns))
                {
                    WriteHighlightLine($"#");
                    WriteHighlightLine($"# Returns");
                    WriteHighlightAligned($"#   ", descriptor.Returns);
                }
                if (!string.IsNullOrEmpty(descriptor.Remarks))
                {
                    WriteHighlightLine($"#");
                    WriteHighlightLine($"# Remarks");
                    WriteHighlightAligned($"#   ", descriptor.Remarks);
                }
                if (!string.IsNullOrEmpty(descriptor.Example))
                {
                    WriteHighlightLine($"#");
                    WriteHighlightLine($"# Example");
                    WriteHighlightAligned($".   ", descriptor.Example, ".   ");
                }
            }
        }


    }
}