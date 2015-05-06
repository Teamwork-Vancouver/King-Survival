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

        public bool IsPositionAvailable(int nextPositionX, int nextPositionY)
        {
            bool occupied =
                this.Figures.FirstOrDefault(x => x.Key.X == nextPositionX && x.Key.Y == nextPositionY).Value == null;
    
            return occupied && this.IsPositionInBounds(nextPositionX, nextPositionY);
        }

        public bool IsPositionInBounds(int nextPositionX, int nextPositionY)
        {
            bool insideX = nextPositionX <= GameConstants.BoardWidth && nextPositionX >= 0;
            bool insideY = nextPositionY <= GameConstants.BoardHeight && nextPositionY >= 0;

            return insideX && insideY;
        }

        private void AddFigure(int x, int y, IFigure fig)
        {
            this.Figures.Add(this.positionFactory.Create(x, y), fig);
        }
    }
}
