using System.Collections.Generic;
using System.Text;

using Dealership.Factories;
using Dealership.IO;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private const char ReportsCharSeparator = '#';
        private const int ReportsCharSeparatorCount = 20;

        private readonly IWriter writer;
        private readonly IDataProvider dataProvider;
        private readonly ICommandManager commandManager;
        private readonly IDealershipFactory dealershipFactory;

        public DealershipEngine(
            IWriter writer,
            IDataProvider dataProvider,
            ICommandManager commandManager,
            IDealershipFactory dealershipFactory)
        {
            this.writer = writer;
            this.dataProvider = dataProvider;
            this.commandManager = commandManager;
            this.dealershipFactory = dealershipFactory;
        }

        public void Start()
        {
            var commands = this.commandManager.ReadCommands();
            var commandResults = this.commandManager.ProcessCommands(commands);
            this.PrintReports(commandResults);
        }

        public void Reset()
        {
            this.dataProvider.WipeData();
            this.Start();
        }

        private void PrintReports(IEnumerable<string> reports)
        {
            var output = new StringBuilder();
            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string(ReportsCharSeparator, ReportsCharSeparatorCount));
            }

            this.writer.Write(output.ToString());
        }
    }
}