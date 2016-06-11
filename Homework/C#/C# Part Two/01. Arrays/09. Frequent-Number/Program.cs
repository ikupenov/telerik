using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = new int[n];

        for (int i = 0; i < input.Length; i++)
        {
            input[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(input);

        int counter = 1;
        int finCounter = 1;
        int? number = null;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                counter++;
            }

            if (counter > finCounter)
            {
                finCounter = counter;
                number = input[i];
            }

            if (input[i] != input[i - 1])
            {
                counter = 1;
            }
        }

        Console.WriteLine("{0} ({1} times)", number, finCounter);
    }
}