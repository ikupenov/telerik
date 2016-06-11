using System;

class Program
{
    static void AppearanceCount(int x, int[] numbers)
    {
        int counter = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == x)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }

        int x = int.Parse(Console.ReadLine());

        AppearanceCount(x, numbers);
    }
}