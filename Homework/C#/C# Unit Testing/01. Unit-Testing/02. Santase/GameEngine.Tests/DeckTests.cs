namespace GameEngine.Tests
{
    using NUnit.Framework;

    using Santase.Logic.Cards;
    using Santase.Logic;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Deck_DrawCardWhenNoneAreLeft_ShouldThrowInternalGameException()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void Deck_CardsLeft_ShouldReturnCorrectCount()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void Deck_InitialTrumpCard_ShouldReturnTrumpCard()
        {
            var deck = new Deck();

            Assert.AreNotEqual(null, deck.TrumpCard);
        }

        [TestCase(CardSuit.Club, CardType.Ace)]
        [TestCase(CardSuit.Diamond, CardType.Jack)]
        public void Deck_ChangeTrumpCard_ShouldChangeTrumpCard(CardSuit cardSuit, CardType cardType)
        {
            var deck = new Deck();
            var nextTrumpCard = new Card(cardSuit, cardType);

            deck.ChangeTrumpCard(nextTrumpCard);

            Assert.AreEqual(nextTrumpCard, deck.TrumpCard);
        }
    }
}