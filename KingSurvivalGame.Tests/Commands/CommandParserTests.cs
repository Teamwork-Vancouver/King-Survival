namespace KingSurvivalGame.Tests.Commands
{
    using KingSurvival.Commands;
    using KingSurvival;
    using KingSurvival.Models;
    using KingSurvival.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandParserTests
    {
        private Board board;
        private int turns;

        [TestInitialize]
        public void InitFigures()
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
                var commandParser = new CommandParser(commandTexts[i], board, this.turns);
                commandParser.Parse();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void CommandParserShouldThrowExceptionWhenTheGiverWordToParseHasLenghtDifferentOfThree()
        {
            string command = "HAHAHa";
            CommandParser commandParser = new CommandParser(command, this.board, this.turns);
            commandParser.Parse();
        }

    }
}
