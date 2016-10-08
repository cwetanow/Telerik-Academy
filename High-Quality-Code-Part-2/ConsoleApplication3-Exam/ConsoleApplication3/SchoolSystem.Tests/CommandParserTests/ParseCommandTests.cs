using System;
using NUnit.Framework;
using SchoolSystem.UI.Models;

namespace SchoolSystem.Tests.CommandParserTests
{
    [TestFixture]
    class ParseCommandTests
    {
        [TestCase("invalid")]
        [TestCase("invalid cmd")]
        public void TestParseCommand_PassInvalidCommand_ShouldThrowArgumentNullException(string input)
        {
            var parser = new CommandParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseCommand(input));
        }
    }
}
