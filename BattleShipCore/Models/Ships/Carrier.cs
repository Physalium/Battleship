using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships;

public class Carrier : BaseShip
{
   public Carrier() : base(CARRIER_NAME, ShipSize.Carrier)
   {
   }
}