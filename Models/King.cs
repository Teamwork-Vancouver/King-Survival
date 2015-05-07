namespace KingSurvival.Models
{
    /// <summary>
    /// Class inheriting the Figure class.
    /// </summary>
    public class King : Figure
    {
        /// <summary>
        /// Constructor for the King class.
        /// </summary>
        /// <param name="symbol">Symbol of type char for representing the King position on the board.</param>
        public King(char symbol)
            : base(symbol)
        {
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
