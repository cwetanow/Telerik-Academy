using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesArmy.Test
{
    [TestFixture]
    public class TestBattleManager
    {
        [Test]
        public void AddCreatures_WhenCreatureIdentifierIsNull_SHouldTHrowArgumentNull()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var manager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.AddCreatures(null, 1));
        }

        [Test]
        public void AddCreatures_WhenValidIdentifierIsPassed_FactoryShouldCallCreateCreature()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var manager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            var fixture = new Fixture();

            fixture.Customizations.Add(new TypeRelay(typeof(Creature), typeof(Angel)));

            var creature = fixture.Create<Creature>();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);
            mockedFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));

        }

        [Test]
        public void AddCreatures_WhenValidIdentifierIsPassed_LoggerSHouldCallWriteLine()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var manager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            var fixture = new Fixture();

            fixture.Customizations.Add(new TypeRelay(typeof(Creature), typeof(Angel)));

            var creature = fixture.Create<Creature>();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);

            mockedLogger.Verify(x=>x.WriteLine(It.IsAny<string>()),Times.Once);
        }
    }
}
