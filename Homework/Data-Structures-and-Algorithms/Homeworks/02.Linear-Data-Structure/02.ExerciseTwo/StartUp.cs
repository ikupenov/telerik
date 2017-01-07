using System;
using System.Collections.Generic;

namespace ExerciseTwo
{
    internal class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(n);

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                stack.Push(inputNumber);
            }

            int stackCount = stack.Count;
            var reversedStack = new int[stack.Count];

            for (int i = 0; i < stackCount; i++)
            {
                reversedStack[i] = stack.Pop();
                Console.WriteLine(reversedStack[i]);
            }
        }
    }
}
