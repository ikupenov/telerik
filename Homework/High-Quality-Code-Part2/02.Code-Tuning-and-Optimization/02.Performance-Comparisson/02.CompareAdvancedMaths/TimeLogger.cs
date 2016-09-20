namespace CompareAdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class TimeLogger
    {
        private const long ExecutionTimes = (long)1e7;

        public static void LogExecutionTime(string numberType, Action action)
        {
            var stopWatch = Stopwatch.StartNew();

            for (var i = 0; i < ExecutionTimes; i++)
            {
                action();
            }

            ResultsLogger.LogResultTime(stopWatch.Elapsed.ToString(), numberType);
        }
    }
}