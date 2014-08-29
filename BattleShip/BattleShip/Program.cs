using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {

            DoAI();


            var grid = new Grid();

            while (!grid.AllShipsDestroyed)
            {
                grid.DisplayGrid(true);
                string x; string y;
                do
                {
                    Console.WriteLine("Enter coordinates (x, y):");
                    Console.Write("(");
                    x = Console.ReadKey().KeyChar.ToString();
                    Console.Write(", ");
                    y = Console.ReadKey().KeyChar.ToString();
                    Console.Write(")");
                    Console.WriteLine();
                } while (!("0123456789".Contains(x) && "0123456789".Contains(y)));

                int aNumber = 0;
                if (!int.TryParse(Console.ReadLine(), out aNumber))
                {

                }

                grid.Target(int.Parse(x), int.Parse(y));
            }

            grid.DisplayGrid();
            Console.WriteLine();
            Console.WriteLine("YOU WON!!!!!!!!!! YEAH!");
            Console.WriteLine();

            Console.ReadKey();
        }

        static void DoAI()
        {
            var g = new Grid();
            var ai = new AI(g);
            ai.Grid.DisplayGrid();
            while (!ai.Grid.AllShipsDestroyed)
            {
                //ai.Grid.DisplayGrid();
                ai.Target();
                //System.Threading.Thread.Sleep(50);
            }
            ai.Grid.DisplayGrid();
            Console.WriteLine();
            Console.WriteLine("YOU WON!!!!!!!!!! YEAH!");
            Console.WriteLine();
            Console.ReadKey();
        }

        #region SpeechSynth
        SpeechSynthesizer synth = new SpeechSynthesizer();

            //// Configure the audio output. 
            //synth.SetOutputToDefaultAudioDevice();

            //// Speak a string.
            //synth.Speak("You sunk my " + Ships.Submarine.ToString() + "!");
        #endregion
    }
}
