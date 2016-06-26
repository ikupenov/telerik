namespace SchoolClasses.School.People
{
    using SchoolClasses.Utilities;

    public class Student : Person
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClassNumber = UniqueClassNumber.GenerateUniqueClassNumber();
        }

        public override string FirstName { get; }

        public override string LastName { get; }

        public int ClassNumber { get; }

        public override string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
