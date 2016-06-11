using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string hexaDecimal = Console.ReadLine();

        Console.WriteLine(string.Join("", ToBinary(hexaDecimal)).TrimStart('0'));
    }

    static List<string> ToBinary(string hexaDec)
    {
        var toBinary = new List<string>();

        for (int i = 0; i < hexaDec.Length; i++)
        {
            char symbol = hexaDec[i];

            switch (symbol)
            {
                case '0': toBinary.Add("0000"); break;
                case '1': toBinary.Add("0001"); break;
                case '2': toBinary.Add("0010"); break;
                case '3': toBinary.Add("0011"); break;
                case '4': toBinary.Add("0100"); break;
                case '5': toBinary.Add("0101"); break;
                case '6': toBinary.Add("0110"); break;
                case '7': toBinary.Add("0111"); break;
                case '8': toBinary.Add("1000"); break;
                case '9': toBinary.Add("1001"); break;
                case 'A': toBinary.Add("1010"); break;
                case 'B': toBinary.Add("1011"); break;
                case 'C': toBinary.Add("1100"); break;
                case 'D': toBinary.Add("1101"); break;
                case 'E': toBinary.Add("1110"); break;
                case 'F': toBinary.Add("1111"); break;
            }
        }

        return toBinary;
    }
}