using System;

class GoikoTower
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int row = 2;
        int addition = 2;

        for (int i = 1; i <= n; i++)
        {

            string dotsOrDash = "..";

            //outside
            for (int firstDots = 1; firstDots <= n - i; firstDots++)
            {
                Console.Write(".");
            }

            for (int firstSlash = 1; firstSlash <= 1; firstSlash++)
            {
                Console.Write("/");
            }


            //inside

            if (row == i)
            {
                dotsOrDash = "--";
                row += addition;
                addition++;
            }

            for (int middle = 1; middle < i; middle++)
            {
                Console.Write(dotsOrDash);
            }

            //for (int midDots = 1; midDots <= i; midDots++)
            //{
            //    Console.Write("..");
            //}


            //outside
            for (int secondSlash = 1; secondSlash <= 1; secondSlash++)
            {
                Console.Write("\\");
            }

            for (int secondDots = 1; secondDots <= n - i; secondDots++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }
    }
}