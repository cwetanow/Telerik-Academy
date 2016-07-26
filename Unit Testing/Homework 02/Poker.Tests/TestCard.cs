using NUnit.Framework;
using Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Tests
{
    [TestFixture]
    public class TestCard
    {
        [TestCase(CardFace.Ace,CardSuit.Clubs)]
        [TestCase(CardFace.Queen, CardSuit.Diamonds)]
        [TestCase(CardFace.Eight, CardSuit.Clubs)]
        [TestCase(CardFace.Ten, CardSuit.Spades)]
        [TestCase(CardFace.Two, CardSuit.Hearts)]
        public void TestCard_ToStringImplement_ShouldReturnCardFaceAndSuite(CardFace face, CardSuit suit)
        {
            var card = new Card(face, suit);
            var result = string.Format("{0} of {1}", card.Face, card.Suit);
            Assert.AreEqual(result, card.ToString());
        }
    }
}
