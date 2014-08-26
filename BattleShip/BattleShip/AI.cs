using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class AI
    {
        public Point LastTargetted { get; set; }
        public List<Point> Chain { get; set; }
        public Grid Grid { get; set; }
        private Random RNG { get; set; }
        public PlaceShipDirection TargetDirection { get; set; }
        public int ShipsDestroyed { get; set; }

        public AI(Grid g)
        {
            this.Chain = new List<Point>();
            this.Grid = g;
            this.RNG = new Random();
            this.ShipsDestroyed = 0;
        }

        public void Target()
        {
            if (this.Grid.Ships.Count(x => x.Destroyed) > ShipsDestroyed)
            {
                this.ShipsDestroyed = this.Grid.Ships.Count(x => x.Destroyed);
                //reset last target and chain
                this.LastTargetted = null;
                this.Chain.Clear();
            }
            if (LastTargetted == null || this.LastTargetted.Status == PointStatus.Miss)
            {
                //clear chain
                this.Chain.Clear();
                //get random x/y
                int x = RNG.Next(0, 10); int y = RNG.Next(0, 10);
                var p = Grid.Ocean[x, y];
                while (p.Status != PointStatus.NotTargeted && p.Status != PointStatus.Ship) {
                    x = RNG.Next(0, 10); y = RNG.Next(0, 10);
                    p = Grid.Ocean[x, y];
                }
                //got a valid target! FIRE!
                this.Grid.Target(x, y);
                this.LastTargetted = p;
                this.Chain.Add(p);
            }
            else if (LastTargetted.Status == PointStatus.Hit && this.Chain.Where(x => x.Status == PointStatus.Hit).Count() > 1)
            {
                var first = this.Chain.Where(t => t.Status == PointStatus.Hit).First();
                var last = this.Chain.Where(t => t.Status == PointStatus.Hit).Last();
                int x = this.LastTargetted.x; int y = this.LastTargetted.y;
                if (first.x == last.x)
                {
                    this.TargetDirection = PlaceShipDirection.Vertically;
                }
                else
                {
                    this.TargetDirection = PlaceShipDirection.Horizontally;
                }
                if (this.TargetDirection == PlaceShipDirection.Horizontally)
                {
                    first = this.Chain.Where(t => t.Status == PointStatus.Hit).OrderBy(t => t.x).First();
                    last = this.Chain.Where(t=> t.Status == PointStatus.Hit).OrderBy(t=> t.x).Last();
                    do
                    {
                        if (this.Chain.Any(t => t.x == x && t.y == y)) { x = first.x - 1; }
                        if (x < 0) { x = this.Chain.Where(t => t.Status == PointStatus.Hit).Select(t => t.x).OrderBy(t => t).Last() + 1; }
                        if (this.Chain.Any(t => t.x == x && t.y == y)) { x = last.x + 1; }
                        if (x > 9) { x = this.Chain.Where(t => t.Status == PointStatus.Hit).Select(t => t.x).OrderBy(t => t).First() - 1; }
                    } while ((x < 0 || x > 9) && (this.Grid.Ocean[x,y].Status != PointStatus.Miss || this.Grid.Ocean[x,y].Status != PointStatus.Hit));
                }
                else
                {
                    first = this.Chain.Where(t => t.Status == PointStatus.Hit).OrderBy(t => t.y).First();
                    last = this.Chain.Where(t => t.Status == PointStatus.Hit).OrderBy(t => t.y).Last();
                    do
                    {
                        if (this.Chain.Any(t => t.x == x && t.y == y)) { y = first.y - 1; }
                        if (y < 0) { y = this.Chain.Where(t => t.Status == PointStatus.Hit).Select(t => t.y).OrderBy(t => t).Last() + 1; }
                        if (this.Chain.Any(t => t.x == x && t.y == y)) { y = last.y + 1; }
                        if (y > 9) { y = this.Chain.Where(t => t.Status == PointStatus.Hit).Select(t => t.y).OrderBy(t => t).First() - 1; }
                    } while ((y < 0 || y > 9) && (this.Grid.Ocean[x,y].Status != PointStatus.Miss || this.Grid.Ocean[x,y].Status != PointStatus.Hit));
                }
                //FIRE!
                this.Grid.Target(x, y);
                var p = this.Grid.Ocean[x, y];
                this.Chain.Add(p);
            }
            else if (LastTargetted.Status == PointStatus.Hit) 
            {
                //go in a circle
                bool targetOK = false; Point p; int x = this.LastTargetted.x; int y = this.LastTargetted.y;
                while (!targetOK)
                {
                    if (!this.Chain.Any(t => t.x == x && t.y  == y - 1) && y > 0)
                    {
                        //try up
                        y--;
                        targetOK = true;
                    }
                    else if (!this.Chain.Any(t => t.x == x + 1 && t.y == y) && x < 9)
                    {
                        //try right
                        x++;
                        targetOK = true;
                    }
                    else if (!this.Chain.Any(t => t.x == x && t.y == y + 1) && y < 9)
                    {
                        //try down
                        y++;
                        targetOK = true;
                    }
                    else if (!this.Chain.Any(t => t.x == x - 1) && x > 0)
                    {
                        //try left
                        x--; 
                        targetOK = true;
                    }
                }
                this.Grid.Target(x, y);
                p = this.Grid.Ocean[x, y];
                this.Chain.Add(p);
            }
            

        }

     
    }
}
