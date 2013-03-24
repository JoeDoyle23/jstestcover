using NSubstitute;
using NUnit.Framework;

namespace jstestcoverreporter.tests
{
    [TestFixture]
    public class ReportControllerTests
    {
        Settings settings;
        ReportController reportController;
        CoverageFileReader coverageFileReader;
        
        [SetUp]
        public void Setup()
        {
            settings = new Settings();

            coverageFileReader = Substitute.For<CoverageFileReader>();

            reportController = new ReportController(settings, coverageFileReader);
        }

        [Test]
        public void GenerateReport_WhenNoCoverageFileInSettings_ReturnsFalse()
        {
            var result = reportController.GenerateReport();

            Assert.IsFalse(result);
        }

        [Test]
        public void GenerateReport_WhenCoverageFileIsNotValid_ReturnsFalse()
        {
            settings.InputTarget = "coverage.json";
            
            coverageFileReader.GetCoverageData(settings.InputTarget).Returns(x => null);

            var result = reportController.GenerateReport();

            Assert.IsFalse(result);
        }
    }
}
