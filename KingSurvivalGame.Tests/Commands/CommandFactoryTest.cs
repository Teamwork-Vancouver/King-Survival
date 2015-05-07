namespace KingSurvivalGame.Tests.Commands
{
    using KingSurvival;
    using KingSurvival.Enumerations;
    using KingSurvival.Exceptions;
    using KingSurvival.Commands;
    using KingSurvival.Contracts;
    using KingSurvival.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandFactoryTest
    {
        private Board board;
        private Position position;
        private IFigure kingFigure;
        private int horizontalDirection;

        [TestInitialize]
        public void Initializer()
        {
            this.board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            this.position = new Position(5, 5, 7, 7);
            this.kingFigure = new King((char)FigureSymbols.King);
            this.horizontalDirection = 1;
        }

        [TestMethod]
        public void CommandFactoryShouldCreateNewMoveUpCommandWhenCalledWithVerticalPositionOfMinusOne()
        {
            int verticalDirection = -1;

            MoveCommand command = CommandFactory.Create(this.horizontalDirection, verticalDirection, this.kingFigure, this.position, this.board);
            
            Assert.IsTrue(command is MoveUpCommand, "The new command type is not MoveUpCommand");
        }

        [TestMethod]
        public void CommandFactoryShouldCreateNewMoveDownCommandWhenCalledWithVerticalPositionOfOne()
        {
            int verticalDirection = 1;

            MoveCommand command = CommandFactory.Create(this.horizontalDirection, verticalDirection, this.kingFigure, this.position, this.board);

            Assert.IsTrue(command is MoveDownCommand, "The new command type is not MoveDownCommand");
        }

        [TestMethod]
        [ExpectedException(typeof(CommandException))]
        public void CommandFactoryShouldThrowExceptionWhenCalledWithInvalidInteger()
        {
            int verticalDirection = 0;
            
            MoveCommand command = CommandFactory.Create(this.horizontalDirection, verticalDirection, this.kingFigure, this.position, this.board);
        }
    }
}
