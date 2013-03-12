using System.Collections.Generic;

namespace jstestcover
{
    public class ConfigurationFileSettings
    {
        public List<string> Files { get; set; }
        public List<string> Directories { get; set; }
        public List<string> ExcludedFiles { get; set; }
        public List<string> ExcludedDirectories { get; set; }

        public ConfigurationFileSettings()
        {
            Files = new List<string>();
            Directories = new List<string>();
            ExcludedFiles = new List<string>();
            ExcludedDirectories = new List<string>();
        }
    }
}
