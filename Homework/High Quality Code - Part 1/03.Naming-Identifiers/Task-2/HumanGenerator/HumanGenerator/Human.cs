using System;

namespace HumanGenerator
{
    public class Human
    {
        const int MinAge = 0;
        const int MaxAge = 120;

        const int MinNameLength = 3;
        const int MaxNameLength = 30;

        private string name;
        private int age;

        public Human()
        {
        }

        public Human(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Name length must be between {MinNameLength} and {MaxNameLength} symbols long.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException($"Age must be between {MinAge} and {MaxAge}.");
                }

                this.age = value;
            }
        }

        public Gender Gender { get; private set; }

        public static Human CreateRandomHuman(int personAge)
        {
            var person = new Human();

            person.Age = personAge;

            if (personAge % 2 == 0)
            {
                person.Name = "Gosho";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Penka";
                person.Gender = Gender.Female;
            }

            return person;
        }
    }
}