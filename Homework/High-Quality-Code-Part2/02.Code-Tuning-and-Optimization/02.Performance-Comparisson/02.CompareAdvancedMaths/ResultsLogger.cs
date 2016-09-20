namespace CompareAdvancedMaths
{
    using System;

    public static class ResultsLogger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogResultTime(string time, string numberType)
        {
            Console.WriteLine($"{numberType} result time -> {time}");
        }
    }
}