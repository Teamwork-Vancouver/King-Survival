namespace KingSurvivalGame.Tests.Commands
{
    using System;
    using System.Linq;
    using KingSurvival;
    using KingSurvival.Commands;
    using KingSurvival.Exceptions;
    using KingSurvival.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MoveCommandTest
    {
        private Board board;
        private int turns;

        [TestInitialize]
        public void InitBoard()
        {
            this.board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            this.turns = 2;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void MoveUpCommandShouldThrowExceptionWhenTheSelectedObjectCannotMoveUp()
        {
            int pawnYposition = this.board.Figures.ToArray()[1].Key.Y = 3;
            string command = "AUR";
            CommandParser parser = new CommandParser(command, this.board, this.turns);
            FigureEntry figureEntry = parser.Parse();
            MoveCommand moveCommand =
                CommandFactory.Create(
                figureEntry.HorizontalDirection,
                figureEntry.VerticalDirection,
                figureEntry.Figure,
                figureEntry.Position,
                this.board);
            moveCommand.ProcessCommand();
        }

        [TestMethod]
        public void MoveUpCommandShouldProccessWhenIsCalledValid()
        {
            this.board.Figures.ToArray()[1].Key.Y = 3;
            string command = "ADR";
            CommandParser parser = new CommandParser(command, this.board, this.turns);
            FigureEntry figureEntry = parser.Parse();
            MoveCommand moveCommand =
                CommandFactory.Create(
                figureEntry.HorizontalDirection,
                figureEntry.VerticalDirection,
                figureEntry.Figure,
                figureEntry.Position,
                this.board);
            moveCommand.ProcessCommand();

            int expectedPawnYPositions = 4;
            
            Assert.AreEqual(expectedPawnYPositions, this.board.Figures.ToArray()[GameConstants.PawnSymbols.Length].Key.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MoveUpCommandShouldThrowExceptionWhenGoesOutOfBoundsInVerticalDirection()
        {
            string command = "KDR";
            this.turns = 1;
            CommandParser parser = new CommandParser(command, this.board, this.turns);
            FigureEntry figureEntry = parser.Parse();
            MoveCommand moveCommand =
                CommandFactory.Create(
                figureEntry.HorizontalDirection,
                figureEntry.VerticalDirection,
                figureEntry.Figure,
                figureEntry.Position,
                this.board);
            moveCommand.ProcessCommand();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void MoveUpCommandShouldThrowExceptionWhenNextPositionIsOccupied()
        {
            this.board.Figures.ToArray()[1].Key.Y = 6;
            this.board.Figures.ToArray()[1].Key.X = 2;

            string command = "ADR";
            CommandParser parser = new CommandParser(command, this.board, this.turns);
            FigureEntry figureEntry = parser.Parse();
            MoveCommand moveCommand =
                CommandFactory.Create(
                figureEntry.HorizontalDirection,
                figureEntry.VerticalDirection,
                figureEntry.Figure,
                figureEntry.Position,
                this.board);
            moveCommand.ProcessCommand();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MoveUpCommandShouldThrowExceptionWhenGoesOutOfBoundsInHorizontalDirection()
        {
            string command = "KUR";
            this.turns = 1;
            this.board.Figures.ToArray()[0].Key.X = 7;
            CommandParser parser = new CommandParser(command, this.board, this.turns);
            FigureEntry figureEntry = parser.Parse();
            MoveCommand moveCommand =
                CommandFactory.Create(
                figureEntry.HorizontalDirection,
                figureEntry.VerticalDirection,
                figureEntry.Figure,
                figureEntry.Position,
                this.board);
            moveCommand.ProcessCommand();
        }
    }
}
