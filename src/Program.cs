using System;
using System.Text;
using ncoverjs.Instrumentation;

namespace ncoverjs
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();

            if (!CommandLine.Parser.Default.ParseArguments(args, settings))
                return;

            if (string.IsNullOrEmpty(settings.InputTarget))
            {
                Console.WriteLine(settings.GetUsage());
            }
            // Consume values here
            //if (options.Verbose) Console.WriteLine("Filename: {0}", options.InputFile);

            var fileI = new FileInstrumenter();
            fileI.Instrument(@"C:\Personal\ncoverjs\src\CourseSelection.js", @"C:\Personal\ncoverjs\src\CourseSelection-I.js", Encoding.UTF8);
        }
    }
}
