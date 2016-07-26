using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Tests
{
    [TestFixture]
    public class TestHandChecker
    {
        private static PokerHandsChecker pokerChecker = new PokerHandsChecker();
        [Test]
        public void TestHandChecker_PassNot5Cards_ShouldReturnFalse()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);
            var valid = pokerChecker.IsValidHand(hand);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestHandChecker_PassTwoSameCards_ShouldReturnFalse()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                 new Card(CardFace.Five, CardSuit.Clubs),
                  new Card(CardFace.Six, CardSuit.Clubs),
                   new Card(CardFace.Eight, CardSuit.Clubs),
                    new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(cards);
            var valid = pokerChecker.IsValidHand(hand);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestHandChecker_PassValidCards_ShouldReturnTrue()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                 new Card(CardFace.Four, CardSuit.Clubs),
                  new Card(CardFace.Six, CardSuit.Clubs),
                   new Card(CardFace.Eight, CardSuit.Clubs),
                    new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(cards);
            var valid = pokerChecker.IsValidHand(hand);
            Assert.IsTrue(valid);
        }

        [Test]
        public void TestHandChecker_PassFourCards_ShouldThrow()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                 new Card(CardFace.Four, CardSuit.Clubs),
                  new Card(CardFace.Six, CardSuit.Clubs),
                   new Card(CardFace.Eight, CardSuit.Clubs),
            };
            var hand = new Hand(cards);
            TestDelegate test = () => pokerChecker.IsFlush(hand);
            Assert.Throws(typeof(ArgumentException), test);
        }

        [Test]
        public void TestHandChecker_PassValidFlush_ShouldReturnTrue()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                 new Card(CardFace.Four, CardSuit.Clubs),
                  new Card(CardFace.Six, CardSuit.Clubs),
                   new Card(CardFace.Eight, CardSuit.Clubs),
                   new Card(CardFace.Queen,CardSuit.Clubs)
            };
            var hand = new Hand(cards);
            Assert.IsTrue(pokerChecker.IsFlush(hand));
        }

        [Test]
        public void TestHandChecker_PassValidFourOfKind_ShouldReturnTrue()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                 new Card(CardFace.Five, CardSuit.Clubs),
                  new Card(CardFace.Five, CardSuit.Hearts),
                   new Card(CardFace.Five, CardSuit.Spades),
                   new Card(CardFace.Queen,CardSuit.Clubs)
            };
            var hand = new Hand(cards);
            Assert.IsTrue(pokerChecker.IsFourOfAKind(hand));
        }
    }
}
