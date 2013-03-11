using System;
using System.IO;
using System.Text;

namespace jstestcover.Instrumentation
{
    public class FileInstrumenter
    {
        public bool Verbose { get; set; }

        readonly IInstrumenter instrumenter;

        public FileInstrumenter(bool verbose)
        {
            Verbose = verbose;
            instrumenter = new JavaScriptInstrumenter();
        }

        public FileInstrumenter(IInstrumenter instrumenter, bool verbose)
        {
            Verbose = verbose;
            this.instrumenter = instrumenter;
        }

        public virtual void Instrument(Stream inputStream, Stream outputStream, string inputFilename)
        {
            if (Verbose)
            {
                Console.WriteLine("[INFO] Preparing to instrument JavaScript file {0}.", inputFilename);
            }

            if (inputStream.Length == 0)
            {
                if (Verbose)
                {
                    Console.WriteLine("[WARN] The input stream for {0} is empty. Skipping file.", inputFilename);
                }
                return;
            }

            var input = new StreamReader(inputStream, true);
            var output = new StreamWriter(outputStream, Encoding.UTF8);

            instrumenter.Instrument(input, inputFilename, output);

            if (Verbose)
            {
                Console.WriteLine("[INFO] Finished instrumenting file {0}.", inputFilename);
            }
        }

    }
}
