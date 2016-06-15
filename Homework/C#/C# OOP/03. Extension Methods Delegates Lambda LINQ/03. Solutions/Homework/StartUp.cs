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

            decimal s = 5m;
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

            //shortList.Sum()

            Console.WriteLine(shortList.MyMin());

            var thirdStudent = new Students("Banio", "Avanov");
            var firstStudent = new Students("Kaloyancho", "Stoykov");
            var secondStudent = new Students("Pesho", "Slaveykov");

            var studentArr = new Students[] { firstStudent, secondStudent, thirdStudent };

            var listed = studentArr.Where((f) => f.FirstName.CompareTo(f.LastName) == -1).ToArray();

        }
    }
}
