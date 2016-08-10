using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    [TestFixture]
    class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void TestGetResources_PassValidCommand_ShouldInitialiseCorrectlyWithValidCoins(string command)
        {
            var factory = new ResourcesFactory();
            var gold = 20;
            var silver = 30;
            var bronze = 40;

            var resources = factory.GetResources(command);

            Assert.IsInstanceOf<IResources>(resources);
            Assert.AreEqual(gold,resources.GoldCoins);
            Assert.AreEqual(bronze, resources.BronzeCoins);
            Assert.AreEqual(silver, resources.SilverCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void TestGetResources_PassInvalidCommand_ShouldThrowInvalidOperationException(string command)
        {
            var factory=new ResourcesFactory();

            Assert.Throws<InvalidOperationException>(() => factory.GetResources(command),"command");
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void TestGetResources_PassInvalidCommandWithCorrectFormat_ShouldThrowOverflowException(string command)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
