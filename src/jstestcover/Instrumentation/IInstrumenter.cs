using System.IO;

namespace jstestcover.Instrumentation
{
    public interface IInstrumenter
    {
        void Instrument(StreamReader inputStream, string inputFilename, StreamWriter outputStream);
    }
}