namespace KingSurvival
{
    using Models;

    public class KingSurvival
    {
        private static void Main()
        {
            var board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            var renderer = new Renderer();
            var game = new Game(board, renderer);
            game.Run();
        }
    }
}