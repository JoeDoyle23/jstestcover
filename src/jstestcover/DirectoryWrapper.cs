using System.IO;

namespace jstestcover
{
    public class DirectoryWrapper : IDirectory
    {
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption);
        }
    }
}
