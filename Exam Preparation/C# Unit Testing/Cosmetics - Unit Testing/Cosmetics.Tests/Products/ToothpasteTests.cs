namespace Cosmetics.Tests.Products
{
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class ToothpasteTests
    {
        [Test]
        public void Print_ShouldReturnCorrectString_IfMethodIsInvoked()
        {
            //Arrange
            var toothpaste = new Toothpaste(
                "White",
                "Lacalut",
                6.00m,
                GenderType.Unisex,
                new List<string> { "fluoride", "magnesium" });

            //Act
            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Lacalut - White:");
            expectedResult.AppendLine($"  * Price: $6.00");
            expectedResult.AppendLine($"  * For gender: Unisex");
            expectedResult.AppendLine($"  * Ingredients: fluoride, magnesium");

            System.Console.WriteLine(toothpaste.Print());
            System.Console.WriteLine(expectedResult.ToString());

            //Assert
            Assert.AreEqual(expectedResult.ToString().Trim(), toothpaste.Print().Trim());
        }
    }
}
