using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException();
            }
            if (hand.Cards.Count != 5)
            {
                return false;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (hand.Cards[i].Face == (hand.Cards[j]).Face && hand.Cards[i].Suit == (hand.Cards[j]).Suit)
                    {
                        return false;
                    }
                }
                for (int j = i + 1; j < 5; j++)
                {
                    if (hand.Cards[i].Face == (hand.Cards[j]).Face && hand.Cards[i].Suit == (hand.Cards[j]).Suit)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }
            var faces = new List<CardFace>
            {
                CardFace.Ace,
                CardFace.Eight,
                CardFace.Five,
                CardFace.Four,
                CardFace.Jack,
                CardFace.King,
                CardFace.Nine,
                CardFace.Queen,
                CardFace.Seven,
                CardFace.Six,
                CardFace.Ten,
                CardFace.Three,
                CardFace.Two
            };
            var counters = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }
            var faces = new List<CardFace>
            {
                CardFace.Ace,
                CardFace.Eight,
                CardFace.Five,
                CardFace.Four,
                CardFace.Jack,
                CardFace.King,
                CardFace.Nine,
                CardFace.Queen,
                CardFace.Seven,
                CardFace.Six,
                CardFace.Ten,
                CardFace.Three,
                CardFace.Two
            };
            var counters = new List<int> { 0, 0, 0, 0 };

            
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }
            var suits = new List<CardSuit>
            {
                CardSuit.Clubs,
                CardSuit.Diamonds,
                CardSuit.Hearts,
                CardSuit.Spades
            };
            var counters = new List<int> { 0, 0, 0, 0 };

            foreach (var card in hand.Cards)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (card.Suit == suits[i])
                    {
                        counters[i]++;
                        break;
                    }
                }
            }

            return counters.Contains(5);

        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }
            var faces = new List<CardFace>
            {
                CardFace.Ace,
                CardFace.Eight,
                CardFace.Five,
                CardFace.Four,
                CardFace.Jack,
                CardFace.King,
                CardFace.Nine,
                CardFace.Queen,
                CardFace.Seven,
                CardFace.Six,
                CardFace.Ten,
                CardFace.Three,
                CardFace.Two
            };
            var counters = new List<int> { 0, 0, 0, 0 };

            
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
