using System;
using System.IO;

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

        public virtual void Instrument(StreamReader inputStream, StreamWriter outputStream, string inputFilename)
        {
            if (Verbose)
            {
                Console.WriteLine("[INFO] Preparing to instrument JavaScript file {0}.", inputFilename);
            }

            if (inputStream.BaseStream.Length == 0)
            {
                if (Verbose)
                {
                    Console.WriteLine("[WARN] The input stream for {0} is empty. Skipping file.", inputFilename);
                }
                return;
            }

            instrumenter.Instrument(inputStream, inputFilename, outputStream);

            if (Verbose)
            {
                Console.WriteLine("[INFO] Finished instrumenting file {0}.", inputFilename);
            }
        }

    }
}
