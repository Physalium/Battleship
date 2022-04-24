﻿
using BattleShipCore.Models.Board;

using Newtonsoft.Json;

using System.Text.Json;

using static BattleShipCore.Constants;

namespace BattleShipCore.Lib
{
    public static class ExtensionMethods
    {
        public static int ToInt(this ShipSize size)
        {
            return (int)size;
        }

        public static Tile At(this List<Tile> panels, Position position)
        {
            return panels.Where(x => x.Coordinates.Row == position.Row && x.Coordinates.Column == position.Column).First();
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

        public static T Clone<T>(this T source)
        {
            var serializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            };
            var serialized = JsonConvert.SerializeObject(source, serializerSettings);
            return JsonConvert.DeserializeObject<T>(serialized, serializerSettings);
        }
    }
}
