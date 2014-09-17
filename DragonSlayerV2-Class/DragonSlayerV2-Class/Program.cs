using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayerV2_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            myGame.Play();
            //keep it open
            Console.ReadKey();
        }
    }
}
