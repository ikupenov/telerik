namespace RangeExceptions
{
    using RangeExceptions.Exceptions;
    using System;

    class StartUp
    {
        static void Main()
        {
            try
            {
                int number = -2;

                if (number < 1 || number > 100)
                {
                    throw new InvalidRangeException<int>("Invalid Number", 1, 100);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

            //-------------------------------------------------------------------

            try
            {
                DateTime date = new DateTime(1950, 1, 1);

                if (date < new DateTime(1980, 1, 1) || date > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Invalid Date", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
