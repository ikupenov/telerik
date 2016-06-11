using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var convert = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

        long toDec = 0;

        for (int i = 0; i < input.Length; i += 3)
        {
            toDec *= 13;

            string substring = input.Substring(i, 3);
            int index = convert.IndexOf(substring);

            toDec += index;
        }

        Console.WriteLine(toDec);
    }
}