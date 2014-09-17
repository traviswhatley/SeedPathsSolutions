using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayerV2_Class
{
    class Enemy
    {
        //Name of the enemy
        private string _name;
        public string Name  
        {
            get { return _name; }
            set { _name = value.ToUpper() ; }
        }
        
        //Health of the enemy
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        //read-only property for IsAlive
        public bool IsAlive
        {
            get { return this.HP > 0; }
        }

        //create our RNG
        Random rng = new Random();

        //Constructor
        public Enemy(string name, int startingHP)
        {
            //initialize the object
            this.HP = startingHP;
            this.Name = name;
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
