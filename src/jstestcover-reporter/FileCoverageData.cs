using System.Collections.Generic;
using Newtonsoft.Json;

namespace jstestcoverreporter
{
    public class FileCoverageData
    {
        public Dictionary<string, int> Lines { get; set; }
        public Dictionary<string, int> Functions { get; set; }
        public int CoveredLines { get; set; }
        public int CalledLines { get; set; }
        public int CoveredFunctions { get; set; }
        public int CalledFunctions { get; set; }
        public List<string> Code { get; set; }
        public string Path { get; set; }

        public FileCoverageData()
        {
            Lines = new Dictionary<string, int>();
            Functions = new Dictionary<string, int>();
        }
    }
}
