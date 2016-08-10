using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.TeleportStationTests.Mocks;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    class TeleportStationTests
    {
        [Test]
        public void TestConstructor_PassValidParameters_ShouldInitialiseCorrectly()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var map = new List<IPath>() { mockedPath.Object };

            var station = new MockedTeleportStation
                (mockedBusinessOwner.Object, map, mockedLocation.Object);

            Assert.AreSame(mockedBusinessOwner.Object, station.Owner);
            Assert.AreSame(mockedLocation.Object, station.Location);
            Assert.AreSame(map, station.GalacticMap);
            Assert.IsInstanceOf<TeleportStation>(station);
        }

        [Test]
        public void TestPayProfits_PassValidOwner_ShouldPayCorrectly()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            mockedBusinessOwner.SetupGet(x => x.IdentificationNumber).Returns(112);
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedCoordinates = new Mock<IGPSCoordinates>();
            mockedCoordinates.SetupGet(x => x.Longtitude).Returns(15);
            mockedCoordinates.SetupGet(x => x.Latitude).Returns(22);

            mockedDestination.SetupGet(x => x.Coordinates).Returns(mockedCoordinates.Object);
            var mockedLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();
            var mockedCurrentPlanet = new Mock<IPlanet>();

            mockedCurrentPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedCurrentPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet).Returns(mockedCurrentPlanet.Object);

            var mockedResource = new Mock<IResources>();
            mockedResource.SetupGet(x => x.GoldCoins).Returns(15);
            mockedResource.SetupGet(x => x.SilverCoins).Returns(15);
            mockedResource.SetupGet(x => x.BronzeCoins).Returns(15);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);
            mockedPath.SetupGet(x => x.Cost).Returns(mockedResource.Object);

            var map = new List<IPath>() { mockedPath.Object };
            var teleportStation = new MockedTeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);
            mockedLocation.SetupGet(x => x.Coordinates).Returns(It.IsAny<IGPSCoordinates>());

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResource.Object);

            mockedCurrentPlanet.SetupGet(x => x.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);
            var profits = teleportStation.PayProfits(mockedBusinessOwner.Object);

            Assert.AreEqual(mockedResource.Object.BronzeCoins,profits.BronzeCoins);
            Assert.AreEqual(mockedResource.Object.SilverCoins, profits.SilverCoins);
            Assert.AreEqual(mockedResource.Object.GoldCoins, profits.GoldCoins);
        }




    }
}
