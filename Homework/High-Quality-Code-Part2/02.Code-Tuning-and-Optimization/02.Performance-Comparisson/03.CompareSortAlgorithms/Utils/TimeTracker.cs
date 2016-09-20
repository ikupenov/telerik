namespace CompareSortAlgorithms.Utils
{
    using System;
    using System.Diagnostics;

    public class TimeTracker
    {
        private const long ExecutionTimes = 100000;

        public static void MeasureTime(string sortingType, Action sortingMethod)
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < ExecutionTimes; i++)
            {
                sortingMethod();
            }

            Logger.Log($"{sortingType} execution time -> {stopwatch.Elapsed.ToString()}");
        }
    }
}