using BattleShipCore.Lib;
using BattleShipCore.Models.Board;
using BattleShipCore.Models.Ships;
using static BattleShipCore.Constants;

namespace BattleShipCore.Models;

public class Player
{
   private Player()
   {
   }

   public Player(string name, GameBoard primaryBoard, List<BaseShip> ships)
   {
      Name = name;
      Board = primaryBoard;
      Ships = ships;
   }

   public string Name { get; set; }
   public GameBoard Board { get; set; }

   public List<BaseShip> Ships { get; set; }

   public bool HasLost
   {
      get { return Ships.All(x => x.IsSunk); }
   }

   public (ShotStatus status, string? sunkenShipName) ProcessShotTaken(Position shotPosition)
   {
      Tile hitTile = Board.Tiles.At(shotPosition);
      hitTile.IsHit = true;
      if (hitTile.Ship == null) return (ShotStatus.Miss, null);

      hitTile.Ship.HitsTaken++;
      if (hitTile.Ship.IsSunk) return (ShotStatus.Hit, hitTile.Ship.Name);
      return (ShotStatus.Hit, null);
   }
}