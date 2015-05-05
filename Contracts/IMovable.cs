namespace KingSurvival.Contracts
{
    public interface IMovable
    {
        void Move(int directionX, int directionY);

        int PositionX { get; set; }

        int PositionY { get; set; }
    }
}
