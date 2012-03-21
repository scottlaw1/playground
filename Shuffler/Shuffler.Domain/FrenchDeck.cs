using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuffler.Domain
{
    public class FrenchDeck : ICardDeck
    {
        const int StandardDeckSize = 52;

        private Stack<Card> _deck;

        public FrenchDeck()
        {
            _deck = new Stack<Card>(StandardDeckSize);
            foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)).Cast<Rank>())
                {
                    _deck.Push(new Card(suit,rank));
                }
            }
        }

        public IEnumerable<Card> GetDeck()
        {
            return _deck;
        }

        public void Shuffle()
        {
            const int cut = StandardDeckSize/2;
            
            _deck = Interleave(cut);
        }

        public void RandomShuffle()
        {
            int cut = new Random().Next(StandardDeckSize);
            _deck = Interleave(cut);
        }

        private Stack<Card> Interleave(int halfDeck)
        {
            var firstHalf = new Stack<Card>(_deck.Take(halfDeck));
            var secondHalf = new Stack<Card>(_deck.Skip(halfDeck));
            var shuffledDeck = new Stack<Card>(StandardDeckSize);

            while (firstHalf.Count > 0 || secondHalf.Count > 0)
            {
                if (firstHalf.Count > 0) shuffledDeck.Push(firstHalf.Pop());
                if (secondHalf.Count > 0) shuffledDeck.Push(secondHalf.Pop());
            }
            return shuffledDeck;
        }

        public int Size
        {
            get { return _deck.Count; }
        }

        public void Print()
        {
            foreach (var card in _deck)
            {
                Console.WriteLine(card+Environment.NewLine);
            }
        }
    }
}
