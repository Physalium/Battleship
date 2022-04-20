using BattleShipCore.Lib;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore.Validation
{
    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(position => position.Row).InclusiveBetween(0,Constants.BOARD_SIZE - 1);
            RuleFor(position => position.Column).InclusiveBetween(0, Constants.BOARD_SIZE - 1);
        }
    }
}
