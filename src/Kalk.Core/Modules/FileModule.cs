using System;
using System.Collections;
using System.IO;
using System.Text;
using Kalk.Core.Helpers;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    public partial class FileModule : KalkModuleWithFunctions
    {
        public const string CategoryMiscFile = "Misc File Functions";

        public FileModule() : base("Files")
        {
            RegisterFunctionsAuto();
        }

        [KalkDoc("file_exists", CategoryMiscFile)]
        public KalkBool FileExists(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return File.Exists(Path.Combine(Environment.CurrentDirectory, path));
        }

        [KalkDoc("directory_exists", CategoryMiscFile)]
        public KalkBool DirectoryExists(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return Directory.Exists(Path.Combine(Environment.CurrentDirectory, path));
        }

        [KalkDoc("dir", CategoryMiscFile)]
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

        [KalkDoc("load_text", CategoryMiscFile)]
        public string LoadText(string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertReadFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return new StreamReader(stream, encoder).ReadToEnd();
        }

        [KalkDoc("load_bytes", CategoryMiscFile)]
        public KalkNativeBuffer LoadBytes(string path)
        {
            var fullPath = AssertReadFile(path);
            using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var buffer = new KalkNativeBuffer((int)stream.Length);
            stream.Read(buffer.AsSpan());
            return buffer;
        }

        [KalkDoc("load_lines", CategoryMiscFile)]
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

        [KalkDoc("save_lines", CategoryMiscFile)]
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

        [KalkDoc("save_text", CategoryMiscFile)]
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

        [KalkDoc("save_bytes", CategoryMiscFile)]
        public object SaveBytes(IEnumerable data, string path)
        {
            var fullPath = AssertWriteFile(path);
            using var stream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

            switch (data)
            {
                case ScriptRange range when range.Values is byte[] byteBuffer:
                    stream.Write(byteBuffer, 0, byteBuffer.Length);
                    break;
                case KalkNativeBuffer byteBuffer:
                {
                    stream.Write(byteBuffer.AsSpan());
                    break;
                }
                case ScriptArray<byte> scriptByteArray:
                    for (int i = 0; i < scriptByteArray.Count; i++)
                    {
                        stream.WriteByte(scriptByteArray[i]);
                    }
                    break;
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