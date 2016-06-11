using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    public static List<string> digits = new List<string>();
    public static List<string> base256 = new List<string>();

    static void Main()
    {
        FillBaseDigits();
        BigInteger decimalN = BigInteger.Parse(Console.ReadLine());

        do
        {
            string convert = (decimalN % 256).ToString();
            int remainder = int.Parse(convert);

            base256.Add(digits[remainder]);

            decimalN /= 256;
        } while (decimalN > 0);

        base256.Reverse();
        Console.WriteLine(string.Join("", base256));
    }

    static void FillBaseDigits()
    {
       for (char i = 'A'; i <= 'Z'; i++)
        {
            digits.Add(i.ToString());
        }

       for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits.Add(i.ToString() + j.ToString());
            }
        }
    }
}