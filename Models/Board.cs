namespace KingSurvival.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enumerations;

    /// <summary>
    /// The class holding all the figures and all their coordinates.
    /// </summary>
    public class Board
    {
        private PositionFactory positionFactory;

        /// <summary>
        /// Constructor method for the Board class.
        /// </summary>
        /// <param name="boardWidth">The number of columns per row of the board.</param>
        /// <param name="boardHeight">The number of rows per column of the board.</param>
        public Board(int boardWidth, int boardHeight)
        {
            this.Figures = new Dictionary<Position, IFigure>();
            this.positionFactory = new PositionFactory(boardWidth, boardHeight);
            this.AddFigure(GameConstants.KingStartPositionX, GameConstants.KingStartPositionY, new King((char)FigureSymbols.King));
            this.AddFigure(GameConstants.PawnAStartPositionX, GameConstants.PawnsStartPositionY, new Pawn((char)FigureSymbols.PawnA));
            this.AddFigure(GameConstants.PawnBStartPositionX, GameConstants.PawnsStartPositionY, new Pawn((char)FigureSymbols.PawnB));
            this.AddFigure(GameConstants.PawnCStartPositionX, GameConstants.PawnsStartPositionY, new Pawn((char)FigureSymbols.PawnC));
            this.AddFigure(GameConstants.PawnDStartPositionX, GameConstants.PawnsStartPositionY, new Pawn((char)FigureSymbols.PawnD));
        }

        public IDictionary<Position, IFigure> Figures { get; set; }

        /// <summary>
        /// Perfoms a check on the desired position and determins whether it is occupied, inside ot outside the field.
        /// </summary>
        /// <param name="nextPositionX">X coordinates of the moving figure.</param>
        /// <param name="nextPositionY">Y coordinates of the moving figure.</param>
        /// <returns>A boolean values showing if the move is valid.</returns>
        public bool IsPositionAvailableForMove(int nextPositionX, int nextPositionY)
        {
            bool occupied =
                this.Figures.FirstOrDefault(x => x.Key.X == nextPositionX && x.Key.Y == nextPositionY).Value == null;
    
            return occupied && this.IsPositionInBounds(nextPositionX, nextPositionY);
        }

        /// <summary>
        /// Determins whether the position specified is inside or outside the field.
        /// </summary>
        /// <param name="nextPositionX">X coordinates of the moving figure.</param>
        /// <param name="nextPositionY">Y coordinates of the moving figure.</param>
        /// <returns>true if the nex place you want to move is in bounds of the field</returns>
        public bool IsPositionInBounds(int nextPositionX, int nextPositionY)
        {
            bool insideX = nextPositionX <= GameConstants.BoardWidth && nextPositionX >= 0;
            bool insideY = nextPositionY <= GameConstants.BoardHeight && nextPositionY >= 0;

            return insideX && insideY;
        }

        /// <summary>
        /// A Figure with its coordinates is being added to the board by this method upon execution.
        /// </summary>
        /// <param name="x">Figure coordinate X.</param>
        /// <param name="y">Figure coordinate Y.</param>
        /// <param name="fig">the figure you want to insert in the dictionary</param>
        private void AddFigure(int x, int y, IFigure fig)
        {
            this.Figures.Add(this.positionFactory.Create(x, y), fig);
        }
    }
}
