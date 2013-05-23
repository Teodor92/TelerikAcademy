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
            StringBuilder textOutput = new StringBuilder();

            for (int i = 0; i < this.Cards.Count; i++)
            {
                textOutput.AppendFormat("{0} ", this.Cards[i].ToString());
            }

            return textOutput.ToString();
        }
    }
}
