namespace KingSurvivalGame.Tests.Models
{
    using KingSurvival.Commands;
    using KingSurvival;
    using KingSurvival.Models;
    using KingSurvival.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandParserTests
    {
        public Board board;

        [TestInitialize]
        public void InitFigures()
        {
            this.board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void TestParseMethodForRightExeptions()
        {
            string[] commandTexts = { "kor", "aor", "kum", "dam" };
            var turns = 0;
            for (int i = 0; i < commandTexts.Length; i++)
            {
                var commandParser = new CommandParser(commandTexts[i], board, turns);
                commandParser.Parse();
            }
        }
    }
}
