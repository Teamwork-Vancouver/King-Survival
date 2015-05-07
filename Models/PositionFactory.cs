namespace KingSurvival.Models
{
    /// <summary>
    /// Factory class for creating instances of Position class.
    /// </summary>
    public class PositionFactory
    {
        private int maxX;
        private int maxY;

        /// <summary>
        /// The constructor class for the PositionFactory class.
        /// </summary>
        /// <param name="maxX">The maximal X coordinate for creating a Position.</param>
        /// <param name="maxY">The maximal Y coordinate for creating a Position.</param>
        public PositionFactory(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }

        /// <summary>
        /// Method creates a Position object with X and Y coordinates.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        /// <returns>Position object</returns>
        public Position Create(int x, int y)
        {
            return new Position(x, y, this.maxX, this.maxY);
        }
    }
}
