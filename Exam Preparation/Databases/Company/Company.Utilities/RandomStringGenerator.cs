using System.Linq;
using System.Text;

using Company.Utilities.Contracts;

namespace Company.Utilities
{
    public class RandomStringGenerator : IStringGenerator
    {
        private static readonly char[] Alphabet;
        private readonly INumberGenerator NumberGenerator;

        static RandomStringGenerator()
        {
            var uppercaseLetters = Enumerable.Range('A', 26);
            var lowercaseLetters = Enumerable.Range('a', 26);
            var digits = Enumerable.Range('0', 10);

            Alphabet = uppercaseLetters
                .Concat(lowercaseLetters)
                .Concat(digits)
                .Select(l => (char)l)
                .ToArray();
        }

        public RandomStringGenerator(INumberGenerator numberGenerator)
        {
            this.NumberGenerator = numberGenerator;
        }

        public string GetRandomString(int minLength, int maxLength)
        {
            var builder = new StringBuilder();

            var stringLength = this.NumberGenerator.GetRandomInteger(minLength, maxLength);

            for (int i = 0; i < stringLength; i++)
            {
                var randomLetterPosition = this.NumberGenerator.GetRandomInteger(0, Alphabet.Length);
                var randomLetter = Alphabet[randomLetterPosition];

                builder.Append(randomLetter);
            }

            return builder.ToString();
        }
    }
}