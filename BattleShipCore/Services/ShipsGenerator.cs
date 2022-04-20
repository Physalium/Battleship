using BattleShipCore.Models.Ships;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
