using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Grid
    {
        public Point[,] Ocean { get; set; }
        public List<Ship> Ships { get; set; }
        public bool AllShipsDestroyed
        {
            get
            {
                return this.Ships.All(x => x.Destroyed);
            }
        }

        /// <summary>
        /// Constructor for the grid class.  
        /// 1. Initialize the grid.  
        /// 2. Fill the cells with point objects.
        /// 3. Create the ship objects
        /// 4. Place the ships on the grid.
        /// </summary>
        public Grid()
        {
            //initialize the ocean (grid/table)
            this.Ocean = new Point[10, 10];
            //set each cell of the ocean (grid/table) to an instance of the 
            // Point object
            for (int y = 0; y < 10; y++)
            {
                //go through each row
                for (int x = 0; x < 10; x++)
                {
                    //for each row go through each column
                    //and create a new instance of the Point object
                    //for each cell of our ocean (grid/table)
                    this.Ocean[x, y] = new Point(x, y, PointStatus.NotTargeted);
                }
            }

            //create the ship objects
            this.Ships = new List<Ship>() {new Ship(ShipType.Battleship), new Ship(ShipType.Cruiser),
                new Ship(ShipType.Frigate), new Ship(ShipType.Submarine), new Ship(ShipType.Minesweeper)};
            //place the ships on the ocean (grid/table)
            //PlaceShips();
            PlaceShipsRandomly();
        }

        public void PlaceShipsRandomly()
        {
            //init random number generator
            var rng = new Random();
            foreach (var ship in this.Ships)
            {
                bool positionOK = true;
                 //for each ship, get a random starting point
                int startX;
                int startY;
                //convert a random 0 or 1 to a direction enum
                PlaceShipDirection dir = (PlaceShipDirection)rng.Next(0, 2);
                do
                {
                    //reset the positionOK flag
                    positionOK = true;
                    //get a random start spot
                    startX = rng.Next(0, 10);
                    startY = rng.Next(0, 10);
                    int x = startX;
                    int y = startY;
                    //check if the coordinates are empty
                    for (int i = 0; i < ship.Length; i++)
                    {
                        try
                        {
                            var p = this.Ocean[x, y];
                            if (p.Status != PointStatus.NotTargeted)
                            {
                                positionOK = false;
                                break;
                            }
                            if (dir == PlaceShipDirection.Horizontally) { x++; } else { y++; }
                        }
                        catch (Exception ex)
                        {
                            //index was outside of the grid, try again
                            positionOK = false;
                            break;
                        }
                    }
                } while (!positionOK);
                //position is clear, place the ship
                PlaceShip(ship, dir, startX, startY);

            }
        }

        #region Place Ships Manually
        //public void PlaceShipsManually() 
        //{
        //    //place each ship manually (for now)
        //    PlaceShip(this.Ships[0], PlaceShipDirection.Horizontally, 5, 5);
        //    PlaceShip(this.Ships[1], PlaceShipDirection.Horizontally, 0, 0);
        //    PlaceShip(this.Ships[2], PlaceShipDirection.Vertically, 3, 3);
        //    PlaceShip(this.Ships[3], PlaceShipDirection.Horizontally, 3, 7);
        //    PlaceShip(this.Ships[4], PlaceShipDirection.Vertically, 7, 2);
        //}
#endregion

        private void PlaceShip(Ship ship, PlaceShipDirection dir, int x, int y)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                var p = this.Ocean[x, y];
                p.Status = PointStatus.Ship;
                ship.Position.Add(p);
                if (dir == PlaceShipDirection.Horizontally) { x++; } else { y++; }
            }
        }


        public void DisplayGrid()
        {
            DisplayGrid(false);
        }

        public void DisplayGrid(bool showShips)
        {
            Console.Clear();
            DisplayTitle();
            Console.WriteLine("   0  1  2  3  4  5  6  7  8  9   X");
            Console.WriteLine("  ==============================");
            for (int y = 0; y < 10; y++)
            {
                Console.Write(y + "|");
                for (int x = 0; x < 10; x++)
                {
                    switch (this.Ocean[x,y].Status)
                    {
                        case PointStatus.Ship:
                            if (showShips)
                            {
                                Console.Write("[S]");
                            }
                            else
                            {
                                Console.Write("[ ]");
                            }
                            break;
                        case PointStatus.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[X]");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case PointStatus.Miss:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[O]");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            Console.Write("[ ]");
                            break;
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Y");
            Console.WriteLine("========================");
        }

        public void Target(int x, int y)
        {
            var point = this.Ocean[x, y];
            if (point.Status == PointStatus.Ship)
            {
                point.Status = PointStatus.Hit;
            } 
            else if (point.Status == PointStatus.NotTargeted)
            {
                point.Status = PointStatus.Miss;
            }
        }     

        private void DisplayTitle() {
            Console.WriteLine(@"
     ____       _______ _______ _      ______  _____ _    _ _____ _____  
    |  _ \   /\|__   __|__   __| |    |  ____|/ ____| |  | |_   _|  __ \ 
    | |_) | /  \  | |     | |  | |    | |__  | (___ | |__| | | | | |__) |
    |  _ < / /\ \ | |     | |  | |    |  __|  \___ \|  __  | | | |  ___/ 
    | |_) / ____ \| |     | |  | |____| |____ ____) | |  | |_| |_| |     
    |____/_/    \_\_|     |_|  |______|______|_____/|_|  |_|_____|_|    
");
            Console.WriteLine();
        }

    }
}
