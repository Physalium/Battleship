using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore.Models.History
{
    public class GameHistory
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public List<ShotHistory> Shots  { get; set; } = new List<ShotHistory>();
        
        public string WinnerName { get; set; }
    }
}
