namespace XMLProcessing.Root
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    internal class CommandHandler : ICommandHandler
    {
        public string Handle(string command)
        {
            var commandName = this.GetCommandName(command);

            var assembly = this.GetType().GetTypeInfo().Assembly;
            var commandType = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(i => i == typeof(ICommand)))
                .First(type => type.Name.ToLower().Contains(commandName.ToLower()));

            var commandInstance = Activator.CreateInstance(commandType) as ICommand;

            var commandParameters = this.GetCommandParameters(command);
            var output = commandInstance.Execute(commandParameters);

            return output;
        }

        private string GetCommandName(string command)
        {
            var commandName = command.Split('(')[0].Trim();

            return commandName;
        }

        private string GetCommandParameters(string command)
        {
            var commandParameters = command.Split('(')[1].Trim().TrimEnd(')');

            return commandParameters;
        }
    }
}