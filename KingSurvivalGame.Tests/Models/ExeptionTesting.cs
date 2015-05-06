namespace KingSurvivalGame.Tests.Models
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.Exceptions;
    using KingSurvival.Models;
    using KingSurvival;
    using KingSurvival.Enumerations;
    using KingSurvival.Contracts;
    using KingSurvival.Commands;

    [TestClass]
    public class ExeptionTesting
    {
        public Board board;
        public IFigure figure;
        public Position position;
        public int horisontalDirection;
        [TestInitialize]
        public void InitFigures()
        {
            this.board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            var keyValuePair = board.Figures.FirstOrDefault(obj => obj.Value.Symbol == (char)FigureSymbols.PawnA);
            this.figure = keyValuePair.Value;
            this.position = keyValuePair.Key;
            this.horisontalDirection = 1;
        }
        [TestMethod]
        [ExpectedException(typeof(CommandException))]
        public void CheckIfCommandFactoryMoveCommandCreateTrowsCommandException()
        {
            int[] existingVerticalDirections = {-1,1};
            for (int i = Int32.MinValue + 1; i < Int32.MaxValue; i++)
            {
                if(i==existingVerticalDirections[0]&&i==existingVerticalDirections[1]){
                    continue;
                }
                else
                {
                    CommandFactory.Create(horisontalDirection,i,this.figure,this.position,this.board);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void CheckIfMoveUpCommandTrowsInvalidCommandExeption()
        {
            var pawn = this.figure;
            MoveUpCommand command = new MoveUpCommand(1, pawn, this.board, this.position);
            command.ProcessCommand();
        }
    }
}
