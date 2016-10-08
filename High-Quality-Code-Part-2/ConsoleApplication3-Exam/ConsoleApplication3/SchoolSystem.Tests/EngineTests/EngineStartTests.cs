using Moq;
using NUnit.Framework;
using SchoolSystem.UI.Models;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.Tests.EngineTests
{
    [TestFixture]
    class EngineStartTests
    {
        [Test]
        public void StartTest_ShouldCallReaderRead()
        {
            var mockedReader = new Mock<IReader>();
            mockedReader.Setup(x => x.ReadLine()).Returns("End");

            var mockedWriter = new Mock<IWriter>();
            var mockedParser = new Mock<ICommandParser>();

            Engine.Start(mockedReader.Object, mockedWriter.Object, mockedParser.Object);

            mockedReader.Verify(x => x.ReadLine(), Times.Once);
        }
    }
}
