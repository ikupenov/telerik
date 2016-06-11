using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int Remainder (int sum)
    {
        int remainder;

        if (sum > 9)
        {
            remainder = 1;
        }
        else
        {
            remainder = 0;
        }

        return remainder;
    }

    static void SumOfArrays(int[] firstArray, int[] secondArray)
    {
        int minLength = Math.Min(firstArray.Length, secondArray.Length);
        var sumOfArrays = new List<int>();

        int counter = 0;
        int remainder = 0;

        for (int i = 0; i < minLength; i++)
        {
            int sum = firstArray[i] + secondArray[i] + remainder;
            remainder = Remainder(sum);

            sumOfArrays.Add(sum % 10);
            counter++;
        }

        if (firstArray.Length > secondArray.Length)
        {
            for (int i = counter; i < firstArray.Length; i++)
            {
                int sum = firstArray[i] + remainder;
                remainder = Remainder(sum);

                sumOfArrays.Add(sum % 10);
            }
        }
        else if (secondArray.Length > firstArray.Length)
        {
            for (int i = counter; i < secondArray.Length; i++)
            {
                int sum = secondArray[i] + remainder;
                remainder = Remainder(sum);

                sumOfArrays.Add(sum % 10);
            }
        }

        Console.WriteLine(string.Join(" ", sumOfArrays));
    }

    static void Main()
    {
        string[] arraysLength = Console.ReadLine().Split(' ');
        int n = int.Parse(arraysLength[0]);
        int m = int.Parse(arraysLength[1]);

        string[] firstArrayInput = Console.ReadLine().Split(' ');
        string[] secondArrayInput = Console.ReadLine().Split(' ');

        int[] firstArray = new int[n];
        int[] secondArray = new int[m];

        for (int i = 0; i < n; i++)
        {
            firstArray[i] = int.Parse(firstArrayInput[i]);
        }

        for (int i = 0; i < m; i++)
        {
            secondArray[i] = int.Parse(secondArrayInput[i]);
        }

        SumOfArrays(firstArray, secondArray);
    }
}