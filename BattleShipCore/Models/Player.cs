using BattleShipCore.Lib;
using BattleShipCore.Models.Board;
using BattleShipCore.Models.Ships;

using static BattleShipCore.Constants;

namespace BattleShipCore.Models
{
    public class Player
    {

        public string Name { get; set; }
        public GameBoard Board { get; set; }

        public List<BaseShip> Ships { get; set; }

        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }
        public Player()
        {

        }
        public Player(string name, Board.GameBoard primaryBoard,  List<BaseShip> ships)
        {
            Name = name;
            Board = primaryBoard;
            Ships = ships;
        }

        public ShotStatus ProcessShotTaken(Position shotPosition, ref string sunkenShipName)
        {
            Tile hitTile = Board.Tiles.At(shotPosition);
            hitTile.IsHit = true;
            if (hitTile.Ship == null)
            {
                return ShotStatus.Miss;
            }

            hitTile.Ship.HitsTaken++;
            if (hitTile.Ship.IsSunk)
            {
                sunkenShipName = hitTile.Ship.Name;
            }
            return ShotStatus.Hit;
        }
    }
}
