using System;
using System.Text.RegularExpressions;
using System.Numerics;

class TheHorror
{
    static void Main()
    {
        string input = Console.ReadLine();
        //input = Regex.Replace(input, "[^0-9]", "");

        BigInteger evenNumbers = 0;
        BigInteger sum = 0;

        char getLast = '0';

        for (int i = 0; i < input.Length; i++)
        {
            getLast = input[i];

            if (getLast != '1' && getLast != '2' && getLast != '3' && getLast != '4' && getLast != '5' && getLast != '6' && getLast != '7' && getLast != '8' && getLast != '9' && getLast != '0')
            {
                continue;
            }

            BigInteger digit = (BigInteger)char.GetNumericValue(getLast);

            if (i % 2 == 0)
            {
                sum += digit;
                evenNumbers++;
            }
        }

        Console.WriteLine("{0} {1}",evenNumbers, sum);
    }
}