namespace StudentsAndWorkers.PeopleGenerator
{
    using NameGenerator;
    using People;
    using System;
    using System.Collections.Generic;

    public static class WorkerGenerator
    {
        private static List<Worker> workers;
        private static Random rnd;

        static WorkerGenerator()
        {
            workers = new List<Worker>();
            rnd = new Random();
        }

        public static List<Worker> GetWorkers
        {
            get
            {
                return workers;
            }
        }

        public static void GenerateWorkers(int numberOfWorkers)
        {
            for (int i = 0; i < numberOfWorkers; i++)
            {
                var firstName = (FirstNameType)rnd.Next(0, 20);
                var lastName = (LastNameType)rnd.Next(0, 20);

                var weekSalary = rnd.Next(1000, 10001);
                var workingHours = rnd.Next(4, 9);

                workers.Add(new Worker(firstName.ToString(), lastName.ToString(), weekSalary, workingHours));
            }
        }
    }
}
