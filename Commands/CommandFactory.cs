namespace KingSurvival.Commands
{
    using Contracts;
    using Exceptions;
    using Models;

    /// <summary>
    /// The class responsible for creating the correct type of command.
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Determines what type of command should be created and creates it.
        /// </summary>
        /// <param name="horizontalDirection">Direction of movement on the X axis.</param>
        /// <param name="verticalDirection">Direction of movement on the Y axis.</param>
        /// <param name="fig">Figure to move given the vertical and horizontal directions.</param>
        /// <param name="position">Current position of the figure.</param>
        /// <param name="board">The board on which all figures are placed.</param>
        /// <returns>MoveUp or Down Command</returns>
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
