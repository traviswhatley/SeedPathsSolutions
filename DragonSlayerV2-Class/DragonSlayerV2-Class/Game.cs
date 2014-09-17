using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayerV2_Class
{
    class Game
    {
        //define properties
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        //Constructor
        public Game()
        {
            this.Player = new Player("The mighty Dustin", 100);
            this.Enemy = new Enemy("The mightier Pat", 200);
        }

        //Methods!
        private void DisplayInfo()
        {
            //displays current hp totals for player and enemy
            Console.WriteLine("{0} {1} HP vs {2} {3} HP", Player.Name, Player.HP, Enemy.Name, Enemy.HP);

        }

        public void Play()
        {
            //playing while both are alive
            while (Player.IsAlive && Enemy.IsAlive)
            {
                DisplayInfo(); //show current HP
                Player.Attack(Enemy); //player attack enemy
                Enemy.Attack(Player); //enemy attack player
            }
            //someone died
            if (!Player.IsAlive)
            {
                Console.WriteLine("{0} hath been slain", this.Player.Name);
            }
            else
            {
                Console.WriteLine("{0} hath been defeated! There was much rejoicing.", this.Enemy.Name);
            }
        }
    }
}
