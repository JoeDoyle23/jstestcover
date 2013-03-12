using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using jstestcover.Instrumentation;
using jstestcover.Wrappers;

namespace jstestcover.tests
{
    public class CoverControllerTests
    {
        FileInstrumenter fileInstrumenter;
        FileListBuilder fileListBuilder;
        IDisk diskIo;
        Settings settings;
        CoverController controller;

        [SetUp]
        public void Setup()
        {
            fileInstrumenter = Substitute.For<FileInstrumenter>(false);
            fileListBuilder = Substitute.For<FileListBuilder>();
            diskIo = Substitute.For<IDisk>();
            settings = new Settings();

            controller = new CoverController(settings, fileListBuilder, diskIo);
        }

        [Test]
        public void RunInstrumentation_CallsFileListBuilderToGetFilesToProcess()
        {
            controller.RunInstrumentation();
            fileListBuilder.Received().BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget);
        }

        [Test]
        public void RunInstrumentation_WhenFileToProcessDoesNotExist_ContinuesToNextFile()
        {
            var javaScriptFile = @"C:\JavaScript\File1.js";
            fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget)
                .Returns(new List<string> { javaScriptFile });

            diskIo.Exists(javaScriptFile).Returns(false);

            controller.RunInstrumentation(fileInstrumenter);
            
            fileInstrumenter.DidNotReceiveWithAnyArgs().Instrument(null, null, null);
        }

        [Test]
        public void RunInstrumentation_WhenOnlyInputFileIsGiven_InputFileIsOverWritten()
        {
            settings.InputTarget = @"C:\JavaScript\File1.js";

            fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget)
                .Returns(new List<string> { settings.InputTarget });

            diskIo.Exists(settings.InputTarget).Returns(true);

            controller.RunInstrumentation(fileInstrumenter);

            diskIo.Received().WriteAllBytes(settings.InputTarget, Arg.Any<byte[]>());
        }

        [Test]
        public void RunInstrumentation_WhenOutputFileIsGiven_ResultSavedToOutputFile()
        {
            settings.OutputLocation = @"C:\Output\File1.js";
            var javaScriptFile = @"C:\JavaScript\File1.js";

            fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget)
                .Returns(new List<string> { javaScriptFile });

            diskIo.Exists(javaScriptFile).Returns(true);

            controller.RunInstrumentation(fileInstrumenter);

            diskIo.Received().WriteAllBytes(settings.OutputLocation, Arg.Any<byte[]>());
        }

        [Test]
        public void RunInstrumentation_WhenOutputDirectoryIsGiven_ResultSavedToOutputDirectory()
        {
            SetupSettingsForDirectoryProcessing();

            var inputFile = @"C:\JavaScript\File1.js";
            var expectedFile = @"C:\Output\File1.js";

            fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget)
                .Returns(new List<string> { inputFile });

            diskIo.Exists(inputFile).Returns(true);

            controller.RunInstrumentation(fileInstrumenter);

            diskIo.Received().WriteAllBytes(expectedFile, Arg.Any<byte[]>());
        }
        
        [Test]
        public void RunInstrumentation_WhenProcessingDirectoryWithSubfolders_CreatesDirectoriesThatMightNotExists()
        {
            SetupSettingsForDirectoryProcessing();

            var inputFile = @"C:\JavaScript\App\File1.js";
            
            fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget)
                .Returns(new List<string> { inputFile });

            diskIo.Exists(inputFile).Returns(true);

            controller.RunInstrumentation(fileInstrumenter);

            diskIo.Received().CreateDirectory(@"C:\Output\App");
        }

        [Test]
        public void RunInstrumentation_WhenProcessingDirectoryWithSubfolders_ResultSavedToOutputDirectoryWithSubfolders()
        {
            SetupSettingsForDirectoryProcessing();

            var inputFile = @"C:\JavaScript\App\File1.js";
            var expectedFile = @"C:\Output\App\File1.js";

            fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget)
                .Returns(new List<string> { inputFile });

            diskIo.Exists(inputFile).Returns(true);

            controller.RunInstrumentation(fileInstrumenter);

            diskIo.Received().WriteAllBytes(expectedFile, Arg.Any<byte[]>());
        }

        void SetupSettingsForDirectoryProcessing()
        {
            settings.IsDirectory = true;
            settings.OutputLocation = @"C:\Output";
            settings.InputTarget = @"C:\JavaScript";
        }
    }
}
