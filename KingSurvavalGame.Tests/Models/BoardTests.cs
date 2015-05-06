namespace KingSurvavalGame.Tests.Models
{
    using System.Collections.Generic;
    using KingSurvival.Contracts;
    using KingSurvival.Enumerations;
    using KingSurvival.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        public Dictionary<Position, IFigure> Figures;

        [TestInitialize]
        public void InitFigures()
        {
           this.Figures = new Dictionary<Position, IFigure>();
        }

        [TestMethod]
        public void IncrementBoardDictionaryCountAfterAddingAnElementToIt()
        {
             Position position = new Position(1,1,7,7);
             Figure figure = new King((char)FigureSymbols.King);
             this.Figures.Add(position, figure);

             Assert.AreEqual(1,this.Figures.Count,"The count shoud be 1 but it is not!");
        }
    }
}
