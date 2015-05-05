namespace KingSurvival.Models
{
    public class Pawn : Figure
    {
        public Pawn(char symbol)
            : base(symbol)
        {
        }

        public override bool CanMoveDigonal
        {
            get { return true; }
        }

        public override bool CanMoveDown
        {
            get { return true; }
        }

    }
}
