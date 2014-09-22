using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Class
{
    class Grid
    {
        //enumerations
        public enum PlaceShipDirection
        { Horizontal, Vertical }

        //define properties
        public Point[,] Ocean { get; set; }
        public List<Ship> ListOfShips { get; set; }
        public bool AllShipsDestroyed
        { get { return this.ListOfShips.All(x => x.IsDestroyed); } }
        public int CombatRound { get; set; }

        //define constructor
        public Grid()
        {
            //initialize the Ocean
            this.Ocean = new Point[10, 10];
            //fill each point in the ocean with a new point object
            // for each y
            for (int y = 0; y < 10; y++)
            {
                //for each x
                for (int x = 0; x < 10; x++)
                {
                    //fill the point with an object
                    this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
                }
            }
            //initialize the ListOfShips
            this.ListOfShips = new List<Ship>();
            //add ships to our list
            this.ListOfShips.Add(new Ship(Ship.ShipType.Carrier));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Battleship));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Cruiser));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Submarine));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Minesweeper));

            //place the ships on the ocean 
            PlaceShip(this.ListOfShips[0], PlaceShipDirection.Horizontal, 0, 0);
            PlaceShip(this.ListOfShips[1], PlaceShipDirection.Horizontal, 0, 1);
            PlaceShip(this.ListOfShips[2], PlaceShipDirection.Horizontal, 0, 2);
            PlaceShip(this.ListOfShips[3], PlaceShipDirection.Horizontal, 0, 3);
            PlaceShip(this.ListOfShips[4], PlaceShipDirection.Horizontal, 0, 4);
        }

        private void PlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
        {
            //loop for each unit of length
            for (int i = 0; i < shipToPlace.Length; i++ )
            {
                //grab the point from the ocean
                Point aPoint = this.Ocean[startX, startY];
                //set the status of the point to be a ship
                aPoint.Status = Point.PointStatus.Ship;
                //add the point to the ship's occupied points list
                shipToPlace.OccupiedPoints.Add(aPoint);
                if (direction == PlaceShipDirection.Horizontal)
                {
                    //if placing horizontal, increase X to go right by 1
                    startX++;
                }
                else
                {
                    //if placing vertical, increase Y to go down by 1
                    startY++;
                }
            }
        }

        private void DisplayOcean()
        {
            //This displays the grid to the user
            //1. Write the X axis to the console, for example:
            //Console.WriteLine(“ 0 1 2 3 4 5 6 7 8 9 X”);
            Console.WriteLine(" 0 1 2 3 4 5 6 7 8 9 X");
            Console.WriteLine(" =====================");
            //2. For each row (y)
            for (int y = 0; y < 10; y++)
            {
                //a. Write the Y axis notation, for example:
                //Console.WriteLine(“0 ||”)
                Console.Write(y + "|");
                //b. For each column (x)
                for (int x = 0; x < 10; x++)
                {
                    //i. Get the Point from the Ocean using (x, y)
                    Point aPoint = this.Ocean[x, y];
                    //ii. Write the cell to console using the following format:
                    //[ ] PointStatus.Empty/ PointStatus.Ship
                    //[X] PointStatus.Hit
                    //[O] PointStatus.Miss
                    switch (aPoint.Status)
                    {
                        case Point.PointStatus.Empty:
                            Console.Write("[ ]");
                            break;
                        case Point.PointStatus.Ship:
                            Console.Write("[S]");
                            break;
                        case Point.PointStatus.Hit:
                            Console.Write("[X]");
                            break;
                        case Point.PointStatus.Miss:
                            Console.Write("[M]");
                            break;
                        default:
                            break;
                    }
                }
                //force the console to write the next line
                Console.WriteLine();
            }
        }

        private void Target(int x, int y)
        {
            //Handles the logic for determining hits or misses
            //1. Get the Point from the Ocean by using x, y
            Point aPoint = this.Ocean[x, y];
            if (aPoint.Status == Point.PointStatus.Ship)
            {
                //2. If the PointStatus is Ship, change the Status to Hit
                aPoint.Status = Point.PointStatus.Hit;
            }
            else if (aPoint.Status == Point.PointStatus.Empty)
            {
                //3. If the PointStatus is Empty, change the Status to Miss
                aPoint.Status = Point.PointStatus.Miss;
            }
        }

        public void PlayGame()
        {
            //Handles the logic for playing the Game
            //1. The game plays until all ships are destroyed
            while (!AllShipsDestroyed)
            {
                //display the ocean
                DisplayOcean();
                //2. For each round
                string xInput = " ";
                string yInput = " ";
                while (!"0123456789".Contains(xInput) && !"0123456789".Contains(yInput))
                {
                    //a. Ask the user to enter an X coordinate
                    Console.WriteLine("Enter X");
                    xInput = Console.ReadLine();
                    //b. Ask the user to enter a Y coordinate
                    Console.WriteLine("Enter Y");
                    yInput = Console.ReadLine();
                    //c. Ensure they are valid entries
                }
                //d. Call the Target() method with the user’s input
                Target(int.Parse(xInput), int.Parse(yInput));
                //e. Increment CombatRound by 1
                this.CombatRound++;
            }
            //3. After the game is complete, tell them they won and how many rounds it took.
            Console.WriteLine("Congrats, it took you {0} rounds to win", this.CombatRound);
        }
    }
}
