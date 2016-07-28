using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using CreaturesArmy.Test.MockedClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesArmy.Test
{
    [TestFixture]
    public class BattleManagerAttackTests
    {
        [Test]
        public void AttackCreatures_WhenAttackerCreatureIdentifierIsNull_SHouldTHrowArgument()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var manager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            
            Assert.Throws<ArgumentException>(() => manager.Attack(null, identifier));
        }

        [Test]
        public void AttackCreatures_WhenDefenderCreatureIdentifierIsNull_SHouldTHrowArgument()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var manager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<ArgumentException>(() => manager.Attack(identifier, null));
        }

        [Test]
        public void AttackCreatures_WhenAttackIsSuccessful_ShouldCallWriteLIne4Times()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var manager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var creature = new Angel();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            manager.AddCreatures(identifier, 1);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            manager.Attack(identifier, identifier);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
