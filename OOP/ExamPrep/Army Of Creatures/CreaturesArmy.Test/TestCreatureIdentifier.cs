using ArmyOfCreatures.Logic.Battles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesArmy.Test
{
    [TestFixture]
    public class TestCreatureIdentifier
    {
        [Test]
        public void CreatureIdentifier_WhenNullPassed_ShouldThrowArgumentNullEx()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifier_WhenInvalidValuePassedToParse_ShouldThrow()
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(test)"));
        }

        [Test]
        public void CreatureIdentifier_WhenInvalidValuePassedWithoutBrackets_ShouldThrowIndexOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel"));
        }

        [Test]
        public void CreatureIdentifier_WhenValidValuePassed_ShouldReturnExpectedType()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.IsInstanceOf<CreatureIdentifier>(identifier);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValuePassed_ShouldReturnExpectedCreature()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.AreEqual("Angel",identifier.CreatureType);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValuePassed_ShouldReturnExpectedArmy()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.AreEqual(1, identifier.ArmyNumber);
        }

        [TestCase("Angel(1)")]
        public void CreatureIdentifier_ToString_ShouldReturnValidToString(string input)
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString(input);

            Assert.AreEqual(input,identifier.ToString());
        }
    }
}
