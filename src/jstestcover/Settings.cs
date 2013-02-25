using System.Text;
using CommandLine;
using CommandLine.Text;

namespace ncoverjs
{
    public class Settings
    {
        [HelpOption('h', "help", HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("ncoverjs", "1.0.0"),
                Copyright = new CopyrightInfo("Joe Doyle", 2013),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine(" ");
            help.AddPreOptionsLine("Usage: ncoverjs [options] [file|dir]");
            help.AddOptions(this);
            return help;
        }

        [Option("charset", HelpText = "Read the input file using specified charset.", MetaValue = "<charset>")]
        public Encoding CharSet { get; set; }

        [Option('d', "dir", HelpText = "Input and output (-o) are both directories.")]
        public bool IsDirectories { get; set; }

        [Option('v', "verbose", HelpText = "Display informational messages and warnings.")]
        public bool Verbose { get; set; }

        [Option('o', HelpText = "Place the output into <file|dir> instead of overwriting the original file.", MetaValue = "<file|dir>")]
        public string OutputLocation { get; set; }

        [ValueOption(0)]
        public string InputTarget { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
