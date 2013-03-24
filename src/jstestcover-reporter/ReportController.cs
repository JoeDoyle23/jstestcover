namespace jstestcoverreporter
{
    public class ReportController
    {
        readonly Settings settings;
        readonly CoverageFileReader coverageFileReader;

        public ReportController(Settings settings, CoverageFileReader coverageFileReader)
        {
            this.settings = settings;
            this.coverageFileReader = coverageFileReader;
        }

        public bool GenerateReport()
        {
            if (string.IsNullOrEmpty(settings.InputTarget))
                return false;

            var fileCoverageData = coverageFileReader.GetCoverageData(settings.InputTarget);

            if (fileCoverageData == null)
                return false;

            return true;
        }
    }
}
