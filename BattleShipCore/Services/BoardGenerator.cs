﻿using BattleShipCore.Lib;
using BattleShipCore.Models.Board;
using BattleShipCore.Models.Ships;

namespace BattleShipCore.Services;

public static class BoardGenerator
{
   public static GameBoard GeneratePrimaryBoard(List<BaseShip> ships)
   {
      List<Tile> tiles = GenerateListOfEmptyTiles();
      var board = new GameBoard(tiles);

      foreach (BaseShip ship in ships)
      {
         PlaceShipRandomly(board, ship);
      }

      return board;
   }

   private static List<Tile> GenerateListOfEmptyTiles()
   {
      var tiles = new List<Tile>();

      for (var column = 0; column < Constants.BOARD_SIZE; column++)
      for (var row = 0; row < Constants.BOARD_SIZE; row++)
      {
         var position = new Position(row, column);
         var tile = new Tile(position);
         tiles.Add(tile);
      }

      return tiles.OrderBy(t => t.Coordinates.Row * 10 + t.Coordinates.Column).ToList();
   }

   private static void PlaceShipRandomly(GameBoard board, BaseShip ship)
   {
      var canBePlaced = false;
      while (!canBePlaced)
      {
         (int startColumn, int startRow, int endColumn, int endRow) = GetRandomCoordinates(ship);

         List<Tile> choosenTiles = board.Tiles.Range(startRow, startColumn, endRow, endColumn);
         if (choosenTiles.Any(t => t.Ship != null || board.GetNeighbors(t.Coordinates).Any(n => n.Ship != null)))
         {
            canBePlaced = false;
            continue;
         }

         foreach (Tile tile in choosenTiles)
         {
            tile.Ship = ship;
            canBePlaced = true;
         }
      }
   }

   /// <summary>
   ///    Get random coordinates for ship placement, by randomly choosing ship orientation and then it's starting column and row
   /// </summary>
   private static (int startColumn, int startRow, int endColumn, int endRow) GetRandomCoordinates(BaseShip ship)
   {
      var rand = new Random(Guid.NewGuid().GetHashCode());

      bool vertical = rand.Next(0, 2) == 1;
      int startColumn = rand.Next(0, vertical ? Constants.BOARD_SIZE : Constants.BOARD_SIZE - ship.Size.ToInt());
      int startRow = rand.Next(0, vertical ? Constants.BOARD_SIZE - ship.Size.ToInt() : Constants.BOARD_SIZE);
      int endColumn = vertical ? startColumn : startColumn + ship.Size.ToInt() - 1;
      int endRow = vertical ? startRow + ship.Size.ToInt() - 1 : startRow;

      return (startColumn, startRow, endColumn, endRow);
   }
}