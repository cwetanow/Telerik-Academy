using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IntergalacticTravel;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    [TestFixture]
    class UnitsFactoryTests
    {
        [TestCase("create unit Procyon Gosho 1")]
        public void TestGetUnit_PassValidProcyonCommand_ShouldInitialiseCorrectly(string command)
        {
            var factory = new UnitsFactory();

            var proycon = factory.GetUnit(command);

            Assert.IsInstanceOf<Procyon>(proycon);
        }

        [TestCase("create unit Luyten Pesho 2")]
        public void TestGetUnit_PassValidLuytenCommand_ShouldInitialiseCorrectly(string command)
        {
            var factory = new UnitsFactory();

            var proycon = factory.GetUnit(command);

            Assert.IsInstanceOf<Luyten>(proycon);
        }

        [TestCase("create unit Lacaille Tosho 3")]
        public void TestGetUnit_PassValidLacailleCommand_ShouldInitialiseCorrectly(string command)
        {
            var factory = new UnitsFactory();

            var proycon = factory.GetUnit(command);

            Assert.IsInstanceOf<Lacaille>(proycon);
        }

        [TestCase("create unit spacer Tosho 3")]
        [TestCase("create unit")]
        public void TestGetUnit_PassInvalidCommand_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            var factory = new UnitsFactory();
            
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
