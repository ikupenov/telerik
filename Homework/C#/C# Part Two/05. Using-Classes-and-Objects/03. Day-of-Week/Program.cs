using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        DateTime now = new DateTime();
        now = DateTime.Now;

        Console.WriteLine(now.DayOfWeek);
    }
}