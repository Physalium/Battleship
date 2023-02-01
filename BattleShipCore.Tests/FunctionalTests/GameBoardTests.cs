using System.Collections.Generic;
using BattleShipCore.Lib;
using BattleShipCore.Models;
using BattleShipCore.Models.Board;
using Xunit;

namespace BattleShipCore.Tests.FunctionalTests;

public class GameBoardTests
{
   public GameBoard board;

   public GameBoardTests()
   {
      var game = new Game();
      board = game.Player1.Board;
   }

   [Theory]
   [InlineData(0, 1, 3)]
   [InlineData(0, 0, 2)]
   [InlineData(1, 0, 3)]
   [InlineData(5, 5, 4)]
   [InlineData(9, 9, 2)]
   [InlineData(9, 8, 3)]
   public void GetNeighbors_Returns_CorrectAmountOfTiles(int row, int column, int expectedCount)
   {
      List<Tile> neighbors = board.GetNeighbors(new Position(row, column));
      Assert.Equal(expectedCount, neighbors.Count);
   }
}