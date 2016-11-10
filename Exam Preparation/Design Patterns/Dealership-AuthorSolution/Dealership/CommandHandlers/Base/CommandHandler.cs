using System;

using Dealership.Engine;

namespace Dealership.CommandHandlers.Base
{
    public abstract class CommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command ({0})!";

        protected ICommandHandler commandHandlerSuccessor;

        public void SetCommandHandlerSuccessor(ICommandHandler commandHandlerSuccessor)
        {
            this.commandHandlerSuccessor = commandHandlerSuccessor;
        }

        public string HandleCommand(ICommand command)
        {
            if (this.CanHandle(command))
            {
                return this.Handle(command);
            }
            else if (this.commandHandlerSuccessor != null)
            {
                return this.commandHandlerSuccessor.HandleCommand(command);
            }
            else
            {
                return string.Format(InvalidCommand, command.Name);
            }
        }

        protected void ValidateRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException();
            }
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command);
    }
}