using System.Collections.Generic;
using System.Linq;
using BattleShipCore.Lib;
using BattleShipCore.Models.Board;
using BattleShipCore.Models.Ships;
using BattleShipCore.Services;
using Xunit;

namespace BattleShipCore.Tests.UnitTests;

public class BoardGeneratorTests
{
   public GameBoard primaryBoard;
   public List<BaseShip> ships;

   public BoardGeneratorTests()
   {
      ships = ShipsGenerator.GenerateShips();

      primaryBoard = BoardGenerator.GeneratePrimaryBoard(ships);
   }

   [Fact]
   public void GeneratePrimaryBoard_Generates_ProperAmountOfTiles()
   {
      int tilesCount = primaryBoard.Tiles.Count;
      int expectedTilesCount = Constants.BOARD_SIZE * Constants.BOARD_SIZE;

      Assert.Equal(expectedTilesCount, tilesCount);
   }

   [Fact]
   public void GeneratePrimaryBoard_Generates_ProperAmountOfOccupiedTiles()
   {
      int expectedOccupiedTilesCount = ships.Sum(s => s.Size.ToInt());
      int occupiedTiles = primaryBoard.Tiles.Count(t => t.Ship != null);

      Assert.Equal(expectedOccupiedTilesCount, occupiedTiles);
   }

   [Fact]
   public void GeneratePrimaryBoard_Generates_TilesWithUniqueCoordinates()
   {
      List<Position> coordinates = primaryBoard.Tiles.Select(t => t.Coordinates).ToList();
      int uniqueCoordinatesCount = coordinates.Distinct().Count();
      int coordinatesCount = coordinates.Count;

      Assert.Equal(uniqueCoordinatesCount, coordinatesCount);
   }
}