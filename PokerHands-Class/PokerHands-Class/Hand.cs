using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands_Class
{
    class Hand
    {
        //define properties
        public List<Card> Cards { get; set; }
        
        //define the constructor
        // Ex. 3H 4H 5H 3C 7S
        public Hand(string handString)
        {
            //initialize the card list
            this.Cards = new List<Card>();
            //split the handString into cardStrings
            var tempList = handString.Split(' ').ToList();
            for (int i = 0; i <= 4; i++)
            {
                //adding new cards to our card list
                this.Cards.Add(new Card(tempList[i]));
            }
        }

        //new functions go here
        public bool HasFlush()
        {
            //how to select just one property of an object
            // and get only unique (distinct) values
            
            //selects the only the suits of our cards, takes only the 
            // distinct values, and counts them.  if there is only 1
            // suit, it must be a flush.
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;
        }

        public bool HasPair()
        {
            // selects only the values of the cards, takes only
            // distinct values, and counts them.  if there are only
            // 4 values, two of them must be the same.
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }

        public bool ThreeOfAKind()
        {
            //Grouping cards by rank.  The Rank is then stored in the Key value.
            // Then ordering the cards by descending order by the number of
            // occurences of each rank
            var tmp = this.Cards.GroupBy(x => x.Rank)
                .OrderByDescending(x=> x.Count());

            //filter the tmp list to find a group where there are three
            // instences of a single value.  The .Any() returns a boolean 
            // value on if there is a value in the filtered list.
            return tmp.Where(x => x.Count() == 3).Any();
        }
    }
}
