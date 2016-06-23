namespace AnimalHierarchy.Generator
{
    using AnimalHierarchy.Models.Abstract;
    using Infrastructure.Enumerations;
    using Models.Animals;
    using NameGenerator;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AnimalGenerator
    {
        private static List<Animal> animals;
        private static Random rnd;

        static AnimalGenerator()
        {
            animals = new List<Animal>();
            rnd = new Random();
        }

        public static List<Dog> GenerateDogs(int numberOfAnimals)
        {
            GenerateAnimals(numberOfAnimals, AnimalType.Dog);
            return animals.Cast<Dog>().ToList();
        }

        public static List<Cat> GenerateCats(int numberOfAnimals)
        {
            GenerateAnimals(numberOfAnimals, AnimalType.Cat);
            return animals.Cast<Cat>().ToList();
        }

        public static List<Frog> GenerateFrogs(int numberOfAnimals)
        {
            GenerateAnimals(numberOfAnimals, AnimalType.Frog);
            return animals.Cast<Frog>().ToList();
        }

        public static List<Kitten> GenerateKittens(int numberOfAnimals)
        {
            GenerateAnimals(numberOfAnimals, AnimalType.Kitten);
            return animals.Cast<Kitten>().ToList();
        }

        public static List<Tomcat> GenerateTomCats(int numberOfAnimals)
        {
            GenerateAnimals(numberOfAnimals, AnimalType.Tomcat);
            return animals.Cast<Tomcat>().ToList();
        }

        private static void GenerateAnimals(int numberOfAnimals, AnimalType animalType)
        {
            animals.Clear();

            for (int i = 0; i < numberOfAnimals; i++)
            {
                string name = string.Empty;
                int age = rnd.Next(0, 30);
                GenderType gender = GenderType.NotSet;

                if (animalType == AnimalType.Kitten)
                {
                    gender = GenderType.Female;
                }
                else if (animalType == AnimalType.Tomcat)
                {
                    gender = GenderType.Male;
                }
                else
                {
                    gender = (GenderType)rnd.Next(1, 3);
                }

                if (gender == GenderType.Male)
                {
                    name = ((AnimalMaleNameType)rnd.Next(0, 5)).ToString();
                }
                else
                {
                    name = ((AnimalFemaleNameType)rnd.Next(0, 5)).ToString();
                }

                switch (animalType)
                {
                    case AnimalType.Dog:
                        animals.Add(new Dog(age, name, gender));
                        break;
                    case AnimalType.Frog:
                        animals.Add(new Frog(age, name, gender));
                        break;
                    case AnimalType.Cat:
                        animals.Add(new Cat(age, name, gender));
                        break;
                    case AnimalType.Kitten:
                        animals.Add(new Kitten(age, name));
                        break;
                    case AnimalType.Tomcat:
                        animals.Add(new Tomcat(age, name));
                        break;
                }
            }
        }
    }
}
