using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcerciseSix
{
    class Program
    {
        static void Main()
        {
            var numbers = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var numberOccurrences = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (!numberOccurrences.ContainsKey(number))
                {
                    numberOccurrences.Add(number, 0);
                }

                numberOccurrences[number]++;
            }

            foreach (var number in numberOccurrences.Keys)
            {
                if (numberOccurrences[number] % 2 != 0)
                {
                    numbers.RemoveAll(x => x == number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
