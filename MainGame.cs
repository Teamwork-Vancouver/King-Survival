namespace KingSurvival
{
    using Models;

    /// <summary>
    /// The starting point class of the KingSurvival game.
    /// </summary>
    public class KingSurvival
    {
        /// <summary>
        /// The main method of the project.
        /// </summary>
        private static void Main()
        {
            var board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            var renderer = new Renderer();
            var game = new Game(board, renderer);
            game.Run();
        }
    }
}