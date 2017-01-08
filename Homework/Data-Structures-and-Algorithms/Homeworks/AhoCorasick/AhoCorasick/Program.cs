using System;
using System.Collections.Generic;

namespace AhoCorasick
{
    class Program
    {
        const char MainChar = (char)0;
        const int CharsCount = 256;

        static void Main()
        {
            Node root = new Node();
            string text = Console.ReadLine();
            string[] patterns = Console.ReadLine().Split();

            BuildTree(patterns, root);
            ComputeFailLinks(root);
            Search(text, patterns, root);
        }

        static void Search(string text, string[] patterns, Node root)
        {
            int n = text.Length;

            Node matched = root;
            for (int i = 0; i < n; i++)
            {
                while (matched != null && matched.Letter[text[i] - MainChar] == null)
                {
                    matched = matched.faillink;
                }

                matched = (matched == null) ? root : matched.Letter[text[i] - MainChar];

                if (matched.Index >= 0)
                {
                    Console.WriteLine("{0} matches at {1}", patterns[matched.Index], i - patterns[matched.Index].Length + 1);
                }

                for (Node x = matched.successlink; x != null; x = x.successlink)
                {
                    Console.WriteLine("{0} matches at {1}", patterns[x.Index], i - patterns[x.Index].Length + 1);
                }
            }
        }

        static void BuildTree(string[] patterns, Node root)
        {
            for (int i = 0; i < patterns.Length; i++)
            {
                Node x = root;
                foreach (char c in patterns[i])
                {
                    if (x.Letter[c - MainChar] == null)
                    {
                        x.Letter[c - MainChar] = new Node();
                    }

                    x = x.Letter[c - MainChar];
                }

                x.Index = i;
            }
        }

        static void ComputeFailLinks(Node root)
        {
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node x = q.Dequeue();

                if (x.faillink != null)
                {
                    if (x.faillink.Index >= 0)
                    {
                        x.successlink = x.faillink;
                    }
                    else if (x.faillink.successlink != null)
                    {
                        x.successlink = x.faillink.successlink;
                    }
                }

                for (int i = 0; i < CharsCount; i++)
                {
                    if (x.Letter[i] == null)
                    {
                        continue;
                    }

                    q.Enqueue(x.Letter[i]);

                    Node y = x.faillink;
                    while (y != null && y.Letter[i] == null)
                    {
                        y = y.faillink;
                    }

                    x.Letter[i].faillink = (y == null) ? root : y.Letter[i];
                }
            }
        }

        class Node
        {
            public Node[] Letter { get; set; }

            public Node faillink { get; set; }

            public Node successlink { get; set; }

            public int Index { get; set; }

            public Node()
            {
                this.Letter = new Node[CharsCount];
                this.Index = -1;
            }
        }
    }
}