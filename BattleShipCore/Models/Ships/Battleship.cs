using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships;

public class Battleship : BaseShip
{
   public Battleship() : base(BATTLESHIP_NAME, ShipSize.Battleship)
   {
   }
}