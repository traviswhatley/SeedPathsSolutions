using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum PointStatus
    {
        NotTargeted = 0,
        Ship,
        Hit,
        Miss
    }

    public enum ShipType
    {
        Battleship = 1,
        Cruiser,
        Submarine,
        Frigate,
        Minesweeper
    }

    public enum PlaceShipDirection
    {
        Horizontally,
        Vertically
    }

   
}
