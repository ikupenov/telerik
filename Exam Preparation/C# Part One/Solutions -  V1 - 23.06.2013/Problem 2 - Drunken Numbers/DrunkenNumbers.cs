using System;
using System.Numerics;

class DrunkenNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int mitkoTotal = 0;
        int vladkoTotal = 0;

        for (int i = 0; i < n; i++)
        {
            int beers = int.Parse(Console.ReadLine());

            if (beers < 0)
            {
                beers *= -1;
            }

            int length = (int)Math.Ceiling(Math.Log10(beers));

            if (length == 0)
            {
                mitkoTotal += beers;
                vladkoTotal += beers;
                continue;
            }

            else if (length % 2 == 0)
            {
                for (int v = 1; v <= length / 2; v++)
                {
                    vladkoTotal += beers % 10;
                    beers /= 10;
                }

                for (int m = 1; m <= length / 2; m++)
                {
                    mitkoTotal += beers % 10;
                    beers /= 10;
                }
            }

            else
            {
                for (int v = 1; v <= (length / 2) + 1; v++)
                {
                    vladkoTotal += beers % 10;

                    if (v < (length / 2) + 1)
                    {
                        beers /= 10;
                    }
                }

                for (int m = 1; m <= (length / 2) + 1; m++)
                {
                    mitkoTotal += beers % 10;
                    beers /= 10;
                }
            }
        }


        if (mitkoTotal > vladkoTotal)
        {
            Console.WriteLine("M {0}", mitkoTotal - vladkoTotal);
        }

        else if (vladkoTotal > mitkoTotal)
        {
            Console.WriteLine("V {0}", vladkoTotal - mitkoTotal);
        }

        else if (vladkoTotal == mitkoTotal)
        {
            Console.WriteLine("No {0}", vladkoTotal + mitkoTotal);
        }
    }
}