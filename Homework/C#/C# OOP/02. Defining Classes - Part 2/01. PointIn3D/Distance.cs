namespace PointIn3D
{
    using System;

    public static class Distance
    {
        private static double Power(double number, double power)
        {
            double result = 1;

            for (int i = 0; i < power; i++)
                result *= number;

            return result;
        }

        public static double FindDistance (Point3D pointA, Point3D pointB)
        {
            double distance = Power((pointB.X - pointA.X), 2) +
                              Power((pointB.Y - pointA.Y), 2) +
                              Power((pointB.Z - pointA.Z), 2);

            return Math.Sqrt(distance);
        }
    }
}
