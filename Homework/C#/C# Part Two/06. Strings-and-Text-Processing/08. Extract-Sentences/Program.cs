using System;
using System.Linq;

class Program
{
    static char[] ExtractSeparators(string text)
    {
        char[] separator = text.Where(x => !char.IsLetter(x))
                                .Distinct()
                                .ToArray();
        return separator;
    }

    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string[] textSplit = text.Split('.');
        char[] separator = ExtractSeparators(text);

        foreach (var sentence in textSplit)
        {
            string[] wordsInSentence = sentence.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (var wordInSentence in wordsInSentence)
            {
                if (word.ToLower() == wordInSentence.ToLower())
                {
                    Console.Write(sentence + ".");
                    break;
                }
            }
        }

        Console.WriteLine();
    }
}