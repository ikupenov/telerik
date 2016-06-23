namespace AnimalHierarchy
{
    using Generator;
    using Models.Abstract;
    using System;

    class StartUp
    {
        static void Main()
        {
            var dogs = AnimalGenerator.GenerateDogs(10);
            Console.WriteLine("Average Age of Dogs: ".PadRight(30, '-') + " {0:F2}", Animal.AverageAge(dogs));

            var cats = AnimalGenerator.GenerateCats(10);
            Console.WriteLine("Average Age of Cats: ".PadRight(30, '-') + " {0:F2}", Animal.AverageAge(cats));

            var frogs = AnimalGenerator.GenerateFrogs(10);
            Console.WriteLine("Average Age of Frogs: ".PadRight(30, '-') + " {0:F2}", Animal.AverageAge(frogs));

            var kittens = AnimalGenerator.GenerateKittens(10);
            Console.WriteLine("Average Age of Kittens: ".PadRight(30, '-') + " {0:F2}", Animal.AverageAge(kittens));

            var tomcats = AnimalGenerator.GenerateTomCats(10);
            Console.WriteLine("Average Age of Tomcats: ".PadRight(30, '-') + " {0:F2}", Animal.AverageAge(tomcats));
        }
    }
}
