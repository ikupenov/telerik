using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        List<int> sumNumbers = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            int sum = 0;
            sumNumbers.Clear();

            for (int j = i; j < numbers.Length; j++)
            {
                sum += numbers[j];
                sumNumbers.Add(numbers[j]);

                if (sum > s)
                {
                    break;
                }

                if (sum == s)
                {
                    Console.WriteLine(string.Join(", ", sumNumbers));
                    return;
                }
            }
        }
    }
}