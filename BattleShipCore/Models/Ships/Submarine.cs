
using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships
{
    public class Submarine : BaseShip
    {
        public Submarine() : base(BATTLESHIP_NAME, ShipSize.Submarine)
        {
        }
    }
}
