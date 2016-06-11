using System;

class PrintADeck
{
    static void Main()
    {
        string readCards = Console.ReadLine();

        int card = 1;
        string output = "";

        switch (readCards)
        {
            case "2":
                card = 2;
                break;

            case "3":
                card = 3;
                break;

            case "4":
                card = 4;
                break;

            case "5":
                card = 5;
                break;

            case "6":
                card = 6;
                break;

            case "7":
                card = 7;
                break;

            case "8":
                card = 8;
                break;

            case "9":
                card = 9;
                break;

            case "10":
                card = 10;
                break;

            case "J":
                card = 11;
                break;

            case "Q":
                card = 12;
                break;

            case "K":
                card = 13;
                break;

            case "A":
                card = 14;
                break;

            default:
                Console.WriteLine("invalid input");
                break;
        }


        for (int i = 2; i <= card; i++)
        {
            if (i <= 10)
            {
                output = Convert.ToString(i);
            }

            if (i == 11)
            {
                output = "J";
            }

            if (i == 12)
            {
                output = "Q";
            }

            if (i == 13)
            {
                output = "K";
            }

            if (i == 14)
            {
                output = "A";
            }

            Console.Write("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", output);
            Console.WriteLine();
        }
    }
}