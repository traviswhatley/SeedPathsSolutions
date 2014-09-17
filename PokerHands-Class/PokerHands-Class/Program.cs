using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            //HIGH CARD
            //var myHand = new Hand("2H 3H 4C 9C 6D");
            //FLUSH
            //var myHand = new Hand("2D 3D 4D 9D 6D");
            //TWO PAIR
            //var myHand = new Hand("2H 3H 3C 6C 6D");
            //ROYAL FLUSH
            var myHand = new Hand("TC JC QC KC AC");

            Console.WriteLine(myHand.ShowHand());
            Console.ReadKey();
        }
    }
}
