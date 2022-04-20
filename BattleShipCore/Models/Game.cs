using BattleShipCore.Lib;
using BattleShipCore.Models.Board;
using BattleShipCore.Models.History;
using BattleShipCore.Services;

namespace BattleShipCore.Models
{
    public class Game
    {
        public GameHistory GameHistory;
        public Player Player1;
        public Player Player2;

        public Game(string firstPlayerName = "Player 1", string secondPlayerName = "Player 2")
        {
            Player1 = CreatePlayer(firstPlayerName);
            Player2 = CreatePlayer(secondPlayerName);

            GameHistory = new GameHistory() { Player1 = Player1, Player2 = Player2 };
        }

        public Player CreatePlayer(string name)
        {
            List<Ships.BaseShip> ships = ShipsGenerator.GenerateShips();
            Board.GameBoard board = BoardGenerator.GeneratePrimaryBoard(ships);
            return new Player(name, board, ships);
        }

        public void PlayRound()
        {
            FireOneShot(Player1, Player2);

            if (!Player2.HasLost)
            {
                FireOneShot(Player2, Player1);
            }

            void FireOneShot(Player firingPlayer, Player firedUponPlayer)
            {
                Lib.Position shotCoordinates = ShootingAI.Fire(firingPlayer, firedUponPlayer);
                string? sunkenShipName = null;
                Constants.ShotStatus shotStatus = firedUponPlayer.ProcessShotTaken(shotCoordinates, ref sunkenShipName);
                saveShotToHistory(shotCoordinates, shotStatus, sunkenShipName);
            }
        }

        private void saveShotToHistory(Position shotCoordinates, Constants.ShotStatus shotStatus, string sunkenShipName)
        {
            ShotHistory shotHistory = new ShotHistory() { HitPosition = shotCoordinates, WasHit = shotStatus == Constants.ShotStatus.Hit, SunkenShipName = sunkenShipName };
            GameHistory.Shots.Add(shotHistory);
        }

        public GameHistory PlayToEnd()
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }

            GameHistory.WinnerName = Player1.HasLost ? Player2.Name : Player1.Name;

            return GameHistory;
        }


    }
}
