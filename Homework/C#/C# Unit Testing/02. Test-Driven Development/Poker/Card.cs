using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            if (!Enum.IsDefined(typeof(CardFace), this.Face) ||
                !Enum.IsDefined(typeof(CardSuit), this.Suit))
            {
                throw new ArgumentException();
            }

            return string.Format($"{this.Face} {this.Suit}");
        }
    }
}
