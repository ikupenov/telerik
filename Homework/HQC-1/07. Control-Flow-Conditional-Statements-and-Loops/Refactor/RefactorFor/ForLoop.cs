namespace RefactorFor
{
    using System;

    public class ForLoop
    {
        public void RefactorForLoop()
        {
            var array = default(int[]);
            int expectedValue = default(int);

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);

                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}