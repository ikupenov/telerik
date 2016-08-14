namespace ArmyOfCreatures.Tests.Console.Commands
{
    using System;

    using NUnit.Framework;

    using Moq;

    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class AddCommandsTests
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_IfBattleManagerIsNull()
        {
            var addCommand = new AddCommand();

            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(null, "10", "AncientBehemoth(1)"));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_IfArgumentIsNull()
        {
            var addCommand = new AddCommand();
            var battleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(battleManager.Object, null));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentException_IfThereAreLessThanTwoArguments()
        {
            var addCommand = new AddCommand();
            var battleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentException>(() => addCommand.ProcessCommand(battleManager.Object, "AncientBehemoth(1)"));
        }

        [Test]
        public void ProcessCommand_ShouldCallAddCreatures_WhenCommandIsParsedSuccessfully()
        {
            var addCommand = new AddCommand();
            var battleManager = new Mock<IBattleManager>();

            addCommand.ProcessCommand(battleManager.Object, "10", "AncientBehemoth(1)");

            battleManager.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Once());
        }
    }
}
