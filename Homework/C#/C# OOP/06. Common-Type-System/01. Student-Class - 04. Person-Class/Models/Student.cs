namespace StudentClass.Models
{
    using System;
    using System.Text;
    using Infrastructure.Enumerations;
    using Infrastructure.Verification;

    public class Student : ICloneable, IComparable<Student>
    {
        ////Field
        private string firstName;
        private string middleName;
        private string lastName;
        private string socialSecurityNumber;
        private string permanentAddress;
        private string phoneNumber;
        private string email;

        ////Constructor
        public Student(
            string firstName,
            string middleName,
            string lastName,
            string socialSecurityNumber,
            string permanentAddress,
            string phoneNumber,
            string emailAddress,
            string course,
            SpecialtyType specialty,
            UniversityType university,
            FacultyType faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = socialSecurityNumber;
            this.permanentAddress = permanentAddress;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        ////Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                InvalidInputVerification.VerifyName(value);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            private set
            {
                InvalidInputVerification.VerifyName(value);
                this.middleName = value;
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
                InvalidInputVerification.VerifyName(value);
                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.socialSecurityNumber;
            }

            private set
            {
                InvalidInputVerification.VerifySSN(value);
                this.socialSecurityNumber = value;
            }
        }

        public string Address
        {
            get { return this.permanentAddress; }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            private set
            {
                InvalidInputVerification.VerifyPhoneNumber(value);
                this.phoneNumber = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.email;
            }

            private set
            {
                InvalidInputVerification.VerifyEmailAddress(value);
                this.email = value;
            }
        }

        public string Course { get; set; }

        public SpecialtyType Specialty { get; set; }

        public UniversityType University { get; set; }

        public FacultyType Faculty { get; set; }

        ////Methods
        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !Student.Equals(firstStudent, secondStudent);
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
            {
                return false;
            }
            else if (this.SSN == student.SSN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(string.Format("Name: {0}", this.firstName + " " + this.middleName + " " + this.lastName));
            builder.AppendLine("Phone Number: " + this.phoneNumber);
            builder.AppendLine("Address: " + this.permanentAddress);
            builder.AppendLine("Email Address: " + this.email);
            builder.AppendLine("University " + this.University);
            builder.AppendLine("Faculty: " + this.Faculty);
            builder.AppendLine("Specialty: " + this.Specialty);

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return Math.Abs(this.LastName.GetHashCode() ^ this.SSN.GetHashCode());
        }

        public object Clone()
        {
            return new Student(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.SSN,
                this.Address,
                this.PhoneNumber,
                this.EmailAddress,
                this.Course,
                this.Specialty,
                this.University,
                this.Faculty);
        }

        public int CompareTo(Student other)
        {
            int result = 0;

            if (this.FirstName.Length > other.FirstName.Length)
            {
                result = 1;
            }
            else if (other.FirstName.Length > this.FirstName.Length)
            {
                result = -1;
            }
            else
            {
                for (int i = 0; i < this.FirstName.Length; i++)
                {
                    if (this.FirstName[i] > other.FirstName[i])
                    {
                        result = 1;
                        break;
                    }
                    else if (other.FirstName[i] > this.FirstName[i])
                    {
                        result = -1;
                        break;
                    }
                }
            }

            if (result == 0)
            {
                if (int.Parse(this.SSN) > int.Parse(other.SSN))
                {
                    result = 1;
                }
                else if (int.Parse(other.SSN) > int.Parse(this.SSN))
                {
                    result = -1;
                }
            }

            return result;
        }
    }
}