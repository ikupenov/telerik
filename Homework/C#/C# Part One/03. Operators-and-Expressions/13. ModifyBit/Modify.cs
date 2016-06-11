using System;

class Modify
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        uint bit = uint.Parse(Console.ReadLine());


        uint mask = bit << p;
        uint maskAndN = mask | n;

        Console.WriteLine(maskAndN);

    }
}
