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
        [Test]
        public void TestCard_ToStringImplement_ShouldReturnCardFaceAndSuite()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);
            var result = string.Format("{0} of {1}", card.Face, card.Suit);
            Assert.AreEqual(result, card.ToString());
        }
    }
}
