using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger decimalN = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(string.Join("", ToHexaDecimal(decimalN)));
    }

    static List<string> ToHexaDecimal(BigInteger decimalN)
    {
        var hexaDecimal = new List<string>();

        while (true)
        {
            BigInteger remainder = decimalN % 16;
            string toString = remainder.ToString();

            switch (toString)
            {
                case "0": hexaDecimal.Add("0"); break;
                case "1": hexaDecimal.Add("1"); break;
                case "2": hexaDecimal.Add("2"); break;
                case "3": hexaDecimal.Add("3"); break;
                case "4": hexaDecimal.Add("4"); break;
                case "5": hexaDecimal.Add("5"); break;
                case "6": hexaDecimal.Add("6"); break;
                case "7": hexaDecimal.Add("7"); break;
                case "8": hexaDecimal.Add("8"); break;
                case "9": hexaDecimal.Add("9"); break;
                case "10": hexaDecimal.Add("A"); break;
                case "11": hexaDecimal.Add("B"); break;
                case "12": hexaDecimal.Add("C"); break;
                case "13": hexaDecimal.Add("D"); break;
                case "14": hexaDecimal.Add("E"); break;
                case "15": hexaDecimal.Add("F"); break;
            }

            decimalN /= 16;

            if (decimalN == 0)
            {
                break;
            }
        }

        var reversed = new List<string>(Enumerable.Reverse(hexaDecimal));
        return reversed;
    }
}