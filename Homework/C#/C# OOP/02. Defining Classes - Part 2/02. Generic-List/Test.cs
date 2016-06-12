using System;

namespace GenericList
{
    public class Test
    {
        public static void IntegerTest()
        {
            Console.WriteLine("Integer Test");
            Console.WriteLine(new string('_', 20));
            var intTest = new Generic<int>(2);
            Console.WriteLine("Initial Capacity: {0}", intTest.Capacity);

            intTest.Add(1);
            intTest.Add(2);
            intTest.Add(3);

            Console.WriteLine("Capacity After: {0}", intTest.Capacity);
            Console.WriteLine("ToString() Override: {0}", intTest);

            var elementIndex = intTest[2];
            Console.WriteLine("Element at 2nd Index: {0}", elementIndex);

            var element = intTest.FindElementByValue(2);
            Console.WriteLine("Find Element By Value (2): {0}", element);

            Console.WriteLine("Max: {0}", intTest.Max());
            Console.WriteLine("Min: {0}", intTest.Min());

            intTest.RemoveElementAtIndex(2);
            Console.WriteLine("After Removal of the Element at 2nd Index: {0}", intTest);

            intTest.Insert(1000, 1);
            Console.WriteLine("'1000' Inserted at Position '1': {0}", intTest);

            intTest.Clear();
            Console.WriteLine("Cleared: {0}", intTest);
            Console.WriteLine(new string('-', 20));
        }

        public static void StringTest()
        {
            Console.WriteLine("\r\nString Test");
            Console.WriteLine(new string('_', 20));
            var stringTest = new Generic<string>(4);

            Console.WriteLine("Initial Capacity: {0}", stringTest.Capacity);

            stringTest.Add("Gosho");
            stringTest.Add("Pesho");
            stringTest.Add("Vanio");
            stringTest.Add("Gosho");
            stringTest.Add("Pesho");
            stringTest.Add("Vanio");

            Console.WriteLine("Capacity After: {0}", stringTest.Capacity);
            Console.WriteLine("ToString() Override: {0}", stringTest);

            var stringElementAtIndex = stringTest[2];
            Console.WriteLine("Element at 2nd Index: {0}", stringElementAtIndex);

            var stringElement = stringTest.FindElementByValue("Vanio");
            Console.WriteLine("Find Element By Value (Vanio): {0}", stringElement);

            Console.WriteLine("Max: {0}", stringTest.Max());
            Console.WriteLine("Min: {0}", stringTest.Min());


            stringTest.RemoveElementAtIndex(5);
            Console.WriteLine("After Removal of the Element at 5th Index: {0}", stringTest);

            stringTest.Insert("Nasko", 0);
            Console.WriteLine("(Nasko) Inserted At Position '0': {0}", stringTest);

            stringTest.Clear();
            Console.WriteLine("Cleared: {0}", stringTest);
            Console.WriteLine(new string('-', 20));
        }
    }
}
