namespace KingSurvival.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enumerations;

    public class Board
    {
        private PositionFactory positionFactory;

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
        /// Finds if the possition you want to move is occupied or in bounds of the field
        /// </summary>
        /// <param name="nextPositionX">the X coordinates the player wants to move</param>
        /// <param name="nextPositionY">the Y coordinates the player wants to move</param>
        /// <returns>Boollean if you can move there</returns>
        public bool IsPositionAvailableForMove(int nextPositionX, int nextPositionY)
        {
            bool occupied =
                this.Figures.FirstOrDefault(x => x.Key.X == nextPositionX && x.Key.Y == nextPositionY).Value == null;
    
            return occupied && this.IsPositionInBounds(nextPositionX, nextPositionY);
        }
        /// <summary>
        /// Finds if the next position is inside of the field
        /// </summary>
        /// <param name="nextPositionX">the X coordinates the player wants to move</param>
        /// <param name="nextPositionY">the Y coordinates the player wants to move</param>
        /// <returns>true if the nex place you want to move is in bounds of the field</returns>
        public bool IsPositionInBounds(int nextPositionX, int nextPositionY)
        {
            bool insideX = nextPositionX <= GameConstants.BoardWidth && nextPositionX >= 0;
            bool insideY = nextPositionY <= GameConstants.BoardHeight && nextPositionY >= 0;

            return insideX && insideY;
        }
        /// <summary>
        /// inserts a figure by position(created by a position factory) in the Figures dictionary
        /// </summary>
        /// <param name="x">position on the X axis</param>
        /// <param name="y">position on the y axis</param>
        /// <param name="fig">the figure you want to insert in the dictionary</param>
        private void AddFigure(int x, int y, IFigure fig)
        {
            this.Figures.Add(this.positionFactory.Create(x, y), fig);
        }
    }
}
