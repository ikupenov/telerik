namespace Classes.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_InitializeWithNull_ShouldThrowNullException()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_AddNull_ShouldThrowNullException()
        {
            var student = new Student("Minko", "Georgiev");
            var course = new Course(new List<Student>() { student });

            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_RemoveNull_ShouldThrowNullException()
        {
            var student = new Student("Minko", "Georgiev");

            var course = new Course(new List<Student>() { student });

            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_RemoveNonExistent_ShouldThrowArgumentException()
        {
            var student = new Student("Minko", "Georgiev");
            var nonExistentInCourse = new Student("Angelina", "Popova");

            var course = new Course(new List<Student>() { student });

            course.RemoveStudent(nonExistentInCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Course_ExceedingCapacity_ShouldThrowOutOfRangeException()
        {
            var student = new Student("Georgi", "Todorov");
            var course = new Course(new List<Student>() { student });

            for (int i = 0; i < 100; i++)
            {
                course.AddStudent(new Student(i.ToString(), i.ToString()));
            }
        }

        [TestMethod]
        public void Course_AddStudent_ShouldAddStudentsCorrectly()
        {
            var student = new Student("Georgi", "Todorov");
            var course = new Course(new List<Student>() { student });

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldRemoveStudentsCorrectly()
        {
            var first = new Student("Georgi", "Todorov");
            var second = new Student("Minko", "Georgiev");

            var course = new Course(new List<Student>() { first, second });

            course.RemoveStudent(second);

            Assert.AreEqual(1, course.Students.Count);
        }
    }
}