﻿using BattleShipCore.Validation;

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

            PositionValidator validator = new PositionValidator();
            validator.ValidateAndThrow(this);
        }

    }
}