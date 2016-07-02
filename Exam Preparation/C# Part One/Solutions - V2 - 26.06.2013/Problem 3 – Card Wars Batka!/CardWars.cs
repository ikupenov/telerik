using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());

        int pGamesWon = 0;
        int gGamesWon = 0;

        BigInteger pScore = 0;
        BigInteger gScore = 0;

        for (int i = 1; i <= rounds; i++)
        {
            string pCard;
            string gCard;

            bool pXDrawn = false;
            bool gXDrawn = false;

            BigInteger pHandStrength = 0;
            BigInteger gHandStrength = 0;

            #region pCards
            for (int k = 1; k <= 3; k++)
            {
                pCard = Console.ReadLine();

                switch (pCard)
                {
                    case "2":
                        pHandStrength += 10;
                        break;
                    case "3":
                        pHandStrength += 9;
                        break;
                    case "4":
                        pHandStrength += 8;
                        break;
                    case "5":
                        pHandStrength += 7;
                        break;
                    case "6":
                        pHandStrength += 6;
                        break;
                    case "7":
                        pHandStrength += 5;
                        break;
                    case "8":
                        pHandStrength += 4;
                        break;
                    case "9":
                        pHandStrength += 3;
                        break;
                    case "10":
                        pHandStrength += 2;
                        break;
                    case "A":
                        pHandStrength += 1;
                        break;
                    case "J":
                        pHandStrength += 11;
                        break;
                    case "Q":
                        pHandStrength += 12;
                        break;
                    case "K":
                        pHandStrength += 13;
                        break;

                    case "Z":
                        pScore *= 2;
                        break;
                    case "Y":
                        pScore -= 200;
                        break;
                    case "X":
                        pXDrawn = true;
                        break;
                }
            }
            #endregion

            #region gCards
            for (int j = 1; j <= 3; j++)
            {
                gCard = Console.ReadLine();

                switch (gCard)
                {
                    case "2":
                        gHandStrength += 10;
                        break;
                    case "3":
                        gHandStrength += 9;
                        break;
                    case "4":
                        gHandStrength += 8;
                        break;
                    case "5":
                        gHandStrength += 7;
                        break;
                    case "6":
                        gHandStrength += 6;
                        break;
                    case "7":
                        gHandStrength += 5;
                        break;
                    case "8":
                        gHandStrength += 4;
                        break;
                    case "9":
                        gHandStrength += 3;
                        break;
                    case "10":
                        gHandStrength += 2;
                        break;
                    case "A":
                        gHandStrength += 1;
                        break;
                    case "J":
                        gHandStrength += 11;
                        break;
                    case "Q":
                        gHandStrength += 12;
                        break;
                    case "K":
                        gHandStrength += 13;
                        break;

                    case "Z":
                        gScore *= 2;
                        break;
                    case "Y":
                        gScore -= 200;
                        break;
                    case "X":
                        gXDrawn = true;
                        break;
                }
            }
            #endregion

            if (pXDrawn == true && gXDrawn == false)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }

            else if (gXDrawn == true && pXDrawn == false)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }

            else if (pXDrawn == true && gXDrawn == true)
            {
                pScore += 50;
                gScore += 50;
            }

            if (pHandStrength > gHandStrength)
            {
                ++pGamesWon;
                pScore += pHandStrength;
            }

            else if (gHandStrength > pHandStrength)
            {
                ++gGamesWon;
                gScore += gHandStrength;
            }

        }

        if (pScore == gScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", pScore);
        }

        else
        {
            if (pScore > gScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", pScore);
                Console.WriteLine("Games won: {0}", pGamesWon);
            }

            else if (gScore > pScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", gScore);
                Console.WriteLine("Games won: {0}", gGamesWon);
            }
        }
    }
}
