namespace Homework
{
    using System;
    using System.Threading;

    static class Timer
    {
        public static void SetInterval(Action action, int time)
        {
            while (true)
            {
                Thread.Sleep(time * 1000);
                action();
            }
        }

        public static void CurrentDate()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
