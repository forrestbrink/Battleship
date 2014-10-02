using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum PointStatus
    {
        Empty,
        Ship,
        Hit,
        Miss
    }
    class Point
    {
        public int Y { get; set; }
        public int X { get; set; }
        public PointStatus Status { get; set; }

        public Point(int x, int y, PointStatus Status)
        {
            this.Y = y;
            this.X = x;
            this.Status = Status;
        }
    }
}
