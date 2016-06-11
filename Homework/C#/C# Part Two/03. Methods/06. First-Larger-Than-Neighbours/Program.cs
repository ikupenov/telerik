using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Index (int[] array)
    {
        int index = -1;

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i] > array[i - 1] && array[i] > array[i + 1])
            {
                index = Array.IndexOf(array, array[i]);
                break;
            }
        }

        Console.WriteLine(index);
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }

        Index(numbers);
    }
}