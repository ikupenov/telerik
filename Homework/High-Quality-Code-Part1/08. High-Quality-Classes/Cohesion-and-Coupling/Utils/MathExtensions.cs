namespace CohesionAndCoupling.Utils
{
    using System;

    using Contracts;

    public class MathExtensions
    {
        public static double Power(double number, int power)
        {
            double onPower = 1;

            for (int i = 0; i < power; i++)
            {
                onPower *= number;
            }

            return onPower;
        }

        public static double CalculateVolume(IShape3D shape)
        {
            double volume = shape.Width * shape.Height * shape.Depth;
            return volume;
        }

        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            double xDistanceOnPow = Power(x2 - x1, 2);
            double yDistanceOnPow = Power(y2 - y1, 2);

            double distance = Math.Sqrt(xDistanceOnPow + yDistanceOnPow);

            return distance;
        }

        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double xDistance = Power(x2 - x1, 2);
            double yDistance = Power(y2 - y1, 2);
            double zDistance = Power(z2 - z1, 2);

            double distance = Math.Sqrt(xDistance + yDistance + zDistance);

            return distance;
        }

        public static double CalculateDiagonal2D(IShape2D shape)
        {
            double distance = CalculateDistance2D(0, 0, shape.Width, shape.Height);

            return distance;
        }

        public static double CalculateDiagonal3D(IShape3D shape)
        {
            double distance = CalculateDistance3D(0, 0, 0, shape.Width, shape.Height, shape.Depth);

            return distance;
        }
    }
}