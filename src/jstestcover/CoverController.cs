using System.Collections.Generic;
using jstestcover.Instrumentation;

namespace jstestcover
{
    public class CoverController
    {
        readonly Settings settings;

        public CoverController(Settings settings)
        {
            this.settings = settings;
        }

        public void RunInstrumentation()
        {
            RunInstrumentation(new FileInstrumenter(settings.Verbose), new DirectoryInstrumenter(settings.Verbose));
        }

        public void RunInstrumentation(FileInstrumenter fileInstrumenter, DirectoryInstrumenter directoryInstrumenter)
        {
            var filesToProcess = BuildFileList();
        }

        private IList<string> BuildFileList()
        {
            if (settings.IsConfig)
            {
                return BuildFileListFromConfig();
            }
            
            if (settings.IsDirectories)
            {
                return BuildFileListFromDirectory();
            }

            return new List<string> {settings.InputTarget};
        }

        private IList<string> BuildFileListFromConfig()
        {
            throw new System.NotImplementedException();
        }

        private IList<string> BuildFileListFromDirectory()
        {
            throw new System.NotImplementedException();
        }
    }
}
