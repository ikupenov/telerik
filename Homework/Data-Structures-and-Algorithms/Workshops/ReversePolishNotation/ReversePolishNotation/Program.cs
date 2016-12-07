using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console
                .ReadLine()
                .Split(' ');

            var numbers = new Stack<int>();

            foreach (var symbol in expression)
            {
                if (IsOperand(symbol))
                {
                    numbers.Push(int.Parse(symbol));
                }
                else
                {
                    int a = numbers.Pop();
                    int b = numbers.Pop();

                    numbers.Push(Calculate(b, a, symbol));
                }
            }

            Console.WriteLine(numbers.Pop());
        }

        static bool IsOperand(string symbol)
        {
            double n;
            return double.TryParse(symbol, out n);
        }

        static int Calculate(int a, int b, string operat)
        {
            switch (operat)
            {
                case "-":
                    return a - b;
                case "+":
                    return a + b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                case "&":
                    return a & b;
                case "|":
                    return a | b;
                case "^":
                    return a ^ b;
                default:
                    return 0;
            }
        }
    }
}