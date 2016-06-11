using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static public int[] MaxElementInArray(int[] unsortedArray, int[] sortedArray, int position)
    {
        int maximalNumber = int.MinValue;

        for (int i = 0; i < unsortedArray.Length; i++)
        {
            if (unsortedArray[i] > maximalNumber)
            {
                maximalNumber = unsortedArray[i];
            }
        }

        int index = Array.IndexOf(unsortedArray, maximalNumber);
        unsortedArray[index] = int.MinValue;

        if (position > 0)
            SortArray(unsortedArray, sortedArray, maximalNumber, position);

        return sortedArray;
    }

    static void SortArray(int[] unsortedArray, int[] sortedArray, int maxNumber, int position)
    {
        position--;

        sortedArray[position] = maxNumber;
        MaxElementInArray(unsortedArray, sortedArray, position);
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] numbersInput = Console.ReadLine().Split(' ');
        int[] numbersToInt = new int[n];

        for (int i = 0; i < numbersToInt.Length; i++)
        {
            numbersToInt[i] = Convert.ToInt32(numbersInput[i]);
        }

        int position = numbersToInt.Length;
        int[] sortedArray = new int[n];

        int[] sorted = MaxElementInArray(numbersToInt, sortedArray, position);

        Console.WriteLine(string.Join(" ", sorted));
    }
}