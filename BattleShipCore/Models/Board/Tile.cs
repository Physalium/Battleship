using BattleShipCore.Lib;
using BattleShipCore.Models.Ships;

namespace BattleShipCore.Models.Board
{
    public class Tile
    {
        public Position Coordinates { get; }

        public BaseShip? Ship { get; set; }

        public bool IsHit { get; set; }
        public bool IsInCheckerboardPattern { get; set; }

        public Tile()
        {
        }

        public Tile(Position position, BaseShip? ship = null)
        {
            Coordinates = position;
            Ship = ship;
            IsHit = false;
            IsInCheckerboardPattern = (Coordinates.Row % 2 == 0 && Coordinates.Column % 2 == 0) || (Coordinates.Row % 2 == 1 && Coordinates.Column % 2 == 1);
        }
    }
}