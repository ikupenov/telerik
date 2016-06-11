using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Reverse(string input)
    {
        input = input.Replace(" ", string.Empty);

        char[] reversed = input.ToCharArray();
        Array.Reverse(reversed);

        Console.WriteLine(reversed);
    }

    static void Main()
    {
        string notReversed = Console.ReadLine();

        Reverse(notReversed);
    }
}