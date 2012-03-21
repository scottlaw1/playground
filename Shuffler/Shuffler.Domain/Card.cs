using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shuffler.Domain
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        private readonly Suit _suit;
        private readonly Rank _rank;

        public Suit Suit { get { return _suit; } }

        public Rank Rank { get { return _rank; } }

        public Card(Suit suit,Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Rank, Suit);
        }
    }
}
