using System.IO;
using System.Reflection;
using System.Text;
using Antlr.Runtime;
using Antlr3.ST;

namespace ncoverjs.Instrumentation
{
    public class JavaScriptInstrumenter
    {
        string inputFile;
        string inputPath;
        StreamReader inputStream;

        public JavaScriptInstrumenter(StreamReader inputStream, string inputFilename)
            : this(inputStream, inputFilename, string.Empty)
        {
        }

        public JavaScriptInstrumenter(StreamReader inputStream, string inputFilename, string path)
        {
            inputFile = inputFilename;
            this.inputStream = inputStream;
            inputPath = path;
        }

        public void Instrument(StreamWriter outputStream, bool verbose)
        {
            //get string headerTemplate group
            StringTemplateGroup testTemplate;

            var stgstream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ncoverjs.templates.ES3YUITestTemplates.stg");
            using (var streamReader = new StreamReader(stgstream))
            {
                testTemplate = new StringTemplateGroup(new StringReader(streamReader.ReadToEnd()));
            }

            //get headerTemplate for file header
            var headerTemplate = testTemplate.GetInstanceOf("file_header");
            headerTemplate.SetAttribute("src", inputFile);
            headerTemplate.SetAttribute("path", inputPath.Replace("\\", "\\\\"));

            //read lines for later usage
            var codeLines = new StringBuilder();
            var code = new StringBuilder();

            codeLines.Append("_yuitest_coverage[\"");
            codeLines.Append(inputFile);
            codeLines.Append("\"].code=[");

            string line;

            while ((line = inputStream.ReadLine()) != null)
            {

                //build up array of lines
                codeLines.Append("\"");
                codeLines.Append(line.Replace("\\", "\\\\").Replace("\"", "\\\""));
                codeLines.Append("\",");

                //build up source code
                code.Append(line);
                code.Append("\n");
            }

            var index = codeLines.Length - 1;
            switch (codeLines.ToString()[index])
            {
                case ',':  //if there's a dangling comma, replace it
                    codeLines.Remove(index, 1);
                    codeLines.Insert(index, ']');
                    break;
                case '[':  //empty file
                    codeLines.Append("]");
                    break;
                //no default
            }
            codeLines.Append(";");

            //output full path

            //setup parser
            var stream = new ANTLRReaderStream(new StringReader(code.ToString()));
            var lexer = new ES3YUITestLexer(stream);
            var tokens = new TokenRewriteStream(lexer);
            var parser = new ES3YUITestParser(tokens);
            parser.TemplateGroup = testTemplate;
            parser.SourceFileName = inputFile;

            var result = "";

            //an empty string will cause the parser to explode
            if (code.ToString().Trim().Length > 0)
            {
                parser.program();
                result = tokens.ToString();
            }

            //close input stream in case writing to the same place

            //output the resulting file
            outputStream.Write(headerTemplate.ToString());
            outputStream.Write("\n");
            outputStream.Write(codeLines.ToString());
            outputStream.Write("\n");
            outputStream.Flush();
            outputStream.Write(result);
            outputStream.Flush();
        }
    }
}
