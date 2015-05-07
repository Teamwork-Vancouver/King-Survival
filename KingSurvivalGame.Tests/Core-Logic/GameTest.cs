namespace KingSurvivalGame.Tests.Core_Logic
{
    using KingSurvival;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameTest
    {
        private Game game;
        
        [TestInitialize]
        public void Initializer()
        {
            this.game = Game.Instance;
        }

        [TestMethod]
        public void GameRunMethodShouldReturnInstanceOfNewGameWhenIsCalled()
        {
            Game gameExpected = Game.Instance;

            Assert.AreEqual(this.game, gameExpected);
        }
    }
}
