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

        public bool HavePair()
        {
            // selects only the values of the cards, takes only
            // distinct values, and counts them.  if there are only
            // 4 values, two of them must be the same.
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }

        public bool HaveTwoPair()
        {
            return this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }

        public bool HaveThreeOfAKind()
        {
            //Grouping cards by rank.  The Rank is then stored in the Key value.
            // Then ordering the cards by descending order by the number of
            // occurences of each rank
            IEnumerable<IGrouping<int, Card>> groupedListOfRank = this.Cards.GroupBy(x => x.Rank);

            //filter the groupListOfRank list to find a group where there are three
            // instences of a single value.  The .Any() returns a boolean 
            // value on if there is a value in the filtered list.
            return groupedListOfRank.Where(x => x.Count() == 3).Any();
        }

        public bool HaveStraight()
        {
            bool straight = true;
            var ordered = this.Cards.OrderBy(x=> x.Rank).ToList();
            for (int i = 0; i < 4; i++)
            {
                if (ordered[i].Rank != ordered[i + 1].Rank - 1)
                {
                    straight = false;
                    break;
                }
            }
            return straight;
        }

        public bool HaveFlush()
        {
            //how to select just one property of an object
            // and get only unique (distinct) values

            //selects the only the suits of our cards, takes only the 
            // distinct values, and counts them.  if there is only 1
            // suit, it must be a flush.
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;
        }

        public bool HaveFullHouse()
        {
            return HaveTwoPair() & HaveThreeOfAKind();
        }

        public bool HaveFourOfAKind()
        {
            return this.Cards.GroupBy(x => x.Rank).Any(x => x.Count() == 4);
        }

        public bool HaveStraightFlush()
        {
            return HaveStraight() && HaveFlush();
        }

        public bool HaveRoyalFlush()
        {
            return HaveStraightFlush() && this.Cards.OrderBy(x => x.Rank).First().Rank == 10;
        }

        public string ShowHand()
        {
            if (HaveRoyalFlush()) {return "Royal Flush";}
            else if (HaveStraightFlush()) { return "Straight Flush"; }
            else if (HaveFourOfAKind()) { return "Four of a Kid"; }
            else if (HaveFullHouse()) { return "Full House"; }
            else if (HaveFlush()) { return "Flush"; }
            else if (HaveStraight()) { return "Straight"; }
            else if (HaveThreeOfAKind()) { return "Three of a Kind"; }
            else if (HaveTwoPair()) { return "Two Pair"; }
            else if (HavePair()) { return "Pair"; }
            else { return "High Card"; } 
        }

        
    }
}
