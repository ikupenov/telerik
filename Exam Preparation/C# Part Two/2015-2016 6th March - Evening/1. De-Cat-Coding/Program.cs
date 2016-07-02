using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static void Main()
    {
        var base21 = Console.ReadLine().Split(' ');

        for (int i = 0; i < base21.Length; i++)
        {
            BigInteger decimalN = ToDecimal(base21[i]);
            var base26 = To26Based(decimalN);

            Console.Write(string.Join("", base26) + " ");
        }

        Console.WriteLine();
    }

    static BigInteger ToDecimal (string base21)
    {
        BigInteger decimalN = 0;

        for (int i = 0; i < base21.Length; i++)
        {
            decimalN *= 21;
            decimalN += base21[i] - 'a';
        }

        return decimalN;
    }

    static List<char> To26Based (BigInteger decimalN)
    {
        var base26 = new List<char>();

        while (true)
        {
            string convert = (decimalN % 26).ToString();
            int remainder = int.Parse(convert);

            base26.Add((char)(remainder + 'a'));

            decimalN /= 26;
            if (decimalN <= 0)
                break;
        }

        base26.Reverse();
        return base26;
    }
}
