using System.IO;
using System.Reflection;
using System.Text;
using Antlr.Runtime;
using Antlr3.ST;

namespace jstestcover.Instrumentation
{
    public class JavaScriptInstrumenter : IInstrumenter
    {
        public virtual void Instrument(StreamReader inputStream, string inputFilename, StreamWriter outputStream)
        {
            var testTemplate = LoadStringTemplateGroup();

            var inputPath = Path.GetFullPath(inputFilename);
            var inputFile = Path.GetFileName(inputFilename);

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
                codeLines.Append(line.Replace(@"\", @"\\").Replace("\"", "\\\""));
                codeLines.Append("\",");

                //build up source code
                code.AppendLine(line);
            }

            var index = codeLines.Length - 1;
            switch (codeLines[index])
            {
                case ',': //if there's a dangling comma, replace it
                    codeLines.Remove(index, 1);
                    codeLines.Insert(index, ']');
                    break;
                case '[': //empty file
                    codeLines.Append("]");
                    break;
                    //no default
            }
            codeLines.Append(";");

            //output full path

            //setup parser
            var antlrStream = new ANTLRReaderStream(new StringReader(code.ToString()));
            var lexer = new ES3YUITestLexer(antlrStream);
            var tokens = new TokenRewriteStream(lexer);
            var parser = new ES3YUITestParser(tokens)
                             {
                                 TemplateGroup = testTemplate,
                                 SourceFileName = inputFile
                             };

            var result = string.Empty;

            //an empty string will cause the parser to explode
            if (code.ToString().Trim().Length > 0)
            {
                parser.program();
                result = tokens.ToString();
            }

            //output the resulting file
            outputStream.Write(headerTemplate.ToString());
            outputStream.WriteLine();
            outputStream.Write(codeLines.ToString());
            outputStream.WriteLine();
            outputStream.Write(result);
            outputStream.Flush();
        }

        StringTemplateGroup LoadStringTemplateGroup()
        {
            var stgstream = Assembly.GetExecutingAssembly().GetManifestResourceStream("jstestcover.templates.ES3YUITestTemplates.stg");
            using (var streamReader = new StreamReader(stgstream))
            {
                return new StringTemplateGroup(new StringReader(streamReader.ReadToEnd()));
            }
        }
    }
}
