namespace SchoolClasses
{
    using Enumerations;
    using School;
    using School.People;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            List<Discipline> disciplines = new List<Discipline>();
            disciplines.Add(new Discipline(DisciplineType.Geography, 40, 200));
            disciplines.Add(new Discipline(DisciplineType.Mathematics, 20, 80));

            var student1 = new Student("Gosho", "Marinov");
            var student2 = new Student("Pesho", "Atanasov");

            var listOfStudents = new List<Student>();
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);

            var disciplineList1 = new List<DisciplineType>();
            disciplineList1.Add(DisciplineType.Geography);
            disciplineList1.Add(DisciplineType.Literature);

            var disciplineList2 = new List<DisciplineType>();
            disciplineList2.Add(DisciplineType.Mathematics);
            disciplineList2.Add(DisciplineType.Physics);

            var teacher1 = new Teacher("Lublana", "Vasileva", disciplineList1);
            var teacher2 = new Teacher("Pavel", "Ivanov", disciplineList2);

            var teacherList = new List<Teacher>();
            teacherList.Add(teacher1);
            teacherList.Add(teacher2);

            SchoolClass firstSchool = new SchoolClass(new List<Student>(), new List<Teacher>());

            SchoolClass secondSchool = new SchoolClass(listOfStudents, teacherList);

            System.Console.WriteLine(firstSchool);
            System.Console.WriteLine(secondSchool);
        }
    }
}
