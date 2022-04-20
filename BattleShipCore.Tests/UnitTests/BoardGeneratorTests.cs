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
        public Models.Board.TrackingBoard trackingBoard;
        public Models.Board.PrimaryBoard primaryBoard;
        public BoardGeneratorTests()
        {
            ships = ShipsGenerator.GenerateShips();

            trackingBoard = BoardGenerator.GenerateTrackingBoard();
            primaryBoard = BoardGenerator.GeneratePrimaryBoard(ships);
        }

        [Fact]
        public void GenerateTrackingBoard_Generates_ProperAmountOfTiles()
        {

            var tilesCount = trackingBoard.Tiles.Count;
            var expectedTilesCount = Constants.BOARD_SIZE * Constants.BOARD_SIZE;

            Assert.Equal(expectedTilesCount, tilesCount);
        }

        [Fact]
        public void GenerateTrackingBoard_Generates_UnoccupiedTiles()
        {
            Assert.All(trackingBoard.Tiles, tile => Assert.Null(tile.Ship));
        }

        [Fact]
        public void GenerateTrackingBoard_Generates_TilesWithUniqueCoordinates()
        {
            var coordinates = trackingBoard.Tiles.Select(t => t.Coordinates).ToList();
            var uniqueCoordinatesCount = coordinates.Distinct().Count();
            var coordinatesCount = coordinates.Count;

            Assert.Equal(uniqueCoordinatesCount, coordinatesCount);
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