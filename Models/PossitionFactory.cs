namespace KingSurvival.Models
{
    public class PossitionFactory
    {
        private int maxX;
        private int maxY;

        public PossitionFactory(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public Position Create(int x, int y)
        {
            return new Position(x, y, this.maxX, this.maxY);
        }
    }
}
