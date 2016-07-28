namespace Classes.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_FirstNameNull_ShouldThrowNullException()
        {
            var student = new Student(null, "LastName");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_LastNameNull_ShouldThrowNullException()
        {
            var student = new Student("FirstName", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_FirstNameEmpty_ShouldThrowNullException()
        {
            var student = new Student("FirstName", "  ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_LastNameEmpty_ShouldThrowNullException()
        {
            var student = new Student("  ", "LastName");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_JoinCourseNullValue_ShouldThrowNullException()
        {
            var student = new Student("Doncho", "Minkov");

            student.JoinCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_LeaveCourseNullValue_ShouldThrowNullException()
        {
            var student = new Student("Doncho", "Minkov");

            student.LeaveCourse(null);
        }

        [TestMethod]
        public void Student_FirstName_ShouldNameCorrectly()
        {
            string firstName = "Ivan";

            var student = new Student("Ivan", "Kolev");

            Assert.AreEqual(firstName, student.FirstName);
        }

        [TestMethod]
        public void Student_LastName_ShouldNameCorrectly()
        {
            string lastName = "Kolev";
            var student = new Student("Ivan", "Kolev");

            Assert.AreEqual(lastName, student.LastName);
        }

        [TestMethod]
        public void Student_JoinCourse_ShouldJoinCourseCorrectly()
        {
            var first = new Student("Steve", "Aoki");
            var second = new Student("Doncho", "Minkov");

            var course = new Course(new List<Student>() { first });

            second.JoinCourse(course);

            Assert.AreEqual(2, course.Students.Count);
        }

        [TestMethod]
        public void Student_LeaveCourse_ShouldLeaveCourseCorrectly()
        {
            var first = new Student("Steve", "Aoki");
            var second = new Student("Doncho", "Minkov");

            var course = new Course(new List<Student>() { first, second });

            second.LeaveCourse(course);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void Student_UniqueNumber_ShouldBeInCorrectRange()
        {
            var student = new Student("Goshko", "Petrov");
            bool isInCorrectRange = true;

            if (student.StudentNumber < 10000 || student.StudentNumber > 99999)
            {
                isInCorrectRange = false;
            }

            Assert.IsTrue(isInCorrectRange);
        }
    }
}
