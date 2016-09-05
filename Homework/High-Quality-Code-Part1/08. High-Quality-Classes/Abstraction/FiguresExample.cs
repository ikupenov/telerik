namespace Abstraction
{
    using System;

    using Figures;

    public class FiguresExample
    {
        private static void Main()
        {
            var circle = new Circle(5);
            Console.WriteLine(circle.ToString());

            var rect = new Rectangle(2, 3);
            Console.WriteLine(rect.ToString());
        }
    }
}