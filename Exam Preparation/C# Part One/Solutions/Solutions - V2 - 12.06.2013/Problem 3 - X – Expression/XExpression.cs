using System;
using System.Text.RegularExpressions;

class XExpression
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = Regex.Replace(input, @"\s+", "");

        double result = 0;
        double parentResult = 0;

        double operat = '+';
        double parentOperat = '+';

        bool inBracket = false;

        foreach (char symb in input)
        {
            if (symb == '(')
            {
                inBracket = true;
                continue;
            }

            if (inBracket == false)
            {
                switch (symb)
                {
                    case '+': operat = symb; break;
                    case '-': operat = symb; break;
                    case '/': operat = symb; break;
                    case '*': operat = symb; break;
                }

                if (char.IsDigit(symb))
                {
                    //int number = symb - '0';
                    int number = (int)char.GetNumericValue(symb);

                    if (operat == '+')
                    {
                        result += number;
                    }

                    else if (operat == '-')
                    {
                        result -= number;
                    }

                    else if (operat == '/')
                    {
                        result /= number;
                    }

                    else if (operat == '*')
                    {
                        result *= number;
                    }
                }
            }
            
            if (inBracket == true)
            {
                if (symb == ')')
                {
                    inBracket = false;
                    
                    if (operat == '+')
                    {
                        result += parentResult;
                    }

                    else if (operat == '-')
                    {
                        result -= parentResult;
                    }

                    else if (operat == '/')
                    {
                        result /= parentResult;
                    }

                    else if (operat == '*')
                    {
                        result *= parentResult;
                    }

                    parentResult = 0;
                    parentOperat = '+';
                    continue;
                }

                switch (symb)
                {
                    case '+': parentOperat = symb; break;
                    case '-': parentOperat = symb; break;
                    case '/': parentOperat = symb; break;
                    case '*': parentOperat = symb; break;
                }

                if (char.IsDigit(symb))
                {
                    int parentNumber = (int)char.GetNumericValue(symb);

                    if (parentOperat == '+')
                    {
                        parentResult += parentNumber;
                    }
                    else if (parentOperat == '-')
                    {
                        parentResult -= parentNumber;
                    }
                    else if (parentOperat == '/')
                    {
                        parentResult /= parentNumber;
                    }
                    else if (parentOperat == '*')
                    {
                        parentResult *= parentNumber;
                    }
                }
            }
        }

        Console.WriteLine("{0:0.00}", result);
    }
}