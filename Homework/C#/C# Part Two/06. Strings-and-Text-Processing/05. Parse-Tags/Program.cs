using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string openTag = "<upcase>";
        string closeTag = "</upcase>";

        while (true)
        {
            string text = string.Empty;

            int openIndex = input.IndexOf(openTag, 0);
            int closeIndex = input.IndexOf(closeTag, 0);

            if (openIndex < 0 || closeIndex < 0)
                break;

            for (int i = openIndex; i < closeIndex + closeTag.Length; i++)
                text += input[i];

            input = input.Replace(text, text.ToUpper());
            input = input.Replace(openTag.ToUpper(), "");
            input = input.Replace(closeTag.ToUpper(), "");
        }

        Console.WriteLine(input);
    }
}