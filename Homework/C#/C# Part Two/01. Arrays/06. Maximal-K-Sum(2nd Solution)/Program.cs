using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxNumber = 0;
        int permMaxNumber = int.MinValue;

        List<int> numbers = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length; j++)
            {
                maxNumber = Math.Max(array[i], array[j]);

                if (maxNumber > permMaxNumber)
                {
                    permMaxNumber = maxNumber;
                }
            }

            int index = Array.IndexOf(array, permMaxNumber);
            numbers.Add(array[index]);

            if (numbers.Count == k)
            {
                Console.WriteLine(string.Join(", ", numbers));
                return;
            }

            array[index] = -1;
            permMaxNumber = int.MinValue;
        }
    }
}

