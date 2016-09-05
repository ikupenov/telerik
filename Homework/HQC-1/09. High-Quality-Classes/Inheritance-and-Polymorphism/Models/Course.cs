namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                // Validation

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                // Validation

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                // Validation

                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("LocalCourse { Name = ");
            result.Append($"{this.Name}; ");

            if (this.TeacherName != null)
            {
                result.Append("Teacher = ");
                result.Append($"{this.TeacherName}; ");
            }

            result.Append("Students = ");
            result.Append($"{this.GetStudentsAsString()}; ");

            return result.ToString();
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}