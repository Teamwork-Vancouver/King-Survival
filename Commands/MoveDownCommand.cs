namespace KingSurvival.Commands
{
    using Contracts;
    using Exceptions;
    using Models;

    public class MoveDownCommand : MoveCommand
    {
        public const int VerticalDirection = 1;

        public MoveDownCommand(int horizontalDirection, IFigure fig, Board board, Position position)
            : base(horizontalDirection, fig, board, position)
        {
        }
        /// <summary>
        /// Processes(check if the current figure can move down) the command given and then passes vertical direction to ExecuteMoveCommand
        /// </summary>
        public override void ProcessCommand()
        {
            if (this.CommandObject.CanMoveDown)
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
