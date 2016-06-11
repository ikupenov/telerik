using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] allNumbers = new int[n];

        List<int> currentIncreasing = new List<int>();
        List<int> finalIncreasing = new List<int>();

        bool firstNumber = true;

        for (int i = 0; i < n; i++)
        {
            allNumbers[i] = int.Parse(Console.ReadLine());

            if (i > 0)
            {
                if (allNumbers[i - 1] + 1 == allNumbers[i])
                {
                    if (firstNumber == true)
                    {
                        currentIncreasing.Add(allNumbers[i - 1]);
                        firstNumber = false;
                    }

                    currentIncreasing.Add(allNumbers[i]);
                }
                else
                {
                    if (currentIncreasing.Count > finalIncreasing.Count)
                    {
                        finalIncreasing = new List<int>(currentIncreasing);
                    }

                    firstNumber = true;
                    currentIncreasing.Clear();
                    continue;
                }

                if (i + 1 == n && currentIncreasing.Count > finalIncreasing.Count)
                {
                    finalIncreasing = new List<int>(currentIncreasing);
                }
            }
        }

        Console.WriteLine(string.Join(", ", finalIncreasing));
    }
}