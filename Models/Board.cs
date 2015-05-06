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

        public void PrintBoard()
        {
            string rowNumbers = "0 1 2 3 4 5 6 7";
            string underscore = string.Format("{0}", new string('_', 17));
            string fieldBeginning = string.Format("UL{2}{0}{2}UR\n{2} {1}", rowNumbers, underscore, new string(' ', 2));
            string fieldEnd = string.Format("DL{1}{0}{1}DR\n{1}", rowNumbers, new string(' ', 2));

            Console.WriteLine(fieldBeginning);
            for (int row = 0; row <= GameConstants.BoardWidth; row++)
            {
                string rowBeginning = string.Format("{0} | ", row);
                string rowEnd = string.Format("| {0}", row);

                Console.Write(rowBeginning);
                for (int column = 0; column <= GameConstants.BoardWidth; column++)
                {
                    IFigure figure = this.Figures.FirstOrDefault(x => x.Key.X == column && x.Key.Y == row).Value;
                    if (figure != null)
                    {
                        Console.Write(figure.Symbol.ToString() + ' ');
                    }
                    else
                    {
                        char symbol = (row + column) % 2 == 0 ? '+' : '-';
                        Console.Write(symbol.ToString() + ' ');
                    }
                }

                Console.Write(rowEnd + "\n");
            }

            Console.WriteLine(string.Format("{0}{1}{2}{1}{0}", new string(' ', 2), '|', underscore) + "\n" + fieldEnd);
        }

        public bool IsNextPositionAvailable(int nextPositionX, int nextPositionY)
        {
            bool occupied =
                this.Figures.FirstOrDefault(x => x.Key.X == nextPositionX && x.Key.Y == nextPositionY).Value == null;

            return occupied && !this.IsInBounds(nextPositionX, nextPositionY);
        }

        public bool IsInBounds(int nextPositionX, int nextPositionY)
        {
            bool insideX = nextPositionX > GameConstants.BoardWidth || nextPositionX < 0;
            bool insideY = nextPositionY > GameConstants.BoardHeight || nextPositionY < 0;

            return insideX || insideY;
        }

        private void AddFigure(int x, int y, IFigure fig)
        {
            this.Figures.Add(this.positionFactory.Create(x, y), fig);
        }
    }
}
