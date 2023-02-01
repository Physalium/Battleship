using BattleShipCore.Lib;

namespace BattleShipCore.Models.History;

public class ShotHistory
{
   public ShotHistory(Position hitPosition, bool wasHit, string? sunkenShipName)
   {
      HitPosition = hitPosition;
      WasHit = wasHit;
      SunkenShipName = sunkenShipName;
   }

   public Position HitPosition { get; set; }
   public bool WasHit { get; set; }

   public string? SunkenShipName { get; set; }
}