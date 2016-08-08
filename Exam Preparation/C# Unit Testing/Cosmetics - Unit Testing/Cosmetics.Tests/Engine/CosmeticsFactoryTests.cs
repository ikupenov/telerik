namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Cosmetics.Engine;
    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        private const string stringOutOfMaxRange = "thisStringIsTotallyOutOfRange";
        private const string stringOutOfMinRange = "s";
        private const string name = "name";
        private const string brand = "brand";
        private const decimal price = 10m;
        private const GenderType gender = GenderType.Unisex;
        private const uint milliliters = 100;
        private const UsageType usage = UsageType.EveryDay;

        [TestCase(null, brand)]
        [TestCase("", brand)]
        [TestCase(name, null)]
        [TestCase(name, "")]
        public void CreateShampoo_ShouldThrowNullReferenceException_IfNameOrBrandIsInvalid(string name, string brand)
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() =>
            cosmeticsFactory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [TestCase(stringOutOfMinRange, brand)]
        [TestCase(stringOutOfMaxRange, brand)]
        [TestCase(name, stringOutOfMinRange)]
        [TestCase(name, stringOutOfMaxRange)]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_IfNameOrBrandLengthIsOutOfRange
            (string name, string brand)
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [Test]
        public void CreateShampoo_ShouldReturnNewShampoo_IfAllParamsAreValid()
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act
            var shampoo = cosmeticsFactory.CreateShampoo(name, brand, price, gender, milliliters, usage);

            //Act
            Assert.IsInstanceOf<Shampoo>(shampoo);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateCategory_ShouldThrowNullReferenceException_IfNameIsInvalid(string name)
        {
            //Arrange 
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateCategory(name));
        }

        [TestCase(stringOutOfMinRange)]
        [TestCase(stringOutOfMaxRange)]
        public void CreateCategory_ShouldThrowIndexOutOfRangeException_IfNameLengthIsOutOfRange(string name)
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_ShouldReturnNewCategory_IfAllParamsAreValid()
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act
            var category = cosmeticsFactory.CreateCategory(name);

            //Assert
            Assert.IsInstanceOf<Category>(category);
        }

        [TestCase(null, brand)]
        [TestCase(name, null)]
        [TestCase("", brand)]
        [TestCase(name, "")]
        public void CreateToothpaste_ShouldNullReferenceException_IfNameOrBrandIsInvalid(string name, string brand)
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() =>
            cosmeticsFactory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [TestCase(stringOutOfMaxRange, brand)]
        [TestCase(stringOutOfMinRange, brand)]
        [TestCase(name, stringOutOfMaxRange)]
        [TestCase(name, stringOutOfMinRange)]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_IfNameOrBrandLengthIsOutOfRange
            (string name, string brand)
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateToothpaste(name, brand, price, gender, new List<string> { "ingr1", "ingr2" }));
        }

        [TestCase(stringOutOfMaxRange)]
        [TestCase(stringOutOfMinRange)]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_IfAnyOfIngredientsLengthIsOutOfRange
            (string ingr)
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateToothpaste(name, brand, price, gender, new List<string> { "ingr1", ingr }));
        }

        [Test]
        public void CreateShoppingCart_ShouldAlwaysReturnNewShoppingCart_IfMethodIsInvoked()
        {
            //Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            //Act
            var shoppingCart = cosmeticsFactory.CreateShoppingCart();

            //Assert
            Assert.IsInstanceOf<ShoppingCart>(shoppingCart);
        }
    }
}
