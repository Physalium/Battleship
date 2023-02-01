using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships;

public class Submarine : BaseShip
{
   public Submarine() : base(SUBMARINE_NAME, ShipSize.Submarine)
   {
   }
}