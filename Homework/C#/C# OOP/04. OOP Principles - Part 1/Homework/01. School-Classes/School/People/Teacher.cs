namespace SchoolClasses.School.People
{
    using Enumerations;
    using System.Collections.Generic;

    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName, List<DisciplineType> setOfDisciplines)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.Disciplines = new List<DisciplineType>();
            this.Disciplines = setOfDisciplines;
        }

        public List<DisciplineType> Disciplines { get; }

        public override string FirstName { get; }

        public override string LastName { get; }

        public override string FullName
        {
            get
            {
                return string.Format("Mr/Mrs {0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
