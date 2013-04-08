using System;

namespace jstestcoverreporter.ReportGenerators
{
    public class HtmlReportGenerator
    {
        string outputPath;
        bool verbose;

        public HtmlReportGenerator(string outputPath, bool verbose)
        {
            this.outputPath = outputPath;
            this.verbose = verbose;
        }

        public void Generate(FileCoverageData coverageData, DateTime timetamp)
        {
            GenerateSummaryPage(coverageData, timetamp);
            GenerateFilePages(coverageData, timetamp);
        }

        void GenerateSummaryPage(FileCoverageData coverageData, DateTime timetamp)
        {
            
        }

        void GenerateFilePages(FileCoverageData coverageData, DateTime timetamp)
        {
            
        }

    }
}
