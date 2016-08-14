namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;

    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void AddCreatures_ShouldThrowArgumentNullException_IfIdentifierIsNull()
        {
            int count = 5;

            var creaturesFactoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManager(creaturesFactoryMock.Object, loggerMock.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, count));
        }

        [Test]
        public void AddCreatures_ShouldCallCreteCreatureFromFactory_IfInputIsValid()
        {
            int count = 5;
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            var creaturesFactoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManager(creaturesFactoryMock.Object, loggerMock.Object);

            try
            {
                battleManager.AddCreatures(creatureIdentifier, count);
            }
            catch { }

            creaturesFactoryMock.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void AddCreatures_ShouldCallWriteLineFromlogger_IfInputIsValid()
        {
            int count = 5;
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            var creature = new Angel();

            //var fixture = new Fixture();
            //var creature = fixture.Create<Angel>(); 

            var creaturesFactoryMock = new Mock<ICreaturesFactory>();
            creaturesFactoryMock.Setup(x => x
            .CreateCreature(It.IsAny<string>()))
            .Returns(() => creature);

            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManager(creaturesFactoryMock.Object, loggerMock.Object);

            battleManager.AddCreatures(creatureIdentifier, count);

            loggerMock.Verify(x => x.WriteLine(It.IsAny<String>()), Times.Once());
        }

        [Test]
        public void AddCreatures_ShouldThrowArgumentException_IfCreatureIsAddedToNonexistentArmy()
        {
            int count = 5;
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(3)");

            var creature = new Angel();

            //var fixture = new Fixture();
            //var creature = fixture.Create<Angel>(); 

            var creaturesFactoryMock = new Mock<ICreaturesFactory>();
            creaturesFactoryMock.Setup(x => x
            .CreateCreature(It.IsAny<string>()))
            .Returns(() => creature);

            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManager(creaturesFactoryMock.Object, loggerMock.Object);

            Assert.Throws<ArgumentException>(() => battleManager.AddCreatures(creatureIdentifier, count));
        }
    }
}
