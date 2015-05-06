namespace KingSurvival.Models
{
    public class King : Figure
    {
        public King(char symbol)
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

        public override bool CanMoveUp
        {
            get { return true; }
        }
    }
}
