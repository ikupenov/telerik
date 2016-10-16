namespace XMLProcessing.Contracts
{
    internal interface ICommandHandler
    {
        string Handle(string command);
    }
}