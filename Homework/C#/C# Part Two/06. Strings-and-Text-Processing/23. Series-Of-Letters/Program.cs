using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var result = new StringBuilder();
        char lastLetter = ' ';

        for (int i = 0; i < input.Length; i++)
        {
            char currentLetter = input[i];

            if (currentLetter != lastLetter)
            {
                result.Append(currentLetter);
            }

            lastLetter = currentLetter;
        }

        Console.WriteLine(string.Join("", result));
    }
}