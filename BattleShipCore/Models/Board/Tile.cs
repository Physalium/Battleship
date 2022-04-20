using BattleShipCore.Lib;
using BattleShipCore.Models.Ships;

namespace BattleShipCore.Models.Board
{
    public class Tile
    {
        public Position Coordinates { get; set; }

        public BaseShip? Ship { get; set; }

        public bool IsHit { get; set; }

        public Tile(Position position, BaseShip? ship = null)
        {
            Coordinates = position;
            Ship = ship;
            IsHit = false;
        }
    }
}
