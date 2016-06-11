using System;

class Program
{
    static void Main()
    {
        string URL = Console.ReadLine();
        Uri parse = new Uri(URL);

        Console.WriteLine("[protocol] = {0}", parse.Scheme);
        Console.WriteLine("[server] = {0}", parse.Authority);
        Console.WriteLine("[resource] = {0}", parse.AbsolutePath);
    }
}
