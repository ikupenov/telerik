using Dealership.Engine;
using Dealership.Models.Contracts;

using Moq;
using NUnit.Framework;

namespace Dealership.Tests.Engine
{
    [TestFixture]
    public class DataProviderTests
    {
        [Test]
        public void LoggedUser_ShouldSetLoggedUserCorrectly_IfValueIsNotNull()
        {
            var dataProvider = new DataProvider();

            var userMock = new Mock<IUser>();
            dataProvider.LoggedUser = userMock.Object;

            Assert.AreEqual(dataProvider.LoggedUser, userMock.Object);
        }

        [Test]
        public void LoggedUser_ShouldSetLoggedUserCorrectly_IfValueIsNull()
        {
            var dataProvider = new DataProvider();

            var userMock = new Mock<IUser>();
            dataProvider.LoggedUser = userMock.Object;

            dataProvider.LoggedUser = null;

            Assert.IsNull(dataProvider.LoggedUser);
        }

        [Test]
        public void WipeData_ShouldRemoveLoggedUser_IfCalled()
        {
            var dataProvider = new DataProvider();

            var userMock = new Mock<IUser>();
            dataProvider.LoggedUser = userMock.Object;

            dataProvider.WipeData();

            Assert.IsNull(dataProvider.LoggedUser);
        }

        [Test]
        public void WipeData_ShouldRemoveRegisteredUsers_IfCalled()
        {
            var dataProvider = new DataProvider();

            var userMock = new Mock<IUser>();
            dataProvider.RegisteredUsers.Add(userMock.Object);

            dataProvider.WipeData();

            Assert.IsEmpty(dataProvider.RegisteredUsers);
        }
    }
}