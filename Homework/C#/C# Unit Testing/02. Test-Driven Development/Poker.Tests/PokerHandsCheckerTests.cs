namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        [Test]
        public void IsValidHand_ShouldThrowArgumentNullException_IfCalledWithNullValue()
        {
            var handChecker = new PokerHandsChecker();

            Assert.Throws<ArgumentNullException>(() => handChecker.IsValidHand(null));
        }

        [Test]
        public void IsValidHand_ShouldThrowArgumentOutOfRangeException_IfHandConsistsOfLessThanFiveCards()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => handChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_ShouldThrowArgumentOutOfRangeException_IfHandConsistsOfMoreThanFiveCards()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => handChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_ShouldReturnTrue_IfHandConsistsOfFiveDifferentCards()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades)
            });

            Assert.IsTrue(handChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_ShouldReturnFalse_IfHandConsistsOfFiveCardsSomeOfWhichAreTheSame()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            });

            Assert.IsFalse(handChecker.IsValidHand(hand));
        }

        [Test]
        public void IsFlush_ShouldReturnTrue_IfHandIsValidAndOnlyContainsCardsOfTheSameSuit()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            });

            Assert.IsTrue(handChecker.IsFlush(hand));
        }

        [Test]
        public void IsFlush_ShouldReturnFalse_IfHandIsValidAndAtLeastOneOfTheCardsHasDifferentSuit()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            Assert.IsFalse(handChecker.IsFlush(hand));
        }

        [Test]
        public void IsFourOfAKind_ShouldReturnTrue_IfHandIsValidAndContainsFourCardsOfTheSameType()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            bool isTrue = handChecker.IsFourOfAKind(hand);

            Assert.IsTrue(handChecker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKind_ShouldReturnFalse_IfHandIsValidAndContainsLessThanFourCardsOfTheSameType()
        {
            var handChecker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });
            
            Assert.IsFalse(handChecker.IsFourOfAKind(hand));
        }
    }
}
