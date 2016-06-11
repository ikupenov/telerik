namespace Main
{
    using System;

    public static class GSMTest
    {
        private static string[] manafacturer = { "Samsung", "HTC", "Huawei" };
        private static string[] model = { "S7", "M10", "P9" };
        private static decimal[] price = { 1200.00m, 1000.00m, 800.00m };
        private static string[] owner = { "Gosho", "Pesho", "Vanio" };

        public static GSM[] GetPhones ()
        {
            GSM[] phones = new GSM[3];
            Battery battery = new Battery("Panasonic", BatteryType.LiPo, 300, 25);
            Display display = new Display(4.5, 16000000);

            for (int i = 0; i < phones.Length; i++)
            {
                phones[i] = new GSM(model[i], manafacturer[i], price[i], owner[i], battery, display);
            }

            return phones;
        }

        public static void PrintPhonesInfo (GSM[] phones)
        {
            foreach (var phone in phones)
            {
                Console.WriteLine("{0}\r\n", phone);
            }
        }

        public static void PrintIPhoneInfo (GSM iPhone)
        {
            Console.WriteLine(iPhone);
        }
    }
}
