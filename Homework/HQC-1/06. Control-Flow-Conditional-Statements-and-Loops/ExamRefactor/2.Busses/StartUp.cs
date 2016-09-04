namespace Busses
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            int numberOfBusses = int.Parse(Console.ReadLine());
            int groupsOfBusses = 1;

            int nextBusSpeed = int.Parse(Console.ReadLine());

            for (int i = 1; i < numberOfBusses; i++)
            {
                int currentBusSpeed = int.Parse(Console.ReadLine());

                if (nextBusSpeed < currentBusSpeed)
                {
                    currentBusSpeed = nextBusSpeed;
                }
                else
                {
                    nextBusSpeed = currentBusSpeed;
                    groupsOfBusses++;
                }
            }

            Console.WriteLine(groupsOfBusses);
        }
    }
}