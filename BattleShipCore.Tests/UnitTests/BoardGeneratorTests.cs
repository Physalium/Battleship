using BattleShipCore.Lib;
using BattleShipCore.Models.Ships;
using BattleShipCore.Services;

using System;
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
            var tilesCount = primaryBoard.Tiles.Count;
            var expectedTilesCount = Constants.BOARD_SIZE * Constants.BOARD_SIZE;

            Assert.Equal(expectedTilesCount, tilesCount);
        }

        [Fact]
        public void GeneratePrimaryBoard_Generates_ProperAmountOfOccupiedTiles()
        {
            var expectedOccupiedTilesCount = ships.Sum(s => s.Size.ToInt());
            var occupiedTiles = primaryBoard.Tiles.Count(t => t.Ship != null);

            Assert.Equal(expectedOccupiedTilesCount,occupiedTiles);
        }

        [Fact]
        public void GeneratePrimaryBoard_Generates_TilesWithUniqueCoordinates()
        {
            var coordinates = primaryBoard.Tiles.Select(t => t.Coordinates).ToList();
            var uniqueCoordinatesCount = coordinates.Distinct().Count();
            var coordinatesCount = coordinates.Count;

            Assert.Equal(uniqueCoordinatesCount, coordinatesCount);
        }
    }
}