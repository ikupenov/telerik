namespace Classes
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private const int minUniqueNumber = 10000;
        private const int maxUniqueNumber = 99999;
        private readonly int maxCapacity;

        private List<Student> studentsInThisSchool;
        private int uniqueNumberCounter;

        public School(List<Student> students)
        {
            maxCapacity = maxUniqueNumber - minUniqueNumber;

            this.studentsInThisSchool = new List<Student>();
            uniqueNumberCounter = minUniqueNumber;
            this.Students = students;
        }

        public List<Student> Students
        {
            get
            {
                return this.studentsInThisSchool;
            }

            private set
            {
                Validator.NullValidator(value);

                if (value.Count > maxCapacity)
                {
                    throw new ArgumentOutOfRangeException();
                }

                foreach (var student in value)
                {
                    foreach (var std in this.studentsInThisSchool)
                    {
                        if (std.StudentNumber == student.StudentNumber && 
                            std.School != null && 
                            student.School != null)
                        {
                            throw new ArgumentException("Student with the same number already exists.");
                        }
                    }

                    if (uniqueNumberCounter > maxUniqueNumber)
                    {
                        throw new ArgumentOutOfRangeException("Students can not exceed school's capacity ({0}).", maxCapacity.ToString());
                    }

                    student.StudentNumber = uniqueNumberCounter++;
                    this.studentsInThisSchool.Add(student);
                    student.School = this;
                }
            }
        }
    }
}