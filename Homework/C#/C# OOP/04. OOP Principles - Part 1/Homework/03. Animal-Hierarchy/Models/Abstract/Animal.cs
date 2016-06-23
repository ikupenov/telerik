namespace AnimalHierarchy.Models.Abstract
{
    using Infrastructure.Contracts;
    using Infrastructure.Enumerations;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private GenderType gender;

        public Animal(int age, string name, GenderType gender)
        {
            this.age = age;
            this.name = name;
            this.gender = gender;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Age
        {
            get { return this.age; }
        }

        public GenderType Gender
        {
            get { return this.gender; }
        }

        public abstract void MakeSound();

        public static double AverageAge<T>(List<T> collection)
            where T : Animal
        {
            return collection.Average(x => x.Age);
        }
    }
}
