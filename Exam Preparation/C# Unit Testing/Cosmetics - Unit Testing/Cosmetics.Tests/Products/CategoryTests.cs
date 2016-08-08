namespace Cosmetics.Tests.Products
{
    using NUnit.Framework;

    using Cosmetics.Products;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Category_ShouldReturnCorrectString_IfMethodIsInvoked()
        {
            //Arrange
            var category = new Category("ForMale");

            //Act
            var expectedString = "ForMale category - 0 products in total";

            //Assert
            Assert.AreEqual(expectedString, category.Print());
        }
    }
}
