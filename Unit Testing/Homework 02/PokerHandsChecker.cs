using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private static List<CardFace> faces = new List<CardFace>
            {
            CardFace.Two,
            CardFace.Three,
            CardFace.Four,
            CardFace.Five,
            CardFace.Six,
            CardFace.Seven,
            CardFace.Eight,
            CardFace.Nine,
            CardFace.Ten,
            CardFace.Jack,
            CardFace.Queen,
            CardFace.King,
            CardFace.Ace
            };

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
            return IsFlush(hand) && IsStraight(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }

            var counters = new List<int>();
            foreach (var item in faces)
            {
                counters.Add(0);
            }

            foreach (var card in hand.Cards)
            {
                foreach (var face in faces)
                {
                    if (card.Face == face)
                    {
                        counters[faces.IndexOf(face)]++;
                    }
                }
            }
            return counters.Contains(4);

        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }

            var counters = new List<int>();
            foreach (var item in faces)
            {
                counters.Add(0);
            }

            foreach (var card in hand.Cards)
            {
                foreach (var face in faces)
                {
                    if (card.Face == face)
                    {
                        counters[faces.IndexOf(face)]++;
                    }
                }
            }
            return counters.Contains(3) && counters.Contains(2);

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
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }

            var counters = new List<int>();
            foreach (var item in faces)
            {
                counters.Add(0);
            }

            foreach (var card in hand.Cards)
            {
                foreach (var face in faces)
                {
                    if (card.Face == face)
                    {
                        counters[faces.IndexOf(face)]++;
                    }
                }
            }
            var result = 0;
            foreach (var item in counters)
            {
                if (item == 0 && result != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }

            var counters = new List<int>();
            foreach (var item in faces)
            {
                counters.Add(0);
            }

            foreach (var card in hand.Cards)
            {
                foreach (var face in faces)
                {
                    if (card.Face == face)
                    {
                        counters[faces.IndexOf(face)]++;
                    }
                }
            }
            return counters.Contains(3);


        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }

            var counters = new List<int>();
            foreach (var item in faces)
            {
                counters.Add(0);
            }

            foreach (var card in hand.Cards)
            {
                foreach (var face in faces)
                {
                    if (card.Face == face)
                    {
                        counters[faces.IndexOf(face)]++;
                    }
                }
            }
            var times = 0;
            foreach (var item in counters)
            {
                if (item == 2)
                {
                    times++;
                }
            }
            return times == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException();
            }

            var counters = new List<int>();
            foreach (var item in faces)
            {
                counters.Add(0);
            }

            foreach (var card in hand.Cards)
            {
                foreach (var face in faces)
                {
                    if (card.Face == face)
                    {
                        counters[faces.IndexOf(face)]++;
                    }
                }
            }
            var times = 0;
            foreach (var item in counters)
            {
                if (item == 2)
                {
                    times++;
                }
            }
            return times == 1;
        }

        public bool IsHighCard(IHand hand)
        {
            return IsOnePair(hand) || IsStraight(hand) || IsFlush(hand);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (GetHandPower(firstHand).CompareTo(GetHandPower(secondHand)) < 0)
            {
                return -1;
            }
            else if (GetHandPower(firstHand).CompareTo(GetHandPower(secondHand)) > 0)
            {
                return 1;
            }
            else
            {
                if (this.IsStraight(firstHand) || this.IsStraightFlush(firstHand) || this.IsFlush(firstHand) || (this.IsHighCard(firstHand)))
                {
                    return firstHand.Cards.Select(x => (int)x.Face).Max().CompareTo(secondHand.Cards.Select(x => (int)x.Face).Max());
                }
                else if (this.IsFourOfAKind(firstHand))
                {

                }
                else if (this.IsThreeOfAKind(firstHand))
                {
                }
                else if (this.IsTwoPair(firstHand))
                {
                }
                else if (this.IsOnePair(firstHand))
                {
                }
                else if (this.IsFullHouse(firstHand))
                {

                }

            }

            return 5;
        }

        private int GetHandPower(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return 10;
            }
            else
                if (this.IsFourOfAKind(hand))
            {
                return 9;
            }
            else if (this.IsFullHouse(hand))
            {
                return 8;
            }
            else if (this.IsFlush(hand))
            {
                return 7;
            }
            else if (this.IsStraight(hand))
            {
                return 6;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return 5;
            }
            else if (this.IsTwoPair(hand))
            {
                return 4;
            }
            else if (this.IsOnePair(hand))
            {
                return 3;
            }
            else
            {
                return 2;
            }
            //Ifs because Koceto doesn't like switch
        }


    }
}
