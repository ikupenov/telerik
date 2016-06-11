using System;

class Program
{
    static void Main()
    {
        string expression = Console.ReadLine();

        int result = 0;
        int bracketResult = 0;

        char operat = '+';
        char bracketOperat = '+';

        bool inBracket = false;

        foreach (char symb in expression)
        {
            if (symb == '=')
            {
                Console.WriteLine("{0:F3}", result);
                return;
            }

            if (inBracket == false)
            {
                switch (symb)
                {
                    case '+': operat = '+'; break;
                    case '-': operat = '-'; break;
                    case '/': operat = '/'; break;
                    case '*': operat = '*'; break;
                    case '%': operat = '%'; break;
                }
            }
            
            if (symb == '(')
            {
                inBracket = true;
                continue;
            }
            
            else if (symb == ')')
            {
                if (operat == '+')
                {
                    result += bracketResult;
                }

                else if (operat == '-')
                {
                    result -= bracketResult;
                }

                else if (operat == '/')
                {
                    result /= bracketResult;
                }

                else if (operat == '*')
                {
                    result *= bracketResult;
                }

                else if (operat == '%')
                {
                    result %= bracketResult;
                }

                bracketResult = 0;
                bracketOperat = '+';
                inBracket = false;
                continue;
            }

            if (inBracket == true)
            {
                switch (symb)
                {
                    case '+': bracketOperat = '+'; break;
                    case '-': bracketOperat = '-'; break;
                    case '/': bracketOperat = '/'; break;
                    case '*': bracketOperat = '*'; break;
                    case '%': bracketOperat = '%'; break;
                }

                if (char.IsDigit(symb))
                {
                    int digit = (int)char.GetNumericValue(symb);

                    if (bracketOperat == '+')
                    {
                        bracketResult += digit;
                    }
                    else if (bracketOperat == '-')
                    {
                        bracketResult -= digit;
                    }
                    else if (bracketOperat == '/')
                    {
                        bracketResult /= digit;
                    }
                    else if (bracketOperat == '*')
                    {
                        bracketResult *= digit;
                    }
                    else if (bracketOperat == '%')
                    {
                        bracketResult %= digit;
                    }
                }
            }
            else
            {            
                if (char.IsDigit(symb))
                {
                    int digit = (int)char.GetNumericValue(symb);

                    if (operat == '+')
                    {
                        result += digit;
                    }

                    else if (operat == '-')
                    {
                        result -= digit;
                    }

                    else if (operat == '/')
                    {
                        result /= digit;
                    }

                    else if (operat == '*')
                    {
                        result *= digit;
                    }

                    else if (operat == '%')
                    {
                        result %= digit;
                    }
                }
            }
        }
    }
}
