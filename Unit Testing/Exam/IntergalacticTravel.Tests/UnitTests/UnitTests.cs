using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestPay_PassNullAsRecourses_ShouldThrowNullReferenceException()
        {
            var unit = new Unit(123, "Pesho");

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [TestCase((uint)2, (uint)3, (uint)4)]
        public void TestPay_PassValidCosts_ShouldReturnResourceObject(uint bronze, uint silver, uint gold)
        {
            var mockedResourcesToPay = new Mock<IResources>();
            var unit = new Unit(123, "Pesho");

            mockedResourcesToPay.SetupGet(x => x.BronzeCoins).Returns(bronze);
            mockedResourcesToPay.SetupGet(x => x.SilverCoins).Returns(silver);
            mockedResourcesToPay.SetupGet(x => x.GoldCoins).Returns(gold);

            var newResource = unit.Pay(mockedResourcesToPay.Object);

            Assert.AreEqual(newResource.BronzeCoins, bronze);
            Assert.AreEqual(newResource.SilverCoins, silver);
            Assert.AreEqual(newResource.GoldCoins, gold);
        }

        [TestCase((uint)2, (uint)3, (uint)4)]
        public void TestPay_PassValidCosts_ShouldPayCorrectly(uint bronze, uint silver, uint gold)
        {
            var mockedResourcesToPay = new Mock<IResources>();
            var unit = new Unit(123, "Pesho");

            mockedResourcesToPay.SetupGet(x => x.BronzeCoins).Returns(bronze);
            mockedResourcesToPay.SetupGet(x => x.SilverCoins).Returns(silver);
            mockedResourcesToPay.SetupGet(x => x.GoldCoins).Returns(gold);

            var unitGold = unit.Resources.GoldCoins;
            var unitSilver = unit.Resources.SilverCoins;
            var unitBronze = unit.Resources.BronzeCoins;

            unit.Pay(mockedResourcesToPay.Object);

            var newResources = unit.Resources;

            Assert.AreEqual(unit.Resources.BronzeCoins, unitBronze - bronze);
            Assert.AreEqual(unit.Resources.SilverCoins, unitSilver - silver);
            Assert.AreEqual(unit.Resources.GoldCoins, unitGold - gold);
        }
    }
}
