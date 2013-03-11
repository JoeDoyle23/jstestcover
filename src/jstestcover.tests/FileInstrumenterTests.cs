using System.IO;
using NSubstitute;
using NUnit.Framework;
using jstestcover.Instrumentation;

namespace jstestcover.tests
{
    public class FileInstrumenterTests
    {
        FileInstrumenter fileInstrumenter;
        IInstrumenter instrumenter;

        [SetUp]
        public void Setup()
        {
            instrumenter = Substitute.For<IInstrumenter>();

            fileInstrumenter = new FileInstrumenter(instrumenter, false);
        }

        [Test]
        public void Instrument_WhenInputStreamIsEmpty_ReturnsWithoutCallingInstrumenter()
        {
            var inputStream = new MemoryStream();
            var outputStream = new MemoryStream();

            fileInstrumenter.Instrument(inputStream, outputStream, "");

            instrumenter.DidNotReceiveWithAnyArgs().Instrument(null, "", null);
        }

        [Test]
        public void Instrument_WhenInputStreamIsNotEmpty_CallsInstrumenter()
        {
            var inputStream = new MemoryStream(new byte[] { 1 });
            var outputStream = new MemoryStream();

            fileInstrumenter.Instrument(inputStream, outputStream, "");

            instrumenter.ReceivedWithAnyArgs().Instrument(null, "", null);
        }
    }
}
