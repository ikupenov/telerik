using System;
using System.Collections.Generic;
using SearchingAlgorithms.Searchers;

namespace SearchingAlgorithms
{
    public class StartUp
    {
        static void Main()
        {
            // Shuffle
            var collectionToShuffle = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var shuffler = new Shuffler<int>();
            Console.WriteLine($"Collection before shuffle -> {string.Join(", ", collectionToShuffle)}");
            shuffler.Shuffle(collectionToShuffle);
            Console.WriteLine($"Collection after shuffle -> {string.Join(", ", collectionToShuffle)}");

            var collectionToSearch = new List<int> { -36, 1, 16, 42, 278, 301 };
            Console.WriteLine();
            Console.WriteLine($"Collection to search -> [{string.Join(", ", collectionToSearch)}]");

            // Binary Search
            var binarySearcher = new BinarySearcher<int>();
            int binarySearcherIndex = binarySearcher.Search(301, collectionToSearch);
            Console.WriteLine($"Binary search, searching for {301} -> index[{binarySearcherIndex}]");

            // Linear Search
            var linearSearcher = new LinearSearcher<int>();
            int linearSearcherIndex = linearSearcher.Search(42, collectionToSearch);
            Console.WriteLine($"Linear search, searching for {42} -> index[{linearSearcherIndex}]");
        }
    }
}
