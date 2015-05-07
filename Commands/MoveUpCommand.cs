namespace KingSurvival.Commands
{
    using Contracts;
    using Exceptions;
    using Models;

    /// <summary>
    /// The constructor of the move up command class.
    /// </summary>
    public class MoveUpCommand : MoveCommand
    {
        public const int VerticalDirection = -1;

        /// <summary>
        /// The constructor of the move up command class.
        /// </summary>
        /// <param name="horizontalDirection">The horizontal direction the figure will take.</param>
        /// <param name="fig">The command object on which the command is executed.</param>
        /// <param name="board">The board on which things get moved.</param>
        /// <param name="position">The current position of the command object.</param>
        public MoveUpCommand(int horizontalDirection, IFigure fig, Board board, Position position)
            : base(horizontalDirection, fig, board, position)
        {
        }

        /// <summary>
        /// Processes(check if the current figure can move up) the command given and then passes vertical direction to ExecuteMoveCommand
        /// </summary>
        public override void ProcessCommand()
        {
            if (this.CommandObject.CanMoveUp)
            {
                this.ExecuteMoveCommand(VerticalDirection);
            }
            else
            {
                throw new InvalidCommandException(ExceptionMessages.InvalidUpMove);
            }
        }
    }
}
