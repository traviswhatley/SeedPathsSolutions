using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayerV2_Class
{
   

    class Enemy : Actor
    {
       

        //Constructor
        public Enemy(string name, int startingHP) : base(startingHP, name)
        {
        }

        //Do our attack method
        public void Attack(Player player)
        {
            //80% to hit
            if (rng.Next(0, 11) > 2)
            {
                //hit!, damage roll for 5-15 hp
                int damage = rng.Next(5, 16);
                //we will hit the player
                player.HP -= damage;
                //write the output to the console
                Console.WriteLine("{0} hit {1} for {2} damage!", this.Name, player.Name, damage);
            }
            else
            {
                //miss
                Console.WriteLine("{0} missed {1}.", this.Name, player.Name);
            }
        }
        
    }
}
