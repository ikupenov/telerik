using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        var sortedNodes = new List<string>();
        var predecessorsCount = CountPredecessors();
        var nextNode = this.graph.Keys
            .FirstOrDefault(node => predecessorsCount[node] == 0);

        while (nextNode != null)
        {
            DecrementPredecessors(nextNode, predecessorsCount);

            sortedNodes.Add(nextNode);
            this.graph.Remove(nextNode);

            nextNode = this.graph.Keys
                .FirstOrDefault(node => predecessorsCount[node] == 0);
        }

        if (this.graph.Count != 0)
        {
            throw new InvalidOperationException();
        }

        return sortedNodes;
    }

    private IDictionary<string, int> CountPredecessors()
    {
        var predecessorsCount = new Dictionary<string, int>();

        foreach (var node in this.graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
            {
                predecessorsCount.Add(node.Key, 0);
            }

            foreach (var childNode in node.Value)
            {
                if (!predecessorsCount.ContainsKey(childNode))
                {
                    predecessorsCount.Add(childNode, 0);
                }
                predecessorsCount[childNode]++;
            }
        }

        return predecessorsCount;
    }

    private void DecrementPredecessors(string node, IDictionary<string, int> predecessorsCount)
    {
        foreach (var childNode in this.graph[node])
        {
            predecessorsCount[childNode]--;
        }
    }
}
