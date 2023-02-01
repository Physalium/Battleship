namespace BattleShipCore;

public static class Constants
{
   public enum ShipSize
   {
      Carrier = 5,
      Battleship = 4,
      Destroyer = 3,
      Submarine = Destroyer,
      PatrolBoat = 2
   }

   public enum ShotStatus
   {
      Miss,
      Hit
   }

   public const int BOARD_SIZE = 10;

   public const string BATTLESHIP_NAME = "Battleship";
   public const string CARRIER_NAME = "Carrier";
   public const string DESTROYER_NAME = "Destroyer";
   public const string PATROLBOAT_NAME = "Patrol boat";
   public const string SUBMARINE_NAME = "Submarine";
}