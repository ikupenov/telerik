namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Moq;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;

    [TestFixture]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [SetUp]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [Test]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [Test]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.controller.Add(null));
        }

        [Test]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [Test]
        public void Details_ShouldThrowArgumentNullException_IfIdIsInvalid()
        {
            const int invalidID = -5;

            Assert.Throws<ArgumentNullException>(() => this.GetModel(() => this.controller.Details(invalidID)));
        }

        [Test]
        public void Search_ShouldReturnCorrectCollection_IfConditionIsMet()
        {
            var foundItems = (IList<Car>)this.GetModel(() => this.controller.Search("BMW"));

            Assert.AreEqual(2, foundItems[0].Id);
            Assert.AreEqual(3, foundItems[1].Id);
        }

        [Test]
        public void Sort_ShouldThrowArgumentException_IfParameterIsNeitherMakeNorYear()
        {
            Assert.Throws<ArgumentException>(() => this.controller.Sort(It.IsAny<string>()));
        }

        [Test]
        public void Sort_ShouldSortByMake_IfParameterIsMake()
        {
            var sortedByMake = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(1, sortedByMake[0].Id);
            Assert.AreEqual(2, sortedByMake[1].Id);
            Assert.AreEqual(3, sortedByMake[2].Id);
            Assert.AreEqual(4, sortedByMake[3].Id);
        }

        [Test]
        public void Sort_ShouldSortByYear_IfParameterIsYear()
        {
            var sortedByYear = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(1, sortedByYear[0].Id);
            Assert.AreEqual(3, sortedByYear[1].Id);
            Assert.AreEqual(2, sortedByYear[2].Id);
            Assert.AreEqual(4, sortedByYear[3].Id);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}