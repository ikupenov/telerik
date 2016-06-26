namespace StudentsAndWorkers.People
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
        }
    }
}
