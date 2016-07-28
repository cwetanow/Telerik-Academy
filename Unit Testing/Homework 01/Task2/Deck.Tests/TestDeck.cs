using System;
using NUnit.Framework;
using Santase.Logic.Cards;
using Santase.Logic;

namespace Deckk.Tests
{
    [TestFixture]
    public class TestDeck
    {
        private static Card card;
        [Test]
        public void TestDeck_SeeIfConstructorInitialisesCorrectly()
        {
            var deck = new Deck();
            Assert.IsNotNull(deck);
        }

        [Test]
        public void TestDeck_InitializesTrumpCardCorrectrly()
        {
            var deck = new Deck();
            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void TestDeck_SeeIfCardsLeftIsValidIntegerBetweenZeroAnd24()
        {
            var deck = new Deck();
            Assert.IsTrue(deck.CardsLeft >= 0 && deck.CardsLeft < 25);
        }

        [Test]
        public void TestDeck_CheckIfGetNextCardThrows_SHouldThrow()
        {
            var deck = new Deck();
            TestDelegate test = () =>
             {
                 while (true)
                 {
                     deck.GetNextCard();
                 }
             };
            Assert.Throws(typeof(InternalGameException), test);
        }


        [Test]
        public void TestDeck_CheckIfGetNextCardReturnsValidCard_ShouldReturnTrue()
        {
            var deck = new Deck();
            Assert.IsTrue(typeof(Card) == deck.GetNextCard().GetType());
        }

        [Test]
        public void TestDeck_CheckCHangeTrumpCard_ShouldChangeCorrectly()
        {
            var deck = new Deck();
            var card =  new Card(CardSuit.Club, CardType.Ace);
            deck.ChangeTrumpCard(card);
            Assert.IsTrue(deck.TrumpCard.Equals(card));
        }
    }
}
