using System;
using NUnit.Framework;
using ArmyOfCreatures.Logic;

namespace CreaturesArmy.Test
{
    [TestFixture]
    public class TestCreaturesFactory
    {
        [TestCase("Angel")]
        [TestCase("CyclopsKing")]
        [TestCase("Goblin")]
        [TestCase("Griffin")]
        [TestCase("WolfRaider")]
        [TestCase("AncientBehemoth")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void TestCreateCreature_InitializesCreatureCorrectly_ShouldReturnTrue(string name)
        {
            var factory = new NewCreatureFactory();

            var creature = factory.CreateCreature(name);

            Assert.AreEqual(name, creature.GetType().Name);
        }

        [TestCase("Batka")]
        public void TestCreateCreature_PassInvalidName_ShouldThrow(string name)
        {
            var factory = new NewCreatureFactory();

            Assert.Throws<ArgumentException>(() => factory.CreateCreature(name));
        }

        [TestCase("Batka")]
        public void TestCreateCreature_PassInvalidName_ShouldThrowWithValidMessage(string name)
        {
            var factory = new NewCreatureFactory();

            try
            {
                factory.CreateCreature(name);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid creature type \"Batka\"!", ex.Message);
            }
        }
    }
}
