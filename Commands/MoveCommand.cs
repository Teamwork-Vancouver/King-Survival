namespace KingSurvival.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;
    using Models;

    /// <summary>
    /// The base abstract class for commands.
    /// </summary>
    public abstract class MoveCommand
    {
        /// <summary>
        /// The class constructor.s
        /// </summary>
        /// <param name="horizontalDirection">The direction on the X axis.</param>
        /// <param name="commandObject">The object of the action executed by the command.</param>
        /// <param name="board">The board on which the action will take place.</param>
        /// <param name="position">the next position on which the command object shall be moved.</param>
        protected MoveCommand(int horizontalDirection, IFigure commandObject, Board board, Position position)
        {
            this.HorizontalDirection = horizontalDirection;
            this.CommandObject = commandObject;
            this.Board = board;
            this.Position = position;
        }

        protected IFigure CommandObject { get; set; }

        private Board Board { get; set; }

        private Position Position { get; set; }

        private int HorizontalDirection { get; set; }

        public abstract void ProcessCommand();

        /// <summary>
        /// Executes a command depending on the vertical direction given.
        /// </summary>
        /// <param name="verticalDirection">(int) The vertical direction for a figure to move.</param>
        protected void ExecuteMoveCommand(int verticalDirection)
        {
            Position positionToMove = new Position(this.Position.X + this.HorizontalDirection, this.Position.Y + verticalDirection, GameConstants.BoardWidth, GameConstants.BoardHeight);

            var occupied = Board.IsPositionAvailableForMove(positionToMove.X, positionToMove.Y);

            if (occupied)
            {
                this.Board.Figures[positionToMove] = this.CommandObject;
                this.Board.Figures.Remove(new KeyValuePair<Position, IFigure>(this.Position, this.CommandObject));
            }
            else
            {
                throw new InvalidCommandException(ExceptionMessages.UnavailablePosition);
            }
        }
    }
}
