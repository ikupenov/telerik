using System;

class Trapezoids
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        bool aCheck = a > -500 && a < 500;
        bool bCheck = b > -500 && b < 500;
        bool hCheck = h > -500 && h < 500;

        bool isWrong = aCheck == false || bCheck == false || hCheck == false;

        while (isWrong)
        {
            Console.WriteLine("Enter numbers between -500 and 500");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            h = double.Parse(Console.ReadLine());

            aCheck = a > -500 && a < 500;
            bCheck = b > -500 && b < 500;
            hCheck = h > -500 && h < 500;

            if (aCheck == true && bCheck == true && hCheck == true)
            {
                isWrong = false;
            }
        }

        double divideBy2 = (a + b) / 2;
        double area = divideBy2 * h;

        Console.WriteLine("{0:0.0000000}", area);
    }
}