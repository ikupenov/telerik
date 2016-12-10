using System;
using System.Linq;

namespace BinaryPasswords
{
    class StartUp
    {
        static void Main()
        {
            long placeholders = Console
                .ReadLine()
                .Where(c => c == '*')
                .Count();

            long result = (long)Math.Pow(2, placeholders);
            Console.WriteLine(result);
        }
    }
}
