using BattleShipCore.Lib;
using BattleShipCore.Models.Ships;
using BattleShipCore.Services;

using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace BattleShipCore.Tests.UnitTests
{
    public class BoardGeneratorTests
    {
        public List<BaseShip> ships;
        public Models.Board.GameBoard primaryBoard;

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
            var coordinates = primaryBoard.Tiles.Select(t => t.Coordinates).ToList();
            int uniqueCoordinatesCount = coordinates.Distinct().Count();
            int coordinatesCount = coordinates.Count;

            Assert.Equal(uniqueCoordinatesCount, coordinatesCount);
        }
    }
}