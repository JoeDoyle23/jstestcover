using System.Collections.Generic;
using System.IO;

namespace jstestcover
{
    public class FileListBuilder
    {
        readonly IDirectory directory;

        public FileListBuilder() : this(new DirectoryWrapper()) {}

        public FileListBuilder(IDirectory directory)
        {
            this.directory = directory;
        }

        public virtual IList<string> BuildFileList(bool isConfig, bool isDirectory, string inputTarget)
        {
            if (isConfig)
            {
                return BuildFileListFromConfig(inputTarget);
            }
            
            if (isDirectory)
            {
                return BuildFileListFromDirectory(inputTarget);
            }

            return new List<string> { inputTarget };
        }

        IList<string> BuildFileListFromConfig(string configFile)
        {
            throw new System.NotImplementedException();
        }

        IList<string> BuildFileListFromDirectory(string path)
        {
            var files = new List<string>();

            if (string.IsNullOrWhiteSpace(path))
            {
                return files;
            }

            files.AddRange(directory.GetFiles(path, "*.js", SearchOption.AllDirectories));

            return files;
        }
    }
}