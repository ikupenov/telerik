using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void AsWord (int a)
    {
        string asWord = "";

        switch (a)
        {
            case 0: asWord = "zero"; break;
            case 1: asWord = "one"; break;
            case 2: asWord = "two"; break;
            case 3: asWord = "three"; break;
            case 4: asWord = "four"; break;
            case 5: asWord = "five"; break;
            case 6: asWord = "six"; break;
            case 7: asWord = "seven"; break;
            case 8: asWord = "eight"; break;
            case 9: asWord = "nine"; break;
        }

        Console.WriteLine(asWord);
    }


    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        AsWord(input % 10);
    }
}