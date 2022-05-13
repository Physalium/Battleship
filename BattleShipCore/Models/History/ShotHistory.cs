using BattleShipCore.Lib;

namespace BattleShipCore.Models.History
{
    public class ShotHistory
    {
        public Position HitPosition { get; set; }
        public bool WasHit { get; set; }

        public string? SunkenShipName { get; set; }
    }
}