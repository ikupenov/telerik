using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] firstArray = new int[n];
        int[] secondArray = new int[n];

        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < secondArray.Length; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool equal = true;
        int arraysLength = firstArray.Length;

        for (int i = 0; i < arraysLength; i++)
        {
            if (firstArray[i] > secondArray[i] || secondArray[i] > firstArray[i])
            {
                equal = false;
                break;
            }
        }

        if (equal == true)
        {
            Console.WriteLine("Equal");
        }
        else
        {
            Console.WriteLine("Not equal");
        }
    }
}