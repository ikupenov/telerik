namespace AnimalHierarchy.Models.Animals
{
    using Infrastructure.Enumerations;
    using AnimalHierarchy.Models.Abstract;
    using System;

    public class Cat : Animal
    {
        public Cat(int age, string name, GenderType gender) : base(age, name, gender) { }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
