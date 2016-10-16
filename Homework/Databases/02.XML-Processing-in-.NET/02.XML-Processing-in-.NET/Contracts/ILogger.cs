namespace XMLProcessing.Contracts
{
    internal interface ILogger
    {
        void Write(string text);

        void WriteLine(string text);
    }
}