namespace Feathers
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            const double MagicNumberForEvenResult = 123123123123;
            const double MagicNumberForOddResult = 317;

            double birds = double.Parse(Console.ReadLine());
            double feathers = double.Parse(Console.ReadLine());

            double averageFeathersPerBird = feathers / birds;

            if (birds % 2 == 0)
            {
                averageFeathersPerBird *= MagicNumberForEvenResult;
            }
            else
            {
                averageFeathersPerBird /= MagicNumberForOddResult;
            }

            Console.WriteLine("{0:F4}", averageFeathersPerBird);
        }
    }
}