using System.IO;
using System.Text;
using jstestcover.Instrumentation;

namespace jstestcover
{
    public class CoverController
    {
        readonly Settings settings;
        readonly FileListBuilder fileListBuilder;

        public CoverController(Settings settings) : this(settings, new FileListBuilder()) { }
        
        public CoverController(Settings settings, FileListBuilder fileListBuilder)
        {
            this.settings = settings;
            this.fileListBuilder = fileListBuilder;
        }

        public virtual void RunInstrumentation()
        {
            RunInstrumentation(new FileInstrumenter(settings.Verbose));
        }

        public virtual void RunInstrumentation(FileInstrumenter fileInstrumenter)
        {
            var filesToProcess = fileListBuilder.BuildFileList(settings.IsConfig, settings.IsDirectories, settings.InputTarget);

            //var input = new StreamReader(inputStream, true);
            //var output = new StreamWriter(outputStream, Encoding.UTF8);


        }
    }
}
