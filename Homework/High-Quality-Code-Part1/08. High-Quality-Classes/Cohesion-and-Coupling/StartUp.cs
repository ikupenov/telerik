namespace CohesionAndCoupling
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            PathExtensionsExample.Start();
            
            Console.WriteLine(new string('-', 50));

            MathExtensionsExample.Start();
        }
    }
}