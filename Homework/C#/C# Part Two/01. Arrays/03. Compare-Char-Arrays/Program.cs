using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        //Regex rgx = new Regex("[^a-zA-Z]");
        //first = rgx.Replace(first, "");
        //second = rgx.Replace(second, "");

        bool areEqual = true;

        if (first.Length > second.Length)
        {
            Console.WriteLine(">");
            return;                      
        }                                           
                                                    
        else if (first.Length < second.Length)      
        {                                           
            Console.WriteLine("<");
            return;          
        }                                           
                                                    
        else                                     
        {  
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    areEqual = false;
                }

                if (first[i] < second[i])
                {
                    Console.WriteLine("<");
                    break;
                }

                if (first[i] > second[i])
                {
                    Console.WriteLine(">");
                    break;
                }
            }                                                                        
        }

        if (areEqual == true)
        {
            Console.WriteLine("=");
        }
    }
}