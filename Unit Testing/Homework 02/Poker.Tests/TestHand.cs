using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Tests
{
    [TestFixture]
    public class TestHand
    {
        [Test]
        public void TestHand_ToStringImplement_ShouldReturnAllCardFaceAndSuite()
        {
            IList<ICard> cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts)
            };
            var hand = new Hand(cards);
            var result = string.Join(", ", hand.Cards);
            Assert.AreEqual(result, hand.ToString());
        }
    }
}
