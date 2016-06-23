namespace SchoolClasses.School
{
    using System.Collections.Generic;
    using People;
    using System.Text;

    public class SchoolClass
    {
        private List<Student> students;
        private List<Teacher> teachers;

        public SchoolClass(List<Student> students, List<Teacher> teachers)
        {
            this.students = new List<Student>();
            this.students = students;

            this.teachers = new List<Teacher>();
            this.teachers = teachers;

            this.UniqueTextIdentifier = Utilities.UniqueTextIdentifier.GenerateUniqueTextIdentifier();
        }

        public string UniqueTextIdentifier { get; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            if (this.students.Count == 0)
            {
                builder.AppendLine("There are currently no students in this class.");
            }
            else
            {
                builder.AppendLine("Students In Class");
                builder.AppendLine(new string('_', 17));
                builder.AppendLine();

                foreach (var student in this.students)
                {
                    builder.Append($"{student.ClassNumber}. {student.FullName}");
                    builder.AppendLine();
                }
            }

            builder.AppendLine();
            builder.AppendLine(new string('=', 17));
            builder.AppendLine();

            if (this.teachers.Count == 0)
            {
                builder.AppendLine("There are currently no teachers in this class.");
            }
            else
            {
                builder.AppendLine("Teachers In Class");
                builder.AppendLine(new string('_', 17));
                builder.AppendLine();

                foreach (var teacher in this.teachers)
                {
                    string teacherDisciplines = string.Empty;

                    foreach (var discipline in teacher.Disciplines)
                    {
                        teacherDisciplines += discipline + ", ";
                    }

                    teacherDisciplines = teacherDisciplines.Trim(',', ' ');
                    builder.Append($"{teacherDisciplines} - {teacher.FullName}");
                    builder.AppendLine();
                }
            }

            builder.AppendLine();
            builder.AppendLine(new string('=', 17));

            return builder.ToString().Trim();
        }
    }
}
