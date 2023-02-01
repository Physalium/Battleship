using BattleShipCore.Lib;
using FluentValidation;

namespace BattleShipCore.Validation;

public class PositionValidator : AbstractValidator<Position>
{
   public PositionValidator()
   {
      RuleFor(position => position.Row).InclusiveBetween(0, Constants.BOARD_SIZE - 1);
      RuleFor(position => position.Column).InclusiveBetween(0, Constants.BOARD_SIZE - 1);
   }
}