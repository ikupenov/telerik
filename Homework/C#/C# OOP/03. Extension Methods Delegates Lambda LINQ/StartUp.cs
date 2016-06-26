namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class StartUp
    {
        static void Main()
        {
            /*Problem 1. StringBuilder.Substring
Implement an extension method Substring(int index, int length) for the class StringBuilder that returns 
new StringBuilder and has the same functionality as Substring in the class String.*/

            var builder = new StringBuilder();

            builder.Append("Implement an extension method");
            builder.Append(" returns new StringBuilder and has the same functionality as");
            builder.Append(" Substring in the class String.");

            var substring = builder.Substring(90, 30);
            Console.WriteLine("StringBuilder Substring Extension Method: [" + substring + "]");
            Console.WriteLine();

            /*Problem 2. IEnumerable extensions
Implement a set of extension methods for IEnumerable<T> that implement 
the following group functions: sum, product, min, max, average.*/

            var list = new List<int>();
            list.Add(5);
            list.Add(1);
            list.Add(10);

            Console.Write("Array: ");

            foreach (var number in list)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Sum:     [" + list.MySum() + "]");
            Console.WriteLine("Product: [" + list.MyProduct() + "]");
            Console.WriteLine("Average: [" + list.MyAverage() + "]");
            Console.WriteLine("Min:     [" + list.MyMin() + "]");
            Console.WriteLine("Max:     [" + list.MyMax() + "]");
            Console.WriteLine();

            var marks1 = new List<byte>() { 4, 3, 5 };
            var marks2 = new List<byte>() { 6, 6, 6 };
            var marks3 = new List<byte>() { 3, 4, 3 };
            var marks4 = new List<byte>() { 2, 2, 3 };
            var marks5 = new List<byte>() { 5, 5, 6 };

            var studentsArr = new List<Student>()
            {
                new Student("Banio", "Avanov", 21, "02-413-4130", "bavanov@abv.bg", marks1, "107205", "2"),
                new Student("Boyano", "Boyanov", 18, "07-409-3313", "bitko.p@abv.bg", marks2, "107205", "1"),
                new Student("Kaloyancho", "Stoykov", 19, "07-436-5022", "k.stoykov@gmail.com", marks3, "107206", "2"),
                new Student("Stoyko", "Stoqnov", 17, "02-285-8624", "ssm_98@gmail.com", marks4, "107206", "1"),
                new Student("Pesho", "Georgiev", 38, "05-352-6526", "pe66@abv.bg", marks5, "107208", "2")
            };

            /* Problem 3. First before last
Write a method that from a given array of students finds all students whose 
first name is before its last name alphabetically.*/

            var listedByName = studentsArr.Where((f) => f.FirstName.CompareTo(f.LastName) == -1)
                                          .ToList();

            Console.WriteLine("First before last");

            foreach (var std in listedByName)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /* Problem 4. Age range
Write a LINQ query that finds the first name and last name of all students 
with age between 18 and 24.*/

            var selectedByAge = studentsArr.Where(s => s.Age >= 18 && s.Age <= 24)
                                           .Select(s => s.FullName)
                                           .ToList();

            Console.WriteLine("Age Between 18 and 24");

            foreach (var std in selectedByAge)
            {
                Console.WriteLine("[" + std + "]");
            }

            Console.WriteLine();

            /* Problem 5. Order students
Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
the students by first name and last name in descending order. */

            var orderedByName = studentsArr.OrderBy(s => s.FirstName)
                                           .ThenBy(s => s.LastName)
                                           .ToList();

            var _orderedByName = from std in studentsArr
                                 orderby std.FirstName, std.LastName
                                 select std;

            Console.WriteLine("Sorted by First and Last name");

            foreach (var std in orderedByName)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /* Problem 6. Divisible by 7 and 3
Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.*/

            var intArr = new int[] { 3, 7, 84, 14, 10, 9, 12, 21, 1603, 42 };

            var divisibleBy7And3 = intArr.Where(x => x % 3 == 0 && x % 7 == 0)
                                         .ToList();

            var _divisibleBy7And3 = from std in intArr
                                    where (std % 3 == 0 && std % 7 == 0)
                                    select std;

            Console.Write("Array: ");

            foreach (var number in intArr)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.Write("Divisible by 7 and 3: ");

            foreach (var divisible in divisibleBy7And3)
            {
                Console.Write(divisible + " " );
            }

            Console.WriteLine();
            Console.WriteLine();

            /*Problem 7. Timer
Using delegates write a class Timer that can execute certain method at each t seconds.*/

            Console.WriteLine("Uncomment Task 8 To Enable the Timer");
            Console.WriteLine();

            //UNCOMMENT TO ACTIVATE (Disabled since it's printing the current date every second)

            //Timer.SetInterval(new Action(() => Timer.CurrentDate()), 1); /*<--------UNCOMMENT ME--------*/ 

            /*Problem 8.* Events
Read in MSDN about the keyword event in C# and how to publish events.
Re-implement the above using .NET events and following the best practices.*/

            Console.WriteLine("Uncomment Task 8 To Enable the Event");
            Console.WriteLine();

            //Publisher p = new Publisher(1);     ////UNCOMMENT
            //Listener l = new Listener(60);      ////---ME----
            //l.Subscribe(p);                     ////---TO----
            //p.Start();                          ////--START--

            //l.Unsubscribe(p);

            /*Problem 9. Student groups
Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
Create a List<Student> with sample students. Select only the students that are from group number 2.
Use LINQ query. Order the students by FirstName.*/

            var selectedByGroup = studentsArr.Where(s => s.GroupNumber == "1")
                                             .OrderBy(x => x.FirstName)
                                             .ToList();

            Console.WriteLine("Students from group number 2");

            foreach (var std in selectedByGroup)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /*Problem 10. Student groups extensions
Implement the previous using the same query expressed with extension methods.*/

            var _selectedByGroup = studentsArr.ExtractAndOrder();

            /*Problem 11. Extract students by email
Extract all students that have email in abv.bg.
Use string methods and LINQ.*/

            var selectABV = studentsArr.Where(s => s.Email.Contains("@abv.bg"))
                                       .ToList();

            Console.WriteLine("Students that have email in abv.bg");

            foreach (var std in selectABV)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /*Problem 12. Extract students by phone
Extract all students with phones in Sofia.
Use LINQ.*/

            var extractByPhone = studentsArr.Where(s => s.Tel.IndexOf("02") == 0)
                                            .ToList();

            Console.WriteLine("Students with phone in Sofia");

            foreach (var std in extractByPhone)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /*Problem 13. Extract students by marks
Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
Use LINQ.*/

            var extractByExcellentMark = studentsArr.Where(s => s.Marks.Contains(6))
                                                    .Select(x => new
                                                    {
                                                        FullName = x.FullName,
                                                        Marks = x.Marks
                                                    });

            Console.WriteLine("Students with at least one excellent mark");

            foreach (var std in extractByExcellentMark)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /*Problem 14. Extract students with two marks
Write down a similar program that extracts the students with exactly two marks "2".
Use extension methods.*/

            var extractedByTwoMarks = studentsArr.FindAll(s => s.Marks.ContainsAtLeast(2, 2))
                                                 .ToList();

            var _extractedByTwoMarks = from std in studentsArr
                                       where (std.Marks.ContainsAtLeast(2, 2))
                                       select std;

            Console.WriteLine(@"Students with exactly two marks ""2""");

            foreach (var std in extractedByTwoMarks)
            {
                Console.WriteLine("[" + std.FullName + "]");
            }

            Console.WriteLine();

            /*Problem 15. Extract marks
Extract all Marks of the students that enrolled in 2006. 
(The students from 2006 have 06 as their 5-th and 6-th digit in the FN).*/

            var extractMarksByYear = studentsArr.FindAll(s => s.FN[5] == '6')
                                                .Select(s => s.Marks)
                                                .ToList();

            Console.WriteLine("Marks of students that enrolled in 2006");

            foreach (var std in extractMarksByYear)
            {
                foreach (var mark in std)
                {
                    Console.Write("[" + mark + "]");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            /*Problem 16.* Groups
Create a class Group with properties GroupNumber and DepartmentName.
Introduce a property GroupNumber in the Student class.
Extract all students from "Mathematics" department.
Use the Join operator.*/

            Console.WriteLine(@"Extract all students from ""Mathematics"" department");

            var grp = new List<Group>()
            {
                new Group("1", "Mathematics"),
                new Group("2", "Sports")
            };

            var extractedByDepartment = from s in studentsArr
                                        join g in grp 
                                        on s.GroupNumber equals g.GroupNumber
                                        where s.GroupNumber == "1"
                                        select new { s.FullName, g.DepartmentName };

            foreach (var item in extractedByDepartment)
            {
                Console.Write("{0} from the {1} department", item.FullName, item.DepartmentName);
                Console.WriteLine();
            }

            Console.WriteLine();

            /*Problem 17. Longest string
Write a program to return the string with maximum length from an array of strings.
Use LINQ.*/

            var arrOfStrings = new string[5] 
            {
                "write a program",
                "to return the string",
                "with maximum length",
                "from an array of strings",
                "use LINQ"
            };    

            var longestString = arrOfStrings.OrderByDescending(s => s.Length)
                                            .First();

            Console.WriteLine("String with maximum length from an array: [" + longestString + "]");
            Console.WriteLine();

            /* Problem 18.Grouped by GroupNumber
Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
Use LINQ.*/

            Console.WriteLine("Students grouped by GroupNumber");

            var groupedByGroupNumber = studentsArr.GroupBy(s => s.GroupNumber);

            foreach (var group in groupedByGroupNumber)
            {
                foreach (var student in group)
                {
                    Console.WriteLine("Student [{0}] is in group [{1}].", student.FullName, group.Key);
                }
            }

            Console.WriteLine();

            /* Problem 19. Grouped by GroupName extensions
Rewrite the previous using extension methods.*/

            var _groupedByGroupNumber = from std in studentsArr
                                        group std by std.GroupNumber
                                        into std
                                        select std;

            /*Problem 20.* Infinite convergent series

By using delegates develop an universal static method to calculate the sum of infinite convergent series 
with given precision depending on a function of its term. By using proper functions for the term calculate 
with a 2-digit precision the sum of the infinite series:
1 + 1/2 + 1/4 + 1/8 + 1/16 + …
1 + 1/2! + 1/3! + 1/4! + 1/5! + …
1 + 1/2 - 1/4 + 1/8 - 1/16 + …*/

            var result1 = ConvergentSeries.InfiniteSeries(5, (y, x, z) => 1 / x);
            Console.Write("First Convergent Series:  ");
            Console.WriteLine("{0:F2}", result1);

            var result2 = ConvergentSeries.InfiniteFactorial(5, (y, x) => 1 / x * y);
            Console.Write("Second Convergent Series: ");
            Console.WriteLine("{0:F2}", result2);

            var result3 = ConvergentSeries.InfiniteSeries(5, (y, x, z) => z % 2 == 0 ? -1 / x : 1 / x);
            Console.Write("Third Convergent Series:  ");
            Console.WriteLine("{0:F2}", result3);
        }
    }
}
 
 