using Dealership.Engine;

namespace Dealership.CommandHandlers.Base
{
    public interface ICommandHandler
    {
        void SetCommandHandlerSuccessor(ICommandHandler commandHandler);

        string HandleCommand(ICommand command);
    }
}