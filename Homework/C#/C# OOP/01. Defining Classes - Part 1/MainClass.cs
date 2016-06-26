using System;

namespace Main
{
    class MainClass
    {
        static void Main()
        {
            var phones = GSMTest.GetPhones();
            GSMTest.PrintPhonesInfo(phones);

            var iPhone = GSM.iPhone4S;
            GSMTest.PrintIPhoneInfo(iPhone);

            GSMCallHistoryTest.Initial(iPhone);
            GSMCallHistoryTest.CallsInfo();
            GSMCallHistoryTest.PriceAfterRemoval();
            GSMCallHistoryTest.PrintCallHistory();

            Console.ReadKey();
        }
    }
}
