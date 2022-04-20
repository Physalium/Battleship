using BattleShipCore.Lib;
using BattleShipCore.Models;

namespace BattleShipCore.Services
{
    public static class ShootingAI
    {
        public static Position Fire(Player firingPlayer, Player firedUponPlayer)
        {
            // simulate basic AI by first trying to sink damaged enemy ships 
            var damagedShipTile = firedUponPlayer.Board.Tiles.FirstOrDefault(t => t.IsHit && t.Ship != null && !t.Ship.IsSunk);
            if (damagedShipTile != null)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                //var shotPosition = damagedShipTile.Coordinates.
            }

            // scan opponent board by firing in a checkboard pattern
            return FireScanningShot(firedUponPlayer);
        }

        private static Position FireScanningShot(Player firedUponPlayer)
        {
            List<Position> availablePositions = firedUponPlayer.Board.Tiles.Where(t => !t.IsHit && t.IsInCheckerboardPattern).Select(t => t.Coordinates).ToList();

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randomPositionIndex = rand.Next(availablePositions.Count);
            return availablePositions[randomPositionIndex];
        }
    }
}
