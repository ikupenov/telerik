namespace Cosmetics.Tests.Common
{
    using System;

    using NUnit.Framework;

    using Cosmetics.Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_ShouldThrowNullReferenceException_IfObjIsNull()
        {
            //Arrange
            object obj = null;

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfNull_ShouldNotThrowAnyExceptions_IfObjIsNotNull()
        {
            //Arrange
            object obj = "some object";

            //Act and Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_IfParamIsNull()
        {
            //Arrange
            string str = null;

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(str));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_IfParamIsEmpty()
        {
            //Arrange
            string str = "";

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(str));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrowAnyExceptions_IfParamIsNeitherNullNorEmpty()
        {
            //Arrange
            string str = "some string";

            //Act and Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(str));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_IfParamLengthIsLowerThanMinAllowedValue()
        {
            //Arrange
            string str = "min";
            const int minLength = 4;
            const int maxLength = 8;

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(str, maxLength, minLength));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_IfParamLengthIsGreaterThanMaxAllowedValue()
        {
            //Arrange
            string str = "maximum allowed length";
            const int minLength = 4;
            const int maxLength = 8;

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(str, maxLength, minLength));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldNotThrowAnyExceptions_IfParamLengthIsInAllowedBoundaries()
        {
            //Arrange
            string str = "valid";
            const int minLength = 4;
            const int maxLength = 8;

            //Act and Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(str, maxLength, minLength));
        }
    }
}
