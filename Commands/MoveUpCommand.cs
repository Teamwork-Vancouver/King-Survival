using System;

namespace KingSurvival.Commands
{
    using Contracts;
    using Models;

    public class MoveUpCommand : MoveCommand
    {
        public const int VerticalDirection = -1;

        public MoveUpCommand(int horizontalDirection, IFigure fig, Board board, Position position)
            : base(horizontalDirection, fig, board, position)
        {
        }

        public override void ProcessCommand()
        {
            if (this.CommandObject.CanMoveUp && this.CommandObject.CanMoveDigonal)
            {
                ExecuteMoveCommand(VerticalDirection);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
