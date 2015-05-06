namespace KingSurvavalGame.Tests.Models
{
    using KingSurvival;
    using KingSurvival.Contracts;
    using KingSurvival.Enumerations;
    using KingSurvival.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        public Board board;
        public Dictionary<Position, IFigure> figures;

        [TestInitialize]
        public void InitFigures()
        {
            this.board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
        }

        [TestMethod]
        public void IncrementBoardDictionaryCountAfterAddingAnElementToIt()
        {
            Position position = new Position(1, 1, 7, 7);
            Figure figure = new King((char)FigureSymbols.King);
            this.board.Figures.Add(position, figure);

            Assert.AreEqual(6, this.board.Figures.Count, "The count shoud be 1 but it is not!");
        }

        [TestMethod]
        public void CheckIfIsPositionInBoundReturnsTheRightResult()
        {

            int minBoundsX = 0;
            int minBoundsY = 0;
            int maxBoundsX = 7;
            int maxBoundsY = 7;

            //var keys = this.board.Figures.Keys;
            for (int i = -10; i <= maxBoundsX * 2; i++)
            {
                for (int j = -10; j <= maxBoundsY * 2; j++)
                {
                    if (i < minBoundsX || j < minBoundsY || i > maxBoundsX || j > maxBoundsY)
                    {
                        Assert.AreEqual(false, this.board.IsPositionInBounds(i, j), "The method shoud return false on values " + i + "and " + j);
                    }
                    else
                    {
                        Assert.AreEqual(true, this.board.IsPositionInBounds(i, j), "The method shoud return true on values " + i + "and " + j);
                    }
                }
            }
        }

        [TestMethod]
        public void CheckIfPositionIsAvailableReturnsTheRightResults()
        {
            int maxBoundsX = 7;
            int maxBoundsY = 7;
            var keys = this.board.Figures.Keys;
            for (int i = 0; i <= maxBoundsX; i++)
            {
                for (int j = 0; j <= maxBoundsY; j++)
                {
                    if (keys.ToArray().FirstOrDefault(obj => obj.X == i && obj.Y == j) != null)
                    {
                        Assert.AreEqual(false, this.board.IsPositionAvailableForMove(i, j), "this method shoud have returned false on values " + i + "and " + j);
                    }
                    else
                    {
                        Assert.AreEqual(true, this.board.IsPositionAvailableForMove(i, j), "This method shoud have return true on values " + i + "and " + j);
                    }

                    //Assert.AreEqual(true, this.board.IsPositionInBounds(i, j), "The method shoud return true");
                }
            }
        }
    }
}
