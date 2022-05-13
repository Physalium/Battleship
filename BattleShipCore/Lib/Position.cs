using BattleShipCore.Validation;

using FluentValidation;

namespace BattleShipCore.Lib
{
    public class Position
    {
        public int Row { get; }

        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;

            var validator = new PositionValidator();
            validator.ValidateAndThrow(this);
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }
    }
}