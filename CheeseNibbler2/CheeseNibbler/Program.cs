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
            Console.WindowWidth = 120;
            bool playAgain = true;
            {
                while (playAgain)
                    new CheeseNibbler().PlayGame();
                Console.WriteLine("Would you like to play again? Y/N");
                string input = Console.ReadLine();
                playAgain = (input.ToLower() == "y");
            }
            Console.WriteLine("Thanks for playing! \n\nPress any key quit...");
            Console.ReadKey(true);
        }
    }


    public class CheeseNibbler
    {
        public Point[,] Grid { get; set; }
        public Mouse Mouse { get; set; }
        public Point Cheese { get; set; }
        public int CheeseCount { get; set; }
        public List<Cat> Cats { get; set; }
        //random num gen
        Random rng = new Random();

        public CheeseNibbler()
        {
            this.Cats = new List<Cat>();
            this.CheeseCount = 0;
            this.Mouse = new Mouse();
            //initialize the Grid

            this.Grid = new Point[10, 10];
            //fill each point in the ocean with a new point object
            // for each y
            for (int y = 0; y < 10; y++)
            {
                //for each x
                for (int x = 0; x < 10; x++)
                {
                    //fill the point with an object
                    this.Grid[x, y] = new Point(x, y);
                }
            }


            //place the mouse
            this.Mouse.Position = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
            this.Mouse.Position.PointStatus = PointStatus.Mouse;

            //place the cheese
            PlaceCheese();

        }

        private void DrawGrid()
        {
            Console.Clear();
            //This displays the grid to the user

            //2. For each row (y)
            for (int y = 0; y < 10; y++)
            {
                //b. For each column (x)
                for (int x = 0; x < 10; x++)
                {
                    //i. Get the Point from the Grid using (x, y)
                    Point aPoint = this.Grid[x, y];
                    //ii. Write the cell to console using the following format:
                    //[ ] PointStatus.Empty/ PointStatus.Ship
                    //[X] PointStatus.Hit
                    //[O] PointStatus.Miss
                    switch (aPoint.PointStatus)
                    {
                        case PointStatus.Empty:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("[          ]");
                            break;
                        case PointStatus.Cheese:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[   C H Z  ]");
                            break;
                        case PointStatus.Cat:
                        case PointStatus.CatAndCheese:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[  =^..^=  ]");
                            break;
                        case PointStatus.Mouse:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("[ ~~(__^·> ]");
                            break;
                        default:
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //force the console to write the next line
                Console.WriteLine();
            }
            Console.WriteLine("Cheese Nibbles Eaten: {0}", this.CheeseCount);
            Console.WriteLine("Mouse Energy: {0}", this.Mouse.Energy);
        }

        public void PlayGame()
        {
            //Handles the logic for playing the Game
            //1. The game plays until all ships are destroyed
            while (this.Mouse.Energy > 0 && !this.Mouse.PouncedByCat)
            {
                //display the grid
                DrawGrid();
                //d. Call the Target() method with the user’s input
                MoveMouse(GetUserMove());
                //move cats
                foreach (Cat cat in this.Cats)
                {
                    MoveCat(cat);
                }
            }
            DrawGrid();
            if (Mouse.PouncedByCat)
            {
                Console.WriteLine("The cat got you!");
            }
            //3. After the game is complete, tell them they won and how many rounds it took.
            Console.WriteLine("Congrats, you ate {0} nibbles of cheese!", this.CheeseCount);
        }

        private ConsoleKey GetUserMove()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.LeftArrow || inputKey.Key == ConsoleKey.RightArrow || inputKey.Key == ConsoleKey.UpArrow || inputKey.Key == ConsoleKey.DownArrow)
                {
                    if (ValidMouseMove(inputKey.Key))
                    {
                        inputValid = true;
                        return inputKey.Key;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Move");
                    }

                }
                else
                {
                    Console.WriteLine("invalid key, use up/down/left/right arrow");
                }
            }
            //this line should never get hit
            return ConsoleKey.UpArrow;
        }
        private void MoveMouse(ConsoleKey input)
        {
            //decrement Energy
            this.Mouse.Energy--;

            int startX = this.Mouse.Position.X;
            int startY = this.Mouse.Position.Y;

            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    startX--;
                    break;
                case ConsoleKey.RightArrow:
                    startX++;
                    break;
                case ConsoleKey.UpArrow:
                    startY--;
                    break;
                case ConsoleKey.DownArrow:
                    startY++;
                    break;
                default:
                    break;

            }
            Point newMousePosition = this.Grid[startX, startY];
            if (newMousePosition.PointStatus == PointStatus.Cheese)
            {
                //got the cheese, increase cheese count
                this.CheeseCount++;
                this.Mouse.EatCheese();
                //place new cheese
                PlaceCheese();

                //check to add a new cat
                if (this.CheeseCount % 2 == 0)
                {
                    AddCat();
                }
                newMousePosition.PointStatus = PointStatus.Mouse;
            }
            else if (newMousePosition.PointStatus == PointStatus.Cat)
            {
                this.Mouse.PouncedByCat = true;
                newMousePosition.PointStatus = PointStatus.Cat;
            }
            else
            {
                newMousePosition.PointStatus = PointStatus.Mouse;
            }

            //move the mouse
            this.Mouse.Position.PointStatus = PointStatus.Empty;
            this.Mouse.Position = newMousePosition;


        }
        public bool ValidMouseMove(ConsoleKey input)
        {
            int startX = this.Mouse.Position.X;
            int startY = this.Mouse.Position.Y;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    startX--;
                    return (startX >= 0);

                case ConsoleKey.RightArrow:
                    startX++;
                    return startX <= 9;

                case ConsoleKey.UpArrow:
                    startY--;
                    return startY >= 0;

                case ConsoleKey.DownArrow:
                    startY++;
                    return startY <= 9;

                default:
                    return false;

            }
        }

        private void PlaceCheese()
        {
            bool placeOK = false;
            while (!placeOK)
            {
                //get a random ppoint
                Point point = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
                if (point.PointStatus == PointStatus.Empty)
                {
                    //status is empty, place the cheese
                    placeOK = true;
                    point.PointStatus = PointStatus.Cheese;
                    this.Cheese = point;
                }
            }
        }

        private void AddCat()
        {
            Cat newCat = new Cat();
            PlaceCat(newCat);
            this.Cats.Add(newCat);
        }
        private void PlaceCat(Cat cat)
        {
            bool placeOK = false;
            while (!placeOK)
            {
                //get a random point
                Point point = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
                if (point.PointStatus == PointStatus.Empty)
                {
                    //status is empty, place the cheese
                    placeOK = true;
                    point.PointStatus = PointStatus.Cat;
                    cat.Position = point;
                }
            }
        }
        private void MoveCat(Cat cat)
        {
            //cat has 80% chance to move
            if (rng.Next(6) > 1)
            {
                int x = this.Mouse.Position.X - cat.Position.X;
                int y = this.Mouse.Position.Y - cat.Position.Y;
                bool validMove = false;
                Point targetLocation = cat.Position;
                bool tryLeft = (x < 0);
                bool tryRight = (x > 0);
                bool tryUp = (y < 0);
                bool tryDown = (y > 0);

                while (!validMove && (tryLeft || tryRight || tryUp || tryDown))
                {
                    int targetX = cat.Position.X;
                    int targetY = cat.Position.Y;


                    if (tryRight)
                    {
                        targetLocation = Grid[++targetX, targetY];
                        tryRight = false;
                    }
                    else if (tryLeft)
                    {
                        targetLocation = Grid[--targetX, targetY];
                        tryLeft = false;
                    }
                    else if (tryDown)
                    {
                        targetLocation = Grid[targetX, ++targetY];
                        tryDown = false;
                    }
                    else if (tryUp)
                    {
                        targetLocation = Grid[targetX, --targetY];
                        tryUp = false;
                    }
                    validMove = IsValidCatMove(targetLocation);
                }
                //leaving space checks
                if (cat.Position.PointStatus == PointStatus.CatAndCheese)
                {
                    cat.Position.PointStatus = PointStatus.Cheese;
                }
                else
                {
                    cat.Position.PointStatus = PointStatus.Empty;
                }
                //new space check
                if (targetLocation.PointStatus == PointStatus.Mouse)
                {
                    this.Mouse.PouncedByCat = true;
                    targetLocation.PointStatus = PointStatus.Cat;
                }
                else if (targetLocation.PointStatus == PointStatus.Cheese)
                {
                    targetLocation.PointStatus = PointStatus.CatAndCheese;
                }
                else
                {
                    targetLocation.PointStatus = PointStatus.Cat;
                }
                cat.Position = targetLocation;
            }
        }
        private bool IsValidCatMove(Point targetLocation)
        {
            return (targetLocation.PointStatus == PointStatus.Empty || targetLocation.PointStatus == PointStatus.Mouse);
        }
    }


    public enum PointStatus { Empty, Mouse, Cheese, Trap, Cat, CatAndCheese }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus PointStatus { get; set; }

        public Point(int x, int y)
        {
            this.X = x; this.Y = y; this.PointStatus = PointStatus.Empty;
        }
    }

    public class Mouse
    {
        public int Energy { get; set; }
        public Point Position { get; set; }
        public bool PouncedByCat { get; set; }
        public Mouse()
        {
            this.PouncedByCat = false;
            this.Energy = 50;
        }
        public void EatCheese()
        {
            this.Energy += 10;
        }
    }

    public class Cat
    {
        public Point Position { get; set; }


    }
}
