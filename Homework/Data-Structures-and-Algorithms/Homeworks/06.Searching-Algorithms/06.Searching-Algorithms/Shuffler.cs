using System;
using System.Collections.Generic;

namespace SearchingAlgorithms
{
    public class Shuffler<T>
    {
        private static Random randomGenerator;

        static Shuffler()
        {
            randomGenerator = new Random();
        }

        public void Shuffle(IList<T> collection)
        {
            int length = collection.Count;
            for (var i = 0; i < length; i++)
            {
                int randomIndex = i + randomGenerator.Next(0, length - i);

                T temp = collection[i];
                collection[i] = collection[randomIndex];
                collection[randomIndex] = temp;
            }
        }
    }
}