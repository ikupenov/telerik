namespace Classes.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void School_InitializeWithNull_ShouldThrowNullException()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void School_ExceedingCapacity_ShouldThrowOutOfRangeException()
        {
            var students = new List<Student>();

            for (int i = 0; i < 1e5; i++)
            {
                students.Add(new Student("Test", "Student"));
            }

            var school = new School(students);
        }

        [TestMethod]
        public void School_SameIDsInSameSchool_ShouldHaveDifferentStudentNumbers()
        {
            var firstStd = new Student("Milen", "Peshov");
            var secondStd = new Student("Nese", "Seshtam");
            var school = new School(new List<Student>() { firstStd, secondStd });

            Assert.AreNotEqual(firstStd.StudentNumber, secondStd.StudentNumber);
        }

        [TestMethod]
        public void School_SameIDsInDifferentSchools_CouldHaveSameStudentNumbers()
        {
            var firstStd = new Student("Milen", "Peshov");
            var firstSchool = new School(new List<Student>() { firstStd });

            var secondStd = new Student("Nese", "Seshtam");
            var secondSchool = new School(new List<Student>() { secondStd });

            Assert.AreEqual(firstStd.StudentNumber, secondStd.StudentNumber);
        }

        [TestMethod]
        public void School_InitialStudents_ShouldGetStudentsCorrectly()
        {
            var firstStd = new Student("Milen", "Peshov");
            var secondStd = new Student("Nese", "Seshtam");

            var school = new School(new List<Student>() { firstStd, secondStd });

            var students = school.Students;

            Assert.AreEqual(students, school.Students);
        }
    }
}