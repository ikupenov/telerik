namespace StudentsAndWorkers.PeopleGenerator
{
    using Constants;
    using NameGenerator;
    using People;
    using System;
    using System.Collections.Generic;

    public static class StudentGenerator
    {
        private static List<Student> students;
        private static Random rnd;

        static StudentGenerator()
        {
            students = new List<Student>();
            rnd = new Random();
        }

        public static List<Student> GetStudents
        {
            get
            {
                return students;
            }
        }

        public static void GenerateStudents(int numberOfStudents)
        {
            for (int i = 0; i < numberOfStudents; i++)
            {
                var firstName = (FirstNameType)rnd.Next(0, 20);
                var lastName = (LastNameType)rnd.Next(0, 20);

                var grade = rnd.Next(GlobalConstants.LowestGrade, GlobalConstants.HighestGrade);

                students.Add(new Student(firstName.ToString(), lastName.ToString(), grade));
            }
        }
    }
}
