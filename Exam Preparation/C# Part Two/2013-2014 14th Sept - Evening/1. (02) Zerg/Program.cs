using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        var numSys = new Dictionary<string, int>()
        {
            {"Rawr", 0},
            {"Rrrr", 1},
            {"Hsst", 2},
            {"Ssst", 3},
            {"Grrr", 4},
            {"Rarr", 5},
            {"Mrrr", 6},
            {"Psst", 7},
            {"Uaah", 8},
            {"Uaha", 9},
            {"Zzzz", 10},
            {"Bauu", 11},
            {"Djav", 12},
            {"Myau", 13},
            {"Gruh", 14}
        };

        long result = 0;

        for (int i = 0; i < input.Length; i += 4)
        {
            string current = input.Substring(i, 4);
            int index = numSys[current];

            result *= 15;
            result += index;
        }

        Console.WriteLine(result);
    }
}