using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static long ToDecimal(string input)
    {
        long decimalN = 0;

        foreach (var digit in input)
        {
            decimalN *= 23;
            decimalN += digit - 'a';
        }

        return decimalN;
    }

    static void Main()
    {
        var sum = Console.ReadLine().Split(' ').Select(ToDecimal).Sum();
        Console.WriteLine("{0} = {1}", string.Join("",SumToBase(sum)), sum);
    }

    static List<char> SumToBase(long sum)
    {
        var toBase = new List<char>();

        foreach (char digit in sum.ToString())
        {
            long remainder = sum % 23;

            toBase.Add(Convert.ToChar(remainder + 'a'));

            sum /= 23;

            if (sum == 0)
                break;
        }

        toBase.Reverse();
        return toBase;
    }
}