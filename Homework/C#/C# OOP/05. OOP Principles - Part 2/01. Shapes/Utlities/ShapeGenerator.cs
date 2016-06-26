namespace ShapesTask.Utlities
{
    using Shapes;
    using Shapes.Abstract;
    using System;
    using System.Collections.Generic;

    public static class ShapeGenerator
    {
        private static Random rnd;

        static ShapeGenerator()
        {
            rnd = new Random();
        }

        public static List<Shape> GenerateRandomShapes(int numberOfShapes)
        {
            var shapes = new List<Shape>();

            for (int i = 0; i < numberOfShapes; i++)
            {
                int rndShape = rnd.Next(0, 3);

                if (rndShape == 0)
                {
                    shapes.Add(new Rectangle(rnd.Next(1, 100), rnd.Next(1, 100)));
                }
                else if (rndShape == 1)
                {
                    shapes.Add(new Triangle(rnd.Next(1, 100), rnd.Next(1, 100)));
                }
                else
                {
                    shapes.Add(new Square(rnd.Next(1, 100)));
                }
            }

            return shapes;
        }
    }
}
