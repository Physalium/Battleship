using BattleShipCore.Lib;

namespace BattleShipCore.Models.Board
{
    public abstract class BaseBoard
    {
        public List<Tile> Tiles { get; set; }

        public BaseBoard(List<Tile> tiles)
        {
            Tiles = tiles;
        }
    }
}
