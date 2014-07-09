using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands_Class
{
    class Card
    {
        //Define properties
        public int Rank { get; set; }
        public string Suit { get; set; }

        //Define constructor
        // Ex: 3D, or KS
        public Card(string cardString)
        {
            //get the rank from the string
            string tempRank = cardString[0].ToString();
            //execute code based on the value
            // of tempRank
            switch (tempRank)
            {
                case "T":
                    this.Rank = 10; 
                    break;
                case "J":
                    this.Rank = 11;
                    break;
                case "Q":
                    this.Rank = 12;
                    break;
                case "K":
                    this.Rank = 13;
                    break;
                case "A":
                    this.Rank = 14;
                    break;
                default:
                    //not a special card, its a number
                    this.Rank = int.Parse(tempRank);
                    break;
            }
            //set the suit
            this.Suit = cardString[1].ToString();
        }
    }
}
