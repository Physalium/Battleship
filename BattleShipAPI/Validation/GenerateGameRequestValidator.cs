using BattleShipAPI.Models;
using FluentValidation;

namespace BattleShipAPI.Validation;

public class GenerateGameRequestValidator : AbstractValidator<GenerateGameRequest>
{
   public GenerateGameRequestValidator()
   {
      RuleFor(r => r.firstPlayerName).MaximumLength(30);
      RuleFor(r => r.secondPlayerName).MaximumLength(30);
   }
}