using System.IO;

namespace jstestcover
{
    public interface IDirectory
    {
        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
    }
}