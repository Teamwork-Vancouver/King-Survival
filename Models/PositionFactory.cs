namespace KingSurvival.Models
{
    public class PositionFactory
    {
        private int maxX;
        private int maxY;

        public PositionFactory(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }

        /// <summary>
        /// Creates a position object via x and y
        /// </summary>
        /// <param name="x">position on the X axis </param>
        /// <param name="y">position on the Y axis</param>
        /// <returns>Position object</returns>
        public Position Create(int x, int y)
        {
            return new Position(x, y, this.maxX, this.maxY);
        }
    }
}
