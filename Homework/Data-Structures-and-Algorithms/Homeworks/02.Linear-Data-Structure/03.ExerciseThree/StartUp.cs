using System;
using System.Collections.Generic;

namespace ExerciseThree
{
    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            var numbers = new List<int>();

            while (!string.IsNullOrEmpty(input))
            {
                int number = int.Parse(input);
                numbers.Add(number);

                input = Console.ReadLine();
            }

            numbers.Sort();
        }
    }
}
