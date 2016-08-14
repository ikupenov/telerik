namespace ArmyOfCreatures.Tests.Extended
{
    using System;

    using NUnit.Framework;

    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        [Test]
        public void CreateCreature_ShouldThrowArgumentExceptionWithCorrectMsg_IfStringIsInvalid()
        {
            var creaturesFactory = new ExtendedCreaturesFactory();

            var expectedExceptionMsg = "Invalid creature type";
            var nonexistentCreatureName = "nonexistent";

            Assert.That(() =>
                creaturesFactory.CreateCreature(nonexistentCreatureName),
                Throws.ArgumentException.With.Message.Contains(expectedExceptionMsg));

            //var ex = Assert.Throws<ArgumentException>(() => creaturesFactory.CreateCreature(nonexistentCreatureName));
            //Assert.IsTrue(ex.Message.Contains(expectedExceptionMsg));
        }

        [TestCase("Devil")]
        [TestCase("Angel")]
        [TestCase("Goblin")]
        [TestCase("Griffin")]
        [TestCase("WolfRaider")]
        [TestCase("CyclopsKing")]
        [TestCase("AncientBehemoth")]
        public void CreateCreature_ShouldReturnCorrespondingCreatureBasedOnInput_IfMethodIsInvoked(string creatureName)
        {
            var creaturesFactory = new ExtendedCreaturesFactory();

            var creature = creaturesFactory.CreateCreature(creatureName);

            Assert.IsInstanceOf<Creature>(creature);
        }
    }
}
