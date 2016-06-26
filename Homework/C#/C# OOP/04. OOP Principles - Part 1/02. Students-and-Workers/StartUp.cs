namespace StudentsAndWorkers
{
    using People;
    using PeopleGenerator;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            StudentGenerator.GenerateStudents(10);
            var students = StudentGenerator.GetStudents;
            students = students.OrderByDescending(s => s.Grade)
                               .ToList();

            WorkerGenerator.GenerateWorkers(10);
            var workers = WorkerGenerator.GetWorkers;
            workers = workers.OrderByDescending(w => w.HourlyWage)
                             .ToList();

            var mergedList = new List<Human>();

            mergedList = mergedList.Concat(students)
                                   .Concat(workers)
                                   .OrderBy(x => x.FirstName)
                                   .ThenBy(x => x.LastName)
                                   .ToList();

            foreach (var person in mergedList)
            {
                Console.WriteLine("{0} {1}", person.FullName.PadRight(25, '-'), Type.GetType(person.ToString()).Name);
            }

        }
    }
}
