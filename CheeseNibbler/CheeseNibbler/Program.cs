using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseNibbler
{
    class Program
    {
        static void Main(string[] args)
        {
            new CheeseNibbler().PlayGame();

            Console.ReadKey();
        }
    }

    enum PointStatus { Empty, Cheese, Mouse}

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }

        public Point(int x, int y)
        {
            this.X = x; this.Y = y; this.Status = PointStatus.Empty;
        }
    }

    class CheeseNibbler
    {
        Point[,] Grid { get; set; }
        Point Mouse { get; set; }
        Point Cheese { get; set; }
        int Round { get; set; }

        public CheeseNibbler()
        {
            this.Grid = new Point[10, 10];
            this.Round = 1;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    this.Grid[x, y] = new Point(x, y);
                }
            }

            Random rng = new Random();
            this.Mouse = Grid[rng.Next(0, 10), rng.Next(0, 10)];
            this.Mouse.Status = PointStatus.Mouse;


            do
            {
                this.Cheese = Grid[rng.Next(0, 10), rng.Next(0, 10)];
            } while (this.Cheese.Status != PointStatus.Empty); 
            this.Cheese.Status = PointStatus.Cheese;
        }

        private void DrawGrid()
        {
            Console.Clear();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    switch (this.Grid[x, y].Status)
                    {
                        case PointStatus.Cheese:
                            Console.Write("[C]");
                            break;
                        case PointStatus.Mouse:
                            Console.Write("[M]");
                            break;
                        default:
                            Console.Write("[ ]");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        private ConsoleKey GetUserMove()
        {
            //Console.ReadKey(true) keeps the character from being written to the console.
            ConsoleKeyInfo input = Console.ReadKey(true);
            while ((input.Key != ConsoleKey.LeftArrow && input.Key != ConsoleKey.RightArrow && input.Key != ConsoleKey.UpArrow && ConsoleKey.DownArrow != input.Key) || !ValidMove(input.Key))
            {
                Console.WriteLine("Invalid Move");
                input = Console.ReadKey(true);
            }
            return input.Key;
        }

        private bool ValidMove(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    return this.Mouse.X - 1 >= 0;
                case ConsoleKey.RightArrow:
                    return this.Mouse.X + 1 < this.Grid.GetLength(1);
                case ConsoleKey.UpArrow:
                    return this.Mouse.Y - 1 >= 0;
                default:
                    return this.Mouse.Y + 1 < this.Grid.GetLength(0);
            }
        }

        private bool MoveMouse(ConsoleKey input)
        {
            int newMouseX = this.Mouse.X;
            int newMouseY = this.Mouse.Y;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    newMouseX--;
                    break;
                case ConsoleKey.RightArrow:
                    newMouseX++;
                    break;
                case ConsoleKey.UpArrow:
                    newMouseY--;
                    break;
                default:
                    newMouseY++;
                    break;
            }
            Point targetPosition = this.Grid[newMouseX, newMouseY];
            if (targetPosition.Status == PointStatus.Cheese)
            {
                return true;
            }
            else
            {
                this.Mouse.Status = PointStatus.Empty;
                targetPosition.Status = PointStatus.Mouse;
                this.Mouse = targetPosition;
                return false;
            }
           
        }

        public void PlayGame()
        {
            bool cheeseFound = false;
            while (!cheeseFound)
            {
                DrawGrid();
                ConsoleKey input = GetUserMove();
                cheeseFound = MoveMouse(input);
                this.Round++;
            }
            Console.WriteLine("Congrats, it took you {0} moves to find the cheese", this.Round);
        }

    }
}
