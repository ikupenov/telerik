using System.Collections.Generic;

using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.IO;

using Moq;
using NUnit.Framework;

namespace Dealership.Tests.Engine
{
    [TestFixture]
    public class CommandManagerTests
    {
        [Test]
        public void ReadCommands_ShouldCallReadLine_IfCalled()
        {
            var readerMock = new Mock<IReader>();
            var commandHandlerMock = new Mock<ICommandHandler>();
            var dealershipFactoryMock = new Mock<IDealershipFactory>();

            var commandManager = new CommandManager(
                readerMock.Object,
                commandHandlerMock.Object,
                dealershipFactoryMock.Object);

            commandManager.ReadCommands();

            readerMock.Verify(x => x.ReadLine(), Times.Once);
        }

        [Test]
        public void ReadCommands_ShouldCallCreateCommand_IfInputIsNotNullOrEmpty()
        {
            var readerMock = new Mock<IReader>();
            var commandHandlerMock = new Mock<ICommandHandler>();
            var dealershipFactoryMock = new Mock<IDealershipFactory>();

            readerMock
                .SetupSequence(x => x.ReadLine())
                .Returns("SomeString");

            var commandManager = new CommandManager(
                readerMock.Object,
                commandHandlerMock.Object,
                dealershipFactoryMock.Object);

            commandManager.ReadCommands();

            dealershipFactoryMock.Verify(x => x.CreateCommand(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ProcessCommands_ShouldCallHandleCommand_IfInputCommandsAreNotNullOrEmpty()
        {
            var readerMock = new Mock<IReader>();
            var commandHandlerMock = new Mock<ICommandHandler>();
            var dealershipFactoryMock = new Mock<IDealershipFactory>();

            var commandMock = new Mock<ICommand>();
            var commands = new List<ICommand>() { commandMock.Object };

            var commandManager = new CommandManager(
               readerMock.Object,
               commandHandlerMock.Object,
               dealershipFactoryMock.Object);

            commandManager.ProcessCommands(commands);

            commandHandlerMock.Verify(x => x.HandleCommand(It.IsAny<ICommand>()), Times.Once);
        }
    }
}