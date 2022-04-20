
using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships
{
    public class Destroyer : BaseShip
    {
        public Destroyer() : base(BATTLESHIP_NAME, ShipSize.Battleship)
        {
        }
    }
}
