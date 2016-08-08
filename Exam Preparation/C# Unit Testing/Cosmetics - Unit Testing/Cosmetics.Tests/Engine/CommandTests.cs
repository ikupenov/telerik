namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ShouldReturnNewCommand_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "AddToCategory SomeProduct";

            //Act
            var actualCommand = Command.Parse(validInput);

            //Assert
            Assert.IsInstanceOf<Command>(actualCommand);
        }

        [Test]
        public void Parse_ShouldSetNameCorrectly_IfInputStringIsInValidFormat()
        {
            //Arrange 
            var validInput = "AddToCategory SomeParam";
            var expectedResult = "AddToCategory";

            //Act
            var actualCommand = Command.Parse(validInput);

            //Assert
            Assert.AreEqual(expectedResult, actualCommand.Name);
        }

        [Test]
        public void Parse_ShouldSetParamsCorrectly_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "AddToCategory FirstParam SecondParam";
            var expectedResult = new List<string>() { "FirstParam", "SecondParam" };

            //Act
            var actualCommand = Command.Parse(validInput);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualCommand.Parameters);
        }

        [Test]
        public void Parse_ShouldThrowNullReferenceException_IfInputStringIsNull()
        {
            //Arrange
            string invalidInput = null;

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(invalidInput));
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullExceptionWithCorrectMsg_IfInputHasInvalidName()
        {
            //Arrange
            string invalidInput = " FirstParam SecondParam";

            //Act and Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullExceptionWithCorrectMsg_IfInputHasInvalidParams()
        {
            //Arrange
            string invalidInput = "AddToCategory  ";

            //Act and Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("List"));
        }
    }
}
