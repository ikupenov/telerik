namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            private set
            {
                // Validation

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            var baseToString = base.ToString();
            builder.Append(baseToString);

            if (this.Lab != null)
            {
                builder.Append($"Lab = {this.Lab}");
            }

            builder.Append(" }");

            return builder.ToString();
        }
    }
}