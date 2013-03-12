using System.Collections.Generic;
using System.IO;
using jstestcover.Wrappers;

namespace jstestcover
{
    public class FileListBuilder
    {
        readonly IDisk disk;

        public FileListBuilder() : this(new DiskWrapper()) {}

        public FileListBuilder(IDisk disk)
        {
            this.disk = disk;
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

            files.AddRange(disk.GetFiles(path, "*.js", SearchOption.AllDirectories));

            return files;
        }
    }
}