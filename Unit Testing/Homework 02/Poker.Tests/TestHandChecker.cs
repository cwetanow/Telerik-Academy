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
        [Test]
        public void TestHandChecker_PassNot5Cards_ShouldReturnFalse()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var pokerChecker = new PokerHandsChecker();
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
            var pokerChecker = new PokerHandsChecker();
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
            var pokerChecker = new PokerHandsChecker();
            var hand = new Hand(cards);
            var valid = pokerChecker.IsValidHand(hand);
            Assert.IsTrue(valid);
        }
    }
}
