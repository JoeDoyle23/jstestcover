using System.IO;

namespace jstestcover.Wrappers
{
    public interface IDisk
    {
        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
        void CreateDirectory(string path);
        byte[] ReadAllBytes(string file);
        void WriteAllBytes(string file, byte[] data);
        bool Exists(string file);
    }
}
