using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSpace
{
   
    class Program
    {
        static void Main(string[] args)
        {
            new HyperSpace().PlayGame();
            Console.ReadKey();
        }
    }

    class Unit
    {
        static Random rng = new Random();
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }
        public bool IsSpaceRift { get; set; }
 
        private static List<string> SymbolList = new List<string>() { ".", "'", ";", ":", "*", "#", "!" };
        public Unit(int x, int y)
        {
            this.X = x; this.Y = y; this.Color = ConsoleColor.Cyan; this.Symbol = SymbolList[rng.Next(SymbolList.Count)];
        }

        public Unit(int x, int y, ConsoleColor color, string symbol, bool isSpaceRift)
        {
            this.X = x; this.Y = y; this.Color = color; this.Symbol = symbol; this.IsSpaceRift = isSpaceRift;
        }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
        }
    }

    class HyperSpace 
    {
        private Random rng = new Random();

        public int Score { get; set; }
        public int Speed { get; set; }
        List<Unit> UnitList { get; set; }
        Unit SpaceShip { get; set; }
        bool Smashed { get; set; }

        public HyperSpace()
        {
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 60;

            this.Score = 0; this.Speed = 0; this.UnitList = new List<Unit>();
            this.SpaceShip = new Unit((Console.WindowWidth / 2) - 1, Console.WindowHeight - 1, ConsoleColor.Red, "@", false);


        }
        
        public void PlayGame() 
        {
            while (!this.Smashed)
            {
                if (rng.Next(20) == 1)
                {
                    //rift
                    UnitList.Add(new Unit(rng.Next(0, Console.WindowWidth - 2), 5, ConsoleColor.Green, "%", true));
                }
                else
                {
                    //obstacle
                    UnitList.Add(new Unit(rng.Next(0, Console.WindowWidth - 2), 5));
                }

                MoveShip();

                MoveObstacles();

                DrawGame();

                // Slow the game down
                if (this.Speed < 170)
                {
                    this.Speed++;
                }
                System.Threading.Thread.Sleep(170 - this.Speed);
            }
        }

        public void MoveShip()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable) 
                { 
                    Console.ReadKey(true);
                }
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (this.SpaceShip.X > 0)
                    {
                        this.SpaceShip.X--;
                    }
                }
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (this.SpaceShip.X < Console.WindowWidth - 2)
                    {
                        this.SpaceShip.X++;
                    }
                }
            }
        }
        public void MoveObstacles()
        {
            List<Unit> newList = new List<Unit>();
            foreach (var unit in UnitList)
            {
                unit.Y++;
                if (unit.IsSpaceRift && unit.X == this.SpaceShip.X && unit.Y == this.SpaceShip.Y)
                {
                    //buff
                    this.Speed -= 50;
                }
                if (!unit.IsSpaceRift && unit.X == this.SpaceShip.X && unit.Y == this.SpaceShip.Y)
                {
                    //collision
                    this.Smashed = true;
                }
                if (unit.Y < Console.WindowHeight)
                {
                    newList.Add(unit);
                }
                else
                {
                    this.Score++;
                }
            }
            this.UnitList = newList;
        }

        public void DrawGame()
        {
            Console.Clear();
            this.SpaceShip.Print();
            foreach (var item in UnitList)
            {
                item.Print();
            }

            //draw score and lives 
            // Draw Score and lives
            for (int i = 0; i < Console.WindowWidth; i++) // Score Divider
            {
                PrintAtPosition(i, 5, "-", ConsoleColor.Gray);
            }
            PrintAtPosition(20, 2, "Score: " + this.Score, ConsoleColor.Green);
            PrintAtPosition(20, 3, "Speed: " + this.Speed, ConsoleColor.Green);
        }

        public void PrintAtPosition(int x, int y, string text, ConsoleColor color) {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
