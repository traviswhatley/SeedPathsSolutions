using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public PointStatus Status {get;set;}

        public Point(int x, int y, PointStatus s)
        {
            this.x = x; this.y = y;
            this.Status = s;
        }
    }
}
