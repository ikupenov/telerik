using System;

class Program
{
    static void Main()
    {
        string pattern = Console.ReadLine().ToLower();
        string text = Console.ReadLine().ToLower();

        int start = 0;
        int counter = 0;

        while (true)
        {
            int index = text.IndexOf(pattern, start);

            if (index >= 0)
                counter++;
            else
                break;

            start = index + pattern.Length;
        }

        Console.WriteLine(counter);
    }
}