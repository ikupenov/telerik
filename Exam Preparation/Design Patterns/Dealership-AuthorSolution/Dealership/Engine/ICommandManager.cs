using System.Collections.Generic;

namespace Dealership.Engine
{
    public interface ICommandManager
    {
        IEnumerable<ICommand> ReadCommands();

        IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands);
    }
}