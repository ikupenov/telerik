using System;

namespace Passwords
{
    class StartUp
    {
        private static int[] digits;
        private static int[] password;

        private static int passwordLength;
        private static string directions;
        private static int passwordIndexToFind;

        static void Main()
        {
            digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            passwordLength = int.Parse(Console.ReadLine());
            directions = Console.ReadLine();
            passwordIndexToFind = int.Parse(Console.ReadLine());

            password = new int[passwordLength];

            FindPassword();
        }

        static int Modulo(int firstNumber, int secondNumber)
        {
            int result = firstNumber % secondNumber;
            if (result < 0)
            {
                result += secondNumber;
            }

            return result;
        }

        static void FindPassword(int passwordIndex = 0, int directionIndex = 0)
        {
            if (passwordIndex == passwordLength)
            {
                passwordIndexToFind--;
                if (passwordIndexToFind == 0)
                {
                    Console.WriteLine(string.Join("", password));
                    Environment.Exit(0);
                }

                return;
            }

            if (passwordIndex == 0)
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    password[passwordIndex] = i;
                    FindPassword(passwordIndex + 1, directionIndex);
                }
            }
            else
            {
                char currentDirection = directions[directionIndex];

                if (currentDirection == '=')
                {
                    password[passwordIndex] = password[passwordIndex - 1];
                    FindPassword(passwordIndex + 1, directionIndex + 1);
                }
                else if (currentDirection == '<')
                {
                    int previousDigit = password[passwordIndex - 1];
                    if (previousDigit == 1)
                    {
                        return;
                    }

                    int previousDigitIndex = Modulo(previousDigit - 1, digits.Length);

                    for (int i = 0; i < previousDigitIndex; i++)
                    {
                        password[passwordIndex] = digits[i];
                        FindPassword(passwordIndex + 1, directionIndex + 1);
                    }
                }
                else if (currentDirection == '>')
                {
                    int previousDigit = password[passwordIndex - 1];
                    if (previousDigit == 0)
                    {
                        return;
                    }

                    int previousDigitIndex = Modulo(previousDigit - 1, digits.Length);

                    for (int i = 0; i < digits.Length; i++)
                    {
                        password[passwordIndex] = i;
                        FindPassword(passwordIndex + 1, directionIndex + 1);

                        if (i == 0)
                        {
                            i += digits[previousDigitIndex];
                        }
                    }
                }
            }
        }
    }
}