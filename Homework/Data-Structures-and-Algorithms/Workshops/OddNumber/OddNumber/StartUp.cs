using System;

namespace OddNumber
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                long number = long.Parse(Console.ReadLine());
                result ^= number;
            }

            Console.WriteLine(result);

            //var numbersCount = new Dictionary<long, int>();

            //for (int i = 0; i < n; i++)
            //{
            //    long number = long.Parse(Console.ReadLine());
            //    if (!numbersCount.ContainsKey(number))
            //    {
            //        numbersCount.Add(number, 0);
            //    }

            //    numbersCount[number]++;
            //}

            //foreach (var pair in numbersCount)
            //{
            //    if (pair.Value % 2 != 0)
            //    {
            //        Console.WriteLine(pair.Key);
            //        break;
            //    }
            //}
        }
    }
}
