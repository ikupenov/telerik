namespace XMLProcessing.Contracts
{
    internal interface ICommand
    {
        string Execute(string parameter);
    }
}