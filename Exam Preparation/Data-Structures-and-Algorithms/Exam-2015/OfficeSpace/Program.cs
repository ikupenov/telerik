using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeSpace
{
    class Program
    {
        private static Dictionary<Task, List<Task>> tasks;
        private static Dictionary<int, int> requiredMinutes;

        private static bool hasCycle = false;

        static void Main()
        {
            tasks = new Dictionary<Task, List<Task>>();
            requiredMinutes = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            int[] vertces = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                var task = new Task(i + 1, vertces[i]);

                if (!tasks.ContainsKey(task))
                {
                    tasks.Add(task, new List<Task>());
                }

                int[] dependencies = Console.ReadLine().Split().Select(int.Parse).ToArray();
                foreach (var dependency in dependencies)
                {
                    if (dependency != 0)
                    {
                        var dependencyTask = new Task(dependency, vertces[dependency - 1]);

                        if (!tasks.ContainsKey(dependencyTask))
                        {
                            tasks.Add(dependencyTask, new List<Task>());
                        }

                        tasks[task].Add(dependencyTask);
                    }
                }
            }

            int minMinutesRequired = 0;
            foreach (var task in tasks)
            {
                int minutesRequired = FindRequiredMinutes(task.Key);

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

        static int FindRequiredMinutes(Task task)
        {
            if (requiredMinutes.ContainsKey(task.Number))
            {
                int value = requiredMinutes[task.Number];

                if (value < 0)
                {
                    hasCycle = true;
                }

                return requiredMinutes[task.Number];
            }

            requiredMinutes.Add(task.Number, -1);

            var dependencies = tasks[task];
            foreach (var dependency in dependencies)
            {
                int totalTime = task.InitialRequiredTime + FindRequiredMinutes(dependency);
                if (totalTime > task.MinRequiredTime)
                {
                    task.MinRequiredTime = totalTime;
                    requiredMinutes[task.Number] = totalTime;
                }
            }

            requiredMinutes[task.Number] = task.MinRequiredTime;

            return task.MinRequiredTime;
        }
    }

    class Task
    {
        public Task(int taskNumber, int requiredTime)
        {
            this.Number = taskNumber;
            this.InitialRequiredTime = requiredTime;
            this.MinRequiredTime = requiredTime;
        }

        public int Number { get; set; }

        public int InitialRequiredTime { get; set; }

        public int MinRequiredTime { get; set; }

        public override int GetHashCode()
        {
            return this.Number;
        }

        public override bool Equals(object obj)
        {
            Task task = obj as Task;
            return this.Number.Equals(task.Number);
        }
    }
}
