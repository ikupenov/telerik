namespace Methods
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            var triangleArea = MathExtensions.CalculateTriangleArea(3, 4, 5);
            Console.WriteLine(triangleArea);

            Console.WriteLine(MathExtensions.GetDigitAsWord(5));

            Console.WriteLine(MathExtensions.GetMaxNumber(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(MathExtensions.FormatNumber(1.3, "f"));
            Console.WriteLine(MathExtensions.FormatNumber(0.75, "%"));
            Console.WriteLine(MathExtensions.FormatNumber(2.30, "r"));

            var pointA = new Point(3, -1);
            var pointB = new Point(3, 2.5);

            bool isHorizontal = MathExtensions.IsHorizontal(pointA, pointB);
            bool isVertical = MathExtensions.IsVertical(pointA, pointB);

            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student("Peter", "Ivanov", 21);
            Student stella = new Student("Stella", "Markova", 18);

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}