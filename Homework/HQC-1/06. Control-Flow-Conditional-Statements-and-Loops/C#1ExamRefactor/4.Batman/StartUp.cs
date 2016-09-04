namespace Batman
{
    using System;
    using System.IO;

    using Common;
    using Common.Drawers;

    public class StartUp
    {
        private static void Main()
        {
            var consoleDrawer = new ConsoleDrawer();
            var paintWithConsoleDrawer = new Paint(consoleDrawer);

            string filePath = Directory.GetCurrentDirectory() + @"..\..\..\batman.txt";
            var streamDrawer = new StreamDrawer(filePath);
            var paintWithStreamDrawer = new Paint(streamDrawer); 

            int drawingSize = int.Parse(Console.ReadLine());
            char drawingSymb = char.Parse(Console.ReadLine());

            paintWithConsoleDrawer.DrawBatman(drawingSize, drawingSymb);
            paintWithStreamDrawer.DrawBatman(drawingSize, drawingSymb);

            streamDrawer.CloseStream();
        }
    }
}