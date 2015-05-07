namespace KingSurvivalGame.Tests.Commands
{
    using System.Linq;
    using KingSurvival;
    using KingSurvival.Commands;
    using KingSurvival.Contracts;
    using KingSurvival.Enumerations;
    using KingSurvival.Exceptions;
    using KingSurvival.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class CommandParserTests
    {
        private Board board;
        private int turns;

        [TestInitialize]
        public void InitBoard()
        {
            this.board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            this.turns = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void TestParseMethodForRightExeptions()
        {
            string[] commandTexts = { "kor", "aor", "kum", "dam" };
            for (int i = 0; i < commandTexts.Length; i++)
            {
                var commandParser = new CommandParser(commandTexts[i], this.board, this.turns);
                commandParser.Parse();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void CommandParserShouldThrowExceptionWhenTheGivenWordToParseHasLenghtDifferentThanThree()
        {
            string command = "KingSurvival";
            CommandParser commandParser = new CommandParser(command, this.board, this.turns);
            commandParser.Parse();
        }

        [TestMethod]
        public void CommandParserShouldReturnFigureEntryWhenIsCalledWithValidCommand()
        {
            string command = "KUR";
            FigureEntry figureEntry;
            CommandParser commandParser = new CommandParser(command, this.board, this.turns);
            IFigure kingFigure = new King((char)FigureSymbols.King);
            Position kingPosition = new Position(3, 7, 7, 7);

            var expectedFigureEnrty = commandParser.Parse();

            figureEntry = new FigureEntry(1, -1, kingFigure, kingPosition);

            Assert.IsInstanceOfType(expectedFigureEnrty, typeof(FigureEntry));
        }

        [TestMethod]
        public void CommandParserShouldReturnFigureEntryWithSymbolEqualstToThePawnSymbolWhenIsCalledWithValidCommandOnEvenTurn()
        {
            this.turns = 2;
            string command = "ADL";
            this.board.Figures.ToArray()[1].Key.X = 3;
            this.board.Figures.ToArray()[1].Key.Y = 3;
            CommandParser commandParser = new CommandParser(command, this.board, this.turns);
            var expectedFigureEnrtySymbol = commandParser.Parse().Figure.Symbol;

            Assert.AreEqual((char)FigureSymbols.PawnA, expectedFigureEnrtySymbol);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void CommandParserShouldThrowExceptionWhenIsCalledWithInvalidCommand()
        {
            string command = "QOK";
            CommandParser commandParser = new CommandParser(command, this.board, this.turns);
            var expectedFigureEnrtySymbol = commandParser.Parse().Figure.Symbol;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void CommandParserShouldThrowExceptionWhenIsCalledWithInvalidHorizontalCommand()
        {
            string command = "KUZ";
            CommandParser commandParser = new CommandParser(command, this.board, this.turns);
            commandParser.Parse();
        }
    }
}
