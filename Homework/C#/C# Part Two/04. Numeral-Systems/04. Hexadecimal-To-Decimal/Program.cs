using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        string hexaDecimal = Console.ReadLine();

        Console.WriteLine(ToDecimal(hexaDecimal));
    }

    static BigInteger ToDecimal (string hexaDecimal)
    {
        BigInteger result = 0;
        int lastDigit = hexaDecimal.Length - 1;

        for (int i = 0; lastDigit >= 0; i++)
        {
            char lastChar = hexaDecimal[lastDigit];
            int toDigit = 0;

            switch (lastChar)
            {
                case '0': toDigit = 0; break;
                case '1': toDigit = 1; break;
                case '2': toDigit = 2; break;
                case '3': toDigit = 3; break;
                case '4': toDigit = 4; break;
                case '5': toDigit = 5; break;
                case '6': toDigit = 6; break;
                case '7': toDigit = 7; break;
                case '8': toDigit = 8; break;
                case '9': toDigit = 9; break;
                case 'A': toDigit = 10; break;
                case 'B': toDigit = 11; break;
                case 'C': toDigit = 12; break;
                case 'D': toDigit = 13; break;
                case 'E': toDigit = 14; break;
                case 'F': toDigit = 15; break;
            }

            result += toDigit * Power(16, i);
            lastDigit--;
        }

        return result;
    }

    static BigInteger Power (BigInteger number, BigInteger onPower)
    {
        BigInteger power = 1;
        
        for (int i = 0; i < onPower; i++)
        {
            power *= number;
        }

        return power;
    }
}