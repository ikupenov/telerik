using System;

class PointInCircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        double xCo = 0;
        double yCo = 0;

        double r = 2;

        //Valid Number Check-START

        bool xCheck = x > -1000 && x < 1000;
        bool yCheck = y > -1000 && y < 1000;

        bool isUserWrong = xCheck == false || yCheck == false;

        while (isUserWrong)
        {
            Console.WriteLine("Numbers must be between -1000 and 1000");
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());

            if (x > -1000 && x < 1000 && y > -1000 && y < 1000)
            {
                isUserWrong = false;
            }
        }

        //Valid Number Check-END

        double firstBrack = Math.Pow(xCo - x, 2);
        double secondBrack = Math.Pow(yCo - y, 2);

        double d = Math.Sqrt(firstBrack + secondBrack);

        bool insideOrOutside = d <= r;

        if (insideOrOutside)
        {
            Console.WriteLine(string.Format("yes {0:0.00}", d));
        }

        else
        {
            Console.WriteLine(string.Format("no {0:0.00}", d));
        }
    }
}