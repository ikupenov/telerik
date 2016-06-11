using System;

//../\..
//./  \.
/// /\ \
//\ \/ /
//.\  /.
//..\/..

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int evenOrOddCounter = 0;
        int evenOrOdd = 0;


        //top
        for (int i = 0; i < n / 2; i++)
        {
            //dots
            for (int leftDots = 1; leftDots <= (n / 2) - 1 - i; leftDots++)
            {
                Console.Write(".");
            }

            //dashLeft
            for (int middleLeft = 0; middleLeft <= i; middleLeft++)
            {
                if (middleLeft % 2 == 0)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            //dashRight
            for (int middleRight = 0; middleRight <= i; middleRight++)
            {
                if (middleRight % 2 == evenOrOdd)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            //dots  
            for (int rightDots = 1; rightDots <= (n / 2) - 1 - i; rightDots++)
            {
                Console.Write(".");
            }

            if (i % 2 == 0)
            {
                evenOrOdd = 1;
            }
            else
            {
                evenOrOdd = 0;
            }
            Console.WriteLine();
        }

        evenOrOdd = 0;

        //bot
        for (int i = 0; i < n / 2; i++)
        {
            //dots
            for (int leftDots = 1; leftDots <= i; leftDots++)
            {
                Console.Write(".");
            }

            //dashLeft
            int secondHalf = 0;

            for (int middleLeft = n / 2 - i; middleLeft >= 1; middleLeft--)
            {
                if (secondHalf % 2 == 0)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write(" ");
                }

                secondHalf++;
            }

            int rightDashSecondHalf = 0;

            //dashRight
            for (int middleRight = n / 2 - i; middleRight >= 1; middleRight--)
            {
                if (rightDashSecondHalf % 2 == evenOrOdd)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(" ");
                }

                rightDashSecondHalf++;
            }

            //dots
            for (int rightDots = 1; rightDots <= i; rightDots++)
            {
                Console.Write(".");
            }

            if (evenOrOddCounter % 2 == 0)
            {
                evenOrOdd = 1;
            }
            else
            {
                evenOrOdd = 0;
            }

            evenOrOddCounter++;
            Console.WriteLine();
        }
    }
}
