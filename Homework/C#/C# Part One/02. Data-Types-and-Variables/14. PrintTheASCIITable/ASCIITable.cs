/*
Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints 
the visible characters of the ASCII table on the console (characters from 33 to 126 including).

Note: You may need to use for-loops (learn in Internet how).
*/

using System;

class ASCIITable
{
    static void Main()
    {
        for (byte i = 33; i < 127; i++)
        {
            Console.Write((char)i);
        }
    }
}