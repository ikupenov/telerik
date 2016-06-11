using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger binaryInput = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(string.Join("", ToHexadecimal(binaryInput)));
    }

    static BigInteger ToDecimal (BigInteger binaryNum)
    {
        BigInteger decimalValue = 0;
        BigInteger length = binaryNum.ToString().Length;

        for (int i = 0; i <= length; i++)
        {
            BigInteger lastDigit = binaryNum % 10;
            decimalValue += lastDigit * Power(2, i);

            binaryNum /= 10;
        }

        return decimalValue;
    }

    static List<string> ToHexadecimal(BigInteger binaryNum)
    {
        BigInteger decimalNumber = ToDecimal(binaryNum);
        var toHex = new List<string>();

        while (true)
        {
            BigInteger remainder = decimalNumber % 16;
            string toString = remainder.ToString();

            switch (toString)
            {
                case "0": toHex.Add("0"); break;
                case "1": toHex.Add("1"); break;
                case "2": toHex.Add("2"); break;
                case "3": toHex.Add("3"); break;
                case "4": toHex.Add("4"); break;
                case "5": toHex.Add("5"); break;
                case "6": toHex.Add("6"); break;
                case "7": toHex.Add("7"); break;
                case "8": toHex.Add("8"); break;
                case "9": toHex.Add("9"); break;
                case "10": toHex.Add("A"); break;
                case "11": toHex.Add("B"); break;
                case "12": toHex.Add("C"); break;
                case "13": toHex.Add("D"); break;
                case "14": toHex.Add("E"); break;
                case "15": toHex.Add("F"); break;
            }

            decimalNumber /= 16;

            if (decimalNumber == 0)
            {
                break;
            }
        }

        var reversed = new List<string>(Enumerable.Reverse(toHex));
        return reversed;
    }

    static BigInteger Power (BigInteger number, BigInteger power)
    {
        BigInteger onPower = 1;

        for (int i = 0; i < power; i++)
        {
            onPower *= number;
        }

        return onPower;
    }
}