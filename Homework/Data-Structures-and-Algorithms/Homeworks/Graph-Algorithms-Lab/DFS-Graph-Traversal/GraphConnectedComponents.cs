using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static bool[] visited;
    private static List<int>[] graph;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());

        graph = new List<int>[n];
        visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }

        return graph;
    }

    private static void DepthFirstSearch(int node)
    {
        if (visited[node])
        {
            return;
        }

        visited[node] = true;

        foreach (var childNode in graph[node])
        {
            DepthFirstSearch(childNode);
        }

        Console.Write(" " + node);
    }

    private static void FindGraphConnectedComponents()
    {
        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component:");
                DepthFirstSearch(startNode);
                Console.WriteLine();
            }
        }
    }
}
