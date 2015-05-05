namespace KingSurvival.Commands
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        protected int HorizontalDirection { get; set; }

        protected IFigure CommandObject { get; set; }

        protected Board Board { get; set; }

        public Position Position { get; set; }

        public abstract void ProcessCommand();

        protected void ExecuteMoveCommand(int verticalDirection)
        {
            Position positionToMove = new Position(this.Position.X + this.HorizontalDirection, this.Position.Y + verticalDirection, GameConstants.BoardWidth, GameConstants.BoardHeight);

            bool occupied = Board.Figures.FirstOrDefault(x => x.Key.X == positionToMove.X && x.Key.Y == positionToMove.Y).Value != null;

            if (!occupied)
            {
                this.Board.Figures[positionToMove] = this.CommandObject;
                this.Board.Figures.Remove(new KeyValuePair<Position, IFigure>(this.Position, this.CommandObject));
            }
            else
            {
                throw new Exception("Occupied Position to move.");
            }
        }

    }
}
