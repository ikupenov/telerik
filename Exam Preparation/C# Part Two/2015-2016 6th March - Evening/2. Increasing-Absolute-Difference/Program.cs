using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            var numbers = Console.ReadLine()
                                 .Split(' ')
                                 .Select(long.Parse)
                                 .ToArray();

            var mainAbsDiff = FindMainAbsDiff(numbers);

            Console.WriteLine(CheckIfSequence(mainAbsDiff));
        }
    }

    static List<long> FindMainAbsDiff(long[] numbers)
    {
        var mainAbsDiff = new List<long>();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            mainAbsDiff.Add(Math.Abs(numbers[i] - numbers[i + 1]));
        }

        return mainAbsDiff;
    }

    static bool CheckIfSequence(List<long> mainAbsDiff)
    {
        bool isSeq = true;

        for (int i = 0; i < mainAbsDiff.Count - 1; i++)
        {
            long currentAbsDiff = Math.Abs(mainAbsDiff[i] - mainAbsDiff[i + 1]);

            if (currentAbsDiff != 0 && currentAbsDiff != 1 || mainAbsDiff[i] > mainAbsDiff[i + 1])
            {
                isSeq = false;
                break;
            }
        }

        return isSeq;
    }
}