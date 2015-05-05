namespace KingSurvival.Contracts
{
    public interface IFigure
    {
        char Symbol { get; set; }
        bool CanMoveUp { get; }
        bool CanMoveDown { get; }
        bool CanMoveLeft { get; }
        bool CanMoveRight { get; }
        bool CanMoveDigonal { get; }
    }
}
