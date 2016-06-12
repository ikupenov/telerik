namespace PointIn3D
{
    using System;

    class StartUp
    {
        static void Main()
        {
            PathStorage.Import();

            var pointA = new Point3D();
            var pointB = new Point3D();
            int counter = 0;

            foreach (var point in Path.SequenceOfPoints)
            {
                if (counter % 2 == 0)
                {
                    pointA = point;
                    Console.WriteLine(new string('_', 20));
                }

                Console.WriteLine(point);

                if (counter % 2 != 0)
                {
                    pointB = point;
                    var distance = Distance.FindDistance(pointA, pointB);

                    Console.WriteLine("Distance: {0:F5}", distance);
                    Console.WriteLine(new string('=', 20));
                    Console.WriteLine("\r");
                }

                if (counter % 2 == 0)
                {
                    pointA = point;
                }

                counter++;
            }

            Console.ReadKey();       
        }
    }
}
