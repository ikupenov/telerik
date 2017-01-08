using System;

namespace Words
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            var prefixes = GetPrefixes(word);
            var sufixes = GetSufixes(word);

            int totalMatches = 0;
            for (int i = 0; i < word.Length - 1; i++)
            {
                string prefix = prefixes[i];
                string sufix = sufixes[sufixes.Length - 1 - i];

                int[] prefixFailLinks = Precompute(prefix);
                int prefixMatches = GetPatternMatches(prefix, text, prefixFailLinks);

                int[] sufixFailLinks = Precompute(sufix);
                int sufixMatches = GetPatternMatches(sufix, text, sufixFailLinks);

                totalMatches += prefixMatches * sufixMatches;
            }

            int[] wordFailLinks = Precompute(word);
            totalMatches += GetPatternMatches(word, text, wordFailLinks);

            Console.WriteLine(totalMatches);
        }

        static string[] GetPrefixes(string word)
        {
            string[] wordPrefixes = new string[word.Length - 1];

            for (int i = 1; i < word.Length; i++)
            {
                string prefix = word.Substring(0, i);
                wordPrefixes[i - 1] = prefix;
            }

            return wordPrefixes;
        }

        static string[] GetSufixes(string word)
        {
            string[] wordSufixes = new string[word.Length - 1];

            for (int i = word.Length - 1, j = 1; j < word.Length; i--, j++)
            {
                string sufix = word.Substring(i, j);
                wordSufixes[j - 1] = sufix;
            }

            return wordSufixes;
        }

        static int[] Precompute(string pattern)
        {
            int patternLen = pattern.Length;

            int[] failLinks = new int[patternLen + 1];
            failLinks[0] = -1;

            for (int i = 1; i < patternLen; i++)
            {
                int j = failLinks[i];
                while (j >= 0 && pattern[j] != pattern[i])
                {
                    j = failLinks[j];
                }
                failLinks[i + 1] = j + 1;
            }

            return failLinks;
        }

        static int GetPatternMatches(string pattern, string text, int[] failLinks)
        {
            int textLen = text.Length;
            int patternLen = pattern.Length;

            int totalMatches = 0;
            int matched = 0;

            for (int i = 0; i < textLen; i++)
            {
                while (matched >= 0 && text[i] != pattern[matched])
                {
                    matched = failLinks[matched];
                }

                matched++;

                if (matched == patternLen)
                {
                    totalMatches++;
                    matched = failLinks[matched];
                }
            }

            return totalMatches;
        }
    }
}
