using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.TeleportStationTests.Mocks;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    class BusinessOwnerTests
    {
        [TestCase(1123)]
        public void TestCollectProfits_ShouldCollectCorrectly(int id)
        {
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var map = new List<IPath>() { mockedPath.Object };
            
            var mockedResources=new Mock<IResources>();
            uint difference = 10;
            mockedResources.SetupGet(x => x.SilverCoins).Returns(difference);
            mockedResources.SetupGet(x => x.GoldCoins).Returns(difference);
            mockedResources.SetupGet(x => x.BronzeCoins).Returns(difference);
            
            var mockedStation=new Mock<ITeleportStation>();
            var businessOwner=new BusinessOwner(id,"Big Boss", new List<ITeleportStation>(){mockedStation.Object});

            mockedStation.Setup(x => x.PayProfits(businessOwner)).Returns(mockedResources.Object);
            var bronze = businessOwner.Resources.BronzeCoins;
            var gold = businessOwner.Resources.GoldCoins;
            var silver = businessOwner.Resources.SilverCoins;

            businessOwner.CollectProfits();

            Assert.AreEqual(businessOwner.Resources.GoldCoins, gold+difference);
            Assert.AreEqual(businessOwner.Resources.SilverCoins, silver+difference);
            Assert.AreEqual(businessOwner.Resources.BronzeCoins, bronze+difference);
        }
    }
}
