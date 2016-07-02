using System;
using System.Linq;

class Program
{
    static void Main()
    {
        long[] input = Console.ReadLine()
                              .Split(' ')
                              .Select(long.Parse)
                              .ToArray();

        long position = 1;
        long absolute = 0;
        long result = 0;

        while (true)
        {
            //Break if out of range
            if (position >= input.Length)
                break;

            //Find absolute difference
            if (input[position] > input[position - 1])
            {
                absolute = input[position] - input[position - 1];
            }
            else
            {
                absolute = input[position - 1] - input[position];
            }

            //If absolute difference is even, add to result
            if (absolute != 0 && absolute % 2 == 0)
                result += absolute;

            //Position in array
            if (absolute % 2 == 0)
                position += 2;
            else
                position++;
        }

        Console.WriteLine(result);
    }
}