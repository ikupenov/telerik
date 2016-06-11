using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void printName (string name)
    {
        Console.WriteLine("Hello, " + name + "!");
    }


    static void Main()
    {
        string inputName = Console.ReadLine();
        printName(inputName);
    }
}