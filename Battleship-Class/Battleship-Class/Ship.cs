using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Class
{
    class Ship
    {
        //enums
        public enum ShipType
        { Carrier, Battleship, Cruiser, Submarine, Minesweeper }

        //properties
        public ShipType Type { get; set; }
        public int Length { get; set; }

        public List<Point> OccupiedPoints { get; set; }
        public bool IsDestroyed
        {
            //return true if all OccupiedPoints have status of Hit
            get { return OccupiedPoints.All(x => x.Status == Point.PointStatus.Hit); }
        }

        //constructor
        public Ship(ShipType typeOfShip)
        {
            //initialize the OccupiedPoints list
            this.OccupiedPoints = new List<Point>();
            //set the type of ship
            this.Type = typeOfShip;
            //set the length based on the type of ship
            switch (this.Type)
            {
                case ShipType.Carrier:
                    this.Length = 5;
                    break;
                case ShipType.Battleship:
                    this.Length = 4;
                    break;
                case ShipType.Cruiser:
                    this.Length = 3;
                    break;
                case ShipType.Submarine:
                    this.Length = 3;
                    break;
                case ShipType.Minesweeper:
                    this.Length = 2;
                    break;
                default:
                    break;
            }
        }


    }
}
