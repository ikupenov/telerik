namespace DancingMoves
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static void Main()
        {
            var integers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rounds = 0;
            int currentIndex = 0;

            double result = 0;

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "stop")
                {
                    break;
                }  

                int positions = int.Parse(commands[0]);
                string direction = commands[1];
                int jumps = int.Parse(commands[2]);

                if (direction == "right")
                {
                    for (int i = 0; i < positions; i++)
                    {
                        currentIndex = Modulo(currentIndex + jumps, integers.Length);
                        result += integers[currentIndex];
                    }
                }
                else if (direction == "left")
                {
                    for (int i = 0; i < positions; i++)
                    {
                        currentIndex = Modulo(currentIndex - jumps, integers.Length);
                        result += integers[currentIndex];
                    }
                }

                rounds++;
            }

            Console.WriteLine("{0:F1}", result / rounds);
        }

        /// <summary>
        /// Superset version of modulo ("%"). Works as expected with negative values.
        /// </summary>
        private static int Modulo(int n, int m)
        {
            return ((n % m) + m) % m;
        }
    }
}