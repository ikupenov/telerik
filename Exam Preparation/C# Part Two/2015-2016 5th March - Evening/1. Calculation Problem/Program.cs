using System;
using System.Collections.Generic;

class Program
{
    static List<char> baseNumbers = new List<char>();
    
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        for (char j = 'a'; j <= 'w' ; j++)
        {
            baseNumbers.Add(j);
        }

        long sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            long decNum = BaseToDecimal(input[i]);
            sum += decNum;
        }

        string sumToBase = DecimalToBase(sum);
        Console.WriteLine("{0} = {1}", sumToBase, sum);
    }

    static long BaseToDecimal(string baseNum)
    {
        long toDec = 0;

        for (int i = 0; i < baseNum.Length; i++)
        {
            toDec *= 23;

            char currentLetter = baseNum[i];
            int index = baseNumbers.IndexOf(currentLetter);

            toDec += index;
        }

        return toDec;
    }

    static string DecimalToBase(long decNumber)
    {
        string DecToBase = string.Empty;

        while (decNumber > 0)
        {
            int remainder = (int)decNumber % 23;
            char letter = baseNumbers[remainder];

            DecToBase = letter + DecToBase;

            decNumber /= 23;
        }

        return DecToBase;
    }
}