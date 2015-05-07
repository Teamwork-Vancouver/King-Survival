namespace KingSurvival.Models
{
    using Contracts;

    /// <summary>
    /// Abstract class hoding the posible directions of movement of such.
    /// </summary>
    public abstract class Figure : IFigure
    {
        /// <summary>
        /// Abstract constructor method.
        /// </summary>
        /// <param name="symbol">The symbol illustrating the figure on the Board.</param>
        protected Figure(char symbol)
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
    }
}
