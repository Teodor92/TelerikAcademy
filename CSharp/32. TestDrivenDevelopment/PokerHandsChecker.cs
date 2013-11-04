using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool isValid = true;

            int numberOfCardsInHand = hand.Cards.Count;

            if (numberOfCardsInHand != 5)
            {
                isValid = false;
            }

            for (int i = 0; i < numberOfCardsInHand; i++)
            {
                for (int j = i + 1; j < numberOfCardsInHand; j++)
                {
                    if (hand.Cards[i].Suit == hand.Cards[j].Suit && hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand was not valid");
            }

            bool isFourOfAKind = false;
            int count = 1;
            int bestCount = int.MinValue;
            int cardsInHand = hand.Cards.Count;

            for (int i = 0; i < cardsInHand; i++)
            {
                for (int j = i + 1; j < cardsInHand; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        count++;
                    }
                }

                if (count == 4)
                {
                    break;
                }

                count = 1;
            }

            if (count == 4)
            {
                isFourOfAKind = true;
            }

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            bool isFlush = true;

            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand was not valid");
            }

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (!(hand.Cards[i].Suit == hand.Cards[i + 1].Suit))
                {
                    isFlush = false;
                }
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
