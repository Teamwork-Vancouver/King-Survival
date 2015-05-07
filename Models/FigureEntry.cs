namespace KingSurvival.Models
{
    using Contracts;

    /// <summary>
    /// Class holding the results of parsing a valid command.
    /// </summary>
    public class FigureEntry
    {
        /// <summary>
        /// Constructor of the FigureEntry class.
        /// </summary>
        /// <param name="horizontalDirection">Horizontal direction movement index.</param>
        /// <param name="verticalDirection">Vertical direction movement index.</param>
        /// <param name="figure">Figure to be executed a command on.</param>
        /// <param name="position">The current positiong of the figure.</param>
        public FigureEntry(int horizontalDirection, int verticalDirection, IFigure figure, Position position)
        {
            this.HorizontalDirection = horizontalDirection;
            this.VerticalDirection = verticalDirection;
            this.Position = position;
            this.Figure = figure;
        }

        public int VerticalDirection { get; set; }

        public int HorizontalDirection { get; set; }

        public Position Position { get; set; }

        public IFigure Figure { get; set; }
    }
}
