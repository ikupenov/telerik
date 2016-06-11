using System;

class Program
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        int c = first.CompareTo(second);

        if (c == -1)
        {
            Console.WriteLine("<");
        }
        else if (c == 1)
        {
            Console.WriteLine(">");
        }
        else if (c == 0)
        {
            Console.WriteLine("=");
        }
    }
}
