using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        n++;

        int howMany = 0;

        for (int i = 0; n < m; n++)
        {
            if (n % 5 == 0)
            {
                //Console.Write("{0} ", n);
                howMany++;
            }
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(howMany);

        if (howMany == 0)
        {
            //Console.WriteLine("think why");
        }

        Console.WriteLine();
    }
}