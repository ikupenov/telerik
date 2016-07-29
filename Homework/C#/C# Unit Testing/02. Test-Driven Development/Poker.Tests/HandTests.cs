namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void ToString_ShouldThrowArgumentNullException_IfHandIsInitializedWithNull()
        {
            var hand = new Hand(null);

            Assert.Throws<ArgumentNullException>(() => hand.ToString());
        }

        [Test]
        public void ToString_ShouldReturnEmptyString_IfAllValuesAreUndefined()
        {
            var hand = new Hand(new List<ICard> { null, null, null });

            string actual = hand.ToString();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_ShouldReturnStringCorrectly_IfAllValuesAreDefined()
        {
            var firstCard = new Card(CardFace.Queen, CardSuit.Diamonds);
            var secondCard = new Card(CardFace.King, CardSuit.Spades);
            var thirdCard = new Card(CardFace.Jack, CardSuit.Hearts);
            var hand = new Hand(new List<ICard>{firstCard, secondCard, thirdCard});

            string expected = $"{firstCard}\r\n{secondCard}\r\n{thirdCard}";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_ShouldReturnStringCorrectly_IfSomeValuesAreUndefined()
        {
            var firstCard = new Card(CardFace.Queen, CardSuit.Diamonds);
            var secondCard = new Card(CardFace.Jack, CardSuit.Hearts);
            var hand = new Hand(new List<ICard> { firstCard, null, secondCard });

            string expected = $"{firstCard}\r\n{secondCard}";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
