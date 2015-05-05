namespace KingSurvival.Models
{
    using Contracts;

    public abstract class Figure : IFigure
    {
        protected Figure( char symbol)
        {
            this.Symbol = symbol;
        }

        public char Symbol { get; set; }

        public virtual bool CanMoveUp
        {
            get { return false; }
        }

        public virtual bool CanMoveDown
        {
            get { return false; }
        }

        public virtual bool CanMoveLeft
        {
            get { return false; }
        }

        public virtual bool CanMoveRight
        {
            get { return false; }
        }

        public virtual bool CanMoveDigonal
        {
            get { return false; }
        }
    }
}
