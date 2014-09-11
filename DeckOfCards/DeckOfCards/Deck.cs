using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public List<Card> DealtCards { get; set; }
        public Deck()
        {
            //initialize the list of cards
            this.Cards = new List<Card>();
            //initialize the list of dealt cards
            this.DealtCards = new List<Card>();
            
            //for each suit
            for (int s = 1; s <= 4; s++)
            {
                //an for each rank
                for (int r = 2; r <= 14; r++)
                {
                    //create a new card and add it to the card list.
                    this.Cards.Add(new Card((Rank)r, (Suit)s));
                }
            }
        }

        public void Shuffle()
        {
            //add back in any dealt card to the deck
            this.Cards.AddRange(DealtCards);
            //clear the dealt cards list
            this.DealtCards.Clear();

            //initialize the new list of shuffled cards
            List<Card> shuffled = new List<Card>();
            //init RNG
            Random rng = new Random();
            //while our unshuffled deck still has a card in it
            while (this.Cards.Count > 0)
            {
                //choose a random card from the unshuffled deck
                Card card = this.Cards[rng.Next(0, this.Cards.Count - 1)];
                //add the card to the shuffled deck
                shuffled.Add(card);
                //remove the card from the unshuffled deck
                this.Cards.Remove(card);
            }
            //set the cards property equal to the shuffled deck
            this.Cards = shuffled;
        }

        public List<Card> Deal(int numCards)
        {
            List<Card> cardsToDeal = new List<Card>();
            for (int i = 0; i < numCards; i++)
            {
                Card drawn = this.Cards.Last();
                cardsToDeal.Add(drawn); // add to the card to the return list
                this.DealtCards.Add(drawn); // add card to the cards drawn deck
                this.Cards.Remove(drawn); // remove card from the undrawn deck
            }
            return cardsToDeal;
        }

        public void PrintDeck()
        {
            Console.WriteLine(string.Join("\n", this.Cards.Select(x => x.GetCardString())));
        }
    }
}
