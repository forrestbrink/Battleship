using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();

            Ship submarine = new Ship(Ship.ShipType.Submarine);
            Ship carrier = new Ship(Ship.ShipType.Carrier);
            Ship cruiser = new Ship(Ship.ShipType.Cruiser);
            Ship minesweeper = new Ship(Ship.ShipType.Minesweeper);
            Ship battleship = new Ship(Ship.ShipType.Battleship);

            grid.PlaceShip(submarine, Grid.PlaceShipDirection.Vertical, 9, 2);
            grid.PlaceShip(carrier, Grid.PlaceShipDirection.Vertical, 7, 3);
            grid.PlaceShip(cruiser, Grid.PlaceShipDirection.Horizontal, 4, 1);
            grid.PlaceShip(minesweeper, Grid.PlaceShipDirection.Horizontal, 6, 2);
            grid.PlaceShip(battleship, Grid.PlaceShipDirection.Vertical, 1, 1);
        }
    }
}
