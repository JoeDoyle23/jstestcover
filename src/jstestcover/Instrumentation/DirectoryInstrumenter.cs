using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace jstestcover.Instrumentation
{
    public class DirectoryInstrumenter
    {
        public bool Verbose { get; set; }

        public DirectoryInstrumenter(bool verbose)
        {
            Verbose = verbose;
        }

        public void Instrument(string inputDir, string outputDir, List<string> excludes)
        {
            var fileInstrumenter = new FileInstrumenter(null, Verbose);

            //normalize
            if (!inputDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                inputDir = inputDir + Path.DirectorySeparatorChar;
            }

            if (!outputDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                outputDir = outputDir + Path.DirectorySeparatorChar;
            }

            var filenames = GetFilenames(inputDir, excludes);

            foreach (var filename in filenames)
            {
                var outputFilename = Path.Combine(outputDir, filename);
                var outputFullPath = Path.GetFullPath(outputFilename);

                //create the directories if necessary
                if (!Directory.Exists(outputFullPath))
                {
                    if (Verbose)
                    {
                        Console.WriteLine("[INFO] Creating directory {0}", outputFullPath);
                    }
                    Directory.CreateDirectory(outputFullPath);
                }

                //fileInstrumenter.Instrument(Path.Combine(inputDir, filename), outputFilename, Encoding.UTF8);
            }

            //copy files and directories excluded from instrumentation, still need them to run tests
            CopyExcludes(inputDir, outputDir, excludes);
        }

        private void CopyExcludes(string inputDir, string outputDir, IEnumerable<string> excludes)
        {
            //copy files and directories excluded for instrumentation, need them to run tests properly
            Console.WriteLine("intput dir={0}", inputDir);

            foreach (var exclude in excludes)
            {
                var srcName = Path.Combine(inputDir, exclude);
                var destName = Path.Combine(outputDir, exclude);

                if (File.Exists(srcName))
                {
                    Console.WriteLine("copying skipped file {0} to {1}", srcName, destName);
                    CopyFile(srcName, destName);
                    continue;
                }

                if (Directory.Exists(srcName))
                {
                    Console.WriteLine("copying skipped directory {0} to {1}", srcName, destName);
                    CopyDirectory(srcName, destName);
                }
            }
        }

        private void CopyFile(string srcFile, string destFile)
        {
            if (!File.Exists(srcFile))
            {
                throw new IOException("src file does not exist or is not a file");
            }

            File.Copy(srcFile, destFile, true);
        }

        private void CopyDirectory(string source, string destination)
        {
            if (!Directory.Exists(source))
            {
                throw new IOException("src file or directory does not exist");
            }

            if (File.Exists(source))
            {
                CopyFile(source, destination);
                return;
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            // child filenames
            foreach (var file in Directory.EnumerateFiles(source))
            {
                CopyFile(Path.Combine(source, file), Path.Combine(destination, file));
            }

            foreach (var dir in Directory.EnumerateDirectories(destination))
            {
                CopyDirectory(Path.Combine(source, dir), Path.Combine(destination, dir));
            }
        }

        private List<string> GetFilenames(string directory, List<String> excludes)
        {
            if (!Directory.Exists(directory))
            {
                throw new FileNotFoundException("'" + directory + "' does not exist or is not a directory.");
            }

            var files = Directory.GetFiles(directory, "*.js", SearchOption.AllDirectories);

            //TODO: Remove exclusions

            return files.ToList();
        }
    }
}
