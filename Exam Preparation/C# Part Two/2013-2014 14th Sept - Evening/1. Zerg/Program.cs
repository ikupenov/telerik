using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine()
                              .Replace("Rawr", "0")
                              .Replace("Rrrr", "1")
                              .Replace("Hsst", "2")
                              .Replace("Ssst", "3")
                              .Replace("Grrr", "4")
                              .Replace("Rarr", "5")
                              .Replace("Mrrr", "6")
                              .Replace("Psst", "7")
                              .Replace("Uaah", "8")
                              .Replace("Uaha", "9")
                              .Replace("Zzzz", "A")
                              .Replace("Bauu", "B")
                              .Replace("Djav", "C")
                              .Replace("Myau", "D")
                              .Replace("Gruh", "E");

        long result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            result *= 15;

            if (input[i] >= '0' && input[i] <= '9')
            {
                result += input[i] - '0';
            }
            else
            {
                result += input[i] - 'A' + 10;
            }

        }

        Console.WriteLine(result);
    }
}