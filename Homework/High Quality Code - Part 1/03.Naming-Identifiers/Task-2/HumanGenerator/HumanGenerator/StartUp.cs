namespace HumanGenerator
{
    using System;

    class StartUp
    {
        private static void Main()
        {
            var person = Human.CreateRandomHuman(14);

            Console.WriteLine($"My name is {person.Name} and I am {person.Age}-years-old");
        }
    }
}