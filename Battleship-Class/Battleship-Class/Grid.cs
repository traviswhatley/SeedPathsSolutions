using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Class
{
    class Grid
    {
        //define properties
        public Point[,] Ocean { get; set; }

        //define constructor
        public Grid()
        {
            //initialize the Ocean
            this.Ocean = new Point[10, 10];
            //this.Ocean[4, 7] = new Point(4, 7, Point.PointStatus.Empty);

        }
    }
}
