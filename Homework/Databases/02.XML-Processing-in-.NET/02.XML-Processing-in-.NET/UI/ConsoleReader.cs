namespace XMLProcessing.UI
{
    using System;

    using Contracts;

    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
