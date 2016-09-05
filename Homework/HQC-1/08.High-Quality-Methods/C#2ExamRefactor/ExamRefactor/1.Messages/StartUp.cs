namespace Messages
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class StartUp
    {
        public static List<string> customNumeralSystem = new List<string>
        {
            "cad",
            "xoz",
            "nop",
            "cyk",
            "min",
            "mar",
            "kon",
            "iva",
            "ogi",
            "yan"
        };

        private static void Main()
        {
            string firstNumber = Console.ReadLine();
            string mathOperator = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            BigInteger firstDecimalBaseNumber = CustomBaseToDecimal(firstNumber);
            BigInteger secondDecimalBaseNumber = CustomBaseToDecimal(secondNumber);

            BigInteger decimalBaseResult = 0;

            switch (mathOperator)
            {
                case "-":
                    decimalBaseResult = firstDecimalBaseNumber - secondDecimalBaseNumber;
                    break;
                case "+":
                    decimalBaseResult = firstDecimalBaseNumber + secondDecimalBaseNumber;
                    break;
            }

            var customBaseResult = DecimalToCustomBase(decimalBaseResult);

            Console.WriteLine(customBaseResult);
        }

        private static BigInteger CustomBaseToDecimal(string numberInCustomBase)
        {
            const int CustomBaseNumberLength = 3;

            BigInteger decimalBaseNumber = 0;

            for (int i = 0; i < numberInCustomBase.Length; i += CustomBaseNumberLength)
            {
                decimalBaseNumber *= 10;

                string customBaseNumber = numberInCustomBase.Substring(i, CustomBaseNumberLength);
                int indexOfCustomBaseNumber = customNumeralSystem.IndexOf(customBaseNumber);

                decimalBaseNumber += indexOfCustomBaseNumber;
            }

            return decimalBaseNumber;
        }

        private static string DecimalToCustomBase(BigInteger decimalBaseNumber)
        {
            var customBaseNumber = new List<string>();

            while (decimalBaseNumber > 0)
            {
                string convert = (decimalBaseNumber % 10).ToString();
                int remainder = int.Parse(convert);

                customBaseNumber.Add(customNumeralSystem[remainder]);

                decimalBaseNumber /= 10;
            }

            customBaseNumber.Reverse();
            string customBaseNumberAsString = string.Join("", customBaseNumber);

            return customBaseNumberAsString;
        }
    }
}