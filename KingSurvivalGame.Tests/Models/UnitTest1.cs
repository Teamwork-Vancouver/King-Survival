namespace KingSurvavalGame.Tests.Models
{
    using System.Collections.Generic;
    using KingSurvival.Contracts;
    using KingSurvival.Enumerations;
    using KingSurvival.Models;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

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
            int maxBoundsX = 7;
            int maxBoundsY = 7;
            //var keys = this.board.Figures.Keys;
            for (int i = 0; i <= maxBoundsX; i++)
            {
                for (int j = 0; j <= maxBoundsY; j++)
                {
                    Assert.AreEqual(true, this.board.IsPositionInBounds(i, j), "The method shoud return true");
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
                        Assert.AreEqual(false, this.board.IsPositionAvailable(i, j), "this method shoud have returned false");
                    }
                    else
                    {
                        Assert.AreEqual(true, this.board.IsPositionAvailable(i, j), "This method shoud have return true");
                    }
                    //Assert.AreEqual(true, this.board.IsPositionInBounds(i, j), "The method shoud return true");
                }
            }
        }
    }
}


