
using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships
{

    public class Carrier : BaseShip
    {
        public Carrier() : base(BATTLESHIP_NAME, ShipSize.Battleship)
        {
        }
    }
}
