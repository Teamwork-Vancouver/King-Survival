namespace KingSurvival.Commands
{
    using Contracts;
    using Models;

    public class MoveDownCommand : MoveCommand
    {
        public const int VerticalDirection = 1;

        public MoveDownCommand(int horizontalDirection, IFigure fig, Board board, Position position)
            : base(horizontalDirection, fig, board, position)
        {
        }

        public override void ProcessCommand()
        {
            if (this.CommandObject.CanMoveDown && this.CommandObject.CanMoveDigonal)
            {
                ExecuteMoveCommand(VerticalDirection);
            }
        }
    }
}
