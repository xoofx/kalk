using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Kalk.Releaser
{
    public class DotNetProgramException : Exception
    {
        public DotNetProgramException(string? message) : base(message)
        {
        }

        public DotNetProgramException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    [DebuggerDisplay("{" + nameof(ToDebuggerDisplay) + "(),nq}")]
    public class DotNetProgram
    {
        public DotNetProgram(string command)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
            Arguments = new List<string>();
            Properties = new Dictionary<string, object>();
            WorkingDirectory = Environment.CurrentDirectory;
        }

        public string Command { get; }

        public List<string> Arguments { get; }

        public Dictionary<string, object> Properties { get; }

        public string WorkingDirectory { get; set; }

        public string Run()
        {
            return Run(Command, Arguments, Properties, WorkingDirectory);
        }

        private string ToDebuggerDisplay()
        {
            return $"dotnet {GetFullArguments(Command, Arguments, Properties)}";
        }

        private static string GetFullArguments(string command, IEnumerable<string> arguments, Dictionary<string, object> properties)
        {
            var argsBuilder = new StringBuilder($"{command}");
            // Add all arguments
            foreach (var arg in arguments)
            {
                argsBuilder.Append($" {arg}");
            }
            // Pass all our user properties to msbuild
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    argsBuilder.Append($" -p:{property.Key}={EscapePath(GetPropertyValueAsString(property.Value))}");
                }
            }

            return argsBuilder.ToString();
        }


        private static string GetPropertyValueAsString(object value)
        {
            if (value is bool b) return b ? "true" : "false";
            if (value is IFormattable formattable) return formattable.ToString(null, CultureInfo.InvariantCulture);
            return value.ToString();
        }

        private static string Run(string command, IEnumerable<string> args, Dictionary<string, object> properties = null, string workingDirectory = null)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (args == null) throw new ArgumentNullException(nameof(args));
            bool success = false;
            string errorMessage = null;

            workingDirectory ??= Environment.CurrentDirectory;

            Exception innerException = null;
            string fullArgs = null;
            var output = new StringBuilder();
            try
            {
                fullArgs = GetFullArguments(command, args, properties);

                var startInfo = new ProcessStartInfo("dotnet", fullArgs)
                {
                    WorkingDirectory = workingDirectory,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                var process = new Process() { StartInfo = startInfo };

                process.OutputDataReceived += (_, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        output.AppendLine(e.Data);
                    }
                };

                process.ErrorDataReceived += (_, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        output.AppendLine(e.Data);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    errorMessage = $"Error while running: dotnet {fullArgs}. Reason:\n{output}";
                }
                else
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Unexpected exceptions while running: dotnet {fullArgs}. Reason:\n{ex}";
                innerException = ex;
            }

            if (!success)
            {
                if (innerException != null)
                    throw new DotNetProgramException(errorMessage, innerException);
                throw new DotNetProgramException(errorMessage);
            }

            return output.ToString();
        }

        private static readonly Regex MatchWhitespace = new Regex(@"[\s\:]");

        public static string EscapePath(string path)
        {
            path = path.Replace("\"", "\\\"");
            return MatchWhitespace.IsMatch(path) ? $"\"{path}\"" : path;
        }
    }
}