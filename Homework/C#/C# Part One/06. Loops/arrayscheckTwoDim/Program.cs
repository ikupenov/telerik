using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 3;
        int counter = 1;


        int topIncreaser = 0;
        int rightIncreaser = 1;
        int botIncreaser = 2;
        int leftIncreaser = 2;

        int insideTopIncreaser = 0;
        int insideRightIncreaser = 1;
        int insideBotIncreaser = 1;
        int insideLeftIncreaser = 0;

        int until = 0;

        int[,] matrix = new int[n, n];

        while (counter <= n * n)

        {
            for (int topCol = (n - n) + insideTopIncreaser; topIncreaser < n - until; topIncreaser++) // top /*changeLater*/ 
            {
                int nextRow = (n - n) + topIncreaser;

                matrix[topCol, nextRow] = counter;
                counter++;
            }

            //===========================



            for (int rightRow = (n - insideRightIncreaser); rightIncreaser < n - until; rightIncreaser++) // right  /*changeLater*/ 
            {
                int nextCol = (n - n) + rightIncreaser;

                matrix[nextCol, rightRow] = counter;
                counter++;
            }

            //===========================


            for (int botCol = (n - insideBotIncreaser); botIncreaser < (n + 1) - until; botIncreaser++) // bot /*changeLater*/ 
            {
                int previousRow = n - botIncreaser;

                matrix[botCol, previousRow] = counter;
                counter++;
            }

            //===========================

            for (int leftRow = (n - n) + insideLeftIncreaser; leftIncreaser < n - until; leftIncreaser++) // left /*changeLater*/ 
            {
                int previousCol = n - leftIncreaser;

                matrix[previousCol, leftRow] = counter;
                counter++;
            }

            insideTopIncreaser++;
            insideRightIncreaser++;
            insideBotIncreaser++;
            insideLeftIncreaser++;

            topIncreaser = 0 + insideTopIncreaser;
            rightIncreaser = 1 + insideRightIncreaser;
            botIncreaser = 2 + insideBotIncreaser;
            leftIncreaser = 2 + insideLeftIncreaser;

            until++;
        }

    }
}
