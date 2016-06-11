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
            array[i] = double.Parse(Console.ReadLine());
        }

        int highestCounter = 1;

        for (int i = 0; i < array.Length; i++)
        {
            int counter = 1;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] > array[i])
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter > highestCounter)
            {
                highestCounter = counter;
            }
        }

        Console.WriteLine(highestCounter);
    }
}