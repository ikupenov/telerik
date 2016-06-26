namespace AnimalHierarchy.Models.Animals
{
    using AnimalHierarchy.Infrastructure.Enumerations;

    public class Tomcat : Cat
    {
        public Tomcat(int age, string name) : base(age, name, GenderType.Male) { }
    }
}
