using BattleShipAPI.Models;

using BattleShipCore.Models;
using BattleShipCore.Models.History;

namespace BattleShipAPI.Services;

public class GameGenerationService : IGameGenerationService
{
    public GameGenerationService()
    {
    }

    public async Task<GameHistory> GenerateGameAndReturnHistory(GenerateGameRequest request)
    {
        var game = new Game(request.firstPlayerName, request.secondPlayerName);

        game.PlayToEnd();

        return game.GameHistory;
    }

}
