using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger decimalN = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(string.Join("", ToBinary(decimalN)));
    }

    static List<char> ToBinary(BigInteger decimalN)
    {
        string binary = "";

        while (true)
        {
            int result = (int)decimalN % 2;
            binary += Convert.ToString(result);

            decimalN /= 2;

            if (decimalN == 0)
            {
                break;
            }
        }

        var reversed = new List<char>(binary.Reverse());
        return reversed;
    }
}