using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] intArray = new int[n];

        List<int> currentEqualNumbers = new List<int>();
        List<int> finalEqualNumbers = new List<int>();

        bool firstNumber = true;

        for (int i = 0; i < n; i++)
        {
            intArray[i] = int.Parse(Console.ReadLine());

            if (i > 0)
            {
                if (intArray[i] == intArray[i - 1])
                {
                    if (firstNumber == true)
                    {
                        currentEqualNumbers.Add(intArray[i - 1]);
                        firstNumber = false;
                    }
                    

                    currentEqualNumbers.Add(intArray[i]);
                }

                else
                {
                    if (currentEqualNumbers.Count > finalEqualNumbers.Count)
                    {
                        finalEqualNumbers = new List<Int32>(currentEqualNumbers);
                    }

                    currentEqualNumbers.Clear();
                    firstNumber = true;             
                }

                if (i + 1 == n && currentEqualNumbers.Count > finalEqualNumbers.Count)
                {
                    finalEqualNumbers = new List<Int32>(currentEqualNumbers);
                }
            }
        }

        Console.WriteLine(string.Join(", ", finalEqualNumbers));
    }
}