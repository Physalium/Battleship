
using static BattleShipCore.Constants;

namespace BattleShipCore.Models.Ships
{
    public class PatrolBoat : BaseShip
    {
        public PatrolBoat() : base(PATROLBOAT_NAME, ShipSize.PatrolBoat)
        {
        }
    }
}
