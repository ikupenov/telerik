using System;
using System.Collections.Generic;

namespace Diameter
{
    public class StartUp
    {
        private static Dictionary<int, Dictionary<int, int>> tree;

        private static int maxSum;
        private static int lastNode;
        private static bool[] isVisited;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            tree = new Dictionary<int, Dictionary<int, int>>();
            isVisited = new bool[n];

            for (int i = 1; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                int firstNode = int.Parse(input[0]);
                int secondNode = int.Parse(input[1]);

                int weight = int.Parse(input[2]);

                if (!tree.ContainsKey(firstNode))
                {
                    tree.Add(firstNode, new Dictionary<int, int>());
                }
                tree[firstNode].Add(secondNode, weight);

                if (!tree.ContainsKey(secondNode))
                {
                    tree.Add(secondNode, new Dictionary<int, int>());
                }
                tree[secondNode].Add(firstNode, weight);
            }

            DepthFirstSearch();
            DepthFirstSearch(lastNode);

            Console.WriteLine(maxSum);
        }

        static void DepthFirstSearch(int index = 0, int currentSum = 0)
        {
            isVisited[index] = true;

            foreach (var node in tree[index])
            {
                if (isVisited[node.Key])
                {
                    continue;
                }

                currentSum += node.Value;
                DepthFirstSearch(node.Key, currentSum);

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                    lastNode = node.Key;
                }

                currentSum -= node.Value;
            }

            isVisited[index] = false;
        }
    }
}