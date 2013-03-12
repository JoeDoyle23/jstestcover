using System.IO;

namespace jstestcover.Wrappers
{
    public class DiskWrapper : IDisk
    {
        public byte[] ReadAllBytes(string file)
        {
            return File.ReadAllBytes(file);
        }

        public void WriteAllBytes(string file, byte[] data)
        {
            File.WriteAllBytes(file, data);
        }

        public bool Exists(string file)
        {
            return File.Exists(file);
        }

        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
