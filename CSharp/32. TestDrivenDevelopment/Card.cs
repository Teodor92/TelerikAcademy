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
            string cardFace = this.CovnerCardFaceToString();
            string cardSuit = this.ConvertCardSuitToString();

            string cardString = string.Format("{0} {1}", cardFace, cardSuit);

            return cardString;
        }

        private string CovnerCardFaceToString()
        {
            string faceString = string.Empty;

            if ((int)this.Face <= 10)
            {
                faceString = ((int)this.Face).ToString();
            }
            else
            {
                faceString = (this.Face.ToString()[0]).ToString();
            }

            return faceString;
        }

        private string ConvertCardSuitToString()
        {
            string suitString = string.Empty;

            switch (this.Suit)
            {
                case CardSuit.Clubs: suitString = "♣";
                    break;
                case CardSuit.Diamonds: suitString = "♦";
                    break;
                case CardSuit.Hearts: suitString = "♥";
                    break;
                case CardSuit.Spades: suitString = "♠";
                    break;
                default: throw new ArgumentException("Card suit was invalid!");
                    break;
            }

            return suitString;
        }
    }
}
