namespace NumberMatrix
{
    using System;

    public class Test
    {
        public static void Multiplication ()
        {
            Matrix<int> test1 = new Matrix<int>(3, 2);
            Matrix<int> test2 = new Matrix<int>(2, 2);

            Random rnd = new Random();

            for (int i = 0; i < test1.GetLength(0); i++)
            {
                for (int j = 0; j < test1.GetLength(1); j++)
                {
                    test1[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1st Matrix");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test1);

            for (int i = 0; i < test2.GetLength(0); i++)
            {
                for (int j = 0; j < test2.GetLength(1); j++)
                {
                    test2[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine("\r\n2nd Matrix");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test2);

            Console.WriteLine("\r\nProduct of Matrices");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test1 * test2);
            Console.WriteLine(new string('-', 50));
        }

        public static void Addition()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 50));

            Matrix<int> test1 = new Matrix<int>(2, 2);
            Matrix<int> test2 = new Matrix<int>(2, 2);

            Random rnd = new Random();

            for (int i = 0; i < test1.GetLength(0); i++)
            {
                for (int j = 0; j < test1.GetLength(1); j++)
                {
                    test1[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine("1st Matrix");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test1);

            for (int i = 0; i < test2.GetLength(0); i++)
            {
                for (int j = 0; j < test2.GetLength(1); j++)
                {
                    test2[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine("\r\n2nd Matrix");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test2);

            Console.WriteLine("\r\nSum of Matrices");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test1 + test2);
            Console.WriteLine(new string('-', 50));
        }

        public static void Subtraction()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 50));

            Matrix<int> test1 = new Matrix<int>(2, 2);
            Matrix<int> test2 = new Matrix<int>(2, 2);

            Random rnd = new Random();

            for (int i = 0; i < test1.GetLength(0); i++)
            {
                for (int j = 0; j < test1.GetLength(1); j++)
                {
                    test1[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine("1st Matrix");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test1);

            for (int i = 0; i < test2.GetLength(0); i++)
            {
                for (int j = 0; j < test2.GetLength(1); j++)
                {
                    test2[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine("\r\n2nd Matrix");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test2);

            Console.WriteLine("\r\nDifference of Matrices");
            Console.WriteLine(new string('_', 20));
            Console.WriteLine(test1 - test2);
            Console.WriteLine(new string('-', 50));
        }
    }
}
