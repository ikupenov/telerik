namespace CohesionAndCoupling
{
    using System;

    using Models;
    using Utils;

    public class MathExtensionsExample
    {
        public static void Start()
        {
            var distance2D = MathExtensions.CalculateDistance2D(1, -2, 3, 4);
            Console.WriteLine($"Distance in the 2D space = {distance2D:f2}");

            var distance3D = MathExtensions.CalculateDistance3D(5, 2, -1, 3, -6, 4);
            Console.WriteLine($"Distance in the 3D space = {distance3D:f2}");

            var rectangle = new Rectangle(3, 4);
            var rectangleDiagonal = MathExtensions.CalculateDiagonal2D(rectangle);
            Console.WriteLine($"Diagonal 2D = {rectangleDiagonal:f2}");

            var parallelepiped = new Parallelepiped(3, 4, 5);
            var parallelepipedDiagonal = MathExtensions.CalculateDiagonal3D(parallelepiped);
            var parallelepipedVolume = MathExtensions.CalculateVolume(parallelepiped);
            Console.WriteLine($"Diagonal 3D = {parallelepipedDiagonal:f2}");
            Console.WriteLine($"Volume = {parallelepipedVolume:f2}");
        }
    }
}