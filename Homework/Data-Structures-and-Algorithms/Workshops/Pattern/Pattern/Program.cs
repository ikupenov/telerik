using System;
using System.Text;

namespace Pattern
{
    class MainClass
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string figure = GetFigure(n);

            Console.WriteLine(figure);

            Svg.WriteToFile("output.svg", figure);
        }

        static string GetFigure(int n)
        {
            if (n == 1)
            {
                return "urd";
            }

            var previousFigure = GetFigure(n - 1);

            var rightTurn = new StringBuilder();
            var leftTurn = new StringBuilder();

            foreach (char symbol in previousFigure)
            {
                switch (symbol)
                {
                    case 'u':
                        rightTurn.Append("r");
                        leftTurn.Append("l");
                        break;
                    case 'r':
                        rightTurn.Append("u");
                        leftTurn.Append("d");
                        break;
                    case 'd':
                        rightTurn.Append("l");
                        leftTurn.Append("r");
                        break;
                    case 'l':
                        rightTurn.Append("d");
                        leftTurn.Append("u");
                        break;
                }
            }

            var result = rightTurn.ToString() + "u" + previousFigure + "r" + previousFigure + "d" + leftTurn.ToString();
            return result;
        }
    }
}