using System;
using System.Linq;

namespace ExcerciseSeven
{
    class Program
    {
        static void Main()
        {
            var numbers = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numberOccurrences = numbers
                .GroupBy(x => x)
                .OrderBy(x => x.Count());

            foreach (var group in numberOccurrences)
            {
                Console.WriteLine($"{group.Key} -> {group.Count()} times");
            }
        }
    }
}
