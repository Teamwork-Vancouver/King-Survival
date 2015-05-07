namespace KingSurvival.Contracts
{
    /// <summary>
    /// Interface defining a figure characteristics.
    /// </summary>
    public interface IFigure
    {
        char Symbol { get; set; }

        bool CanMoveUp { get; }
        
        bool CanMoveDown { get; }
        
        bool CanMoveLeft { get; }
        
        bool CanMoveRight { get; }
    }
}
