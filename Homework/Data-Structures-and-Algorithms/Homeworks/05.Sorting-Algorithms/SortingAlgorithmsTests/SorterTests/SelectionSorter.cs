using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithms.Sorters;

namespace SortingAlgorithmsTests.SorterTests
{
    [TestClass]
    public class SelectionSorter
    {
        [TestMethod]
        public void ShouldSortNumbersCorrectly()
        {
            var array = new int[] { 1, 4, 100, -3, 1 };
            var mergeSorter = new SelectionSorter<int>();
            mergeSorter.Sort(array);

            var expected = new int[] { -3, 1, 1, 4, 100 };

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void ShouldSortCharactersCorrectly()
        {
            var array = new char[] { 'a', 'c', 'b', 'z', 'a' };
            var mergeSorter = new SelectionSorter<char>();
            mergeSorter.Sort(array);

            var expected = new char[] { 'a', 'a', 'b', 'c', 'z' };

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void ShouldSortNegativeNumbersCorrectly()
        {
            var array = new int[] { -103, -166, -42, -3, -1 };
            var mergeSorter = new SelectionSorter<int>();
            mergeSorter.Sort(array);

            var expected = new int[] { -166, -103, -42, -3, -1 };

            CollectionAssert.AreEqual(expected, array);
        }
    }
}