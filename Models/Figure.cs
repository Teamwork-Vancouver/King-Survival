namespace KingSurvival.Models
{
    using Contracts;

    public abstract class Figure : IMovable
    {
        protected Figure(int positionX, int positionY, char symbol)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Symbol = symbol;
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public char Symbol { get; set; }

        public void Move(int directionX, int directionY)
        {
            this.PositionX += directionX;
            this.PositionY += directionY;
        }
    }
}
