namespace BattleShipAPI.Models
{
    public record GenerateGameRequest(string? firstPlayerName = null, string? secondPlayerName = null)
    {
    }
}
