using KingSurvival.Exceptions;

namespace KingSurvival.Commands
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public abstract class MoveCommand
    {
        protected MoveCommand(int horizontalDirection, IFigure commandObject, Board board, Position position)
        {
            this.HorizontalDirection = horizontalDirection;
            this.CommandObject = commandObject;
            this.Board = board;
            this.Position = position;
        }

        public abstract void ProcessCommand();

        protected IFigure CommandObject { get; set; }

        private Board Board { get; set; }

        private Position Position { get; set; }

        private int HorizontalDirection { get; set; }

        protected void ExecuteMoveCommand(int verticalDirection)
        {
            Position positionToMove = new Position(this.Position.X + this.HorizontalDirection, this.Position.Y + verticalDirection, GameConstants.BoardWidth, GameConstants.BoardHeight);

            var occupied = Board.IsNextPositionAvailable(positionToMove.X, positionToMove.Y);

            if (occupied)
            {
                this.Board.Figures[positionToMove] = this.CommandObject;
                this.Board.Figures.Remove(new KeyValuePair<Position, IFigure>(this.Position, this.CommandObject));
            }
            else
            {
                throw new Exception(ExceptionMessages.UnavailablePosition);
            }
        }
    }
}
