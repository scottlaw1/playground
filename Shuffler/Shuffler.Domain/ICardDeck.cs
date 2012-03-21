using System.Collections.Generic;

namespace Shuffler.Domain
{
    public interface ICardDeck
    {
        IEnumerable<Card> GetDeck();
        void Shuffle();
        void RandomShuffle();
    }
}