using BattleShipCore.Models;
using BattleShipCore.Models.History;

using System.Linq;

using Xunit;

namespace BattleShipCore.Tests.FunctionalTests
{
    public class GameTests
    {
        public Game game;

        public GameTests()
        {
            game = new Game();
        }

        [Fact]
        public void Game_Initializes_PlayersBoards()
        {
            Assert.NotNull(game.Player1.Board);
            Assert.NotNull(game.Player2.Board);
        }

        [Fact]
        public void Game_ProperlyInitializes_PlayersShips()
        {
            int firstPlayerShipCount = game.Player1.Ships.Count;
            bool firstPlayerShipsAreOnFullHealth = game.Player1.Ships.All(s => s.HitsTaken == 0 && !s.IsSunk);
            int secondPlayerShipCount = game.Player2.Ships.Count;
            bool secondPlayerShipsAreOnFullHealth = game.Player2.Ships.All(s => s.HitsTaken == 0 && !s.IsSunk);

            Assert.Equal(5, firstPlayerShipCount);
            Assert.Equal(5, secondPlayerShipCount);
            Assert.True(firstPlayerShipsAreOnFullHealth);
            Assert.True(secondPlayerShipsAreOnFullHealth);
        }

        [Fact]
        public void Game_SavesShotsToHistory()
        {
            var newGame = new Game();

            newGame.PlayRound();
            newGame.PlayRound();

            Assert.True(newGame.GameHistory.Shots.Count == 4);
            Assert.True(newGame.GameHistory.Shots.All(s => s.HitPosition != null));
        }

        [Fact]
        public void Game_EndsWith_Winner()
        {
            var game = new Game();

            GameHistory history = game.PlayToEnd();
            Player? winner = game.Player1.Name == history.WinnerName ? game.Player1 : game.Player2;

            Assert.True(history.WinnerName != null);
            Assert.NotNull(winner);
        }

        [Fact]
        public void Game_EndsWith_AllLosingSideShipsSunken()
        {
            var game = new Game();

            GameHistory history = game.PlayToEnd();
            Player? loser = game.Player1.Name == history.WinnerName ? game.Player2 : game.Player1;

            Assert.True(loser.Ships.All(s => s.IsSunk));
        }
    }
}