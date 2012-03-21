using System;
using Shuffler.Domain;

namespace Shuffler
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new FrenchDeck();
            deck.RandomShuffle();
            deck.Shuffle();
            deck.RandomShuffle();
            deck.Shuffle();
            deck.Print();

            Console.ReadKey();
        }
    }
}
