namespace Methods
{
    using System;

    public static class MathExtensions
    {
        public static double Power(double number, double power)
        {
            double onPower = 1;

            for (int i = 0; i < power; i++)
            {
                onPower *= number;
            }

            return onPower;
        }

        public static int GetMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No elements provided!");
            }

            int maxNumber = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides cannot be equal or less than zero!");
            }

            double semiPerimeter = (a + b + c) / 2;

            double semiPerimeterMinusA = semiPerimeter - a;
            double semiPerimeterMinusB = semiPerimeter - b;
            double semiPerimeterMinusC = semiPerimeter - c;

            double triangleArea = Math.Sqrt(semiPerimeter * semiPerimeterMinusA * semiPerimeterMinusB * semiPerimeterMinusC);

            return triangleArea;
        }

        public static double CalculateDistance(Point pointA, Point pointB)
        {
            double x = Power(pointB.X - pointA.X, 2);
            double y = Power(pointB.Y - pointA.Y, 2);
            double distanceBetweenPoints = Math.Sqrt(x + y);

            return distanceBetweenPoints;
        }

        public static bool IsVertical(Point pointA, Point pointB)
        {
            bool isVertical = pointA.X == pointB.X;

            return isVertical;
        }

        public static bool IsHorizontal(Point pointA, Point pointB)
        {
            bool isHorizontal = pointA.Y == pointB.Y;

            return isHorizontal;
        }

        public static string GetDigitAsWord(int number)
        {
            string numberAsString = string.Empty;

            switch (number)
            {
                case 0:
                    numberAsString = "zero";
                    break;
                case 1:
                    numberAsString = "one";
                    break;
                case 2:
                    numberAsString = "two";
                    break;
                case 3:
                    numberAsString = "three";
                    break;
                case 4:
                    numberAsString = "four";
                    break;
                case 5:
                    numberAsString = "five";
                    break;
                case 6:
                    numberAsString = "six";
                    break;
                case 7:
                    numberAsString = "seven";
                    break;
                case 8:
                    numberAsString = "eight";
                    break;
                case 9:
                    numberAsString = "nine";
                    break;
                default:
                    throw new ArgumentException("A single digit must be provided!");
            }

            return numberAsString;
        }

        public static string FormatNumber(double number, string format)
        {
            string formattedNumber = string.Empty;

            switch (format)
            {
                case "f":
                    formattedNumber = string.Format("{0:F2}", number);
                    break;
                case "%":
                    formattedNumber = string.Format("{0:P0}", number);
                    break;
                case "r":
                    formattedNumber = string.Format("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }

            return formattedNumber;
        }
    }
}