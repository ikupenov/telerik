namespace Cosmetics.Tests.Products
{
    using System.Text;

    using NUnit.Framework;

    using Cosmetics.Products;
    using Cosmetics.Common;

    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_ShouldReturnCorrectString_IfMethodIsInvoked()
        {
            //Arrange
            var shampoo = new Shampoo("Hair", "Loreal", 0.005m, GenderType.Unisex, 600, UsageType.EveryDay);

            //Act
            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Loreal - Hair:");
            expectedResult.AppendLine($"  * Price: $3.000");
            expectedResult.AppendLine($"  * For gender: Unisex");
            expectedResult.AppendLine($"  * Quantity: 600 ml");
            expectedResult.AppendLine($"  * Usage: EveryDay");

            //Assert
            Assert.AreEqual(expectedResult.ToString().Trim(), shampoo.Print().Trim());
        }
    }
}
