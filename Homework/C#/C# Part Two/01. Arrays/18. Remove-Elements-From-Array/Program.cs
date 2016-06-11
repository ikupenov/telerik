using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] originalArray = new int[n];
        int[] secondaryArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            originalArray[i] = int.Parse(Console.ReadLine());
            secondaryArray[i] = 1;
        }

        for (int mainIndex = 1; mainIndex < n; mainIndex++)
        {
            for (int leftNumbers = 0; leftNumbers < mainIndex; leftNumbers++)
            {
                if (originalArray[leftNumbers] <= originalArray[mainIndex] && secondaryArray[mainIndex] < secondaryArray[leftNumbers] + 1)
                {
                    secondaryArray[mainIndex] = secondaryArray[leftNumbers] + 1;
                }
            }
        }

        int maxSubSeq = secondaryArray.Max();

        Console.WriteLine(n - maxSubSeq);
    }
}