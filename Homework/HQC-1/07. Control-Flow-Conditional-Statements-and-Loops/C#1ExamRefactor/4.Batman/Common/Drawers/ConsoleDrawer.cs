namespace Batman.Common.Drawers
{
    using System;

    using Contracts;

    public class ConsoleDrawer : IDrawer
    {
        public void NewLineDraw(char symb)
        {
            Console.WriteLine(symb);
        }

        public void NewLineDraw(char symbol, int count)
        {
            Console.WriteLine(new string(symbol, count));
        }

        public void SameLineDraw(char symb)
        {
            Console.Write(symb);
        }

        public void SameLineDraw(char symbol, int count)
        {
            Console.Write(new string(symbol, count));
        }

        public void DrawEmptyLine()
        {
            Console.WriteLine();
        }

        public void DrawWhiteSpace()
        {
            Console.Write(" ");
        }

        public void DrawWhiteSpace(int count)
        {
            Console.Write(new string(' ', count));
        }
    }
}