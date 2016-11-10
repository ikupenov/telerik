using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Dealership.CommandHandlers.Base;
using Dealership.Factories;
using Dealership.IO;

namespace Dealership.Engine
{
    public class CommandManager : ICommandManager
    {
        private readonly IReader reader;
        private readonly ICommandHandler commandHandler;
        private readonly IDealershipFactory dealershipFactory;

        public CommandManager(
            IReader reader,
            ICommandHandler commandHandler,
            IDealershipFactory dealershipFactory)
        {
            this.reader = reader;
            this.commandHandler = commandHandler;
            this.dealershipFactory = dealershipFactory;
        }

        public IEnumerable<ICommand> ReadCommands()
        {
            var commands = new HashSet<ICommand>();

            string currentLine = this.reader.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                ICommand currentCommand = this.dealershipFactory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.reader.ReadLine();
            }

            return commands;
        }

        public IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new Collection<string>();

            foreach (var command in commands)
            {
                try
                {
                    string report = this.commandHandler.HandleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }
    }
}