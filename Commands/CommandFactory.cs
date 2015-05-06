using KingSurvival.Exceptions;

namespace KingSurvival.Commands
{
    using System;
    using Contracts;
    using Models;

    public static class CommandFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="horizontalDirection">Direction on the X axis</param>
        /// <param name="verticalDirection">Direction on the Y axis</param>
        /// <param name="fig">Figure to move given the vertical and horizontal directions</param>
        /// <param name="position">Current position of the figure</param>
        /// <param name="board">The board on which all figures are placed</param>
        /// <returns></returns>
        public static MoveCommand Create(int horizontalDirection, int verticalDirection, IFigure fig, Position position, Board board)
        {
            switch (verticalDirection)
            {
                case MoveUpCommand.VerticalDirection:
                    return new MoveUpCommand(horizontalDirection, fig, board, position);
                case MoveDownCommand.VerticalDirection:
                    return new MoveDownCommand(horizontalDirection, fig, board, position);
                default:
                    throw new CommandException(ExceptionMessages.InvalidFactoryCommand);
            }
        }
    }
}
