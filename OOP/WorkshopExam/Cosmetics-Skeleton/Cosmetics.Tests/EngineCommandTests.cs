using Cosmetics.Engine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class EngineCommandTests
    {
        [TestCase("ValidCommand")]
        public void TestParse_PassValidInput_ShouldReturnCommand(string commandText)
        {
            var command = Command.Parse(commandText);

            Assert.AreEqual("Command", command.GetType().Name);
        }

        [Test]
        public void TestParse_PassValidInput_ShouldReturnCommandWithValidName()
        {
            var name = "Command";
            var parameters = new List<string>() { "ParameterOne", "ParameterTwo" };
            var commandText = name + " " + string.Join(" ", parameters);

            var command = Command.Parse(commandText);

            Assert.AreEqual(command.Name, name);
        }

        [Test]
        public void TestParse_PassValidInput_ShouldReturnCommandWithValidParameters()
        {
            var name = "Command";
            var parameters = new List<string>() { "ParameterOne", "ParameterTwo" };
            var commandText = name + " " + string.Join(" ", parameters);

            var command = Command.Parse(commandText);

            Assert.AreEqual(command.Parameters, parameters);
        }

        [Test]
        public void TestParse_PassStringEmpty_ShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => Command.Parse(string.Empty));
        }

    }
}
