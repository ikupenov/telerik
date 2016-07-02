using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        var numSys = new List<string>()
        {
            {"Rawr"},
            {"Rrrr"},
            {"Hsst"},
            {"Ssst"},
            {"Grrr"},
            {"Rarr"},
            {"Mrrr"},
            {"Psst"},
            {"Uaah"},
            {"Uaha"},
            {"Zzzz"},
            {"Bauu"},
            {"Djav"},
            {"Myau"},
            {"Gruh"}
        };

        long result = 0;

        for (int i = 0; i < input.Length; i += 4)
        {
            string current = input.Substring(i, 4);
            int index = numSys.IndexOf(current);

            result *= 15;
            result += index;
        }

        Console.WriteLine(result);
    }
}