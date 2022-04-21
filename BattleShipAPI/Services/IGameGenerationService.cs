using BattleShipAPI.Models;

using BattleShipCore.Models.History;

namespace BattleShipAPI.Services;

public interface IGameGenerationService
{
    Task<GameHistory> GenerateGameAndReturnHistory(GenerateGameRequest request);
}