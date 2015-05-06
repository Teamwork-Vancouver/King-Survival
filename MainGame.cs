namespace KingSurvival
{
    using Models;

    public class KingSurvival
    {
        private static void Main()
        {
            var game = Game.Instance;
            game.Run();
        }
    }
}