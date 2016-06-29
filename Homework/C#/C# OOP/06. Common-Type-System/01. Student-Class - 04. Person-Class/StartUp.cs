namespace StudentClass
{
    using System;

    using Infrastructure.Enumerations;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("01. Student Class  \n02. ICloneable  \n03. IComparable");
            Console.WriteLine(new string('-', 20));

            Student firstStudent = new Student(
                "Jake",
                "Jacob",
                "Jackson",
                "123456789",
                "Str. 8, Bld. 2",
                "4412849222",
                "jj.jackson@gmail.com",
                "Biotechnology ",
                SpecialtyType.InternalMedicine,
                UniversityType.CardiffUniversity,
                FacultyType.Medical);

            Student secondStudent = new Student(
                "Stephen",
                "Lee",
                "Manning",
                "123456788",
                "Str. 87, Ent. 3",
                "4471494602",
                "stephee@gmail.com",
                "Advanced Photography",
                SpecialtyType.PhotoJournalism,
                UniversityType.UniversityOfCalifornia,
                FacultyType.Journalism);

            Console.WriteLine("Compare: " + firstStudent.CompareTo(secondStudent) + "\n");
            Console.WriteLine("First Student Hashcode: " + firstStudent.GetHashCode());
            Console.WriteLine("Second Student Hashcode: " + secondStudent.GetHashCode() + "\n");

            Console.WriteLine("04. Person Class");
            Console.WriteLine(new string('-', 20));
            var firstPerson = new Person("Mihael");
            var secondPerson = new Person("Gosho", 12);

            Console.WriteLine(firstPerson + "\n");
            Console.WriteLine(secondPerson);


        }
    }
}