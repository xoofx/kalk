using System.Collections.Generic;
using System.IO;

namespace Kalk.Core
{
    /// <summary>
    /// Simple file abstraction to mitigate UWP access issues.
    /// </summary>
    public interface IFileService
    {
        Stream FileOpen(string path, FileMode mode, FileAccess access, FileShare share);

        void DirectoryCreate(string path);

        IEnumerable<string> EnumerateFileSystemEntries(
            string path,
            string searchPattern,
            SearchOption searchOption);

        void DirectoryDelete(string path, bool recursive);

        string FileReadAllText(string path);

        void FileDelete(string path);

        bool FileExists(string path);

        bool DirectoryExists(string path);
    }

    /// <summary>
    /// Default implementation of file service using .NET API directly (not working on UWP)
    /// </summary>
    class DefaultFileService : IFileService
    {
        public Stream FileOpen(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(path, mode, access, share);
        }

        public void DirectoryCreate(string path)
        {
            Directory.CreateDirectory(path);
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);
        }

        public void DirectoryDelete(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }

        public string FileReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void FileDelete(string path)
        {
            File.Delete(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}