using CommandLine;
using CommandLine.Text;

namespace jstestcoverreporter
{
    public class Settings
    {
        [HelpOption('h', "help", HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("jstestcover-reporter", "1.0.0"),
                Copyright = new CopyrightInfo("Joe Doyle", 2013),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine(" ");
            help.AddPreOptionsLine("Usage: jstestcover-reporter [options] [file]");
            help.AddOptions(this);
            return help;
        }

        [Option('v', "verbose", HelpText = "Display informational messages and warnings.")]
        public bool Verbose { get; set; }

        [Option('o', HelpText = "Place the output into <file|dir>", MetaValue = "<file|dir>")]
        public string OutputLocation { get; set; }

        [Option('f', "format", HelpText = "Output reports in <format>. Defaults to HTML.", MetaValue = "<file|dir>")]
        public string Format { get; set; }

        [ValueOption(0)]
        public string InputTarget { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
