using System.Collections.Generic;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.IO;

using Moq;
using NUnit.Framework;

namespace Dealership.Tests.Engine
{
    [TestFixture]
    public class DealershipEngineTests
    {
        [Test]
        public void Start_ShouldCallCommandManagerReadCommands_IfCalled()
        {
            var writerMock = new Mock<IWriter>();
            var dataProviderMock = new Mock<IDataProvider>();
            var commandManagerMock = new Mock<ICommandManager>();
            var dealershipFactoryMock = new Mock<IDealershipFactory>();

            var dealershipEngine = new DealershipEngine(
                writerMock.Object, 
                dataProviderMock.Object, 
                commandManagerMock.Object, 
                dealershipFactoryMock.Object);
            
            dealershipEngine.Start();

            commandManagerMock.Verify(x => x.ReadCommands(), Times.Once);
        }

        [Test]
        public void Start_ShouldCallCommandManagerProcessCommand_IfCalled()
        {
            var writerMock = new Mock<IWriter>();
            var dataProviderMock = new Mock<IDataProvider>();
            var commandManagerMock = new Mock<ICommandManager>();
            var dealershipFactoryMock = new Mock<IDealershipFactory>();

            var dealershipEngine = new DealershipEngine(
                writerMock.Object,
                dataProviderMock.Object,
                commandManagerMock.Object,
                dealershipFactoryMock.Object);

            dealershipEngine.Start();

            commandManagerMock.Verify(x => x.ProcessCommands(It.IsAny<IEnumerable<ICommand>>()), Times.Once);
        }

        [Test]
        public void Reset_ShouldCallDataProviderWipeData_IfCalled()
        {
            var writerMock = new Mock<IWriter>();
            var dataProviderMock = new Mock<IDataProvider>();
            var commandManagerMock = new Mock<ICommandManager>();
            var dealershipFactoryMock = new Mock<IDealershipFactory>();

            var dealershipEngine = new DealershipEngine(
                writerMock.Object,
                dataProviderMock.Object,
                commandManagerMock.Object,
                dealershipFactoryMock.Object);

            dealershipEngine.Start();
            dealershipEngine.Reset();

            dataProviderMock.Verify(x => x.WipeData(), Times.Once);
        }
    }
}