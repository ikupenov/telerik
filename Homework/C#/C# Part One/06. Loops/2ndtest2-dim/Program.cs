using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 1;

        int topIncreaser = 0;
        int topRow = n - n;
        int topUntil = 1;

        int rightIncreaser = 1;
        int rightDecreaser = 1;
        int rightCol = (n - n) + rightIncreaser;

        int botDecreaser = 1;
        int botRowDecreaser = 2;
        int botRow = n - 2;
        int botIncreaser = 0;
        int botTest = 2;

        int leftRowIncreaser = 0;
        int leftIncreaser = 1;
        int leftCol = n - 2;
        int leftN = 1;

        int[,] matrix = new int[n, n];


        while (counter <= n * n)

        {
            //======================================================================================================================


            for (int topCol = (n - n) + topIncreaser; topRow <= (n - topUntil); topRow++) // top 
            {
                if (counter == n * n + 1)
                {
                    break;
                }

                matrix[topCol, topRow] = counter;
                counter++;
            }


            //===========================

            for (int rightRow = n - rightDecreaser; rightCol <= n - rightDecreaser; rightCol++) // right  /*changeLater*/ 
            {
                if (counter == n * n + 1)
                {
                    break;
                }
                matrix[rightCol, rightRow] = counter;
                counter++;
            }

            //===========================

            for (int botCol = n - botDecreaser; botRow >= ((n - n) + botIncreaser); botRow--) // bot 
            {
                if (counter == n * n + 1)
                {
                    break;
                }
                matrix[botCol, botRow] = counter;
                counter++;
            }

            //===========================

            for (int leftRow = (n - n) + leftRowIncreaser; leftCol >= ((n - n) + leftIncreaser); leftCol--) // left /*changeLater*/ 
            {
                if (counter == n * n + 1)
                {
                    break;
                }
                matrix[leftCol, leftRow] = counter;
                counter++;
            }
            //======================================================================================================================

            topIncreaser++;
            topUntil++;
            topRow = (n - n) + topIncreaser;

            rightIncreaser++;
            rightDecreaser++;
            rightCol = (n - n) + rightIncreaser;

            botIncreaser++;
            botDecreaser++;
            botRowDecreaser++;
            botTest++;
            botRow = n - botTest;

            leftRowIncreaser++;
            leftIncreaser++;
            leftCol = (n - 2) - leftN;
            leftN++;

        }

        for (int cols = 0; cols < n; cols++) // Print Matrix
        {
            for (int rows = 0; rows < n; rows++)
            {
                Console.Write("{0} ", matrix[cols, rows]);
            }
            Console.WriteLine();
        }
    }
}
