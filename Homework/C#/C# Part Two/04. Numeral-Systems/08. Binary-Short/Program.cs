using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static BigInteger Power(BigInteger number, BigInteger power)
    {
        BigInteger onPower = 1;

        for (int i = 0; i < power; i++)
        {
            onPower *= number;
        }

        return onPower;
    }

    static void Main()
    {
        BigInteger integer = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(string.Join("", ToBinary(integer)));
    }

    static BigInteger[] ToBinary(BigInteger decimalNumber)
    {
        var binary = new List<BigInteger>();

        //Check if number is negative
        bool negative = false;
        if (decimalNumber < 0)
        {
            negative = true;
            decimalNumber *= -1;
        }

        //Decimal to Binary
        for (int i = 0; decimalNumber > 0; i++)
        {
            BigInteger remainder = decimalNumber % 2;
            binary.Add(remainder);

            decimalNumber /= 2;
        }

        //Pad with zeros
        for (int i = 16 - binary.Count; i > 0; i--)
        {
            binary.Add(0);
        }

        var reverse = new List<BigInteger>(Enumerable.Reverse(binary));

        if (negative == true)
        {
            return ToNegativeBinary(reverse);
        }
        else
        {
            BigInteger[] toArray = new BigInteger[16];
            for (int i = 0; i < 16; i++)
            {
                toArray[i] = reverse[i];
            }
            return toArray;
        }
    }

    //Convert to negative Binery
    static BigInteger[] ToNegativeBinary(List<BigInteger> positiveBinary)
    {
        var swap = new BigInteger[16];

        for (int i = 0; i < 16; i++)
        {
            if (positiveBinary[i] == 0)
            {
                swap[i] = 1;
            }
            else if (positiveBinary[i] == 1)
            {
                swap[i] = 0;
            }
        }

        for (int i = 15; i >= 0; i--)
        {
            if (swap[i] == 1)
            {
                swap[i] = 0;
            }
            else if (swap[i] == 0)
            {
                swap[i] = 1;
                break;
            }
        }

        return swap;
    }
}