using System;

    class FormattingNumbers
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());

        string binaryA = Convert.ToString(a, 2);
        binaryA = binaryA.PadLeft(10, '0');

        Console.WriteLine("{0,-10:X} {1} {2,10:0.00} {3,-10:F3}", a, binaryA, b, c);
    }
}