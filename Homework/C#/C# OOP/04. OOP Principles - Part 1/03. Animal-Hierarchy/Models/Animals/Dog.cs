namespace AnimalHierarchy.Models.Animals
{
    using Infrastructure.Enumerations;
    using AnimalHierarchy.Models.Abstract;
    using System;

    public class Dog : Animal
    {
        public Dog(int age, string name, GenderType gender) : base(age, name, gender) { }

        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }
}
