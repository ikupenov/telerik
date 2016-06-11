using System;

class Sort3
{
    static void Main()
    {
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());

        if (first > second && first > third)
        {
            Console.Write("{0} ", first);

            if (second > third)
            {
                Console.Write("{0} ", second);
                Console.Write("{0} ", third);
            }

            else if (third > second)
            {
                Console.Write("{0} ", third);
                Console.Write("{0} ", second);
            }

            else
            {
                Console.Write("{0} {1}", second, third);
            }
        }

        else if (second > first && second > third)
        {
            Console.Write("{0} ", second);

            if (first > third)
            {
                Console.Write("{0} ", first);
                Console.Write("{0} ", third);
            }

            else if (third > first)
            {
                Console.Write("{0} ", third);
                Console.Write("{0} ", first);
            }

            else
            {
                Console.Write("{0} {1}", first, third);
            }
        }

        else if (third > first && third > second)
        {
            {
                Console.Write("{0} ", third);

                if (first > second)
                {
                    Console.Write("{0} ", first);
                    Console.Write("{0} ", second);
                }

                else if (second > first)
                {
                    Console.Write("{0} ", second);
                    Console.Write("{0} ", first);
                }

                else
                {
                    Console.Write("{0} {1}", first, second);
                }
            }
        }

        else
        {
            Console.Write("{0} {1} {2}", first, second, third);
        }

        Console.WriteLine();
    }
}