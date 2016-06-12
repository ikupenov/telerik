namespace PointIn3D
{
    using System;
    using System.IO;
    using System.Linq;

    public class PathStorage
    {
        private static string filePath = Directory.GetCurrentDirectory() + "\\Text.txt";

        static PathStorage()
        {
            filePath = Directory.GetCurrentDirectory() + "\\Text.txt";
        }

        private static void RandomCoordGen()
        {
            var writer = new StreamWriter(filePath, false);
            Random rnd = new Random();

            if (!File.Exists(filePath))
            {
                File.CreateText(filePath);
            }

            using (writer)
            {
                for (int i = 0; i < 60; i++)
                {
                    double X = rnd.Next(-1000, 1000);
                    double Y = rnd.Next(-1000, 1000);
                    double Z = rnd.Next(-1000, 1000);

                    writer.WriteLine("{{{0}, {1}, {2}}}", X, Y, Z);
                }
            }
        }

        public static void Import()
        {
            RandomCoordGen();

            var text = new StreamReader(filePath);
            string line;

            using (text)
            {
                while ((line = text.ReadLine()) != null)
                {
                    var separator = new char[] { ' ', ',', '(', ')', '{', '}' };
                    var coordinates = line.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(double.Parse)
                                          .ToArray();

                    double X = coordinates[0];
                    double Y = coordinates[1];
                    double Z = coordinates[2];

                    Path.AddPoint(new Point3D(X, Z, Y));
                }
            }
        }
    }
}
