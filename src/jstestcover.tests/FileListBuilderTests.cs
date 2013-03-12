using System.IO;
using NSubstitute;
using NUnit.Framework;

namespace jstestcover.tests
{
    public class FileListBuilderTests
    {
        [Test]
        public void BuildFileList_WhenIsNotConfigOrDirectory_ReturnsListWithInputTarget()
        {
            var builder = new FileListBuilder();

            var result = builder.BuildFileList(false, false, "file.js");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("file.js", result[0]);
        }

        [Test]
        public void BuildFileList_WhenIsDirectory_CallsDirectoryTraverserToGetAllJSFiles()
        {
            var directory = Substitute.For<IDirectory>();
            var builder = new FileListBuilder(directory);

            directory.GetFiles(@"C:\JavaScript", "*.js", SearchOption.AllDirectories)
                .Returns(new[]
                             {
                                 @"C:\JavaScript\File1.js",
                                 @"C:\JavaScript\Dir1\File2.js",
                                 @"C:\JavaScript\Dir2\File3.js",
                             });

            var result = builder.BuildFileList(false, true, @"C:\JavaScript");

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(@"C:\JavaScript\File1.js", result[0]);
            Assert.AreEqual(@"C:\JavaScript\Dir1\File2.js", result[1]);
            Assert.AreEqual(@"C:\JavaScript\Dir2\File3.js", result[2]);
        }
    }
}
