namespace Homework
{
    using System.Collections.Generic;

    public class Student
    {
        public string FirstName { get; }

        public string LastName { get; }

        public byte Age { get; }

        public string Tel { get; }

        public string Email { get; }

        public List<byte> Marks { get; }

        public string FN { get; }

        public string GroupNumber { get; }

        public Student(string firstName, string lastName, byte age, string tel,
                        string email, List<byte> marks, string FN,string groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.FN = FN;
            this.GroupNumber = groupNumber;
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            private set
            {
                FullName = FirstName + " " + LastName;
            }
        }
    }
}
