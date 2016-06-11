using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        double currentSum = 0;
        double maximalSum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            currentSum = 0;

            for (int j = i; j < array.Length; j++)
            {
                currentSum += array[j];

                if (currentSum > maximalSum)
                {
                    maximalSum = currentSum;
                }
            }         
        }

        Console.WriteLine(maximalSum);
    }
}
