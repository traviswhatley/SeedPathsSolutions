using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.PrintDeck();
            deck.Shuffle();
            Console.WriteLine("\nSHUFFLED\n");
            deck.PrintDeck();
            var draw5 = deck.Deal(5);

            Console.ReadKey();

            
        }
    }
}
