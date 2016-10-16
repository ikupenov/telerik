namespace XMLProcessing.UI
{
    using System;

    using Contracts;

    internal class ConsoleLogger : ILogger
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}