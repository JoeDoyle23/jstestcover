using System.IO;
using Newtonsoft.Json.Linq;

namespace jstestcoverreporter
{
    public class CoverageFileReader
    {
        public virtual SummaryCoverageData GetCoverageData(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var fileData = File.ReadAllText(fileName);

            var jsonData = JObject.Parse(fileData);

            var summary = new SummaryCoverageData();

            foreach (var node in jsonData)
            {
                var file = node.Key;
                var coverageData = node.Value.ToObject<FileCoverageData>();
                summary.CoverageData.Add(file, coverageData);
            }

            return summary;
        }
    }
}
