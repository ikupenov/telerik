using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


class Program
{
    static void Main()
    {
        BigInteger binary = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(ToDecimal(binary));
    }

    static BigInteger ToDecimal (BigInteger binaryN)
    {
        BigInteger result = 0;
        BigInteger length = binaryN.ToString().Length;

        for (int i = 0; i <= length; i++)
        {
            BigInteger lastNum = binaryN % 10;
            result += lastNum * Power(2, i);

            binaryN /= 10;
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