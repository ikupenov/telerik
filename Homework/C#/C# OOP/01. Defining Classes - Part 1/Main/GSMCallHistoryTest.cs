namespace Main
{
    using System;
    using System.Collections.Generic;

    public class GSMCallHistoryTest
    {
        private static string[] date = { "1/06/2016", "3/06/2016", "10/06/2016" };
        private static string[] time = { "12:04", "21:37", "18:53" };
        private static string[] dialedNumber = { "0888888888", "0899999999", "0877777777" };
        private static ushort[] duration = { 300, 70, 900 };

        private static List<Call> calls = new List<Call>();

        public static void Initial (GSM phone)
        {
            for (int i = 0; i < 3; i++)
            {
                Call currCall = new Call(date[i], time[i], dialedNumber[i], duration[i]);
                calls.Add(currCall);
                phone.AddCall(currCall);
            }
        }

        public static void CallsInfo ()
        {
            double totalDuration = 0;

            foreach (var call in calls)
            {
                Console.WriteLine($"\r\nCall Date and Time: {call.CallDate} {call.CallTime}\r\nDialed Number: {call.GetDialedPhoneNumber}\r\nCall Duration: {call.CallDuration}s");
                totalDuration += call.CallDuration;
            }

            Console.WriteLine();

            double durationAsMinutes = Math.Ceiling(totalDuration / 60);
            Console.WriteLine("Total Price of Calls in History: {0:C}", durationAsMinutes * 0.37);
        }

        public static void PriceAfterRemoval()
        {
            ushort longestDuration = 0;
            int longestDurationIndex = 0;
            double totalDuration = 0;

            for (int i = 0; i < calls.Count; i++)
            {
                ushort currentDuration = calls[i].CallDuration;
                totalDuration += calls[i].CallDuration;

                if (currentDuration > longestDuration)
                {
                    longestDuration = currentDuration;
                    longestDurationIndex = i;
                }
            }

            calls.Remove(calls[longestDurationIndex]);
            totalDuration -= longestDuration;

            double durationAsMinutes = Math.Ceiling(totalDuration / 60);
            Console.WriteLine("Total Price of Calls in History: {0:C} (After Removal)", durationAsMinutes * 0.37);
        }

        public static void PrintCallHistory ()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 14));
            Console.WriteLine("|Call History|");
            Console.WriteLine(new string('-', 14));

            foreach (var call in calls)
            {
                Console.WriteLine("| " + call.GetDialedPhoneNumber + " |");
            }

            Console.WriteLine("\r\nAre you sure you want to clear the call history?");
            Console.Write(@"Select ""1"" to confirm, select ""2"" to cancel: ");

            int confirm = 0;

            try
            {
                confirm = int.Parse(Console.ReadLine());

                if (confirm > 2 || confirm < 1)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("\r\nInvalid Input!\r\nExitting...");
            }

            switch (confirm)
            {
                case 1:
                    calls.Clear();
                    Console.WriteLine("\n\r[{0}] 100%", new string('|', 40));
                    Console.WriteLine("Call History Successfully Cleared!\r\nExitting...");
                    break;
                case 2:
                    Console.WriteLine("\n\r[{0}] Cancelled", new string('X', 40));
                    break;
            }
        }
    }
}
