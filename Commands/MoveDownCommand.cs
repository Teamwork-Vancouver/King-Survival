namespace KingSurvival.Commands
{
    using Contracts;
    using Exceptions;
    using Models;

    /// <summary>
    /// The class for the the command that moves objects down on a board.
    /// </summary>
    public class MoveDownCommand : MoveCommand
    {
        public const int VerticalDirection = 1;

        /// <summary>
        /// The constructor of the move down command class.
        /// </summary>
        /// <param name="horizontalDirection">The horizontal direction the figure will take.</param>
        /// <param name="fig">The command object on which the command is executed.</param>
        /// <param name="board">The board on which things get moved.</param>
        /// <param name="position">The current position of the command object.</param>
        public MoveDownCommand(int horizontalDirection, IFigure fig, Board board, Position position)
            : base(horizontalDirection, fig, board, position)
        {
        }

        /// <summary>
        /// Processes(check if the current figure can move down) the command given and then passes vertical direction to ExecuteMoveCommand.
        /// </summary>
        public override void ProcessCommand()
        {
            if (this.CommandObject.CanMoveDown)
            {
                this.ExecuteMoveCommand(VerticalDirection);
            }
        }
    }
}
