using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static List<int> digits = new List<int>();
    public static int cypherLength = 0;

    public static StringBuilder decoded = new StringBuilder();

    public static string message = string.Empty;
    public static string cypher = string.Empty;

    static void Main()
    {
        string input = Console.ReadLine();

        //Find Cypher' Length
        FindCypherLength(input);

        //Decode & Separate
        Decode(input);

        //Decrypt
        string decrpytedMessage = Decrypt(message, cypher);

        Console.WriteLine(decrpytedMessage);
    }

    static void FindCypherLength (string original)
    {
        int previous = original.Length - 1;
        char currentCh = original[previous];

        while(char.IsDigit(currentCh))
        {
            digits.Add(currentCh - '0');

            previous--;
            currentCh = original[previous];
        }

        digits.Reverse();

        for (int i = 0; i < digits.Count; i++)
        {
            cypherLength *= 10;
            cypherLength += digits[i];
        }
    }

    static void Decode (string original)
    {
        int totalLength = original.Length - digits.Count;
        int repeat = 0;

        for (int i = 0; i < totalLength; i++)
        {
            char currentCh = original[i];

            if (char.IsDigit(currentCh))
            {
                repeat *= 10;
                repeat += currentCh - '0';
            }
            else
            {
                decoded.Append(currentCh, Math.Max(1, repeat));
                repeat = 0;
            }
        }

        int messageLength = decoded.Length - cypherLength;

        message = decoded.ToString().Substring(0, messageLength);
        cypher = decoded.ToString().Substring(messageLength, cypherLength);
    }

    static string Decrypt (string message, string cypher)
    {
        var decrypted = new StringBuilder();

        if (message.Length == cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                char messageSymb = message[i];
                char cypherSymb = cypher[i];

                char result = Convert.ToChar(((messageSymb - 'A') ^ (cypherSymb - 'A')) + 'A');
                decrypted.Append(result);
            }
        }

        else if (message.Length > cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                char messageSymb = message[i];

                int cypherPos = i % cypher.Length;
                char cypherSymb = cypher[cypherPos];

                char result = Convert.ToChar(((messageSymb - 'A') ^ (cypherSymb - 'A')) + 'A');
                decrypted.Append(result);
            }
        }

        else if (cypher.Length > message.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                char messageSymb = message[i];
                char cypherSymb = cypher[i];

                char result = Convert.ToChar(((messageSymb - 'A') ^ (cypherSymb - 'A')) + 'A');

                if (message.Length + i < cypher.Length)
                {
                    cypherSymb = cypher[message.Length + i];
                    result = Convert.ToChar(((result - 'A') ^ (cypherSymb - 'A')) + 'A');
                }

                decrypted.Append(result);
            }
        }

        return decrypted.ToString();
    }
}