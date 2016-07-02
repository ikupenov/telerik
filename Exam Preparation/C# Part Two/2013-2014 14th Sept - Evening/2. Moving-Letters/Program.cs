using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');

        Console.WriteLine(MovingLetters(ExtractingLetters(input)));
    }

    static StringBuilder ExtractingLetters(string[] input)
    {
        var builder = new StringBuilder();
        var longestWord = input.Max(x => x.Length);

        for (int i = 0; i < longestWord; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                string word = input[j];
                int wordLength = word.Length;

                if (wordLength > i)
                {
                    char lastLetter = word[wordLength - 1 - i];
                    builder.Append(lastLetter);
                }
            }
        }

        return builder;
    }

    static StringBuilder MovingLetters(StringBuilder builder)
    {
        int totalLength = builder.Length;

        for (int i = 0; i < totalLength; i++)
        {
            char currentLetter = Convert.ToChar(builder[i]);
            int index = char.ToLower(currentLetter) - 'a' + 1;
            int position = (index + i) % totalLength;

            builder.Remove(i, 1);
            builder.Insert(position, currentLetter.ToString());
        }

        return builder;
    }
}