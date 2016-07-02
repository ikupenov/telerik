using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var words = new List<string>();

        for (int i = 0; i < n; i++)
        {
            words.Add(Console.ReadLine());
        }

        for (int pos = 0; pos < n; pos++)
        {
            string word = words[pos];
            int insertToPos = word.Length % (n + 1);

            words[pos] = null;
            words.Insert(insertToPos, word);
            words.Remove(null);
        }

        int longestWord = words.Max(x => x.Length);
        var output = new StringBuilder();

        for (int i = 0; i < longestWord; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (words[j].Length > i)
                {
                    output.Append(words[j][i]);
                }
            }
        }

        Console.WriteLine(output);
    }
}