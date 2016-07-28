namespace Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private const int courseCapacity = 30;

        private List<Student> students;

        public Course(List<Student> students)
        {
            this.students = new List<Student>();
            this.Students = students;
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                Validator.NullValidator(value);
                CapacityValidator();

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            Validator.NullValidator(student);
            CapacityValidator();

            if (this.students.Any(std => std == student))
            {
                throw new ArgumentException("This student has been already added.");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.NullValidator(student);
            CapacityValidator();

            if (this.students.All(std => std != student))
            {
                throw new ArgumentException("There is no such student in this course");
            }

            this.Students.Remove(student);
        }

        private void CapacityValidator()
        {
            if (this.Students.Count >= courseCapacity)
            {
                throw new ArgumentOutOfRangeException("The number of students can not exceed the course capacity.");
            }
        }
    }
}