using BattleShipCore.Lib;
using BattleShipCore.Models;

namespace BattleShipCore.Services
{
    public static class ShootingAI
    {
        public static Position Fire(Player firingPlayer, Player firedUponPlayer)
        {
            // simulate basic AI by first trying to sink damaged enemy ships 
            Position? seekingShot = FireSeekingShot(firedUponPlayer);
            if (seekingShot != null)
            {
                return seekingShot;
            }

            // scan opponent board by firing in a checkboard pattern
            return FireScanningShot(firedUponPlayer);
        }

        private static Position? FireSeekingShot(Player firedUponPlayer)
        {
            // seeking shot scans all hit tiles, picks one of them and then check if any of it's neighbors are hit; if not - the method returns position of found neighbor
            var damagedShipTiles = firedUponPlayer.Board.Tiles.Where(t => t.IsHit && t.Ship != null && !t.Ship.IsSunk).ToList();
            foreach (Models.Board.Tile? tile in damagedShipTiles)
            {
                List<Models.Board.Tile>? fireCandidates = firedUponPlayer.Board.GetNotHitNeighbors(tile.Coordinates);
                if (fireCandidates.Count == 0)
                {
                    continue;
                }

                var rand = new Random(Guid.NewGuid().GetHashCode());
                int randomPositionIndex = rand.Next(fireCandidates.Count);
                return fireCandidates[randomPositionIndex].Coordinates;
            }

            return null;
        }

        private static Position FireScanningShot(Player firedUponPlayer)
        {
            var availablePositions = firedUponPlayer.Board.Tiles.Where(t => !t.IsHit && t.IsInCheckerboardPattern).Select(t => t.Coordinates).ToList();

            var rand = new Random(Guid.NewGuid().GetHashCode());
            int randomPositionIndex = rand.Next(availablePositions.Count);
            return availablePositions[randomPositionIndex];
        }
    }
}
