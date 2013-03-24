using NUnit.Framework;

namespace jstestcoverreporter.tests
{
    [TestFixture]
    public class CoverageFileReaderTests
    {
        CoverageFileReader coverageFileReader;

        [SetUp]
        public void Setup()
        {
            coverageFileReader = new CoverageFileReader();    
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void GetCoverageData_WhenFileNameIsEmpty_ReturnNull(string fileName)
        {
            var result = coverageFileReader.GetCoverageData(fileName);
            Assert.IsNull(result);
        }
    }
}
