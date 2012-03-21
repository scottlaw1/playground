using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shuffler.Domain;

namespace Shuffler.Tests
{
    [TestFixture]
    public class DeckTests
    {
        private FrenchDeck deck;

        [SetUp]
        public void Given()
        {
            deck = new FrenchDeck();
        }

        [Test]
        public void Has52Cards()
        {
            Assert.That(deck.Size,Is.EqualTo(52));
        }

        [Test]
        public void Has4Suits()
        {
            var numberOfSuits = (from card in deck.GetDeck() select card.Suit).Distinct();
            Assert.That(numberOfSuits.Count(),Is.EqualTo(4));
        }

        [Test]
        public void Has13CardsPerSuit()
        {
            const int CardsPerSuit = 13;
            
            var numberOfHearts = from card in deck.GetDeck() where card.Suit == Suit.Hearts select card;
            var numberOfClubs = from card in deck.GetDeck() where card.Suit == Suit.Clubs select card;
            var numberOfDiamonds = from card in deck.GetDeck() where card.Suit == Suit.Diamonds select card;
            var numberOfSpades = from card in deck.GetDeck() where card.Suit == Suit.Spades select card;

           
            Assert.That(numberOfClubs.Count(), Is.EqualTo(CardsPerSuit));
            Assert.That(numberOfDiamonds.Count(), Is.EqualTo(CardsPerSuit));
            Assert.That(numberOfHearts.Count(), Is.EqualTo(CardsPerSuit));
            Assert.That(numberOfSpades.Count(), Is.EqualTo(CardsPerSuit));
        }

        [Test]
        public void ShuffledDeckDifferentFromInitialDeck()
        {
            var initialDeck = deck.GetDeck();
            
            deck.Shuffle();

            var shuffledDeck = deck.GetDeck();

           Assert.That(initialDeck.SequenceEqual(shuffledDeck),Is.False);
        }
        
        [Test]
        public void RandomShuffledDeckDifferentFromInitialDeck()
        {
            var initialDeck = deck.GetDeck();
            
            deck.RandomShuffle();

            var shuffledDeck = deck.GetDeck();

           Assert.That(initialDeck.SequenceEqual(shuffledDeck),Is.False);
        }
    }
}
