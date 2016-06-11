using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static long Power(long number, long power)
    {
        long result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= number;
        }

        return result;
    }

    static void Main()
    {
        int currentBase = int.Parse(Console.ReadLine());
        string number = Console.ReadLine();
        int toBase = int.Parse(Console.ReadLine());

        long decimalNumber;

        if (currentBase == 10)
        {
            decimalNumber = long.Parse(number);
        }
        else
        {
            decimalNumber = BaseToDecimal(number, currentBase);
        }

        Console.WriteLine(DecimalToBase(decimalNumber, toBase));
    }

    static long BaseToDecimal (string number, int currentBase)
    {
        long result = 0;
        long digit = 0;
        number = number.ToUpper();

        for (int i = 0; i < number.Length; i++)
        {
            int position = number.Length - i - 1;

            if (number[position] >= '0' && number[position] <= '9')
            {
                digit = number[position] - '0';
            }
            else if (number[position] >= 'A' && number[position] <= 'F')
            {
                digit = number[position] - 'A' + 10; 
            }

            result += digit * Power(currentBase, i);
        }

        return result;
    }

    static string DecimalToBase (long decimalNumber, long toBase)
    {
        string result = "";

        while (decimalNumber > 0)
        {
            long digit = decimalNumber % toBase;

            if (digit >= 0 && digit <= 9)
            {
                result = (char)(digit + '0') + result;
            }
            else if (digit >= 10 && digit <= 15)
            {
                result = (char)(digit - 10 + 'A') + result;
            }

            decimalNumber /= toBase;
        }

        return result;
    }
}
