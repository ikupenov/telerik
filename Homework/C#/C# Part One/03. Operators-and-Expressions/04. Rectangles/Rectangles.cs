using System;

class Rectangles
{
    static void Main()
    {
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());

        decimal perimeter = 2 * (width + height);
        decimal area = width * height;

        Console.WriteLine("{0:0.00} {1:0.00}", area, perimeter);
    }
}
