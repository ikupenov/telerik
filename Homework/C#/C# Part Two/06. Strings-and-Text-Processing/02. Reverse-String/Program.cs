using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var input = Console
                    .ReadLine()
                    .Reverse();

        Console.WriteLine(string.Join("", input));
    }
}