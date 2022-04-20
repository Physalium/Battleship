
using BattleShipCore.Models.Board;

using static BattleShipCore.Constants;

namespace BattleShipCore.Lib
{
    public static class ExtensionMethods
    {
        public static int ToInt(this ShipSize size)
        {
            return (int)size;
        }

        public static Tile At(this List<Tile> panels, int row, int column)
        {
            return panels.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }

        public static List<Tile> Range(this List<Tile> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels.Where(x => x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row <= endRow
                                     && x.Coordinates.Column <= endColumn).ToList();
        }
    }
}
