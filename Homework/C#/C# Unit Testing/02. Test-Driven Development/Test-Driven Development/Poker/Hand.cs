using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards == null)
            {
                throw new ArgumentNullException();
            }

            var builder = new StringBuilder();

            foreach (var card in this.Cards)
            {
                if (card != null)
                {
                    builder.AppendLine(card.ToString());
                }
            }

            return builder.ToString().Trim();
        }
    }
}
