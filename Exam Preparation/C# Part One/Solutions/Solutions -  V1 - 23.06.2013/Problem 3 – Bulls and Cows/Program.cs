using System;

class Program
{
    static void Main()
    {
        int secretNum = int.Parse(Console.ReadLine());
        int bullsInput = int.Parse(Console.ReadLine());
        int cowsInput = int.Parse(Console.ReadLine());

        bool isZero = true;

        for (int i = 1000; i <= 9999; i++)
        {
            int cows = 0;
            int bulls = 0;

            int iD = i % 10;
            int iC = i / 10 % 10;
            int iB = i / 100 % 10;
            int iA = i / 1000 % 10;

            int sD = secretNum % 10;
            int sC = secretNum / 10 % 10;
            int sB = secretNum / 100 % 10;
            int sA = secretNum / 1000 % 10;

            int permIA = iA;
            int permIB = iB;
            int permIC = iC;
            int permID = iD;

            if (sA == iA || iB == sB || iC == sC || iD == sD)
            {

                if (iA == sA)
                {
                    iA = -1;
                    sA = -2;
                    bulls++;
                }

                if (iB == sB)
                {
                    iB = -3;
                    sB = -4;
                    bulls++;
                }

                if (iC == sC)
                {
                    iC = -5;
                    sC = -6;
                    bulls++;
                }

                if (iD == sD)
                {
                    iD = -7;
                    sD = -8;
                    bulls++;
                }
            }

            if (sA == iB || sA == iC || sA == iD || 
                sB == iA || sB == iC || sB == iD || 
                sC == iA || sC == iB || sC == iD || 
                sD == iA || sD == iB || sD == iC)
            {
                if (sA == iB)
                {
                    sA = -9;
                    iB = -10;
                    cows++;
                }
                else if (sA == iC)
                {
                    sA = -11;
                    iC = -12;
                    cows++;
                }
                else if (sA == iD)
                {
                    sA = -13;
                    iD = -14;
                    cows++;
                }

                //------------- END - sA

                if (sB == iA)
                {
                    sB = -15;
                    iA = -16;
                    cows++;
                }
                else if (sB == iC)
                {
                    sB = -17;
                    iC = -18;
                    cows++;
                }
                else if (sB == iD)
                {
                    sB = -19;
                    iD = -20;
                    cows++;
                }

                //----------------END - sB

                if (sC == iA)
                {
                    sC = -21;
                    iA = -22;
                    cows++;
                }
                else if (sC == iB)
                {
                    sC = -23;
                    iB = -24;
                    cows++;
                }
                else if (sC == iD)
                {
                    sC = -25;
                    iD = -26;
                    cows++;
                }

                //--------------- END - sC

                if (sD == iA)
                {
                    sD = -27;
                    iA = -28;
                    cows++;
                }
                else if (sD == iB)
                {
                    sD = -29;
                    iB = -30;
                    cows++;
                }
                else if (sD == iC)
                {
                    sD = -31;
                    iC = -32;
                    cows++;
                }

                //---------------- END - sD
            }

            if (cowsInput == cows && bullsInput == bulls)
            {
                if (permIA > 0 && permIB > 0 && permIC > 0 && permID > 0)
                {
                    Console.Write("{0} ", i);
                    isZero = false;
                }
            }
        }

        if (isZero == true)
        {
            Console.WriteLine("No");
        }
        
        Console.WriteLine();
    }
}