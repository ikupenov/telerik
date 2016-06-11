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

        int sum = 0;
        int finalSum = 0;

        List<int> tempSumElements = new List<int>();
        List<int> finalSumElements = new List<int>();

        for (int i = 0; i <= array.Length - k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                sum += array[i + j];
                tempSumElements.Add(array[i + j]);
            }

            if (sum > finalSum)
            {
                finalSumElements = new List<int>(tempSumElements);
                finalSum = sum;
            }

            tempSumElements.Clear();
            sum = 0;
        }

        Console.WriteLine(finalSum);
        Console.WriteLine(string.Join(", ", finalSumElements));
    }
}