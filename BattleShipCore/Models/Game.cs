using BattleShipCore.Lib;
using BattleShipCore.Models.History;
using BattleShipCore.Services;

namespace BattleShipCore.Models
{
    public class Game
    {
        public GameHistory GameHistory { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game(string firstPlayerName = "Player 1", string secondPlayerName = "Player 2")
        {
            Player1 = CreatePlayer(firstPlayerName);
            Player2 = CreatePlayer(secondPlayerName);

            GameHistory = new GameHistory(Player1, Player2);
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
                (Constants.ShotStatus shotStatus, string? sunkenShipName) = firedUponPlayer.ProcessShotTaken(shotCoordinates);
                saveShotToHistory(shotCoordinates, shotStatus, sunkenShipName);
            }
        }

        private void saveShotToHistory(Position shotCoordinates, Constants.ShotStatus shotStatus, string? sunkenShipName)
        {
            var shotHistory = new ShotHistory(shotCoordinates, shotStatus == Constants.ShotStatus.Hit, sunkenShipName);
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