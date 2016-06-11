using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = input.Replace("\\", "");
        Console.WriteLine(input.PadRight(20, '*'));
    }
}