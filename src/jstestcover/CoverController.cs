using System;
using System.IO;
using System.Text;
using jstestcover.Instrumentation;
using jstestcover.Wrappers;

namespace jstestcover
{
    public class CoverController
    {
        readonly Settings settings;
        readonly FileListBuilder fileListBuilder;
        readonly IDisk diskIo;

        public CoverController(Settings settings) : this(settings, new FileListBuilder(), new DiskWrapper()) { }
        
        public CoverController(Settings settings, FileListBuilder fileListBuilder, IDisk diskIo)
        {
            this.settings = settings;
            this.fileListBuilder = fileListBuilder;
            this.diskIo = diskIo;
        }

        public virtual void RunInstrumentation()
        {
            RunInstrumentation(new FileInstrumenter(settings.Verbose));
        }

        public virtual void RunInstrumentation(FileInstrumenter fileInstrumenter)
        {
            var filesToProcess = fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectory, settings.InputTarget);

            foreach (var javaScriptFile in filesToProcess)
            {
                if (!diskIo.Exists(javaScriptFile))
                {
                    if (settings.Verbose)
                    {
                        Console.WriteLine("Could not file to be processed: {0}", javaScriptFile);
                    }
                    
                    continue;
                }

                var inputStream = new MemoryStream(diskIo.ReadAllBytes(javaScriptFile));
                var inputReader = new StreamReader(inputStream, true);
                var outputStream = new MemoryStream();
                var outputWriter = new StreamWriter(outputStream, Encoding.UTF8);

                fileInstrumenter.Instrument(inputReader, outputWriter, javaScriptFile);

                inputReader.Close();

                var outputFile = GetOutputFilePath(javaScriptFile);

                diskIo.WriteAllBytes(outputFile, outputStream.ToArray());
                outputWriter.Close();
            }
        }

        private string GetOutputFilePath(string inputFile)
        {
            var outputFile = inputFile;

            if (!string.IsNullOrWhiteSpace(settings.OutputLocation))
            {
                if (settings.IsDirectory)
                {
                    var fileInfo = new FileInfo(inputFile);
                    var additionalPath = fileInfo.DirectoryName.Replace(settings.InputTarget, "");
                    var outputPath = settings.OutputLocation + additionalPath;
                    diskIo.CreateDirectory(outputPath);
                    return string.Format(@"{0}\{1}", outputPath, fileInfo.Name);
                }

                if (!settings.IsConfig)
                {
                    outputFile = settings.OutputLocation;
                }
            }

            return outputFile;
        }
    }
}
