using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        var sequence = Console.ReadLine().Split(' ');
        var text = new StringBuilder();

        for (int i = 0; i < sequence.Length; i++)
        {
            text.Append(Convert.ToString(byte.Parse(sequence[i]), 2)
                               .PadLeft(8, '0'));
        }

        int lines = int.Parse(Console.ReadLine());
        var symbols = new Dictionary<byte, char>();

        for (int i = 0; i < lines; i++)
        {
            string both = Console.ReadLine();

            char symbol = both[0];

            string number = both.Substring(1);
            byte freqency = byte.Parse(number);

            symbols.Add(freqency, symbol);
        }

        var split = text.ToString().Split(new char[] { '0' },
                                    StringSplitOptions.RemoveEmptyEntries);
        text.Clear();

        for (int i = 0; i < split.Length; i++)
        {
            byte sum = 0;

            for (int j = 0; j < split[i].Length; j++)
            {
                sum += (byte)(split[i][j] - '0');
            }

            char symbol;
            symbols.TryGetValue(sum, out symbol);
            text.Append(symbol);
        }

        Console.WriteLine(text);
    }
}