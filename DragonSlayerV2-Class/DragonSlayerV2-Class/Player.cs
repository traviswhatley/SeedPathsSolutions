using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayerV2_Class
{

    class Actor
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get { return HP > 0; } }
        public Random rng { get; set; }
        public Actor(int hp, string name)
        {
            this.HP = hp; this.Name = name; this.RNG = new Random();
        }
        public void DoAttack(Actor actor);
    }
    class Player :Actor
    {
        //enum for attack types
        public enum AttackType { Sword = 1, Magic, Heal }


        //Constructor
        public Player(string name, int startingHP) : base(startingHP, name)
        {
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

        public override void DoAttack(Actor actor)
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
                        actor.HP -= damage;
                        //write output to the user
                        Console.WriteLine("{0} deals {1} damage to {2}", this.Name, damage, actor.Name);
                    }
                    else
                    {
                        //missed
                        Console.WriteLine("{0} missed {1} with the sword!", this.Name, actor.Name);
                    }
                    break;
                case AttackType.Magic:
                    //magic always deal 5-15 damage
                    damage = rng.Next(5, 16);
                    //deal damage to enemy
                    actor.HP -= damage;
                    //write to the console
                    Console.WriteLine("{0} did {1} damage to {2}", this.Name, damage, actor.Name);
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
