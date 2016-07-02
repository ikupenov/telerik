using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());

        var system = new List<string>
        {
            "LON+",
            "VK-",
            "*ACAD",
            "^MIM",
            "ERIK|",
            "SEY&",
            "EMY>>",
            "/TEL",
            "<<DON"
         };

        var toBase = new List<string>();

        while (true)
        {
            string convert = (number % 9).ToString();
            int remainder = int.Parse(convert);

            toBase.Add(system[remainder]);

            number /= 9;

            if (number <= 0)
                break;
        }

        toBase.Reverse();
        Console.WriteLine(string.Join("", toBase));
    }
}