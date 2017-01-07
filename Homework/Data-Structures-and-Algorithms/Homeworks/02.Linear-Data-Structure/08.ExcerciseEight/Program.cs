using System;
using System.Linq;

namespace ExcerciseEight
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

            var majorantNumber = numbers
                .GroupBy(x => x)
                .FirstOrDefault(x => x.Count() >= numbers.Length / 2 + 1)
                ?.Key;

            Console.WriteLine(majorantNumber?.ToString() ?? "No majorant number");
        }
    }
}
