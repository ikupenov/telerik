using System;
using System.Collections.Generic;

namespace SearchingAlgorithms.Searchers
{
    public interface ISearcher<T>
        where T : IComparable<T>
    {
        int Search(T value, IList<T> collection);
    }
}