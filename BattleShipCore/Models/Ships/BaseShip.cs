using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships;

public abstract class BaseShip
{
   protected BaseShip(string name, ShipSize size)
   {
      Name = name;
      Size = size;

      HitsTaken = 0;
   }

   public string Name { get; set; }
   public ShipSize Size { get; set; }
   public int HitsTaken { get; set; }
   public bool IsSunk => HitsTaken >= (int)Size;
}