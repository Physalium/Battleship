using BattleShipAPI.Models;
using BattleShipCore.Models.History;

namespace BattleShipAPI.Services;

public interface IGameGenerationService
{
   GameHistory GenerateGameAndReturnHistory(GenerateGameRequest request);
}