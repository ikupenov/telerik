using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        char[] charArray = input.ToCharArray();
        char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        char[] alphaBig = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        List<int> result = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            int index = Array.IndexOf(alpha, charArray[i]);

            if (index == -1)
            {
                index = Array.IndexOf(alphaBig, charArray[i]);
            }

            result.Add(index);
        }

        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}