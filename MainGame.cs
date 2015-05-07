namespace KingSurvival
{
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
            var game = Game.Instance;
            game.Run();
        }
    }
}