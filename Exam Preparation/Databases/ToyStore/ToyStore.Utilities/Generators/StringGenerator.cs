using System.Linq;
using System.Text;

namespace ToyStore.Utilities.Generators
{
    public class StringGenerator
    {
        private static readonly char[] Alphabet;
        private readonly NumberGenerator NumberGenerator;

        static StringGenerator()
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

        public StringGenerator(NumberGenerator numberGenerator)
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