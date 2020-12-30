using System;
using System.Collections;
using System.IO;
using System.Text;
using Kalk.Core.Helpers;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Modules providing file related functions.
    /// </summary>
    [KalkExportModule(ModuleName)]
    public partial class FileModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "Files";

        public const string CategoryMiscFile = "Misc File Functions";

        public FileModule() : base(ModuleName)
        {
            RegisterFunctionsAuto();
        }

        /// <summary>
        /// Gets the current directory.
        /// </summary>
        /// <returns>The current directory.</returns>
        /// <example>
        /// ```kalk
        /// >>> pwd
        /// # pwd
        /// out = "/code/kalk/tests"
        /// ```
        /// </example>
        [KalkExport("pwd", CategoryMiscFile)]
        public string CurrentDirectory()
        {
            return Environment.CurrentDirectory;
        }

        /// <summary>
        /// Changes the current directory to the specified path.
        /// </summary>
        /// <param name="path">Path to the directory to change.</param>
        /// <returns>The current directory or throws an exception if the directory does not exists</returns>
        /// <example>
        /// ```kalk
        /// >>> cd
        /// # cd
        /// out = "/code/kalk/tests"
        /// >>> mkdir "testdir"
        /// >>> cd "testdir"
        /// # cd("testdir")
        /// out = "/code/kalk/tests/testdir"
        /// >>> cd ".."
        /// # cd("..")
        /// out = "/code/kalk/tests"
        /// >>> rmdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = false
        /// ```
        /// </example>
        [KalkExport("cd", CategoryMiscFile)]
        public string ChangeDirectory(string path = null)
        {
            if (path != null)
            {
                if (!DirectoryExists(path)) throw new ArgumentException($"The folder `{path}` does not exists", nameof(path));
                Environment.CurrentDirectory = Path.Combine(Environment.CurrentDirectory, path);
            }

            return CurrentDirectory();
        }

        /// <summary>
        /// Checks if the specified file path exists on the disk.
        /// </summary>
        /// <param name="path">Path to a file.</param>
        /// <returns>`true` if the specified file path exists on the disk.</returns>
        /// <example>
        /// ```kalk
        /// >>> rm "test.txt"
        /// >>> file_exists "test.txt"
        /// # file_exists("test.txt")
        /// out = false
        /// >>> save_text("content", "test.txt")
        /// >>> file_exists "test.txt"
        /// # file_exists("test.txt")
        /// out = true
        /// ```
        /// </example>
        [KalkExport("file_exists", CategoryMiscFile)]
        public KalkBool FileExists(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return Engine.FileService.FileExists(Path.Combine(Environment.CurrentDirectory, path));
        }

        /// <summary>
        /// Checks if the specified directory path exists on the disk.
        /// </summary>
        /// <param name="path">Path to a directory.</param>
        /// <returns>`true` if the specified directory path exists on the disk.</returns>
        /// <example>
        /// ```kalk
        /// >>> mkdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = true
        /// >>> rmdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = false
        /// ```
        /// </example>
        [KalkExport("dir_exists", CategoryMiscFile)]
        public KalkBool DirectoryExists(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return Engine.FileService.DirectoryExists(Path.Combine(Environment.CurrentDirectory, path));
        }

        /// <summary>
        /// List files and directories from the specified path or the current directory.
        /// </summary>
        /// <param name="path">The specified directory or the current directory if not specified.</param>
        /// <param name="recursive">A boolean to perform a recursive list. Default is `false`.</param>
        /// <returns>An enumeration of the files and directories.</returns>
        /// <example>
        /// ```kalk
        /// >>> mkdir "testdir"
        /// >>> cd "testdir"
        /// # cd("testdir")
        /// out = "/code/kalk/tests/testdir"
        /// >>> mkdir "subdir"
        /// >>> save_text("content", "file.txt")
        /// >>> dir "."
        /// # dir(".")
        /// out = ["./file.txt", "./subdir"]
        /// >>> save_text("content", "subdir/file2.txt")
        /// >>> dir(".", true)
        /// # dir(".", true)
        /// out = ["./file.txt", "./subdir", "./subdir/file2.txt"]
        /// >>> cd ".."
        /// # cd("..")
        /// out = "/code/kalk/tests"
        /// >>> rmdir("testdir", true)
        /// ```
        /// </example>
        [KalkExport("dir", CategoryMiscFile)]
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
            if (!Engine.FileService.DirectoryExists(fullDir)) throw new ArgumentException($"Directory `{path}` not found.");

            if (string.IsNullOrEmpty(path))
            {
                path = ".";
            }
            return new ScriptRange(Engine.FileService.EnumerateFileSystemEntries(path, search, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        }

        /// <summary>
        /// Deletes a file from the specified path.
        /// </summary>
        /// <param name="path">Path to the file to delete.</param>
        /// <example>
        /// ```kalk
        /// >>> rm "test.txt"
        /// >>> file_exists "test.txt"
        /// # file_exists("test.txt")
        /// out = false
        /// >>> save_text("content", "test.txt")
        /// >>> file_exists "test.txt"
        /// # file_exists("test.txt")
        /// out = true
        /// ```
        /// </example>
        [KalkExport("rm", CategoryMiscFile)]
        public void RemoveFile(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (FileExists(path))
            {
                Engine.FileService.FileDelete(Path.Combine(Environment.CurrentDirectory, path));
            }
        }

        /// <summary>
        /// Creates a directory at the specified path.
        /// </summary>
        /// <param name="path">Path of the directory to create.</param>
        /// <example>
        /// ```kalk
        /// >>> mkdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = true
        /// >>> rmdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = false
        /// ```
        /// </example>
        [KalkExport("mkdir", CategoryMiscFile)]
        public void CreateDirectory(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (DirectoryExists(path)) return;
            Engine.FileService.DirectoryCreate(Path.Combine(Environment.CurrentDirectory, path));
        }

        /// <summary>
        /// Deletes the directory at the specified path.
        /// </summary>
        /// <param name="path">Path to the directory to delete.</param>
        /// <example>
        /// ```kalk
        /// >>> mkdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = true
        /// >>> rmdir "testdir"
        /// >>> dir_exists "testdir"
        /// # dir_exists("testdir")
        /// out = false
        /// ```
        /// </example>
        [KalkExport("rmdir", CategoryMiscFile)]
        public void RemoveDirectory(string path, bool recursive = true)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (DirectoryExists(path))
            {
                Engine.FileService.DirectoryDelete(Path.Combine(Environment.CurrentDirectory, path), recursive);
            }
        }

        /// <summary>
        /// Loads the specified file as text.
        /// </summary>
        /// <param name="path">Path to a file to load as text.</param>
        /// <param name="encoding">The encoding of the file. Default is "utf-8"</param>
        /// <returns>The file loaded as a string.</returns>
        /// <example>
        /// ```kalk
        /// >>> load_text "test.csv"
        /// # load_text("test.csv")
        /// out = "a,b,c\n1,2,3\n4,5,6"
        /// ```
        /// </example>
        [KalkExport("load_text", CategoryMiscFile)]
        public string LoadText(string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertReadFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = Engine.FileService.FileOpen(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return new StreamReader(stream, encoder).ReadToEnd();
        }

        /// <summary>
        /// Loads the specified file as binary.
        /// </summary>
        /// <param name="path">Path to a file to load as binary.</param>
        /// <returns>The file loaded as a a byte buffer.</returns>
        /// <example>
        /// ```kalk
        /// >>> load_bytes "test.csv"
        /// # load_bytes("test.csv")
        /// out = bytebuffer([97, 44, 98, 44, 99, 10, 49, 44, 50, 44, 51, 10, 52, 44, 53, 44, 54])
        /// >>> ascii out
        /// # ascii(out)
        /// out = "a,b,c\n1,2,3\n4,5,6"
        /// ```
        /// </example>
        [KalkExport("load_bytes", CategoryMiscFile)]
        public KalkNativeBuffer LoadBytes(string path)
        {
            var fullPath = AssertReadFile(path);
            using var stream = Engine.FileService.FileOpen(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var buffer = new KalkNativeBuffer((int)stream.Length);
            stream.Read(buffer.AsSpan());
            return buffer;
        }

        /// <summary>
        /// Load each lines from the specified file path.
        /// </summary>
        /// <param name="path">Path to a file to load lines from.</param>
        /// <param name="encoding">The encoding of the file. Default is "utf-8"</param>
        /// <returns>An enumeration on the lines.</returns>
        /// <example>
        /// ```kalk
        /// >>> load_lines "test.csv"
        /// # load_lines("test.csv")
        /// out = ["a,b,c", "1,2,3", "4,5,6"]
        /// ```
        /// </example>
        [KalkExport("load_lines", CategoryMiscFile)]
        public ScriptRange LoadLines(string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertReadFile(path);
            var encoder = GetEncoding(encoding);
            return new ScriptRange(new LineReader(() =>
            {
                var stream = Engine.FileService.FileOpen(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return new StreamReader(stream, encoder);
            }));
        }

        /// <summary>
        /// Saves an array of data as string to the specified files.
        /// </summary>
        /// <param name="lines">An array of data.</param>
        /// <param name="path">Path to the file to save the lines to.</param>
        /// <param name="encoding">The encoding of the file. Default is "utf-8"</param>
        /// <example>
        /// ```kalk
        /// >>> save_lines(1..10, "lines.txt")
        /// >>> load_lines("lines.txt")
        /// # load_lines("lines.txt")
        /// out = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"]
        /// ```
        /// </example>
        [KalkExport("save_lines", CategoryMiscFile)]
        public object SaveLines(IEnumerable lines, string path, string encoding = KalkConfig.DefaultEncoding)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            var fullPath = AssertWriteFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = Engine.FileService.FileOpen(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            using var writer = new StreamWriter(stream, encoder);
            foreach (var lineObj in lines)
            {
                var line = Engine.ObjectToString(lineObj);
                writer.WriteLine(line);
            }
            // return object to allow this function to be used in a pipe
            return null;
        }

        /// <summary>
        /// Saves a text to the specified file path.
        /// </summary>
        /// <param name="text">The text to save.</param>
        /// <param name="path">Path to the file to save the text to.</param>
        /// <param name="encoding">The encoding of the file. Default is "utf-8"</param>
        /// <example>
        /// ```kalk
        /// >>> save_text("Hello World!", "test.txt")
        /// >>> load_text("test.txt")
        /// # load_text("test.txt")
        /// out = "Hello World!"
        /// ```
        /// </example>
        [KalkExport("save_text", CategoryMiscFile)]
        public object SaveText(string text, string path, string encoding = KalkConfig.DefaultEncoding)
        {
            var fullPath = AssertWriteFile(path);
            var encoder = GetEncoding(encoding);
            using var stream = Engine.FileService.FileOpen(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            using var writer = new StreamWriter(stream, encoder);
            text ??= string.Empty;
            writer.Write(text);
            // return object to allow this function to be used in a pipe
            return null;
        }

        /// <summary>
        /// Saves a byte buffer to the specified file path.
        /// </summary>
        /// <param name="data">The data to save.</param>
        /// <param name="path">Path to the file to save the data to.</param>
        /// <example>
        /// ```kalk
        /// >>> utf8("Hello World!")
        /// # utf8("Hello World!")
        /// out = bytebuffer([72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33])
        /// >>> save_bytes(out, "test.bin")
        /// >>> load_bytes("test.bin")
        /// # load_bytes("test.bin")
        /// out = bytebuffer([72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33])
        /// >>> utf8(out)
        /// # utf8(out)
        /// out = "Hello World!"
        /// ```
        /// </example>
        [KalkExport("save_bytes", CategoryMiscFile)]
        public object SaveBytes(IEnumerable data, string path)
        {
            var fullPath = AssertWriteFile(path);
            using var stream = Engine.FileService.FileOpen(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

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


        public string AssertWriteFile(string path)
        {
            return AssertFile(path, true);
        }

        public string AssertReadFile(string path)
        {
            return AssertFile(path, false);
        }

        private string AssertFile(string path, bool toWrite)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            var fullPath = Path.Combine(Environment.CurrentDirectory, path);
            if (toWrite)
            {
                var directory = Path.GetDirectoryName(fullPath);
                if (!Engine.FileService.DirectoryExists(directory))
                {
                    try
                    {
                        Engine.FileService.DirectoryCreate(directory);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException($"Cannot write to file {path}. Cannot create directory {directory}. Reason: {ex.Message}");
                    }
                }
            }
            else
            {
                if (!Engine.FileService.FileExists(fullPath)) throw new ArgumentException($"File {path} was not found.");
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