namespace KingSurvival.Models
{
    using Contracts;

    public class FigureEntry
    {
        private int horizontalDirection;
        private int verticalDirection;
        private Position position;
        private IFigure figure;

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
