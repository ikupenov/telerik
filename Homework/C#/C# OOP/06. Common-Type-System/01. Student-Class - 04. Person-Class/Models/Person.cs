namespace StudentClass.Models
{
    using System;
    using System.Text;

    public class Person
    {
        private int? age;

        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int? Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age out of range [0, 120]");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Name: " + this.Name);
            
            if (this.age == null)
            {
                builder.AppendLine("Age: [unspecified]");
            }
            else
            {
                builder.AppendLine("Age: " + this.Age);
            }

            return builder.ToString().Trim();
        }
    }
}
