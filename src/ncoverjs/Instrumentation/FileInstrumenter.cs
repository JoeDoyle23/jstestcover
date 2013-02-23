using System;
using System.IO;
using System.Text;

namespace ncoverjs.Instrumentation
{
    public class FileInstrumenter
    {
        public bool Verbose { get; set; }

        public void Instrument(string inputFilename, string outputFilename, Encoding charSet)
        {
            if (Verbose)
            {
                Console.WriteLine("[INFO] Preparing to instrument JavaScript file {0}.", inputFilename);
                Console.WriteLine("[INFO] Output file will be {0}.", outputFilename);
            }

            try
            {

                using (var inputStream = new StreamReader(inputFilename, charSet))
                using (var outputStream = new StreamWriter(outputFilename, false, charSet))
                {

                    //if the file is empty, don't bother instrumenting
                    //if (inputFile.length() > 0){
                    //strip out relative paths - that just messes up coverage report writing
                    var instrumenter = new JavaScriptInstrumenter(inputStream, inputFilename);
                    //in, inputFilename.replaceAll("\\.\\./", ""),(new File(inputFilename)).getCanonicalPath());
                    instrumenter.Instrument(outputStream, Verbose);
                    //} else {
                    //    out.write("");
                    //}
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }

            if (Verbose)
            {
                Console.WriteLine("[INFO] Created file {0}.", outputFilename);
            }
        }

    }
}
