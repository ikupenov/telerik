namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class CoursesExamples
    {
        public static void Run()
        {
            var localCourse = new LocalCourse(
                "Databases",
                "Ivan Todorov",
                new List<string> { "Gosho", "Pesho" },
                "SomeLab");
            Console.WriteLine(localCourse);

            var offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev",
                new List<string>() { "Thomas", "Ani", "Steve" },
                "SomeTown");
            Console.WriteLine(offsiteCourse);
        }
    }
}