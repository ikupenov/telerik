namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Students
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public byte Age { get; private set; }

        public Students(string firstName, string lastName, byte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
