using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeSpace
{
    class Program
    {
        private static int[] taskMinutes;
        private static List<int>[] taskDependencies;

        private static int[] requiredMinutes = new int[50];
        private static bool hasCycle = false;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            taskMinutes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            taskDependencies = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                taskDependencies[i] = Console.ReadLine()
                    .Split()
                    .Select(x => int.Parse(x) - 1)
                    .ToList();
            }

            int minMinutesRequired = 0;
            for (int i = 0; i < n; i++)
            {
                int minutesRequired = FindRequiredMinutes(i);

                if (hasCycle)
                {
                    Console.WriteLine(-1);
                    return;
                }

                if (minutesRequired > minMinutesRequired)
                {
                    minMinutesRequired = minutesRequired;
                }
            }

            Console.WriteLine(minMinutesRequired);
        }

        static int FindRequiredMinutes(int taskNumber)
        {
            if (requiredMinutes[taskNumber] < 0)
            {
                hasCycle = true;
            }

            if (requiredMinutes[taskNumber] != 0)
            {
                return requiredMinutes[taskNumber];
            }

            if (taskDependencies[taskNumber].Count == 1 && taskDependencies[taskNumber][0] == -1)
            {
                return taskMinutes[taskNumber];
            }

            requiredMinutes[taskNumber] = -1;

            int maxTotalTime = 0;
            var dependencies = taskDependencies[taskNumber];
            foreach (var dependency in dependencies)
            {
                int totalTime = FindRequiredMinutes(dependency);
                maxTotalTime = Math.Max(totalTime, maxTotalTime);
            }

            requiredMinutes[taskNumber] = taskMinutes[taskNumber] + maxTotalTime;
            return requiredMinutes[taskNumber];
        }
    }
}
