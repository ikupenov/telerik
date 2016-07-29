namespace Poker.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class CardTests
    {
        [TestCase(CardFace.Ace, CardSuit.Clubs)]
        [TestCase(CardFace.Eight, CardSuit.Spades)]
        public void ToString_ShouldReturnStringCorrectly_IfTheCardDoesNotContainUndefinedValues(CardFace cardFace, CardSuit cardSuit)
        {
            var card = new Card(cardFace, cardSuit);
            string expectedString = $"{cardFace} {cardSuit}";

            string cardString = card.ToString();

            Assert.AreEqual(expectedString, cardString);
        }

        [TestCase(CardFace.Queen, (CardSuit)100)]
        [TestCase((CardFace)100, CardSuit.Diamonds)]
        [TestCase(CardFace.Eight, null)]
        [TestCase(null, CardSuit.Clubs)]
        [TestCase(null, null)]
        public void ToString_ShouldThrowArgumentException_IfAtLeastOneOfTheValuesIsUndefined(CardFace cardFace, CardSuit cardSuit)
        {
            var card = new Card(cardFace, cardSuit);

            Assert.Throws<ArgumentException>(() => card.ToString());
        }
    }
}
