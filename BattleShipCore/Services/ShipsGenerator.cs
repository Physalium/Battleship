using BattleShipCore.Models.Ships;

namespace BattleShipCore.Services
{
    public static class ShipsGenerator
    {
        public static List<BaseShip> GenerateShips()
        {
            return new List<BaseShip>()
            {
                new Battleship(),
                new Carrier(),
                new Destroyer(),
                new Submarine(),
                new PatrolBoat(),
            };
        }
    }
}