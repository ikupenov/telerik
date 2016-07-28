namespace Classes
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int studentNumber;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.studentNumber = 10000;
            School = null;
        }

        public School School { get; internal set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name can not be null or empty");
                }

                value.Trim();
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name can not be null or empty");
                }

                value.Trim();
                this.lastName = value;
            }
        }

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            internal set
            {
                this.studentNumber = value;
            }
        }

        public void JoinCourse(Course course)
        {
            Validator.NullValidator(course);
            
            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            Validator.NullValidator(course);

            course.RemoveStudent(this);
        }
    }
}