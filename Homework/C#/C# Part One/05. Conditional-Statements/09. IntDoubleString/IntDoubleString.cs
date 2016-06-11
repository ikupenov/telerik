using System;

class IntDoubleString
{
    static void Main()
    {
        string choose = Console.ReadLine();

        switch (choose)
        {
            case "integer":
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine(i + 1);
                break;
            case "real":
                double d = double.Parse(Console.ReadLine());
               Console.WriteLine("{0:0.00}", d + 1);
                break;
            case "text":
                string text = Console.ReadLine();
                Console.WriteLine("{0}*", text);
                break;
            default:
                break;
        }
    }
}
