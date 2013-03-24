using System.IO;
using Newtonsoft.Json;

namespace jstestcoverreporter
{
    public class CoverageFileReader
    {
        public virtual FileCoverageData GetCoverageData(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var fileData = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<FileCoverageData>(fileData);
        }
    }
}
