using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Ship
    {
        public ShipType Type { get; set; }
        public List<Point> Position { get; set; }
        public int Length { get; set; }
        public bool Destroyed
        {
            get
            {
                return this.Position.Where(x => x.Status == PointStatus.Hit).Count() == this.Position.Count();
            }
        }
        public Ship(ShipType type)
        {
            this.Position = new List<Point>();
            this.Type = type;
            switch (this.Type)
            {
                case ShipType.Battleship:
                    this.Length = 5;
                    break;
                case ShipType.Cruiser:
                    this.Length = 4;
                    break;
                case ShipType.Submarine:
                    this.Length = 3;
                    break;
                case ShipType.Frigate:
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
