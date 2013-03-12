using NSubstitute;
using NUnit.Framework;

namespace jstestcover.tests
{
    public class CoverControllerTests
    {
        [Test]
        public void RunInstrumentation_CallsFileListBuilderToGetFilesToProcess()
        {
            var fileListBuilder = Substitute.For<FileListBuilder>();
            var settings = new Settings();
            var controller = new CoverController(settings, fileListBuilder);

            controller.RunInstrumentation();
            fileListBuilder.Received().BuildFileList(settings.IsConfig, settings.IsDirectories, settings.InputTarget);

        }
    }
}
