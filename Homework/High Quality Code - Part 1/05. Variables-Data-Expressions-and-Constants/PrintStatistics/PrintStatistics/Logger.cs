namespace PrintStatistics
{
    using System;

    using Contracts;

    public class Logger : ILogger
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}