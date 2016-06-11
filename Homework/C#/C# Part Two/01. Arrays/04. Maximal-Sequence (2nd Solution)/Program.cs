using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        int counter = 1;
        int finalCounter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0)
            {
                array[i] = int.Parse(Console.ReadLine());
                continue;
            }

            array[i] = int.Parse(Console.ReadLine());

            if (array[i] == array[i - 1])
            {
                counter++;
            }

            if (counter > finalCounter)
            {
                finalCounter = counter;
            }

            if (array[i] != array[i - 1])
            {
                counter = 1;
            }
        }

        Console.WriteLine(finalCounter);
    }
}