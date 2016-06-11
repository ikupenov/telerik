using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        double[] array = new double[n];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = double.Parse(Console.ReadLine());
        }

        double highestNumber = double.MinValue;
        double sum = 0;

        for (int i = 0; ;i++)
        {
            if (i == k)
            {
                Console.WriteLine(sum);
                return;
            }

            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] > highestNumber)
                {
                    highestNumber = array[j];
                }
            }

            sum += highestNumber;

            int index = Array.IndexOf(array, highestNumber);
            array[index] = double.MinValue;

            highestNumber = double.MinValue;
        }
    }
}