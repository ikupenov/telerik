using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] unordered = new int[n];

        for (int i = 0; i < n; i++)
        {
            unordered[i] = int.Parse(Console.ReadLine());
        }

        int tempMin = 0;
        int permMin = int.MaxValue;
        List<int> ordered = new List<int>();


        for (int i = 0; i < unordered.Length; i++)
        {
            for (int j = 0; j < unordered.Length; j++)
            {
                tempMin = Math.Min(unordered[i], unordered[j]);

                if (tempMin < permMin)
                {
                    permMin = tempMin;
                }
            }

            int index = Array.IndexOf(unordered, permMin);
            ordered.Add(unordered[index]);
            unordered[index] = int.MaxValue;
            permMin = int.MaxValue;
        }

        //Console.WriteLine(string.Join(", ", ordered));

        for (int i = 0; i < ordered.Count; i++)
        {
            Console.WriteLine(ordered[i]);
        }
    }
}