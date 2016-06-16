namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main()
        {
            var builder = new StringBuilder();

            builder.Append("Gosho");
            builder.Append("c");
            builder.Append("PEsho");

            var after = builder.Substring(0,11);
            Console.WriteLine(after);

            var list = new List<int>();
            list.Add(5);
            list.Add(1);
            list.Add(10);
            Console.WriteLine(list.MySum());

            var shortList = new List<long>();
            shortList.Add(10);
            shortList.Add(200);
            shortList.Add(107);
            Console.WriteLine(shortList.MySum());
            Console.WriteLine(shortList.MyMin());

            var thirdStudent = new Students("Banio", "Avanov", 21);
            var st2 = new Students("Boyano", "Boyanov", 18);
            var firstStudent = new Students("Kaloyancho", "Stoykov", 19);
            var ran1 = new Students("Stoyko", "Stoqnov", 17);
            var secondStudent = new Students("Pesho", "Slaveykov", 58);

            var studentArr = new Students[] { firstStudent, secondStudent, ran1, thirdStudent, st2 };

            /* Problem 3. First before last
Write a method that from a given array of students finds all students whose 
first name is before its last name alphabetically.*/

            var listedByName = studentArr.Where((f) => f.FirstName.CompareTo(f.LastName) == -1)
                                         .ToArray();

            /* Problem 4. Age range
Write a LINQ query that finds the first name and last name of all students 
with age between 18 and 24.*/

            var listedByAge = studentArr.Where(s => s.Age >= 18 && s.Age <= 24)
                                        .Select(s => s.FirstName + " " + s.LastName)
                                        .ToArray();

            /* Problem 5. Order students

Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
the students by first name and last name in descending order. */

            var orderedByName = studentArr.OrderBy(s => s.FirstName)
                                          .ThenBy(s => s.LastName)
                                          .ToArray();

            /* Problem 6. Divisible by 7 and 3
Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.*/

            var intArr = new int[] { 3, 7, 84, 14, 10, 9, 12, 21, 1603, 42 };

            var divisibleBy7And3 = intArr.Where(x => x % 3 == 0 && x % 7 == 0)
                                         .ToArray();


        }
    }
}
