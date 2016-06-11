using System;

class CircleRectangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        bool wrongInput = x < -1000 || x > 1000 || y < -1000 || y > 1000;

        while (wrongInput)
        {
            Console.WriteLine("You must enter numbers between -1000 and 1000");
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());

            wrongInput = x < -1000 || x > 1000 || y < -1000 || y > 1000;

            if (wrongInput != true)
            {
                wrongInput = false;
            }
        }

        //------------Circle------------Start

        double circleX = 1.0;
        double circleY = 1.0;
        double circleR = 1.5;

        double firstBrack = Math.Pow(circleX - x, 2);
        double secondBrack = Math.Pow(circleY - y, 2);
        double circleD = Math.Sqrt(firstBrack + secondBrack);

        bool isInside = circleD <= circleR;

        if (isInside)
        {
            Console.Write("inside circle");
        }
        else
        {
            Console.Write("outside circle");
        }

        //------------Circle-------------End


        //-----------Rectangle----------Start

        bool insideRectangle = x >= -1 && x <= 6 && y >= -1 && y <= 1;

        if (insideRectangle)
        {
            Console.Write(" inside rectangle");
        }
        else
        {
            Console.Write(" outside rectangle");
        }

        //-----------Rectangle-----------End
    }
}

