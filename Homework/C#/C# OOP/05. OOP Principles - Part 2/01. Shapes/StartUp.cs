namespace ShapesTask
{
    using System;
    using System.Linq;
    using Utlities;

    class StartUp
    {
        static void Main()
        {
            var shapes = ShapeGenerator.GenerateRandomShapes(20);
            var shapesSurface = shapes.OrderBy(x => x.CalculateSurface())
                                      .ToList();

            foreach (var shapeSurface in shapesSurface)
            {
                Console.WriteLine("Surface: {0} Type: {1}", shapeSurface.Surface.ToString().PadRight(10),
                                                            shapeSurface.GetType().Name);
            }
        }
    }
}
