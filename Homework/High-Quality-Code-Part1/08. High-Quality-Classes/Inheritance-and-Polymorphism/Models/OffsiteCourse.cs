namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            private set
            {
                // Validation

                this.town = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            var baseToString = base.ToString();
            builder.Append(baseToString);

            if (this.Town != null)
            {
                builder.Append($"Town = {this.Town}");
            }

            builder.Append(" }");

            return builder.ToString();
        }
    }
}