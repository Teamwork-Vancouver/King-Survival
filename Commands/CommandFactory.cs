namespace KingSurvival.Commands
{
    using System;
    using Contracts;
    using Models;

    public static class CommandFactory
    {
        public static MoveCommand Create(int horizontalDirection, int verticalDirection, IFigure fig, Board board, Position position)
        {
            switch (verticalDirection)
            {
                case MoveUpCommand.VerticalDirection:
                    return new MoveUpCommand(horizontalDirection, fig, board, position);
                case MoveDownCommand.VerticalDirection:
                    return new MoveDownCommand(horizontalDirection, fig, board, position);
                default:
                    throw new Exception();
            }
        }
    }
}
