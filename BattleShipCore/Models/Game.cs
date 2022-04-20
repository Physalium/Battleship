using BattleShipCore.Models.Board;
using BattleShipCore.Services;

namespace BattleShipCore.Models
{
    public class Game
    {

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game()
        {
            Player1 = CreatePlayer("Player 1");
            Player2 = CreatePlayer("Player 2");
        }

        public Player CreatePlayer(string name)
        {
            TrackingBoard trackingBoard = BoardGenerator.GenerateTrackingBoard();
            List<Ships.BaseShip> ships = ShipsGenerator.GenerateShips();
            PrimaryBoard primaryBoard = BoardGenerator.GeneratePrimaryBoard(ships);
            Player player = new Player(name, primaryBoard, trackingBoard, ships);

            return player;
        }
    }
}
