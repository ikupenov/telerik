namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using NUnit.Framework;

    using Moq;

    using Contracts;
    using Cosmetics.Common;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_ShouldCreateCategory_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "CreateCategory SomeCategory";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            Assert.IsTrue(cosmeticsEngine.Categories.ContainsKey("SomeCategory"));
        }

        [Test]
        public void Start_ShouldAddToCategory_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "AddToCategory ForMale Nivea";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            categoryMock.SetupGet(x => x.Name).Returns("ForMale");
            productMock.SetupGet(x => x.Name).Returns("Nivea");

            cosmeticsEngine.Categories.Add(categoryMock.Object.Name, categoryMock.Object);
            cosmeticsEngine.Products.Add(productMock.Object.Name, productMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            categoryMock.Verify(x => x.AddCosmetics(productMock.Object), Times.Once());
        }

        [Test]
        public void Start_ShouldRemoveFromCategory_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "RemoveFromCategory ForMale Nivea";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            categoryMock.SetupGet(x => x.Name).Returns("ForMale");
            productMock.SetupGet(x => x.Name).Returns("Nivea");

            cosmeticsEngine.Categories.Add(categoryMock.Object.Name, categoryMock.Object);
            cosmeticsEngine.Products.Add(productMock.Object.Name, productMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            categoryMock.Verify(x => x.RemoveCosmetics(productMock.Object), Times.Once());
        }

        [Test]
        public void Start_ShouldShowCategory_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "ShowCategory ForMale";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            var categoryMock = new Mock<ICategory>();

            categoryMock.SetupGet(x => x.Name).Returns("ForMale");

            cosmeticsEngine.Categories.Add(categoryMock.Object.Name, categoryMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            categoryMock.Verify(x => x.Print(), Times.Once());
        }

        [Test]
        public void Start_ShouldCreateShampoo_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "CreateShampoo Hair Elseve 10.00 men 100 everyday";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var shampooMock = new Mock<IShampoo>();

            factoryMock.Setup(x => x.CreateShampoo(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<GenderType>(),
                It.IsAny<uint>(),
                It.IsAny<UsageType>()))
                .Returns(shampooMock.Object);

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            Assert.IsTrue(cosmeticsEngine.Products.ContainsKey("Hair"));
            Assert.AreEqual(shampooMock.Object, cosmeticsEngine.Products["Hair"]);
        }

        [Test]
        public void Start_ShouldCreateToothpaste_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "CreateToothpaste White Lacalut 5.00 men igredientOne,igredientTwo";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var toothpasteMock = new Mock<IToothpaste>();

            factoryMock.Setup(x => x.CreateToothpaste(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<GenderType>(),
                It.IsAny<List<string>>()))
                .Returns(toothpasteMock.Object);

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            Assert.IsTrue(cosmeticsEngine.Products.ContainsKey("White"));
            Assert.AreEqual(toothpasteMock.Object, cosmeticsEngine.Products["White"]);
        }

        [Test]
        public void Start_ShouldAddToShoppingCart_IfInputStringIsInValidFormat()
        {
            //Arrange
            var productKey = "Nivea";
            var validInput = $"AddToShoppingCart {productKey}";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            cosmeticsEngine.Products.Add(productKey, It.IsAny<IProduct>());

            //Act
            cosmeticsEngine.Start();

            //Assert
            shoppingCartMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()), Times.Once());
        }

        [Test]
        public void Start_ShouldRemoveFromShoppingCart_IfInputStringIsInValidFormat()
        {
            //Arrange
            var productKey = "Nivea";
            var validInput = $"AddToShoppingCart {productKey}\nRemoveFromShoppingCart {productKey}";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            cosmeticsEngine.Products.Add(productKey, It.IsAny<IProduct>());

            shoppingCartMock.Setup(x => x.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            //Act
            cosmeticsEngine.Start();

            //Assert
            shoppingCartMock.Verify(x => x.RemoveProduct(It.IsAny<IProduct>()), Times.Once());
        }
    }
}