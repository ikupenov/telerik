using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[] numbers = new double[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = double.Parse(Console.ReadLine());
        }

        double x = double.Parse(Console.ReadLine());

        int min = 0;
        int max = n - 1;

        while (true)
        {
            int mid = (min + max) / 2;

            if (max < min)
            {
                Console.WriteLine("-1");
                return;
            }

            else if (numbers[mid] == x)
            {
                Console.WriteLine(mid);
                return;
            }
                     
            else
            {
                if (numbers[mid] < x)
                {
                    min = mid + 1;
                }

                else if (numbers[mid] > x)
                {
                    max = mid - 1;
                }
            }           
        }      
    }
}