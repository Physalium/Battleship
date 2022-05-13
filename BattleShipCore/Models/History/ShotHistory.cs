using BattleShipCore.Lib;
using BattleShipCore.Models.Board;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore.Models.History
{
    public class ShotHistory
    {
        public Position HitPosition { get; set; }
        public bool WasHit { get; set; }

        public string? SunkenShipName { get; set; }
    }
}
