namespace NumberMatrix
{
    using System;

    class StartUp
    {
        static void Main()
        {
            Matrix<int> test1 = new Matrix<int>(3, 2);
            Matrix<int> test2 = new Matrix<int>(2, 2);

            test1[0, 0] = 4;
            test1[0, 1] = 8;
            test1[1, 0] = 0;
            test1[1, 1] = 2;
            test1[2, 0] = 1;
            test1[2, 1] = 6;

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1st Matrix");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test1);
            Console.WriteLine();

            test2[0, 0] = 5;
            test2[0, 1] = 2;
            test2[1, 0] = 9;
            test2[1, 1] = 4;

            Console.WriteLine("2nd Matrix");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test2);
            Console.WriteLine();

            Console.WriteLine("Product of FIRST and SECOND Matrices");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test1 * test2);
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();

            Matrix<int> test3 = new Matrix<int>(2, 2);
            Matrix<int> test4 = new Matrix<int>(2, 2);

            test3[0, 0] = 10;
            test3[0, 1] = 28;
            test3[1, 0] = 47;
            test3[1, 1] = 86;

            Console.WriteLine("3rd Matrix");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test3);
            Console.WriteLine();

            test4[0, 0] = 42;
            test4[0, 1] = 13;
            test4[1, 0] = 11;
            test4[1, 1] = 38;

            Console.WriteLine("4th Matrix");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test4);
            Console.WriteLine();

            Console.WriteLine("Sum of THIRD and FOURTH Matrices");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test3 + test4);
            Console.WriteLine();

            Console.WriteLine("Difference of THIRD and FOURTH Matrices");
            Console.WriteLine(new string('_', 15));
            Console.WriteLine(test3 - test4);
            Console.WriteLine(new string('=', 50));
        }
    }
}
