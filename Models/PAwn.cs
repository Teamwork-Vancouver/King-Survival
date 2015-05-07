namespace KingSurvival.Models
{
    /// <summary>
    /// Class inheriting the Figure class.
    /// </summary>
    public class Pawn : Figure
    {
        /// <summary>
        /// Constructor for the Pawn class.
        /// </summary>
        /// <param name="symbol">Symbol of type char for representing the Pawn position on the board.</param>
        public Pawn(char symbol)
            : base(symbol)
        {
        }

        public override bool CanMoveDown
        {
            get { return true; }
        }
    }
}
