using BattleShipCore.Lib;

namespace BattleShipCore.Models.Board
{
    public class GameBoard
    {
        public List<Tile> Tiles { get; set; }
        public GameBoard(List<Tile> tiles)
        {
            Tiles = tiles;
        }
        public List<Tile> GetNeighbors(Position coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Tile> panels = new List<Tile>();
            if (column >= 1)
            {
                panels.Add(Tiles.At(row, column - 1));
            }
            if (row >= 1)
            {
                panels.Add(Tiles.At(row - 1, column));
            }
            if (row < Constants.BOARD_SIZE - 1)
            {
                panels.Add(Tiles.At(row + 1, column));
            }
            if (column < Constants.BOARD_SIZE - 1)
            {
                panels.Add(Tiles.At(row, column + 1));
            }
            return panels;
        }

        public List<Tile> GetNotHitNeighbors(Position coordinates)
        {
            List<Tile> allNeighbors = GetNeighbors(coordinates);
            return allNeighbors.Where(n => !n.IsHit).ToList();
        }
    }
}

