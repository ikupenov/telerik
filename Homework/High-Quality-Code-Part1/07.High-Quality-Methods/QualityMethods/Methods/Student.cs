namespace Methods
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            
            private set
            {
                // Validation

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
                // Validation

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                // Validation 

                this.age = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = this.Age > other.Age;

            return isOlder;
        }
    }
}