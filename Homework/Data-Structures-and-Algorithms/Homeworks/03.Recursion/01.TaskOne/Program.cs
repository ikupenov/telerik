using System;

namespace TaskOne
{
    class Program
    {
        private static int n;
        private static int[] arr;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            arr = new int[n];

            SimulateLoop();
        }

        private static void SimulateLoop(int index = 0)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    SimulateLoop(index + 1);
                }
            }
        }
    }
}
