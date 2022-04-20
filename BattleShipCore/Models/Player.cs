using BattleShipCore.Models.Board;
using BattleShipCore.Models.Ships;

namespace BattleShipCore.Models
{
    public class Player
    {

        public string Name { get; set; }
        public PrimaryBoard PrimaryBoard { get; set; }
        public TrackingBoard TrackingBoard { get; set; }

        public List<BaseShip> Ships { get; set; }

        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(string name, PrimaryBoard primaryBoard, TrackingBoard trackingBoard, List<BaseShip> ships)
        {
            Name = name;
            PrimaryBoard = primaryBoard;
            TrackingBoard = trackingBoard;
            Ships = ships;
        }
    }
}
