using BattleShipCore.Lib;

namespace BattleShipCore.Models.History
{
    public class GameHistory
    {
        public GameHistory(Player player1, Player player2)
        {
            Player1 = player1.Clone();
            Player2 = player2.Clone();
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public List<ShotHistory> Shots { get; set; } = new List<ShotHistory>();

        public string WinnerName { get; set; }
    }
}