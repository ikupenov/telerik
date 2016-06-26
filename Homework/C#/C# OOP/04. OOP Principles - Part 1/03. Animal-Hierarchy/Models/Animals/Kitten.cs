namespace AnimalHierarchy.Models.Animals
{
    using AnimalHierarchy.Infrastructure.Enumerations;

    public class Kitten : Cat
    {
        public Kitten(int age, string name) : base(age, name, GenderType.Female) { }
    }
}
