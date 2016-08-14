namespace ArmyOfCreatures.Tests.Extended
{
    using System.Collections.Generic;
    using System.Reflection;

    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class BattleManagerWithThreeArmiesTests
    {
        [Test]
        public void Constructor_ShouldCallBaseConstructorAndinstantiateAllProperties()
        {
            var creaturesFactoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(creaturesFactoryMock.Object, loggerMock.Object);

            var firstArmy = battleManager
                .GetType()
                .BaseType
                .GetField("firstArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(battleManager);

            var secondArmy = battleManager
                .GetType()
                .BaseType
                .GetField("secondArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(battleManager);

            var creaturesFactory = battleManager
                .GetType()
                .BaseType
                .GetField("creaturesFactory", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(battleManager);

            var logger = battleManager
                .GetType()
                .BaseType
                .GetField("logger", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(battleManager);

            Assert.That(firstArmy, Is.Not.Null.And.InstanceOf<ICollection<ICreaturesInBattle>>());
            Assert.That(secondArmy, Is.Not.Null.And.InstanceOf<ICollection<ICreaturesInBattle>>());
            Assert.That(creaturesFactory, Is.Not.Null.And.InstanceOf<ICreaturesFactory>());
            Assert.That(logger, Is.Not.Null.And.InstanceOf<ILogger>());
        }
    }
}