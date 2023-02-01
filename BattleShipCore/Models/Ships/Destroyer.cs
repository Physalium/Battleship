using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships;

public class Destroyer : BaseShip
{
   public Destroyer() : base(DESTROYER_NAME, ShipSize.Destroyer)
   {
   }
}