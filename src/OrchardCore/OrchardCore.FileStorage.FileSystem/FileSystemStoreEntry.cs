using System;
using System.IO;

namespace OrchardCore.FileStorage.FileSystem
{
    public class FileSystemStoreEntry : IFileStoreEntry
    {
        private readonly FileSystemInfo _fileInfo;
        private readonly string _path;

        internal FileSystemStoreEntry(string path, FileSystemInfo fileInfo)
        {
            _fileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Path => _path;
        public string Name => _fileInfo.Name;
        public string DirectoryPath => _path.Substring(0, _path.Length - Name.Length).TrimEnd('/');
        public DateTime LastModified => _fileInfo.LastWriteTimeUtc;
        public long Length => (_fileInfo as FileInfo)?.Length ?? 0;
        public bool IsDirectory => _fileInfo is DirectoryInfo;
    }
}