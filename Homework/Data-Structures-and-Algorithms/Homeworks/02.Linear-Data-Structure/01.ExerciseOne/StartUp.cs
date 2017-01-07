using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseOne
{
    internal class StartUp
    {
        private static void Main()
        {
            var numbers = new List<int>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                int n = int.Parse(input);
                numbers.Add(n);

                input = Console.ReadLine();
            }

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
        }
    }
}
