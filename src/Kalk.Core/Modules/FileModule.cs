using System;
using System.Collections;
using System.IO;
using System.Text;
using Kalk.Core.Helpers;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    public class FileModule : KalkModule
    {
        private const string CategoryMiscFile = "Misc File Functions";

        public FileModule()
        {
            RegisterCustomFunction("file_exists", DelegateCustomFunction.CreateFunc<string, bool>(FileExists), CategoryMiscFile);
            RegisterCustomFunction("dir_exists", DelegateCustomFunction.CreateFunc<string, bool>(DirectoryExists), CategoryMiscFile);
            RegisterCustomFunction("dir", DelegateCustomFunction.CreateFunc<string, bool, IEnumerable>(DirectoryListing), CategoryMiscFile);
            RegisterCustomFunction("load_text", DelegateCustomFunction.CreateFunc<string, string, string>(LoadText), CategoryMiscFile);
            RegisterCustomFunction("load_bytes", DelegateCustomFunction.CreateFunc<string, ScriptArray<byte>>(LoadBytes), CategoryMiscFile);
            RegisterCustomFunction("load_lines", DelegateCustomFunction.CreateFunc<string, string, ScriptRange>(LoadLines), CategoryMiscFile);
            RegisterCustomFunction("load_csv", DelegateCustomFunction.CreateFunc<string, bool, ScriptRange>(LoadCsv), CategoryMiscFile);
            RegisterCustomFunction("save_text", DelegateCustomFunction.CreateFunc<string, string, string, object>(SaveText), CategoryMiscFile);
            RegisterCustomFunction("save_bytes", DelegateCustomFunction.CreateFunc<IEnumerable, string, object>(SaveBytes), CategoryMiscFile);
            RegisterCustomFunction("save_lines", DelegateCustomFunction.CreateFunc<IEnumerable, string, string, object>(SaveLines), CategoryMiscFile);
        }

        [KalkDoc("file_exists")]
        public bool FileExists(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return File.Exists(Path.Combine(Environment.CurrentDirectory, path));
        }

        [KalkDoc("directory_exists")]
        public bool DirectoryExists(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return Directory.Exists(Path.Combine(Environment.CurrentDirectory, path));
        }

        [KalkDoc("dir")]
        public IEnumerable DirectoryListing(string path = null, bool recursive = false)
        {
            string search = "*";
            if (!string.IsNullOrEmpty(path))
            {
                var wildcardIndex = path.IndexOf('*', StringComparison.OrdinalIgnoreCase);
                if (wildcardIndex >= 0)
                {
                    search = path.Substring(wildcardIndex);
                    path = path.Substring(0, wildcardIndex);
                }
            }

            var fullDir = string.IsNullOrEmpty(path) ? Environment.CurrentDirectory : Path.Combine(Environment.CurrentDirectory, path);
            if (!Directory.Exists(fullDir)) throw new ArgumentException($"Directory `{path}` not found.");

            if (string.IsNullOrEmpty(path))
            {
                path = ".";
            }
            return new ScriptRange(Directory.EnumerateFileSystemEntries(path, search, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        }

        [KalkDoc("load_text")]
        public string LoadText(string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertReadFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return new StreamReader(stream, encoder).ReadToEnd();
        }

        [KalkDoc("load_bytes")]
        public ScriptArray<byte> LoadBytes(string path)
        {
            var fullPath = AssertReadFile(path);
            using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return new ScriptArray<byte>(buffer);
        }

        [KalkDoc("load_lines")]
        public ScriptRange LoadLines(string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertReadFile(path);
            var encoder = GetEncoding(encoding);
            return new ScriptRange(new LineReader(() =>
            {
                var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return new StreamReader(stream, encoder);
            }));
        }

        [KalkDoc("save_lines")]
        public object SaveLines(IEnumerable lines, string path, string encoding = KalkConfig.DefaultEncoding)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            var fullPath = AssertWriteFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            using var writer = new StreamWriter(stream, encoder);
            foreach (var lineObj in lines)
            {
                var line = Engine.ObjectToString(lineObj);
                writer.WriteLine(line);
            }
            // return object to allow this function to be used in a pipe
            return null;
        }

        [KalkDoc("save_text")]
        public object SaveText(string text, string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertWriteFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            using var writer = new StreamWriter(stream, encoder);
            text ??= string.Empty;
            writer.Write(text);
            // return object to allow this function to be used in a pipe
            return null;
        }

        [KalkDoc("save_bytes")]
        public object SaveBytes(IEnumerable data, string path)
        {
            var fullPath = AssertWriteFile(path);
            using var stream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

            switch (data)
            {
                case ScriptRange range when range.Values is byte[] byteBuffer:
                    stream.Write(byteBuffer, 0, byteBuffer.Length);
                    break;
                case ScriptArray<byte> byteArray:
                {
                    for (int i = 0; i < byteArray.Count; i++)
                    {
                        stream.WriteByte(byteArray[i]);
                    }

                    break;
                }
                default:
                {
                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            var b = Engine.ToObject<byte>(0, item);
                            stream.WriteByte(b);
                        }
                    }
                    break;
                }
            }
            // return object to allow this function to be used in a pipe
            return null;
        }

        [KalkDoc("load_csv")]
        public ScriptRange LoadCsv(string path, bool headers = true)
        {
            var fullPath = AssertReadFile(path);
            return new ScriptRange(new KalkCsvReader(() =>
            {
                var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return new StreamReader(stream);
            }, headers));
        }

        public static string AssertWriteFile(string path)
        {
            return AssertFile(path, true);
        }

        public static string AssertReadFile(string path)
        {
            return AssertFile(path, false);
        }

        private static string AssertFile(string path, bool toWrite)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            var fullPath = Path.Combine(Environment.CurrentDirectory, path);
            if (toWrite)
            {
                var directory = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directory))
                {
                    try
                    {
                        Directory.CreateDirectory(directory);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException($"Cannot write to file {path}. Cannot create directory {directory}. Reason: {ex.Message}");
                    }
                }
            }
            else
            {
                if (!File.Exists(fullPath)) throw new ArgumentException($"File {path} was not found.");
            }
            return fullPath;
        }

        private static Encoding GetEncoding(string encoding)
        {
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            try
            {
                switch (encoding)
                {
                    case "utf-8": return Encoding.UTF8;
                    case "utf-32": return Encoding.UTF32;
                    case "ascii": return Encoding.ASCII;
                    default:
                        return Encoding.GetEncoding(encoding);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid encoding name `{encoding}`. Reason: {ex.Message}");
            }
        }







    }
}