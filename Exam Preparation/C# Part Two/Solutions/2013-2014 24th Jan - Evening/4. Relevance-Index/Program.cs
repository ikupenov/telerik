using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string searchWord = Console.ReadLine();
        int numberOfP = int.Parse(Console.ReadLine());

        var text = new string[numberOfP];
        var sortedText = new SortedDictionary<int, int>();

        char[] separator = { ' ', ',', '.', '(', ')', ';', '-', '!', '?' };

        for (int pos = 0; pos < numberOfP; pos++)
        {
            text[pos] = Console.ReadLine();
            var words = text[pos].Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int counter = 0;

            for (int current = 0; current < words.Length; current++)
            {
                if (searchWord.ToLower() == words[current].ToLower())
                {
                    words[current] = searchWord.ToUpper();
                    counter++;
                }
            }

            text[pos] = string.Format(string.Join(" ", words));
            sortedText.Add(counter, pos);
        }

        for (int i = numberOfP - 1; i >= 0; i--)
        {
            int index = sortedText.Values.ElementAt(i);
            Console.WriteLine(text[index]);
        }
    }
}