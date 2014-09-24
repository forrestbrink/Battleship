using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Ship
    {
        //ship type enum
        public enum ShipType
        {
            Carrier,
            Battleship,
            Cruiser,
            Submarine,
            Minesweeper
        }
            //properties
            public ShipType Type {get; set;}
        public int Length {get; set;}
        public List<Point> OccupiedPoints {get; set;}
        public bool IsDestroyed {get; {return OccupiedPoints.All(x => x.Status == Point.PointStatus.Hit}}
        
        public Ship(ShipType typeOfShip)
        {
            this.Type = typeOfShip;
            switch(this.Type)
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
