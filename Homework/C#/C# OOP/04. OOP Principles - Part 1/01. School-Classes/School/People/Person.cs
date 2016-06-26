namespace SchoolClasses.School.People
{
    using Contracts;

    public abstract class Person : IComment
    {
        public abstract string FirstName { get; }

        public abstract string LastName { get; }

        public abstract string FullName { get; }

        public string Comment { get; set; }
    }
}
