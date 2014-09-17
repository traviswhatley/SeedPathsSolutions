using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayerV2_Class
{
    class Player
    {
        //enum for attack types
        public enum AttackType { Sword = 1, Magic, Heal }

        //Health of our player
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        //player's name
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //read-only property for IsAlive
        public bool IsAlive
        {
            get { return this.HP > 0; }
        }

        //create a RNG
        private Random rng = new Random();

        //Constructor
        public Player(string name, int startingHP)
        {
            //initialize the player
            this.Name = name; this.HP = startingHP;
        }
        
        //create new function to choose attack
        private AttackType ChooseAttack()
        {
            Console.WriteLine(@"
Choose Attack:
1. Sword
2. Magic
3. Heal");
            //get input from user
            int input = int.Parse(Console.ReadLine());
            //return the correct AttackType using a CAST
            return (AttackType)input;
        }

        public void Attack(Enemy enemy)
        {
            //use a switch statement to perform
            // the attack
            int damage; //variable to hold damage dealt
            switch (ChooseAttack())
            {
                case AttackType.Sword:
                    //70% chance to hit.
                    if (rng.Next(0, 11) > 3)
                    {
                        //Hit! Deal 15-30 damage
                        damage = rng.Next(15, 31);
                        //deal the damage to the enemy
                        enemy.HP -= damage;
                        //write output to the user
                        Console.WriteLine("{0} deals {1} damage to {2}", this.Name, damage, enemy.Name);
                    }
                    else
                    {
                        //missed
                        Console.WriteLine("{0} missed {1} with the sword!", this.Name, enemy.Name);
                    }
                    break;
                case AttackType.Magic:
                    //magic always deal 5-15 damage
                    damage = rng.Next(5, 16);
                    //deal damage to enemy
                    enemy.HP -= damage;
                    //write to the console
                    Console.WriteLine("{0} did {1} damage to {2}", this.Name, damage, enemy.Name);
                    break;
                case AttackType.Heal:
                    //always heals for 10-20
                    int amountToHealPlayer = rng.Next(10, 21);
                    //heal the player
                    this.HP += amountToHealPlayer;
                    //write the results to the user
                    Console.WriteLine("{0} was healed for {1} HP!", this.Name, amountToHealPlayer);
                    break;
                default:
                    break;
            }
        }
        
    }
}
