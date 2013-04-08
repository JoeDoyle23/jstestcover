using System.Collections.Generic;

namespace jstestcoverreporter
{
    public class SummaryCoverageData
    {
        public Dictionary<string, FileCoverageData> CoverageData { get; set; }

        public SummaryCoverageData()
        {
            CoverageData = new Dictionary<string, FileCoverageData>();
        }
    }
}
