using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        var arr = new List<char> { 'f', 'b', 'o', 'm', 'l', 'p', 'h' };
        long result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];

            if (char.IsLower(current))
            {
                long index = arr.IndexOf(current);

                result *= 7;
                result += index;
            }
        }

        Console.WriteLine(result);
    }
}