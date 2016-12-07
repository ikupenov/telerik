using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchingAlgorithms.Searchers;

namespace SearchingAlgorithmsTests.SearchersTests
{
    [TestClass]
    public class BinarySearcherTests
    {
        [TestMethod]
        public void ShouldReturnCorrectIndexIfElementExists()
        {
            var collection = new List<int> { -1, 10, 98, 103, 1067, 1069 };
            var binarySearcher = new BinarySearcher<int>();

            int actualIndex = binarySearcher.Search(98, collection);
            int expectedIndex = 2;

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestMethod]
        public void ShouldReturnCorrectIndexIfElementDoesNotExists()
        {
            var collection = new List<int> { -1, 10, 98, 103, 1067, 1069 };
            var binarySearcher = new BinarySearcher<int>();

            int actualIndex = binarySearcher.Search(1, collection);
            int expectedIndex = -1;

            Assert.AreEqual(expectedIndex, actualIndex);
        }
    }
}