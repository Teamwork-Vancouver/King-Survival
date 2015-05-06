using System;
using System.IO;
using KingSurvival;
using KingSurvival.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvivalGame.Tests.Models
{
    [TestClass]
    public class RendererTest
    {
        [TestMethod]
        public void RendererShouldReturnBoartWithFixedWidthAndHeightToSeven()
        {
            var output = "UL  0 1 2 3 4 5 6 7  UR\n" +
                         "   _________________\r\n" +
                         "0 | A - B - C - D - | 0\n" +
                         "1 | - + - + - + - + | 1\n" +
                         "2 | + - + - + - + - | 2\n" +
                         "3 | - + - + - + - + | 3\n" +
                         "4 | + - + - + - + - | 4\n" +
                         "5 | - + - + - + - + | 5\n" +
                         "6 | + - + - + - + - | 6\n" +
                         "7 | - + - K - + - + | 7\n" +
                         "  |_________________|  \n" +
                         "DL  0 1 2 3 4 5 6 7  DR\n" +
                         "  \r\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
                var renderer = new Renderer();
                renderer.Render(board);

                var expected =
                    string.Format(output, Environment.NewLine);

                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}