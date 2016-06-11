using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();

        foreach (char symb in input)
        {
            int ascii = symb;
            string output = string.Format("{0:X}", ascii);
            Console.Write("\\u" + output.PadLeft(4, '0'));
        }

        Console.WriteLine();
    }
}