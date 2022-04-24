using BattleShipCore.Lib;
using BattleShipCore.Models.Board;
using BattleShipCore.Models.Ships;

namespace BattleShipCore.Services
{
    public static class BoardGenerator
    {
        public static GameBoard GeneratePrimaryBoard(List<Models.Ships.BaseShip> ships)
        {
            List<Tile> tiles = generateListOfEmptyTiles();
            GameBoard board = new GameBoard(tiles);

            foreach (Models.Ships.BaseShip ship in ships)
            {
                PlaceShipRandomly(tiles, ship);
            }

            return board;
        }

        private static List<Tile> generateListOfEmptyTiles()
        {
            List<Tile> tiles = new List<Tile>();

            for (int column = 0; column < Constants.BOARD_SIZE; column++)
            {
                for (int row = 0; row < Constants.BOARD_SIZE; row++)
                {
                    Position position = new Position(row, column);
                    Tile tile = new Tile(position);
                    tiles.Add(tile);
                }
            }
            return tiles.OrderBy(t=>t.Coordinates.Row* 10 + t.Coordinates.Column).ToList();
        }

        private static void PlaceShipRandomly(List<Tile> tiles, BaseShip ship)
        {
            bool canBePlaced = false;
            while (!canBePlaced)
            {
                GetRandomCoordinates(ship, out int startColumn, out int startRow, out int endColumn, out int endRow);

                List<Tile> choosenTiles = tiles.Range(startRow, startColumn, endRow, endColumn);
                if (choosenTiles.Any(t => t.Ship != null))
                {
                    canBePlaced = false;
                    continue;
                }

                foreach (Tile tile in choosenTiles)
                {
                    tile.Ship = ship;
                    canBePlaced = true;
                }
            }
        }

        private static void GetRandomCoordinates(BaseShip ship, out int startColumn, out int startRow, out int endColumn, out int endRow)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            bool vertical = rand.Next(0, 2) == 1;
            startColumn = rand.Next(0, vertical ? Constants.BOARD_SIZE : Constants.BOARD_SIZE - ship.Size.ToInt());
            startRow = rand.Next(0, vertical ? Constants.BOARD_SIZE - ship.Size.ToInt() : Constants.BOARD_SIZE);
            endColumn = vertical ? startColumn : startColumn + ship.Size.ToInt() - 1;
            endRow = vertical ? startRow + ship.Size.ToInt() - 1 : startRow;
        }
    }
}
