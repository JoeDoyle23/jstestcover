using System.Collections.Generic;
using Newtonsoft.Json;

namespace jstestcoverreporter
{
    public class FileCoverage
    {
        [JsonProperty("lines")]
        public Dictionary<string, int> Lines { get; set; }
        [JsonProperty("functions")]
        public Dictionary<string, int> Functions { get; set; }
        [JsonProperty("coveredLines")]
        public int CoveredLines { get; set; }
        [JsonProperty("calledLines")]
        public int CalledLines { get; set; }
        [JsonProperty("coveredFunctions")]
        public int CoveredFunctions { get; set; }
        [JsonProperty("calledFunctions")]
        public int CalledFunctions { get; set; }
        [JsonProperty("code")]
        public List<string> Code { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }

        public FileCoverage()
        {
            Lines = new Dictionary<string, int>();
            Functions = new Dictionary<string, int>();
        }
    }
}
