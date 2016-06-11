using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var sum = Console
                    .ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .Sum();

        Console.WriteLine(sum);
    }
}