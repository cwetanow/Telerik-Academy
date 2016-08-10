using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.TeleportStationTests.Mocks;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    class TeleportStationTeleportUnitTests
    {
        [Test]
        public void TestTeleportUnit_PassUnitToTeleportAsNull_ShouldThrowArgumentNullException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var map = new List<IPath>() { mockedPath.Object };
            var mockedDestination = new Mock<ILocation>();

            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, mockedDestination.Object), "unitToTeleport");
        }

        [Test]
        public void TestTeleportUnit_PassLockationToTeleportAsNull_ShouldThrowArgumentNullException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var map = new List<IPath>() { mockedPath.Object };
            var mockedUnit = new Mock<IUnit>();

            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(mockedUnit.Object, null), "destination");
        }

        [Test]
        public void TestTeleportUnit_PassDistantLockationForUnit_ShouldThrowTeleportOutOfRangeException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var map = new List<IPath>() { mockedPath.Object };
            var mockedDestination = new Mock<ILocation>();

            var mockedLocation = new Mock<ILocation>();
            var mockedUnitLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitPlanet = new Mock<IPlanet>();
            var mockedCurrentPlanet = new Mock<IPlanet>();

            mockedCurrentPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedCurrentPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet).Returns(mockedCurrentPlanet.Object);

            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            mockedUnitPlanet.SetupGet(x => x.Galaxy.Name).Returns("Way out");
            mockedUnitPlanet.SetupGet(x => x.Name).Returns("Unknown");
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedUnitPlanet.Object);

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            Assert.Throws<TeleportOutOfRangeException>(() =>
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object),
                "unitToTeleport.CurrentLocation");
        }

        [Test]
        public void TestTeleportUnit_PassOccupiedLockationToTeleport_ShouldThrowInvalidTeleportationLocationException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);

            var collection = new List<IUnit>() { mockedUnitThatIsThere.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);
            var mockedLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();
            var mockedCurrentPlanet = new Mock<IPlanet>();

            mockedCurrentPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedCurrentPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet).Returns(mockedCurrentPlanet.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);
            var map = new List<IPath>() { mockedPath.Object };
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            Assert.Throws<InvalidTeleportationLocationException>(() =>
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object),
                "units will overlap");
        }

        [Test]
        public void TestTeleportUnit_PassGalaxyNotInTheStationList_ShouldThrowLocationNotFoundException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

            var mockedLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();
            var mockedCurrentPlanet = new Mock<IPlanet>();

            mockedCurrentPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedCurrentPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet).Returns(mockedCurrentPlanet.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);

            var map = new List<IPath>() { };
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            Assert.Throws<LocationNotFoundException>(() =>
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object),
                "Galaxy");
        }

        [Test]
        public void TestTeleportUnit_PassPlanetNotInTheStationList_ShouldThrowLocationNotFoundException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedPathLocation = new Mock<ILocation>();
            var mockedPathPlanet = new Mock<IPlanet>();

            mockedPathPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedPathPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedPathLocation.SetupGet(x => x.Planet).Returns(mockedPathPlanet.Object);
            mockedPathLocation.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedPathLocation.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("KiroLand");
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

            var mockedLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();
            var mockedCurrentPlanet = new Mock<IPlanet>();

            mockedCurrentPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedCurrentPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet).Returns(mockedCurrentPlanet.Object);
            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedPathLocation.Object);

            var map = new List<IPath>() { mockedPath.Object };

            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            Assert.Throws<LocationNotFoundException>(() =>
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object),
                "Planet");
        }

        [Test]
        public void TestTeleportUnit_UnitWithoutMoney_ShouldThrowInsufficientResourcesException()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);
            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

            var mockedLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();
            var mockedCurrentPlanet = new Mock<IPlanet>();

            mockedCurrentPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedCurrentPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet).Returns(mockedCurrentPlanet.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);

            var map = new List<IPath>() { mockedPath.Object };
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            Assert.Throws<InsufficientResourcesException>(
                () => teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object));

        }

        [Test]
        public void TestTeleportUnit_ShouldCallUnitToPay()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);
            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

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
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, map, mockedLocation.Object);

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResource.Object);
            mockedCurrentPlanet.SetupGet(x => x.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);

            mockedUnit.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
        }

        [Test]
        public void TestTeleportUnit_ShouldReceiveFunds()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);
            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

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

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResource.Object);
            mockedCurrentPlanet.SetupGet(x => x.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var bronze = teleportStation.Recources.BronzeCoins;
            var gold = teleportStation.Recources.GoldCoins;
            var silver = teleportStation.Recources.SilverCoins;

            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);

            Assert.IsTrue(teleportStation.Recources.BronzeCoins > bronze);
            Assert.IsTrue(teleportStation.Recources.SilverCoins > silver);
            Assert.IsTrue(teleportStation.Recources.GoldCoins > gold);
        }

        [Test]
        public void TestTeleportUnit_ShouldSetUnitToTeleportPReviousLocationToCurrent()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);
            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

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

            Assert.AreSame(mockedUnit.Object.PreviousLocation, mockedLocation.Object);
        }

        [Test]
        public void TestTeleportUnit_ShouldAddUnitToNewPlanetUnits()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);
            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

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

            var initial = mockedDestination.Object.Planet.Units.Count;
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);

            Assert.AreEqual(mockedDestination.Object.Planet.Units.Count, initial + 1);
        }

        [Test]
        public void TestTeleportUnit_ShouldRemoveUnitFromCurrentPlanetUnits()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var mockedUnitThatIsThere = new Mock<IUnit>();
            mockedUnitThatIsThere.SetupGet(x => x.CurrentLocation).Returns(mockedDestination.Object);
            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedDestination.SetupGet(x => x.Coordinates.Latitude).Returns(15);
            mockedDestination.SetupGet(x => x.Coordinates.Longtitude).Returns(22);

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

            var initial = mockedLocation.Object.Planet.Units.Count;
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);

            Assert.AreEqual(mockedLocation.Object.Planet.Units.Count, initial - 1);
        }

        [Test]
        public void TestTeleportUnit_ShouldSetUnitToTeleportCurrentLocationToDestination()
        {
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();

            var collection = new List<IUnit>() { };

            mockedDestinationPlanet.SetupGet(x => x.Galaxy.Name).Returns("Milky Way");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(collection);

            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedCoordinates=new Mock<IGPSCoordinates>();
            mockedCoordinates.SetupGet(x=>x.Longtitude).Returns(15);
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

            Assert.AreSame(mockedUnit.Object.CurrentLocation, mockedDestination.Object);
        }
    }
}
