using System;

class Program
{
    static void Main()
    {
        long M = long.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        long result = 0;
        long number = 0;

        foreach (char symb in input)
        {
            if (symb == '@')
            {
                Console.WriteLine("{0}", result);
                return;
            }

            else if (char.IsDigit(symb))
            {
                number = (long)char.GetNumericValue(symb);

                result *= number;
            }

            else
            {
                switch (symb)
                {
                    case 'A': case 'a': result += 0; break;
                    case 'B': case 'b': result += 1; break;
                    case 'C': case 'c': result += 2; break;
                    case 'D': case 'd': result += 3; break;
                    case 'E': case 'e': result += 4; break;
                    case 'F': case 'f': result += 5; break;
                    case 'G': case 'g': result += 6; break;
                    case 'H': case 'h': result += 7; break;
                    case 'I': case 'i': result += 8; break;
                    case 'J': case 'j': result += 9; break;
                    case 'K': case 'k': result += 10; break;
                    case 'L': case 'l': result += 11; break;
                    case 'M': case 'm': result += 12; break;
                    case 'N': case 'n': result += 13; break;
                    case 'O': case 'o': result += 14; break;
                    case 'P': case 'p': result += 15; break;
                    case 'Q': case 'q': result += 16; break;
                    case 'R': case 'r': result += 17; break;
                    case 'S': case 's': result += 18; break;
                    case 'T': case 't': result += 19; break;
                    case 'U': case 'u': result += 20; break;
                    case 'V': case 'v': result += 21; break;
                    case 'W': case 'w': result += 22; break;
                    case 'X': case 'x': result += 23; break;
                    case 'Y': case 'y': result += 24; break;
                    case 'Z': case 'z': result += 25; break;
                    default: result %= M; break;
                }
            }        
        }

        Console.WriteLine("{0}", result);
    }
}