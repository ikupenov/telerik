using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int year = int.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(year);

        if (isLeap == true)
        {
            Console.WriteLine("Leap");
        }
        else
        {
            Console.WriteLine("Common");
        }
    }
}